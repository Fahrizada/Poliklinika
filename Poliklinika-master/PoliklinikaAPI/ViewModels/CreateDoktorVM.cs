using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class CreateDoktorVM
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Spol { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(6)]
        public string BrojRadneKnjizice { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Specijalizacija { get; set; }
        public string SubSpecijalizacija { get; set; }
        [Required]
        public int OdjelID { get; set; }
    }
}
