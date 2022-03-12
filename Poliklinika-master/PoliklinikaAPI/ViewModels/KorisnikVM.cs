using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class KorisnikVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        
        public string Prezime { get; set; }
        public string Spol { get; set; }
      
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
       
        public DateTime DatumRodjenja { get; set; }
        public string KrvnaGrupa { get; set; }
    }
}
