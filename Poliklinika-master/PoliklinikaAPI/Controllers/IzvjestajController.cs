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
    public class IzvjestajController : ControllerBase
    {
        private BaseInterface<Izvjestaj, IzvjestajVM> _baseInterface;
        public IzvjestajController(BaseInterface<Izvjestaj, IzvjestajVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin, Doktor")]
        public List<IzvjestajVM> GetAll()
        {
            return _baseInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Doktor")]
        public IzvjestajVM Get(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Doktor")]
        public IzvjestajVM Insert(IzvjestajVM model)
        {
            return _baseInterface.Insert(model);
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Doktor")]
        public IzvjestajVM Update(IzvjestajVM model)
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
