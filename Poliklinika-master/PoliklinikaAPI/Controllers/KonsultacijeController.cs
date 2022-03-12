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
    public class KonsultacijeController : ControllerBase
    {
        private BaseInterface<Konsultacije, KonsultacijeVM> _baseInterface;

        public KonsultacijeController(BaseInterface<Konsultacije, KonsultacijeVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Doktor, Korisnik")]
        public List<KonsultacijeVM> Index()
        {
            return _baseInterface.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Doktor, Korisnik")]
        public KonsultacijeVM Get(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Korisnik")]
        public KonsultacijeVM Insert(KonsultacijeVM model)
        {
            return _baseInterface.Insert(model);
        }
    }
}
