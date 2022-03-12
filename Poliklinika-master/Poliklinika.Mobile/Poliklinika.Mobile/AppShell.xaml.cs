using Poliklinika.Mobile.ViewModels;
using Poliklinika.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Poliklinika.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {

        public FlyoutItem _profil;
        public FlyoutItem _poruke;
        public FlyoutItem _prijava;
        public FlyoutItem _odjava;
        public FlyoutItem _register;
        public FlyoutItem _pregledi;

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(Register), typeof(Register));

            _profil = Profil;
            _poruke = Poruke;
            _prijava = Prijava;
            _odjava = Odjava;
            _register = Register;
            _pregledi = Pregled;
        }

        protected override void OnAppearing()
        {
            if (CurrentUser.IsLogedIn())
            {
                _profil.IsVisible = true;
                _poruke.IsVisible = true;
                _prijava.IsVisible = false;
                _odjava.IsVisible = true;
                _register.IsVisible = false;
                _pregledi.IsVisible = true;
            }
            else
            {
                _profil.IsVisible = false;
                _poruke.IsVisible = false;
                _prijava.IsVisible = true;
                _odjava.IsVisible = false;
                _register.IsVisible = true;
                _pregledi.IsVisible = false;
            }

            base.OnAppearing();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Register");
        }
    }
}
