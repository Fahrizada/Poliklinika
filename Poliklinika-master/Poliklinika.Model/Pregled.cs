using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Pregled
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Doktor")]
        public int? DoktorID { get; set; }
        public Doktor Doktor { get; set; }
        [ForeignKey("Korisnik")]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        [ForeignKey("Odjel")]
        public int OdjelID { get; set; }
        public Odjel Odjel { get; set; }
        [ForeignKey("Tehnicar")]
        public int? TehnicarID { get; set; }
        public Tehnicar Tehnicar { get; set; }
    }
}
