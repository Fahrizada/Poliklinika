using Poliklinika.Mobile.Views;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            OpenRegister = new Command(async () => await Shell.Current.GoToAsync($"//{nameof(Register)}"));
            OpenLogin = new Command(async () => await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenRegister { get; }
        public ICommand OpenLogin { get; }

    }
}