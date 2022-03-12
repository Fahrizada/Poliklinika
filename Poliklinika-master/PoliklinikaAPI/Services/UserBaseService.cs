using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Model;
using PoliklinikaAPI.Data;
using PoliklinikaAPI.Interfaces;
using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PoliklinikaAPI.Services
{
    public class UserBaseService<T, TVM, TCreateVM> : UserBaseInterface<T, TVM, TCreateVM> where T: class
    {
        private DBContext _db;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;

        public UserBaseService(DBContext db, IMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Delete(int id)
        {
            var user = _db.Set<T>().Find(id);

            _db.Set<T>().Remove(user);
            _db.SaveChanges();

        }

        public TVM Get(int id)
        {
            return _mapper.Map<TVM>(_db.Set<T>().Find(id));
        }

        public IList<TVM> GetAll()
        {
            return _mapper.Map<IList<TVM>>(_db.Set<T>().ToList());
        }

        public async Task<TVM> Insert(TCreateVM user)
        {
            User signupUser;
            string roleName = "";

            if (typeof(T) == typeof(Korisnik))
            {
                signupUser = _mapper.Map<TCreateVM, Korisnik>(user);
                roleName = nameof(Korisnik);
            }
            else if (typeof(T) == typeof(Doktor))
            {
                signupUser = _mapper.Map<TCreateVM, Doktor>(user);
                roleName = nameof(Doktor);
            }
            else if (typeof(T) == typeof(Tehnicar))
            {
                signupUser = _mapper.Map<TCreateVM, Tehnicar>(user);
                roleName = nameof(Tehnicar);
            }
            else
            {
                signupUser = _mapper.Map<TCreateVM, Admin>(user);
                roleName = nameof(Admin);
            }

            var mail = user.GetType().GetProperty("Email").GetValue(user, null);
            signupUser.GetType().GetProperty("UserName").SetValue(signupUser, mail);
            if(typeof(TCreateVM) != typeof(SignupAdminVM) && signupUser.Spol != null)
                signupUser.Spol = user.GetType().GetProperty("Spol").GetValue(user, null).ToString();

            var userCreateResult = await _userManager.CreateAsync(signupUser, user.GetType().GetProperty("Password").GetValue(user, null).ToString());

            string role = null;

            var rlResult = await _roleManager.FindByNameAsync(roleName);

            if (role == null || role == "")
            {
                var createRole = new Role { Name = roleName };
                var result = await _roleManager.CreateAsync(createRole);
                var roleResult = await _roleManager.FindByNameAsync(roleName);
                role = roleResult.Name;
            }
            else
                role = rlResult.Name;

            if (userCreateResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(signupUser, role);
                return _mapper.Map<TCreateVM, TVM>(user);
            }

            var errors = new List<Exception>();

            foreach (var e in userCreateResult.Errors)
            {
                errors.Add(new Exception(e.Description));
            }

            throw new AggregateException(errors);
        }

        public TVM Update(TVM user)
        {
            int userID;
            if (user.GetType().GetProperty("Id") != null)
                userID = int.Parse(user.GetType().GetProperty("Id").GetValue(user, null).ToString());
            else
                userID = int.Parse(user.GetType().GetProperty("ID").GetValue(user, null).ToString());

            var entity = _db.Set<T>().Find(userID);
            var map = _mapper.Map(user, entity);
            map.GetType().GetProperty("UserName").SetValue(map, user.GetType().GetProperty("Email").GetValue(user, null).ToString());
            _db.SaveChanges();
            return _mapper.Map<TVM>(map);
        }

        public async void UpdatePassword(UpdatePasswordVM update)
        {
            var user = _db.User.Find(update.UserId);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, update.password);
            _db.User.Update(user);
            _db.SaveChanges();
        }
    }
}
