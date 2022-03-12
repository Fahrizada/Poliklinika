using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class ChatObaveza
    {
        [Key]
        public int ID { get; set; }
        public int ObavezaID { get; set; }
        [ForeignKey(nameof(ObavezaID))]
        public Obaveza Obaveza { get; set; }
        public int OsobljeID { get; set; }
        [ForeignKey(nameof(OsobljeID))]
        public Osoblje Osoblje { get; set; }
        public int AdminID { get; set; }
        [ForeignKey(nameof(AdminID))]
        public Admin Admin { get; set; }
    }
}
