using Poliklinika.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Poliklinika.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}