using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Poliklinika.Mobile.ViewModels
{
    public class OdjelViewModel:BaseViewModel
    {
        #region atributi
        int _ID;
        public int ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }

      
        string _Naziv=string.Empty;
        public string Naziv
        {
            get { return _Naziv; }
            set { SetProperty(ref _Naziv, value); }
        }
         string _Opis = string.Empty;
        public string Opis
        {
            get { return _Opis; }
            set { SetProperty(ref _Opis, value); }
        }
        byte[] _Slika;
        public byte[] Slika
        {
            get { return _Slika; }
            set { SetProperty(ref _Slika, value); }
        }
        #endregion

    }
}
