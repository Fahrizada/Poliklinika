using Poliklinika.Mobile.Models;
using Poliklinika.Mobile.ViewModels;
using Poliklinika.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Poliklinika.Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        private ItemsViewModel model=null;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = model = new ItemsViewModel();
        }

        protected override async void OnAppearing()
        {
            await model.Init();
            base.OnAppearing();
            
        }

        private async void  ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var odjel = (ItemsViewModel.OdjelVM)e.SelectedItem;

            
            await Navigation.PushAsync(new PrikazOdjela(odjel.ID));
        }
    }
}