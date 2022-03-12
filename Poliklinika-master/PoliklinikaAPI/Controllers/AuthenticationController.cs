using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poliklinika.Model;
using PoliklinikaAPI.Interfaces;
using PoliklinikaAPI.Services;
using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private AuthenticationInterface _userService;
        
        public AuthenticationController(AuthenticationInterface userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            return response;
        }
    }
}
