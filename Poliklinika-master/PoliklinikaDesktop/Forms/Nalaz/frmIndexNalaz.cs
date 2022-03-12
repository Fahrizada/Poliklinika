using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Nalaz
{
    public partial class frmIndexNalaz : Form
    {
        private readonly APIService _service = new APIService("Nalaz");
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _korisnik = new APIService("Korisnik");

        public frmIndexNalaz()
        {
            InitializeComponent();
        }

        private async void frmIndexNalaz_Load(object sender, EventArgs e)
        {
            var id = CurrentUser.User.Id;

            var result = await _pregled.Get<List<PregledVM>>(new PregledVM()
            {
                DoktorID = id,
                Opis = "Nalaz"
            });

            dgvPregled.AutoGenerateColumns = false;
            dgvPregled.DataSource = result;

            if (result != null)
            {
                foreach(DataGridViewRow i in dgvPregled.Rows)
                {
                    var prid = await _pregled.GetById<PregledVM>(result[i.Index].ID);
                    var korisnik = await _korisnik.GetById<KorisnikVM>(prid.KorisnikID);
                    i.Cells[1].Value = korisnik.Prezime;
                    i.Cells[2].Value = korisnik.Ime;
                } 
            }
            var result2 = await _service.Get<List<NalazVM>>(new PregledVM()
            {
                DoktorID = id
            });

            dgvNalaz.AutoGenerateColumns = false;
            dgvNalaz.DataSource = result2;

            if (result2 != null)
            {
                foreach (DataGridViewRow i in dgvNalaz.Rows)
                {
                    var prid = await _pregled.GetById<PregledVM>(result2[i.Index].PregledID);
                    var korisnik = await _korisnik.GetById<KorisnikVM>(prid.KorisnikID);
                    i.Cells[1].Value = korisnik.Prezime;
                    i.Cells[2].Value = korisnik.Ime;
                }
            }
        }

        private async void dgvPregled_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvPregled.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                var id = dgvPregled.CurrentRow.Cells[0].Value;

                var pregled = await _pregled.GetById<PregledVM>(id);
                var nalaz = await _service.Get<List<NalazVM>>(null);
               
                nalaz = nalaz.Where(x => x.PregledID == int.Parse(id.ToString())).ToList();
                if (nalaz.Count!=0)
                {
                    MessageBox.Show("Nalaz za ovaj pregled je već kreiran.");
                }
                else
                {

                    frmDetaljiNalaz detalji = new frmDetaljiNalaz("pregled", int.Parse(id.ToString()));
                    detalji.Show();
                }
            }
        }

        private void dgvNalaz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvNalaz.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                var id = dgvNalaz.CurrentRow.Cells[0].Value;
                frmDetaljiNalaz detalji = new frmDetaljiNalaz("nalaz",int.Parse(id.ToString()));
                detalji.Show();
            }
        }
    }
}
