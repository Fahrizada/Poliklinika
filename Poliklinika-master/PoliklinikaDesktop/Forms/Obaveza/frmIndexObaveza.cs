using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Obaveza
{
    public partial class frmIndexObaveza : Form
    {
        private readonly APIService _service = new APIService("Obaveza");
        private readonly APIService _odjel = new APIService("Odjel");
        public frmIndexObaveza()
        {
            InitializeComponent();
        }

        private async void frmIndexObaveza_Load(object sender, EventArgs e)
        {
            var request = await _service.Get<List<ObavezaVM>>(new ObavezaVM {
                Aktivna=true
            });
            var request2 = await _service.Get<List<ObavezaVM>>(new ObavezaVM
            {
                Aktivna = false
            });

            dgvObaveze.AutoGenerateColumns = false;
            dgvAktivne.AutoGenerateColumns = false;

            dgvAktivne.DataSource = request;
            dgvObaveze.DataSource = request2;


            if (request2 != null)
            {
                foreach (DataGridViewRow i in dgvObaveze.Rows)
                {
                    var prid = await _odjel.GetById<OdjelVM>(request2[i.Index].OdjelID);
                    i.Cells[2].Value = prid.Naziv;
                 
                }
            }

            if (request != null)
            {
                foreach (DataGridViewRow i in dgvAktivne.Rows)
                {
                    var prid = await _odjel.GetById<OdjelVM>(request[i.Index].OdjelID);
                    i.Cells[2].Value = prid.Naziv;

                }
            }


        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDetaljiObaveza obaveza = new frmDetaljiObaveza();
            obaveza.Show();
        }

        private void dgvObaveze_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvObaveze.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                var id = dgvObaveze.CurrentRow.Cells[0].Value;
                frmDetaljiObaveza detalji = new frmDetaljiObaveza
                    (int.Parse(id.ToString()));
                detalji.Show();
            }
        }

        private async void dgvAktivne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvAktivne.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                var id = dgvAktivne.CurrentRow.Cells[0].Value;
                frmDetaljiOsobljeObaveza detalji = new frmDetaljiOsobljeObaveza
                    (int.Parse(id.ToString()));
                detalji.Show();
            }
            else if(columnIndex == 4)
            {
                var id = dgvAktivne.CurrentRow.Cells[0].Value;
                try
                {
                    await _service.Delete<object>(id);

                    MessageBox.Show("Operacija uspješna");
                }
                catch (Exception)
                {

                    MessageBox.Show("Operacija nije uspješna");
                }
                
            }
        }

       
    }
}
