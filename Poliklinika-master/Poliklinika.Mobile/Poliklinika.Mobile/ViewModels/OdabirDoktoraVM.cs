using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poliklinika.Mobile.ViewModels
{
    class OdabirDoktoraVM : BaseViewModel
    {
        private readonly APIService _doktori = new APIService("Doktor");
        DoktorVM _selectedDoktor;
        public DoktorVM SelectedDoktor
        {
            get { return _selectedDoktor; }
            set { SetProperty(ref _selectedDoktor, value); }
        }

        string _poruka = string.Empty;
        public string Poruka
        {
            get { return _poruka; }
            set { SetProperty(ref _poruka, value); }
        }

        public OdabirDoktoraVM()
        {
        }

        public class DoktorVM
        {
            public int ID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public int OdjelID { get; set; }
            public string ImeIPrezime
            {
                get { return $"{this.Ime} {this.Prezime}"; }
            }
        }
    }
}
