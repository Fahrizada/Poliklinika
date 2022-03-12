using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Model;
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
    public class TehnicarController : ControllerBase
    {
        private UserBaseInterface<Tehnicar, TehnicarVM, CreateTehnicarVM> _userInterface;
        public TehnicarController(UserBaseInterface<Tehnicar, TehnicarVM, CreateTehnicarVM> userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        [Authorize]
        public IList<TehnicarVM> GetAll()
        {
            return _userInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public TehnicarVM Get(int id)
        {
            return _userInterface.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<TehnicarVM> Insert(CreateTehnicarVM tehnicar)
        {
            return await _userInterface.Insert(tehnicar);
        }

        [HttpPut]
        [Authorize(Roles = "Tehnicar, Admin")]
        public TehnicarVM Update(int id, TehnicarVM tehnicar)
        {
            return _userInterface.Update(tehnicar);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Tehnicar")]
        public void Delete(int id)
        {
            _userInterface.Delete(id);
        }

        [HttpPost("update-password")]
        [Authorize(Roles = "Tehnicar")]
        public void UpdatePassword(UpdatePasswordVM update)
        {
            _userInterface.UpdatePassword(update);
        }
    }
}
