using Microsoft.AspNetCore.Authorization;
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
    public class NalazController : Controller
    {
        private readonly BaseInterface<Nalaz, NalazVM> _nalazInterface;
        public NalazController(BaseInterface<Nalaz, NalazVM> nalazInterface)
        {
            _nalazInterface = nalazInterface;
        }

        [HttpPost]
        [Authorize(Roles = "Doktor")]
        public NalazVM Insert(NalazVM nalaz)
        {
            return _nalazInterface.Insert(nalaz);
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Doktor, Korisnik")]
        public List<NalazVM> GetAll()
        {
            return _nalazInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Doktor, Korisnik")]
        public NalazVM Get(int id)
        {
            return _nalazInterface.GetById(id);
        }

        [HttpPut]
        [Authorize(Roles = "Admin, Doktor")]
        public NalazVM Update(NalazVM nalaz)
        {
            return _nalazInterface.Update(nalaz);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
            _nalazInterface.Delete(id);
        }
    }
}
