using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class KonsultacijePorukaVM
    {
        public int ID { get; set; }
        [Required]
        public int KonsultacijeID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Poruka { get; set; }
    }
}
