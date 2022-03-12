using Poliklinika.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Poliklinika.Mobile.ViewModels.KorisnikPregled;

namespace Poliklinika.Mobile.Views
{
    public partial class AboutPage : ContentPage
    {

        Button _login;
        Button _register;
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _korisnik = new APIService("Korisnik");
  
        public AboutPage()
        {
            InitializeComponent();
            _login = Login;
            _register = Register;
          
        }

        protected override async void OnAppearing()
        {
            if (CurrentUser.IsLogedIn())
            {
                (Shell.Current as AppShell)._profil.IsVisible = true;
                (Shell.Current as AppShell)._poruke.IsVisible = true;
                (Shell.Current as AppShell)._prijava.IsVisible = false;
                (Shell.Current as AppShell)._odjava.IsVisible = true;
                (Shell.Current as AppShell)._register.IsVisible = false;  
                (Shell.Current as AppShell)._pregledi.IsVisible = true;  
                _login.IsVisible = false;
                _register.IsVisible = false;
            }
            else
            {
                (Shell.Current as AppShell)._profil.IsVisible = false;
                (Shell.Current as AppShell)._poruke.IsVisible = false;
                (Shell.Current as AppShell)._prijava.IsVisible = true;
                (Shell.Current as AppShell)._odjava.IsVisible = false;
                (Shell.Current as AppShell)._register.IsVisible = true;
                (Shell.Current as AppShell)._pregledi.IsVisible = false;
                _login.IsVisible = true;
                _register.IsVisible = true;
            }
            if (CurrentUser.IsLogedIn())
            {
             preporukeContainer.Children.Clear();
                TrenutniKorisnik trenutni = new TrenutniKorisnik
                {
                    korisnikID = CurrentUser.User.Id
                };
                gridPreporuke.IsVisible = true;
                var pregledi = await _pregled.Get<List<Pregledvm>>(trenutni);

                if (pregledi.Count() == 0 && string.IsNullOrEmpty(CurrentUser.User.Spol))
                {
                    gridPreporuke.IsVisible = false;
                }
                List<int> odjeliID = new List<int>();
                foreach (var pregled in pregledi)
                {
                    if (!odjeliID.Contains(pregled.OdjelID))
                        odjeliID.Add(pregled.OdjelID);
                }

                preporukeContainer.Children.Add(new Label 
                { Text="Preporuke na osnovu Vaših dosadašnjih pregleda:",
                FontSize=20});

                foreach (var i in odjeliID)
                {
                    var O=await _odjel.GetById<odjeldvm>(i);
                    preporukeContainer.Children.Add(new Label
                    { Text = O.Naziv,
                        HorizontalOptions=LayoutOptions.CenterAndExpand,
                        FontSize=20});

                }

                var pacijent = await _korisnik.GetById<K>(trenutni.korisnikID);
                DateTime now = DateTime.Now;
                int age = now.Year - pacijent.DatumRodjenja.Year;
                if (age >= 65 && CurrentUser.User.Spol=="M")
                {
                    preporukeContainer.Children.Add(new Label
                    {
                        Text = "Na osnovu Vaše starosne dobi preporučujemo pregled na:",
                        FontSize = 20
                    });

                    preporukeContainer.Children.Add(new Label
                    {
                        Text = "Oko 60% slučajeva raka prostate je diagnosticirano " +
                        "kod osoba starosne dobi od 65 ili više." +
                        " Vi spadate u ovu grupu ljudi," +
                        " s toga Vam preporučujemo pregled na odjelu: Urologija",
                        FontSize = 20
                    });
                }
                if (age >=50 && CurrentUser.User.Spol == "Ž")
                {
                    preporukeContainer.Children.Add(new Label
                    {
                        Text = "Rak maternice se najčesće pojavjuje kod žena " +
                        "starosne dobi preko 50. Prosječna dob diagnosticiranih " +
                        "slučajeva je 60. Vi spadate u ovu grupu, s toga Vam " +
                        "preporučujemo pregled na odjelu: Ginekologija",
                        FontSize = 20
                    });
                }
            }
            else
                gridPreporuke.IsVisible = false;

            base.OnAppearing();
        }

        class Pregledvm
        {
            public int korisnikID { get; set; }
            public int OdjelID { get; set; }
        }
        class odjeldvm:BaseViewModel
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
        }
        public class K
        {
            public string BrojTelefona { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string KrvnaGrupa { get; set; }
        }
    }
}