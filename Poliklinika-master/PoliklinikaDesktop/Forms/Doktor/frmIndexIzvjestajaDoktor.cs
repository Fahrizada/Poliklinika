using PoliklinikaAPI.ViewModels;
using PoliklinikaDesktop.Forms.Izvjestaj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Doktor
{
    public partial class frmIndexIzvjestajaDoktor : Form
    {
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _korisnik = new APIService("Korisnik");
        private readonly APIService _service = new APIService("Izvjestaj");
        public frmIndexIzvjestajaDoktor()
        {
            InitializeComponent();
        }

        private async void frmIndexIzvjestajaDoktor_Load(object sender, EventArgs e)
        {
            var id = CurrentUser.User.Id;

            var result = await _pregled.Get<List<PregledVM>>(new PregledVM()
            {
                DoktorID = id,
            });

            dgvPregled.AutoGenerateColumns = false;
            dgvPregled.DataSource = result;

            if (result != null)
            {
                foreach (DataGridViewRow i in dgvPregled.Rows)
                {
                    var prid = await _pregled.GetById<PregledVM>(result[i.Index].ID);
                    var korisnik = await _korisnik.GetById<KorisnikVM>(prid.KorisnikID);
                    i.Cells[1].Value = korisnik.Prezime;
                    i.Cells[2].Value = korisnik.Ime;
                }
            }
            var result2 = await _service.Get<List<IzvjestajVM>>(new PregledVM()
            {
                DoktorID = id
            });

            dgvIzvjestaj.AutoGenerateColumns = false;
            dgvIzvjestaj.DataSource = result2;

            if (result2 != null)
            {
                foreach (DataGridViewRow i in dgvIzvjestaj.Rows)
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
                var izvjestaj = await _service.Get<List<NalazVM>>(null);

                izvjestaj = izvjestaj.Where(x => x.PregledID == int.Parse(id.ToString())).ToList();
                if (izvjestaj.Count != 0)
                {
                    MessageBox.Show("Izvještaj za ovaj pregled je već kreiran.");
                }
                else
                {
                    frmDetaljiIzvjestaj detalji =
                        new frmDetaljiIzvjestaj("pregled", int.Parse(id.ToString()));
                    detalji.Show();
                }
            }
        }

        private void dgvIzvjestaj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvIzvjestaj.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                var id = dgvIzvjestaj.CurrentRow.Cells[0].Value;
                frmDetaljiIzvjestaj detalji = 
                    new frmDetaljiIzvjestaj("izvjestaj",int.Parse(id.ToString()));
                detalji.Show();
            }
        }

       
    }
}

