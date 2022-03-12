using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poliklinika.Model
{
    public class ChatPoruka
    {
        [Key]
        public int ID { get; set; }
        public int ChatObavezaID { get; set; }
        [ForeignKey(nameof(ChatObavezaID))]
        public ChatObaveza ChatObaveza { get; set; }
        public int OsobljeID { get; set; }
        [ForeignKey(nameof(OsobljeID))]
        public Osoblje Osoblje { get; set; }
        public string Poruka { get; set; }   
    }
}
