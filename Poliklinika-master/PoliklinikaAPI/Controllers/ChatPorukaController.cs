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
    public class ChatPorukaController : ControllerBase
    {
        private BaseInterface<ChatPoruka, ChatPorukaVM> _baseInterface;
        public ChatPorukaController(BaseInterface<ChatPoruka, ChatPorukaVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Doktor, Tehnicar")]
        public List<ChatPorukaVM> Index()
        {
            return _baseInterface.GetAll();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Doktor, Tehnicar")]
        public ChatPorukaVM Insert(ChatPorukaVM model)
        {
            return _baseInterface.Insert(model);
        }
    }
}

