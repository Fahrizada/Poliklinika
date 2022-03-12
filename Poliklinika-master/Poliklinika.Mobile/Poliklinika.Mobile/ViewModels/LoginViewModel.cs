using Acr.UserDialogs;
using Poliklinika.Mobile.Views;
using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private readonly APIService _service = new APIService("Authentication");
        private readonly APIService _korisnik = new APIService("Korisnik");

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

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

        private async void OnLoginClicked(object obj)
        {
            if (string.IsNullOrWhiteSpace(this.Username) ||
               string.IsNullOrWhiteSpace(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Greška", "Unesite ispravne podatke", "OK");
            }
            else
            {

                APIService.Username = Username;
                APIService.Password = Password;

                var req = new request
                {
                    email = this._username,
                    password = this._password
                };

                try
                {
                    var usr = await _service.Insert<response>(req);

                    if (usr != null)
                    {
                        CurrentUser.JWT = usr.Token;
                        CurrentUser.User = await _korisnik.GetById<Korisnik>(usr.Id);
                        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                    }
                    else
                        throw (new Exception("Pogrešan Email ili Password"));
                }
                catch(Exception e)
                {
                    UserDialogs.Instance.Alert(e.Message, null, "OK");

                }
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            }
        }
        private class request
        {
            public string email { get; set; }
            public string password { get; set; }
        }
        private class response
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public string Token { get; set; }
        }
    }
}
