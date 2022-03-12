using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class UpdatePasswordVM
    {
        [Required(AllowEmptyStrings = false)]
        public string password { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
