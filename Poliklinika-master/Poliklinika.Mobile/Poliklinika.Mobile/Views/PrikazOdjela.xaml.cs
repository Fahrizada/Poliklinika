using Poliklinika.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poliklinika.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrikazOdjela : ContentPage
    {
        private readonly APIService _odjel = new APIService("Odjel");
        int _id;
        public PrikazOdjela(int id)
        {
            _id = id;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var odjel = await _odjel.GetById<OdjelViewModel>(_id);

            naziv.Text = odjel.Naziv;
            opis.Text = odjel.Opis;
            slika.Source = ImageSource.FromStream(() => new MemoryStream(odjel.Slika));

            base.OnAppearing();
        }

        private async void termin_Clicked(object sender, EventArgs e)
        {
            if (CurrentUser.IsLogedIn())
                await Navigation.PushAsync(new OdabirTerminaPage(_id));
            else
                await Navigation.PushAsync(new Register());

        }

        private async void savjet_Clicked(object sender, EventArgs e)
        {
            if (CurrentUser.IsLogedIn())
                await Navigation.PushAsync(new OdabirSavjetnikaPage(_id));
            else
                await Navigation.PushAsync(new Register());
        }
    }
}