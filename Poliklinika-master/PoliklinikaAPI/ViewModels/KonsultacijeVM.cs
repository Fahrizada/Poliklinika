using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class KonsultacijeVM
    {
        public int ID { get; set; }
        [Required]
        public int KorisnikID { get; set; }
        [Required]
        public int DoktorID { get; set; }
    }
}
