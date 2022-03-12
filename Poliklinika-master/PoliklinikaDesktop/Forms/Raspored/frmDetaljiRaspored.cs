using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Raspored
{
    public partial class frmDetaljiRaspored : Form
    {
        private readonly int _id;
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _doktor = new APIService("Doktor");
        private readonly APIService _tehnicar = new APIService("Tehnicar");
        private readonly APIService _raspored = new APIService("Raspored");
        
        public frmDetaljiRaspored(int rasporedid)
        {
            InitializeComponent();
            _id = rasporedid;
        }
        PregledVM pregled = new PregledVM();
        RasporedVM raspored = new RasporedVM();
        private async void frmDetaljiRaspored_Load(object sender, EventArgs e)
        {
                    await LoadDoktori();
                    await LoadTehnicari();

                    pregled = await _pregled.GetById<PregledVM>(_id);
                    dtpPocetak.Text = pregled.Datum.TimeOfDay.ToString();
                    dtpPocetak.Enabled = false;
                    lblDatum.Text = pregled.Datum.Date.ToString();
                    dtpKraj.Format = DateTimePickerFormat.Custom;
                    dtpKraj.CustomFormat = "HH:mm";

        }
        private async Task LoadDoktori()
        {
            pregled = await _pregled.GetById<PregledVM>(_id);
            var result = await _doktor.Get<List<DoktorVM>>(null);
            result = result.Where(x => x.OdjelID == pregled.OdjelID).ToList();
            result.Insert(0, new DoktorVM());
            cmbDoktor.DisplayMember = "Ime";
            cmbDoktor.ValueMember = "ID";
            cmbDoktor.DataSource = result;
        }

        private async Task LoadTehnicari()
        {
            var result2 = await _tehnicar.Get<List<TehnicarVM>>(null);
            result2.Insert(0, new TehnicarVM());
            cmbTehnicar.DisplayMember = "Ime";
            cmbTehnicar.ValueMember = "ID";
            cmbTehnicar.DataSource = result2;
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idDok = cmbDoktor.SelectedValue;

            if (int.TryParse(idDok.ToString(), out int dokID))
            {
                raspored.DoktorID = dokID;
                pregled.DoktorID = dokID;
            }
        }

        private void cmbTehnicar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idTeh = cmbTehnicar.SelectedValue;

            if (int.TryParse(idTeh.ToString(), out int tehID))
            {
                raspored.TehnicarID = tehID;
                pregled.TehnicarID = tehID;
            }
        }
        private void cmbDoktor_Format(object sender, ListControlConvertEventArgs e)
        {
            string ime = ((DoktorVM)e.ListItem).Ime;
            string prezime = ((DoktorVM)e.ListItem).Prezime;
            e.Value = ime + " " + prezime;
        }

        private void cmbTehnicar_Format(object sender, ListControlConvertEventArgs e)
        {
            string ime = ((TehnicarVM)e.ListItem).Ime;
            string prezime = ((TehnicarVM)e.ListItem).Prezime;
            e.Value = ime + " " + prezime;
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            raspored.Vrijeme = $"{dtpPocetak.Text} - {dtpKraj.Text}";
            raspored.PregledID = _id;
            raspored.Datum = pregled.Datum;

            if (this.ValidateChildren())
            {
                await _pregled.Update<PregledVM>(pregled);
                await _raspored.Insert<RasporedVM>(raspored);

                MessageBox.Show("Operacija uspješna");
            }
        }

        private void cmbDoktor_Validating(object sender, CancelEventArgs e)
        {
                var _validator = new Validatori(sender, e, errorProvider);
                _validator.ValidacijaPraznogStringacmb(cmbDoktor);
        
        }

        private void cmbTehnicar_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringacmb(cmbTehnicar);
        }
    }
}
