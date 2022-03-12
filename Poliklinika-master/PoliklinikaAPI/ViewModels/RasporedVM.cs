using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class RasporedVM
    {
        public int ID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public string Vrijeme { get; set; }
        [Required]
        public int DoktorID { get; set; }
        [Required]
        public int TehnicarID { get; set; }
        [Required]
        public int PregledID { get; set; }
    }
}
