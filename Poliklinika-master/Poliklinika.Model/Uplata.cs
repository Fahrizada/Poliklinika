using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Uplata
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Pregled")]
        public int PregledID { get; set; }
        public Pregled Pregled { get; set; }
        public float Iznos { get; set; }
        public DateTime DatumUplate { get; set; }
    }
}
