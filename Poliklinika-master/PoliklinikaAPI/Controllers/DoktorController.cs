using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Model;
using PoliklinikaAPI.Interfaces;
using PoliklinikaAPI.ViewModels;

namespace PoliklinikaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "BasicAuthentication")]
    public class DoktorController : ControllerBase
    {
        protected UserBaseInterface<Doktor, DoktorVM, CreateDoktorVM> _userInterface;

        public DoktorController(UserBaseInterface<Doktor, DoktorVM, CreateDoktorVM> userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        [Authorize]
        public IList<DoktorVM> GetAll()
        {
            return _userInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public DoktorVM Get(int id)
        {
            return _userInterface.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public Task<DoktorVM> Insert(CreateDoktorVM doktor)
        {
            return _userInterface.Insert(doktor);
        }

        [HttpPut]
        [Authorize(Roles = "Doktor,Admin")]
        public DoktorVM Update(DoktorVM doktor)
        {
            return _userInterface.Update(doktor);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _userInterface.Delete(id);
        }

        [HttpPost("update-password")]
        [Authorize(Roles = "Doktor")]
        public void UpdatePassword(UpdatePasswordVM update)
        {
            _userInterface.UpdatePassword(update);
        }
    }
}

