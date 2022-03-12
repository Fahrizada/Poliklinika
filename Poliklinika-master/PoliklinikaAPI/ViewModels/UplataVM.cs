using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class UplataVM
    {
        public int ID { get; set; }
        [Required]
        public int PregledID { get; set; }
        public float Iznos { get; set; }
        [Required]
        public DateTime DatumUplate { get; set; }
    }
}
