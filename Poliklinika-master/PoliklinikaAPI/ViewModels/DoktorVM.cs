using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.ViewModels
{
    public class DoktorVM
    {
        public int ID { get; set; }
     
        public string Ime { get; set; }
      
        public string Prezime { get; set; }
       
        public string Spol { get; set; }
    
        public int OdjelID { get; set; }
       
        public string Email { get; set; }
       
        public string BrojRadneKnjizice { get; set; }
       
        public string Specijalizacija { get; set; }
        public string SubSpecijalizacija { get; set; }
    }
}
