using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class ChatObavezaVM
    {
        public int ID { get; set; }
        [Required]
        public int ObavezaID { get; set; }
        [Required]
        public int OsobljeID { get; set; }
        [Required]
        public int AdminID { get; set; }
    }
}
