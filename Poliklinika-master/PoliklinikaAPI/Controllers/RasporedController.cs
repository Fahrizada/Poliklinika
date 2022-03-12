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
    public class RasporedController : ControllerBase
    {
        private BaseInterface<Raspored, RasporedVM> _baseInterface;

        public RasporedController(BaseInterface<Raspored, RasporedVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet]
        [Authorize]
        public List<RasporedVM> Index()
        {
            return _baseInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Doktor, Tehnicar")]
        public RasporedVM Get(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public RasporedVM Insert(RasporedVM model)
        {
            return _baseInterface.Insert(model);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public RasporedVM Update(RasporedVM model)
        {
            return _baseInterface.Update(model);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _baseInterface.Delete(id);
        }
    }
}
