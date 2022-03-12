using Acr.UserDialogs;
using Poliklinika.Mobile.Views;
using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class RegisterVM : BaseViewModel
    {
        public Command RegisterCommand { get; }
        private readonly APIService _korisnik = new APIService("Korisnik");
        private readonly APIService _service = new APIService("Authentication");
        
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        DateTime _datumRodjenja;
        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }
        public RegisterVM()
        {
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnRegisterClicked(object obj)
        {
            if(string.IsNullOrWhiteSpace(this.Username) ||
               string.IsNullOrWhiteSpace(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Greška", "Unesite ispravne podatke", "OK");
            }
            else
            {
                var req = new request
                {
                    email = this.Username,
                    password = this.Password,
                    Ime=this.Ime,
                    Prezime=this.Prezime,
                    DatumRodjenja=this.DatumRodjenja
                  
                    
                };

                try
                {

                    var signup = await _korisnik.Insert<response>(req);
                    if(signup != null)
                    {
                        await Application.Current.MainPage.DisplayAlert
                           ("Uspješna registracija", "Molimo ulogujte se", "OK");
                        
                        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                    }
                }
                catch
                {
                    UserDialogs.Instance.Alert("Pogrešan Email ili Password format (Password mora sadržavati slova, brojeve i znakove)", null, "OK");
                }
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            }

        }

        public class request
        {
            public string email { get; set; }
            public string password { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumRodjenja { get; set; }
        }

        public class response
        {
            public int ID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Spol { get; set; }
            public string Email { get; set; }
            public string BrojTelefona { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string KrvnaGrupa { get; set; }
        }
    }
}
