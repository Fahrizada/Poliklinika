using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Poliklinika.Model;
using PoliklinikaAPI.Data;
using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.Services
{
    public class OsobljeService : BaseService<Osoblje, OsobljeVM>
    {
        UserManager<User> _userManager;

        public OsobljeService(DBContext db, IMapper mapper, UserManager<User> UsrManger) : base(db, mapper, UsrManger)
        {
            _userManager = UsrManger;
        }

        public override List<OsobljeVM> GetAll()
        {
            var osoblje = _db.Osoblje.ToList();
            var lista = new List<OsobljeVM>();

            foreach(var i in osoblje)
            {
                var role =  _userManager.GetRolesAsync(i);
                role.Wait();
                var roleName = role.Result.FirstOrDefault();

                if (roleName != "Admin")
                {
                    var osb = _mapper.Map<OsobljeVM>(i);
                    osb.Role = roleName;
                    lista.Add(osb);
                }
            }

            return lista;
        }
    }
}
