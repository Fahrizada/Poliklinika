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
    public class PregledController : ControllerBase
    {
        private BaseInterface<Pregled, PregledVM> _baseInterface;

        public PregledController(BaseInterface<Pregled, PregledVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet]
        [Authorize]
        public List<PregledVM> GetAll()
        {
            return _baseInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public PregledVM Get(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Korisnik")]
        public PregledVM Insert(PregledVM model)
        {
            return _baseInterface.Insert(model);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public PregledVM Update(PregledVM model)
        {
            return _baseInterface.Update(model);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Korisnik")]
        public void Delete(int id)
        {
            _baseInterface.Delete(id);
        }
    }
}
