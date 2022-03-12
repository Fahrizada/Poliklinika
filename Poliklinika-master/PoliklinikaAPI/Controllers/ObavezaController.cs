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

    public class ObavezaController : ControllerBase
    {
        private BaseInterface<Obaveza, ObavezaVM> _baseInterface;
        public ObavezaController(BaseInterface<Obaveza, ObavezaVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Doktor, Tehnicar")]
        public List<ObavezaVM> GetAll()
        {
            return _baseInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Doktor, Tehnicar")]
        public ObavezaVM Get(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ObavezaVM Insert(ObavezaVM model)
        {
            return _baseInterface.Insert(model);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Doktor, Tehnicar")]
        public ObavezaVM Update(ObavezaVM model)
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
