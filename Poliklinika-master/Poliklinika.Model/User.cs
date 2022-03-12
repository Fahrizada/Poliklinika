using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Poliklinika.Model
{
    public class User : IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Spol { get; set; }
    }
}
