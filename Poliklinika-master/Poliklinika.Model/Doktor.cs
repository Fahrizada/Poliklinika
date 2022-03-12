using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class Doktor:Osoblje
    {
        [ForeignKey("Odjel")]
        public int OdjelID { get; set; }
        public Odjel Odjel { get; set; }
        public string Specijalizacija { get; set; }
        public string SubSpecijalizacija { get; set; }
    }
}
