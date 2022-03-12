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

namespace PoliklinikaDesktop.Forms.Izvjestaj
{
    public partial class frmIndexIzvjestaj : Form
    {
        private readonly APIService _zaposleni = new APIService("Doktor");
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _izvjestaj = new APIService("Izvjestaj");
        private readonly APIService _pregled = new APIService("Pregled");
        public frmIndexIzvjestaj()
        {
            InitializeComponent();
        }


        private async void frmIndexIzvjestaj_Load(object sender, EventArgs e)
        {
            await LoadOdjel();
        }
        private async Task LoadOdjel()
        {
            var result = await _odjel.Get<List<Poliklinika.Model.Odjel>>(null);
            result.Insert(0, new Poliklinika.Model.Odjel());
            cmbOdjel.DisplayMember = "Naziv";
            cmbOdjel.ValueMember = "ID";
            cmbOdjel.DataSource = result;

        }

        private async void cmbOdjel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbOdjel.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                if(int.Parse(idObj.ToString()) != 0)
                    await LoadIzvjestaj(id);
            }
        }
        private async Task LoadIzvjestaj(int OdjelID)
        {
            var odjel = new PregledVM
            {
                OdjelID = OdjelID
            };
            var pregledi = await _pregled.Get<List<PregledVM>>(odjel);
           
            var izvjestaj = await _izvjestaj.Get<List<IzvjestajVM>>(null);
            List<IzvjestajVM> result = new List<IzvjestajVM>();
            foreach (var i in izvjestaj)
            {
                foreach (var j in pregledi)
                {
                    if (i.PregledID == j.ID)
                        result.Add(i);
                }
            }
            

            dgvIzvjestaj.AutoGenerateColumns = false;
            dgvIzvjestaj.DataSource = result;
        }

        private void dgvIzvjestaj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvIzvjestaj.CurrentCell.ColumnIndex;
            if (columnIndex == 1)
            {
                var id = dgvIzvjestaj.CurrentRow.Cells[0].Value;
                frmDetaljiIzvjestaj detalji = 
                    new frmDetaljiIzvjestaj("izvjestaj", int.Parse(id.ToString()));
                detalji.Show();
            }
        }
    }
}
