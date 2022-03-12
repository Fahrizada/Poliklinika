using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Nalaz
{
    public partial class frmDetaljiNalaz : Form
    {
        private readonly APIService _service = new APIService("Nalaz");
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _korisnik = new APIService("Korisnik");
        private readonly APIService _doktor = new APIService("Doktor");
        private readonly APIService _odjel = new APIService("Odjel");

        private int? _id = null;
        private string _opis;
        public frmDetaljiNalaz(string opis, int? nalazid = null)
        {
            InitializeComponent();
            _id = nalazid;
            _opis = opis;
        }

        NalazVM request = new NalazVM();
        private async void frmDetaljiNalaz_Load(object sender, EventArgs e)
        {
            

            if (_opis== "pregled") { 
                var prid = await _pregled.GetById<PregledVM>(_id);

                var korisnik = await _korisnik.GetById<KorisnikVM>(prid.KorisnikID);
                var doktor = await _doktor.GetById<DoktorVM>(prid.DoktorID);
                var odjel = await _odjel.GetById<OdjelVM>(doktor.OdjelID);

                lblDatum.Text = prid.Datum.ToString();
                lblImeKosrisnik.Text = $"{korisnik.Ime} {korisnik.Prezime}";
                lblOdjel.Text = odjel.Naziv;
                txtpregledID.Text = prid.ID.ToString();


            }
            else if (_opis == "nalaz")
            {
                var nalaz = await _service.GetById<NalazVM>(_id);
                var Prid = await _pregled.GetById<PregledVM>(nalaz.PregledID);
                var korisnik = await _korisnik.GetById<KorisnikVM>(Prid.KorisnikID);
                var doktor = await _doktor.GetById<DoktorVM>(Prid.DoktorID);
                var odjel = await _odjel.GetById<OdjelVM>(doktor.OdjelID);

                lblDatum.Text = Prid.Datum.ToString();
                lblImeKosrisnik.Text = $"{korisnik.Ime} { korisnik.Prezime}";
                txtOpis.Text = nalaz.Opis;
                txtOpis.Enabled = false;
                lblOdjel.Text = odjel.Naziv;
                btnSacuvaj.Visible = false;


            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                request.Opis = txtOpis.Text;

                if (_opis == "pregled")
                {
                    request.PregledID = int.Parse(txtpregledID.Text);
                    await _service.Insert<NalazVM>(request);
                }
                else
                {
                    var nalaz = await _service.GetById<NalazVM>(_id);
                    nalaz.Opis = txtOpis.Text;

                    await _service.Update<NalazVM>(nalaz);
                }
                MessageBox.Show("Operacija uspješna");
            }

        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtOpis);
        }
    }
}
