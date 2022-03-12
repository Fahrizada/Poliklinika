using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class ChatPorukaVM
    {
        public int ID { get; set; }
        [Required]
        public int OsobljeID { get; set; }
        [Required]
        public int ChatObavezaID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Poruka { get; set; }
    }
}
