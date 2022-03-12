using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poliklinika.Model
{
    public class KonsultacijePoruka
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Konsultacije))]
        public int KonsultacijeID { get; set; }
        public Konsultacije Konsultacije { get; set; }
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public User User { get; set; }
        public string Poruka { get; set; }
    }
}
