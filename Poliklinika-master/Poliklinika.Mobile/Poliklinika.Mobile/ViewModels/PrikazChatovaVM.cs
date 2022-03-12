using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    class PrikazChatovaVM : BaseViewModel
    {
        private readonly APIService _chat = new APIService("Konsultacije");
        private readonly APIService _doktor = new APIService("Doktor");
        private readonly APIService _odjel = new APIService("Odjel");

        public ObservableCollection<Chat> Chatovi { get; set; } = new ObservableCollection<Chat>();
        public ICommand InitCommand { get; }
        public PrikazChatovaVM()
        {
            InitCommand = new Command(async () => await Init());
        }

        public async Task Init()
        {
            var list = await _chat.Get<IEnumerable<Chat>>(null);
            Chatovi.Clear();

            foreach (var c in list)
            {
                if (c.KorisnikID == CurrentUser.User.Id)
                {
                    var doktor = await _doktor.GetById<Doktor>(c.DoktorID);
                    var odjel = await _odjel.GetById<Odjel>(doktor.OdjelID);
                    c.ImeDoktoraIOdjel = $"{doktor.Ime} {doktor.Prezime}  :  {odjel.Naziv}";
                    Chatovi.Add(c);
                }
            }
        }
        public class Chat
        {
            public int ID { get; set; }
            public int KorisnikID { get; set; }
            public int DoktorID { get; set; }
            public string ImeDoktoraIOdjel { get; set; }
        }

        public class Doktor
        {
            public int ID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public int OdjelID { get; set; }
        }
        public class Odjel
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
        }
    }
}
