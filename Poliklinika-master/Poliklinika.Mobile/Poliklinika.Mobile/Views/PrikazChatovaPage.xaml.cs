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
    public partial class PrikazChatovaPage : ContentPage
    {
        private PrikazChatovaVM model = null;

        public PrikazChatovaPage()
        {
            BindingContext = model = new PrikazChatovaVM();

            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await model.Init();
            base.OnAppearing();

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var chat = (PrikazChatovaVM.Chat)e.SelectedItem;

            await Navigation.PushAsync(new ChatPage(chat.ID));
        }
    }
}