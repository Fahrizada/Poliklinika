using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Obaveza
    {
        [Key]
        public int ID { get; set; }
        public int OsobljeID { get; set; }
        [ForeignKey("OsobljeID")]
        public Osoblje Osoblje { get; set; }
        public int OdjelID { get; set; }
        [ForeignKey("OdjelID")]
        public Odjel Odjel { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public bool Aktivna { get; set; }
    }
}
