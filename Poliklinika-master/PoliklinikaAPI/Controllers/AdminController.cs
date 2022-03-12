using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Poliklinika.Model;
using PoliklinikaAPI.Data;
using PoliklinikaAPI.Interfaces;
using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]

    public class AdminController : ControllerBase
    {
        protected UserBaseInterface<Admin, Admin, SignupAdminVM> _userInterface;
        private DBContext _db;
        public AdminController(UserBaseInterface<Admin, Admin, SignupAdminVM> userInterface, DBContext db)
        {
            _userInterface = userInterface;
            _db = db;
        }

        [HttpGet]
        [AllowAnonymous]
        public Admin Index()
        {
            return _db.Admin.FirstOrDefault();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Admin> Insert(SignupAdminVM korisnik)
        {
            var list = _db.Admin.ToList().Count();
            if (list == 0)
                return await _userInterface.Insert(korisnik);
            else
                throw (new Exception("Administrator već postoji!"));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public Admin Get(int id)
        {
            return _userInterface.Get(id);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public Admin Update(Admin admin)
        {
            return _userInterface.Update(admin);
        }

        [HttpPost("update-password")]
        [Authorize(Roles = "Admin")]
        public void UpdatePassword(UpdatePasswordVM update)
        {
            _userInterface.UpdatePassword(update);
        }
    }
}
