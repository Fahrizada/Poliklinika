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
    public class OsobljeController : ControllerBase
    {
        private BaseInterface<Osoblje, OsobljeVM> _baseInterface;

        public OsobljeController(BaseInterface<Osoblje, OsobljeVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet("{id}")]
        [Authorize]
        public OsobljeVM GetById(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpGet]
        [Authorize]
        public List<OsobljeVM> GetAll()
        {
            return _baseInterface.GetAll();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _baseInterface.Delete(id);
        }
    }
}
