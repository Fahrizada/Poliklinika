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
    public partial class ChatPage : ContentPage
    {
        private readonly int _id;
        private readonly APIService _konsultacijePoruka = new APIService("KonsultacijePoruka");

        public ChatPage(int iD)
        {
            _id = iD;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            var svePoruke = await _konsultacijePoruka.Get<List<response>>(null);
            var poruke = svePoruke.Where(x => x.KonsultacijeID == _id);

            foreach (var p in poruke) 
            {
                if(p.UserID == CurrentUser.User.Id)
                    Container.Children.Add(new Label { Text = p.Poruka, HorizontalOptions = LayoutOptions.EndAndExpand });
                else
                    Container.Children.Add(new Label { Text = p.Poruka, HorizontalOptions = LayoutOptions.StartAndExpand });
            }

            base.OnAppearing();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var resp = new response
            {
                KonsultacijeID = _id,
                Poruka = Poruka.Text,
                UserID = CurrentUser.User.Id
            };

            if (!string.IsNullOrWhiteSpace(resp.Poruka))
            {
                Poruka.Text = " ";
                Container.Children.Add(new Label { Text = resp.Poruka, HorizontalOptions = LayoutOptions.EndAndExpand });
                await _konsultacijePoruka.Insert<response>(resp);
            }
        }

        public class response
        {
            public int UserID { get; set; }
            public int KonsultacijeID { get; set; }
            public string Poruka { get; set; }
        }
    }
}