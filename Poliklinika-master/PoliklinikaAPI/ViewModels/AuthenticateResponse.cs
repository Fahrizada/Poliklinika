using Microsoft.AspNetCore.Http;
using Poliklinika.Model;
using PoliklinikaAPI.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user)
        {
            if (user != null)
            {
                Id = user.Id;
                Ime = user.Ime;
                Prezime = user.Prezime;
                Email = user.Email;
                Role = user.GetType().Name;
                Token = "";
            }
        }
    }
}
