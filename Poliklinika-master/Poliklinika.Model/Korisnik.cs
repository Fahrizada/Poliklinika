using System;
using System.Collections.Generic;
using System.Text;

namespace Poliklinika.Model
{
    public class Korisnik : User
    {
        public string BrojTelefona { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string KrvnaGrupa { get; set; }
    }
}
