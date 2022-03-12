using Poliklinika.Mobile.Models;
using Poliklinika.Mobile.Views;
using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly APIService _odjel=new APIService("Odjel");
       public ItemsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<OdjelVM> OdjeliLista { get; set; } = new ObservableCollection<OdjelVM>();
        public ICommand InitCommand { get; }
    

        public async Task Init()
        {

            var list = await _odjel.Get<IEnumerable<OdjelVM>>(null);
            OdjeliLista.Clear();

            foreach (var odjeli in list)
            {
                OdjeliLista.Add(odjeli);
            }
        }
        public class OdjelVM
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public byte[] Slika { get; set; }
        }
    }
}