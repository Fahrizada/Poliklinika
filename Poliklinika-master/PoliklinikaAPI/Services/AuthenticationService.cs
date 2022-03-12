using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PoliklinikaAPI.Interfaces;
using Poliklinika.Model;
using PoliklinikaAPI.ViewModels;
using PoliklinikaAPI.Data;
using PoliklinikaAPI.Helpers;
using Microsoft.AspNetCore.Identity;

namespace PoliklinikaAPI.Services
{

    public class AuthenticationService : AuthenticationInterface
    {

        private readonly AppSettings _appSettings;
        private DBContext _db;
        UserManager<User> _userManager;

        public AuthenticationService(IOptions<AppSettings> appSettings, DBContext db, UserManager<User> userManager)
        {
            _appSettings = appSettings.Value;
            _db = db;
            _userManager = userManager;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User user = _db.User.FirstOrDefault(x => x.Email == model.Email);

            if(_userManager.CheckPasswordAsync(user, model.Password).Result)
            {
                return new AuthenticateResponse(user); ;
            }

            return null;
        }

        public User GetById(int id)
        {
            return _db.User.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        //private string generateJwtToken(User user)
        //{
        //    // generate token that is valid for 7 days
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("Role", user.GetType().Name) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}