using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class ObavezaVM
    {
        public int ID { get; set; }
        [Required]
        public int OsobljeID { get; set; }
        [Required]
        public int OdjelID { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Opis { get; set; }
        public bool Aktivna { get; set; }
        public int ChatID { get; set; }
    }
}
