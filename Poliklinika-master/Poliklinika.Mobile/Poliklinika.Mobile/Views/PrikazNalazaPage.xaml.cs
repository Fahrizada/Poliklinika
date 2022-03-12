using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poliklinika.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrikazNalazaPage : ContentPage
    {
        private readonly int _id;
        private readonly APIService _nalaz = new APIService("Nalaz");
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _doktor = new APIService("Doktor");
        public PrikazNalazaPage(int id)
        {
            _id = id;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var nalazi=await _nalaz.Get<List<NalazVM>>(null);
            var nalaz =  nalazi.Where(x => x.PregledID == _id).FirstOrDefault();
            var pregled = await _pregled.GetById<PregledVM>(_id);
            var doktor = await _doktor.GetById<DoktorVM>(pregled.DoktorID);
            opis.Text = nalaz.Opis;
            doc.Text = $"{doktor.Ime} {doktor.Prezime}";
            
            
            base.OnAppearing();
        }

        public class NalazVM
        {
            public int ID { get; set; }
            public int PregledID { get; set; }
            public string Opis { get; set; }
        }
        public class PregledVM
        {
            public int ID { get; set; }
            public int? DoktorID { get; set; }
            public int KorisnikID { get; set; }
            public DateTime Datum { get; set; }
            public string Opis { get; set; }
            public int? TehnicarID { get; set; }
            public int OdjelID { get; set; }
        }
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
}