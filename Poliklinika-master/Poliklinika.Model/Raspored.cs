using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Raspored
    {
        [Key]
        public int ID { get; set; }
        public DateTime Datum { get; set; } 
        public string Vrijeme { get; set; }
        [ForeignKey("Doktor")]
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
        [ForeignKey("Tehnicar")]
        public int TehnicarID { get; set; }
        public Tehnicar Tehnicar { get; set; }
        [ForeignKey("Pregled")]
        public int PregledID { get; set; }
        public Pregled Pregled { get; set; }
    }
}
