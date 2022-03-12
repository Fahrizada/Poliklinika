using Poliklinika.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class PregledVM : BaseViewModel
    {
        public Command ZakaziCommand { get; }
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _doktor = new APIService("Doktor");
        private readonly APIService _raspored = new APIService("Raspored");

        #region atributi
        int _odjelID;
       
        DateTime _datum=DateTime.Now;
        public DateTime Datum
        {
            get { return _datum; }
            set
            {
                if(_datum != value)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                    GetTermini();
                }
            }
        }
        
        int _korisnikID = CurrentUser.User.Id;
        public int KorisnikID
        {
            get { return _korisnikID; }
        }
        
        public List<string> _termini;
        public List<string> Termini
        {
            get { return _termini; }
            set { SetProperty(ref _termini, value); }
        }
        
        object _selectedTermin;
        public object SelectedTermin
        {
            get { return _selectedTermin; }
            set { SetProperty(ref _selectedTermin, value); }
        }
        #endregion

        public PregledVM(int id)
        {
            _odjelID = id;
            ZakaziCommand = new Command(OnZakaziClicked);
            _termini = SetTermini();
            GetTermini();
        }

        public List<string> SetTermini()
        {
            var ter = new List<string>();

            ter.Add("08:00");
            ter.Add("09:00");
            ter.Add("10:00");
            ter.Add("11:00");
            ter.Add("12:00");
            ter.Add("13:00");
            ter.Add("14:00");
            ter.Add("15:00");

            return ter;
        }

        public async void GetTermini()
        {
            _termini.Clear();
            _termini = SetTermini();


            var req = new request
            {
                Datum = _datum,
                OdjelID = _odjelID
            };

            var rasporedi = await _raspored.Get<List<Termin>>(req);

            var doktori = await _doktor.Get<List<Doktor>>(null);

            int DoktoriOdjel = 0;

            foreach (var d in doktori)
            {
                if (d.OdjelID == _odjelID)
                    DoktoriOdjel++;
            }

            foreach (var r in rasporedi)
            {
                int brojac = 0;

                foreach (var t in _termini)
                {
                    if (r.Vrijeme.Substring(0,5) == t)
                    {
                        brojac++;
                    }
                }

                if (brojac >= DoktoriOdjel)
                {
                    var zauzet = new List<string>();
                    zauzet.Add(r.Vrijeme.Substring(0,5));
                    Termini = _termini.Except(zauzet).ToList();
                }
            }
        }

        private async void OnZakaziClicked(object obj)
        {
            var datum = this.Datum;
            var hours = int.Parse(SelectedTermin.ToString().Split(':')[0]);
            var minutes = int.Parse(SelectedTermin.ToString().Split(':')[1]);
            TimeSpan ts = new TimeSpan(hours, 0, 0);
            datum = datum.Date + ts;

            var pregled = new Pregled
            {
                Datum = datum,
                KorisnikID = CurrentUser.User.Id,
                OdjelID = _odjelID
            };

            await _pregled.Insert<Pregled>(pregled);
        }

        public class Pregled
        {
            public int ID { get; set; }
            public int KorisnikID { get; set; }
            public DateTime Datum { get; set; }
            public int OdjelID { get; set; }
            public string OdjelNaziv { get; set; }
        }

        public class Termin
        {
            public int ID { get; set; }
            public DateTime Datum { get; set; }
            public string Vrijeme { get; set; }
            public int DoktorID { get; set; }
            public int TehnicarID { get; set; }
            public int PregledID { get; set; }
        }

        public class Doktor
        {
            public int OdjelID { get; set; }
        }

        public class request
        {
            public DateTime Datum { get; set; }
            public int OdjelID { get; set; }
        }
    }
}
