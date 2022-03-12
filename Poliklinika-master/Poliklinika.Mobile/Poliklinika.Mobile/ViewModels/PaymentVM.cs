using Acr.UserDialogs;
using Poliklinika.Mobile.Views;
using Poliklinika.Model;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class PaymentVM : BaseViewModel
    {
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _pregledServis = new APIService("Pregled");
        private readonly APIService _uplata = new APIService("Uplata");

        INavigation Navigation;

        public KorisnikPregled.PreglediVM _pregled;
        public KorisnikPregled.PreglediVM Pregled { get { return _pregled; } }
        public string NazivOdjela { get; set; }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public PaymentVM(KorisnikPregled.PreglediVM pregled, INavigation navigation)
        {
            SubmitCommand = new Command(async () => await Submit());
            Navigation = navigation;
            _pregled = pregled;
        }

        public class Odjel
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
        }

        public class Uplata
        {
            public int ID { get; set; }
            public int PregledID { get; set; }
            public float Iznos { get; set; }
            public DateTime DatumUplate { get; set; }
        }

        private string StripeTestApiKey = "pk_test_51J1IB4IQ7S2NMYmSbUrGE6zUl3kHJEPxOv2BwCSYTER8YOLHb6Yt0WBGBAGmCg9ZzgKqbV9BxPrWSYIWqXilBmjG00TAnSOOZC";

        private CreditCard _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;
        private string _number;
        private string _cvc;

        User user = CurrentUser.User;
        public string Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }
        public string Cvc
        {
            get { return _cvc; }
            set { SetProperty(ref _cvc, value); }
        }
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }
        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }
        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        public CreditCard CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }
        public ICommand SubmitCommand { get; set; }
        private async Task<string> CreateTokenAsync()
        {
            try
            {
                StripeConfiguration.ApiKey = StripeTestApiKey;

                var Tokenoptions = new TokenCreateOptions()
                {
                    Card = new TokenCardOptions()
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = user.Ime + " " + user.Prezime,
                        AddressLine1 = "Vukovarska 3",
                        AddressLine2 = "",
                        AddressCity = "Tuzla",
                        AddressZip = "75000",
                        AddressState = "Tuzla12",
                        AddressCountry = "Bosna i Hercegovina",
                        Currency = "usd",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> MakePaymentAsync(string token)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_test_51J1IB4IQ7S2NMYmSGWTIRBAKKqvPZpSitCGEo736TcDuervfaFBsGoEmbtSNXYWEkqoAJwj8X4uIj8owhHc9ep5I00zDFICA8d";

                var options = new ChargeCreateOptions();

                options.Amount = Convert.ToInt64(100);
                options.Currency = "usd";
                options.Description = _pregled.Datum.ToString();
                options.Source = stripeToken.Id;
                options.StatementDescriptor = "Custom descriptor";
                options.Capture = true;
                options.ReceiptEmail = user.Email.ToString();
                var service = new ChargeService();
                Charge charge = service.Create(options);
                UserDialogs.Instance.Alert("Uplata uspješna!");
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(_pregled.Datum.ToString() + " (CreateCharge)" + ex.Message);
                throw ex;
            }
        }
        public async Task Submit()
        {

            if (ExpMonth == null || ExpMonth == "" || ExpYear == null || ExpYear == "" || Number == null || Number == "" || Cvc == null || Cvc == "")
            {
                UserDialogs.Instance.Alert("You have to fill all fields!", "Payment failed", "OK");
                return;
            }
            if (ExpMonth != null || ExpMonth != "" || ExpYear != null || ExpYear != "" || Number != null || Number != "" || Cvc != null || Cvc != "")
            {
                if (!IsDigitsOnly(ExpMonth) || !IsDigitsOnly(ExpMonth) || !IsDigitsOnly(Number) || !IsDigitsOnly(Cvc))
                {
                    UserDialogs.Instance.Alert("You can't use letters!", "Payment failed", "OK");
                    return;
                }
            }
            CreditCardModel = new CreditCard();
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
            CreditCardModel.Number = Number;
            CreditCardModel.Cvc = Cvc;
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Uplata u toku...");
                await Task.Run(async () =>
                {
                    var Token = CreateTokenAsync();
                    Console.Write(_pregled.Datum.ToString() + "Token :" + Token);
                    if (Token.ToString() != null)
                    {
                        IsTransectionSuccess = await MakePaymentAsync(Token.Result);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Podaci kartice nisu ispravni", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write(_pregled.Datum.ToString() + ex.Message);
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    KorisnikPregled.PreglediVM preg;
                    if (_pregled.ID == 0)
                        preg = await _pregledServis.Insert<KorisnikPregled.PreglediVM>(_pregled);
                    else
                        preg = _pregled;
                    
                    var uplata = new Uplata
                    {
                        DatumUplate = DateTime.Now,
                        Iznos = 50,
                        PregledID = preg.ID
                    };

                    await _uplata.Insert<Uplata>(uplata);
                    Console.Write(_pregled.Datum.ToString() + "Uplata uspješna");
                    UserDialogs.Instance.HideLoading();
                    await Navigation.PushAsync(new PrikazPregledaPage());
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    //UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                    Console.Write(_pregled.Datum.ToString() + "Uplata neuspješna ");
                }
            }
        }
    }
}
