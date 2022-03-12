using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Nalaz
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Predled")]
        public int PregledID { get; set; }
        public Pregled Pregled { get; set; }
        public string Opis { get; set; }
    }
}
