using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class PregledVM
    {
        public int ID { get; set; }
        public int? DoktorID { get; set; }
        [Required]
        public int KorisnikID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public int? TehnicarID { get; set; }
        [Required]
        public int OdjelID { get; set; }
    }
}
