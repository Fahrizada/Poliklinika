
using PoliklinikaAPI.ViewModels;
using PoliklinikaDesktop.Forms.Raspored;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Administrator
{
    public partial class frmOdabirTerminaAdmin : Form
    {
        private readonly APIService _service = new APIService("Pregled");
        private readonly APIService _odjel = new APIService("Odjel");
        public frmOdabirTerminaAdmin()
        {
            InitializeComponent();
        }


        private async void dgvPregledi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnindex = dgvPregledi.CurrentCell.ColumnIndex;

            if (columnindex == 3)
            {
                var id = dgvPregledi.CurrentRow.Cells[0].Value;

                var Pregled = await _service.GetById<PregledVM>(id);
                if (Pregled.DoktorID != null && Pregled.TehnicarID !=null)
                {
                    MessageBox.Show("Raspored za ovaj pregled je već kreiran.");

                }
                else
                {
                    frmDetaljiRaspored doktor = new frmDetaljiRaspored(int.Parse(id.ToString()));
                    doktor.Show();

                }

            }
        }

        private async void frmOdabirTerminaAdmin_Load(object sender, EventArgs e)
        {
            var result = await _service.Get<List<PregledVM>>(null);
            dgvPregledi.AutoGenerateColumns = false;
            dgvPregledi.DataSource = result;

            if (result != null)
            {
                foreach (DataGridViewRow i in dgvPregledi.Rows)
                {
                    var prid = await _service.GetById<PregledVM>(result[i.Index].ID);
                    var odjel = await _odjel.GetById<OdjelVM>(prid.OdjelID);
                    i.Cells[2].Value = odjel.Naziv;
                    
                }
            }
        }
    }
}