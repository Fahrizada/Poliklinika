using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Konsultacije
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        [ForeignKey(nameof(Doktor))]
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
    }
}
