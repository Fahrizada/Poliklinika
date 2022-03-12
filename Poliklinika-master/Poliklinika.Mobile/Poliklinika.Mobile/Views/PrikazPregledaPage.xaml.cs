using Poliklinika.Mobile.ViewModels;
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
    public partial class PrikazPregledaPage : ContentPage
    {
        private KorisnikPregled model = null;
        private readonly APIService _uplate = new APIService("Uplata");
        private readonly APIService _nalaz = new APIService("Nalaz");
        public PrikazPregledaPage()
        {
            InitializeComponent();
            BindingContext = model = new KorisnikPregled();
        }
        protected override async void OnAppearing()
        {
            await model.Init();
            base.OnAppearing();

        }


        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var pregled = (KorisnikPregled.PreglediVM)e.SelectedItem;
            var uplate = await _uplate.Get<List<PaymentVM.Uplata>>(null);
            uplate = uplate.Where(x => x.PregledID == pregled.ID).ToList();
            var nalazLista = await _nalaz.Get<List<NalazVM>>(null);
            var nalaz= nalazLista.Where(x => x.PregledID == pregled.ID).FirstOrDefault();

            if (nalaz == null)
            {
                await Application.Current.MainPage.DisplayAlert
                   ("Upozorenje", "Pregled još nije izvršen", "OK");
                
            }

            else if (uplate.Count()==1)
            {
                await Application.Current.MainPage.DisplayAlert
                   ("Upozorenje", "Morate uplatiti ostatak iznosa cijene pregleda", "OK");
                await Navigation.PushAsync(new PlacanjePage(pregled));
            }
            else
            await Navigation.PushAsync(new PrikazNalazaPage(pregled.ID));
        }
        public class NalazVM
        {
            public int ID { get; set; }
            public int PregledID { get; set; }
            public string Opis { get; set; }
        }
    }
}