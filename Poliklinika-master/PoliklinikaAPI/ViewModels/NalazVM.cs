using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class NalazVM
    {
        public int ID { get; set; }
        [Required]
        public int PregledID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Opis { get; set; }
    }
}
