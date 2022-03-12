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
    public class ChatObavezaController : ControllerBase
    {
        private BaseInterface<ChatObaveza, ChatObavezaVM> _baseInterface;
        public ChatObavezaController(BaseInterface<ChatObaveza, ChatObavezaVM> baseInterface)
        {
            _baseInterface = baseInterface;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Doktor, Tehnicar")]
        public ChatObavezaVM Get(int id)
        {
            return _baseInterface.GetById(id);
        }

        [HttpPost]
        [Authorize(Roles = "Doktor, Tehnicar")]
        public ChatObavezaVM Insert(ChatObavezaVM model)
        {
            return _baseInterface.Insert(model);
        }
    }
}
