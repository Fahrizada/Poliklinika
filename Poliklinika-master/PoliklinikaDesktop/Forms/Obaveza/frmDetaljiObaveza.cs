using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Obaveza
{
    public partial class frmDetaljiObaveza : Form
    {
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _osoblje = new APIService("Osoblje");
        private readonly APIService _service = new APIService("Obaveza");
        private int? _id = null;
        public frmDetaljiObaveza(int? odjelid = null)
        {
            InitializeComponent();
            _id = odjelid;
        }

        ObavezaVM obaveza = new ObavezaVM();
        ObavezaVM request = new ObavezaVM();
        private async void frmDetaljiObaveza_Load(object sender, EventArgs e)
        {
            await LoadOdjel();
            await LoadZaposleni();

            if (_id.HasValue)
            {
                obaveza = await _service.GetById<ObavezaVM>(_id);

                cmbOdjel.SelectedValue = obaveza.OdjelID;
                cmbOdjel.Enabled = false;

                cmbZaposlenik.SelectedValue = obaveza.OsobljeID;
                cmbZaposlenik.Enabled = false;

                dtpDatum.Value = obaveza.Datum;
                dtpDatum.Enabled = false;
                txtOpis.Text = obaveza.Opis;
                txtOpis.Enabled = false;
                btnSacuvaj.Visible = false;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                request.Opis = txtOpis.Text;
                request.Datum = dtpDatum.Value;

                if (_id.HasValue)
                {
                    obaveza.Opis = txtOpis.Text;
                    obaveza.Datum = dtpDatum.Value;
                    await _service.Update<ObavezaVM>(request);
                }
                else
                {
                    request.Aktivna = true;
                    await _service.Insert<ObavezaVM>(request);
                }
                MessageBox.Show("Operacija uspješna");
            }

        }
        private async Task LoadOdjel()
        {
            var result = await _odjel.Get<List<Poliklinika.Model.Odjel>>(null);
            result.Insert(0, new Poliklinika.Model.Odjel());
            cmbOdjel.DisplayMember = "Naziv";
            cmbOdjel.ValueMember = "ID";
            cmbOdjel.DataSource = result;

        }
        private async Task LoadZaposleni()
        {
            var result = await _osoblje.Get<List<OsobljeVM>>(null);
            result.Insert(0, new OsobljeVM());
            cmbZaposlenik.DisplayMember = "Ime";
            cmbZaposlenik.ValueMember = "ID";
            cmbZaposlenik.DataSource = result;
        }

        private void cmbZaposlenik_Format(object sender, ListControlConvertEventArgs e)
        {
            string ime = ((OsobljeVM)e.ListItem).Ime;
            string prezime = ((OsobljeVM)e.ListItem).Prezime;
            e.Value = ime + " " + prezime;
        }

        private void cmbZaposlenik_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbZaposlenik.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int osobID))
            {
                request.OsobljeID = osobID;
            }
        }

        private void cmbOdjel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbOdjel.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int odjelID))
            {
                request.OdjelID = odjelID;
            }
        }

        private void cmbZaposlenik_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringacmb(cmbZaposlenik);
        }

        private void cmbOdjel_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringacmb(cmbOdjel);
        }


        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtOpis);
        }
    }
}
