using Poliklinika.Mobile.Views;
using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    class ProfilVM : BaseViewModel
    {
        public Command UpdateCommand { get; }
        string _ime = string.Empty;
        string _prezime = string.Empty;
        string _spol = string.Empty;
        string _email = string.Empty;
        string _brojTelefona = string.Empty;
        DateTime _datumRodjenja = DateTime.Now;
        string _krvnaGrupa = string.Empty;

        private readonly APIService _korisnik = new APIService("Korisnik");

        public ProfilVM()
        {
            UpdateCommand = new Command(OnUpdateClicked);
        }

        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        public string Spol
        {
            get { return _spol; }
            set { SetProperty(ref _spol, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string BrojTelefona
        {
            get { return _brojTelefona; }
            set { SetProperty(ref _brojTelefona, value); }
        }
        public DateTime DatumRodjenja
        {
            get { return _datumRodjenja; }
            set { SetProperty(ref _datumRodjenja, value); }
        }
        public string KrvnaGrupa
        {
            get { return _krvnaGrupa; }
            set { SetProperty(ref _krvnaGrupa, value); }
        }

        private async void OnUpdateClicked()
        {
            var userVM = new RegisterVM.response
            {
                ID = CurrentUser.User.Id,
                Ime = this._ime,
                Prezime = this._prezime,
                BrojTelefona = this._brojTelefona,
                Email = this._email,
                DatumRodjenja = this._datumRodjenja,
                Spol = this._spol,
                KrvnaGrupa = this._krvnaGrupa
            };

            var updatedUser = await _korisnik.Update<RegisterVM.response>(userVM);

            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
