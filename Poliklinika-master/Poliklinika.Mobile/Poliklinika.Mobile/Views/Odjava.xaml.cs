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
    public partial class Odjava : ContentPage
    {
        public Odjava()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            CurrentUser.User = null;
            CurrentUser.JWT = null;

            await Shell.Current.GoToAsync("//AboutPage");
        }
    }
}