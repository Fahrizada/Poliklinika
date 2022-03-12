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
    public partial class OdabirSavjetnikaPage : ContentPage
    {
        private readonly int _odjelID;
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _doktori = new APIService("Doktor");
        private readonly APIService _konsultacije = new APIService("Konsultacije");
        private readonly APIService _konsultacijePoruka = new APIService("KonsultacijePoruka");


        List<DoktorVM> doktori;
        public OdabirSavjetnikaPage(int OdjelID)
        {
            _odjelID = OdjelID;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            doktori = await _doktori.Get<List<DoktorVM>>(null);
            var lista = doktori.Where(x => x.OdjelID == _odjelID).ToList();
            picker.ItemsSource = lista;

            base.OnAppearing();
        }
        public class DoktorVM
        {
            public int ID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public int OdjelID { get; set; }
            public override string ToString() 
            {
                return $"{this.Ime} {this.Prezime}";
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var lista = doktori.Where(x => x.OdjelID == _odjelID).ToList();
            var selectedDoktor = lista[picker.SelectedIndex];

            var req = new request
            {
                DoktorID = selectedDoktor.ID,
                KorisnikID = CurrentUser.User.Id
            };
            var konsultacije = await _konsultacije.Get<List<response>>(null);

            var konsultacija = konsultacije.FirstOrDefault(x => x.KorisnikID == CurrentUser.User.Id && x.DoktorID == selectedDoktor.ID);

            if(konsultacija == null)
            {
                konsultacija = await _konsultacije.Insert<response>(req);
            }

            var poruka = new KonsPoruka
            {
                KonsultacijeID = konsultacija.ID,
                UserID = CurrentUser.User.Id,
                Poruka = Poruka.Text
            };
            await _konsultacijePoruka.Insert<KonsPoruka>(poruka);

            await Navigation.PushAsync(new ChatPage(konsultacija.ID));
        }

        public class KonsPoruka 
        { 
            public int KonsultacijeID { get; set; }
            public int UserID { get; set; }
            public string Poruka { get; set; }
        }

        public class request
        {
            public int KorisnikID { get; set; }
            public int DoktorID { get; set; }
        }

        public class response
        {
            public int ID { get; set; }
            public int DoktorID { get; set; }
            public int KorisnikID { get; set; }
        }
    }
}