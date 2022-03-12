using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using PoliklinikaAPI.ViewModels;

namespace PoliklinikaDesktop.Forms.Odjel
{
   
    public partial class frmIndexOdjel : Form
    {
        private readonly APIService _apiService = new APIService("Odjel");
        public frmIndexOdjel()
        {
            InitializeComponent();
        }

   
        private async void frmIndexOdjel_Load(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<Poliklinika.Model.Odjel>>(null);
            dgvOdjeli.AutoGenerateColumns = false;
            dgvOdjeli.DataSource = result;
        }

     
        private async void dgvOdjeli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvOdjeli.CurrentCell.ColumnIndex;
            if (columnIndex == 2)
            {
                var id = dgvOdjeli.SelectedRows[0].Cells[0].Value;
                frmDetaljiOdjel detalji = new frmDetaljiOdjel(int.Parse(id.ToString()));
                detalji.Show();
                dgvOdjeli.Refresh();
            }
            else if (columnIndex == 3)
            {
                var id = dgvOdjeli.SelectedRows[0].Cells[0].Value;
              
                try
                {
                    await _apiService.Delete<object>(id);

                    MessageBox.Show("Operacija uspješna");
                }
                catch (Exception)
                {

                    MessageBox.Show("Operacija nije uspješna");
                }
               
            }
           
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmDetaljiOdjel odjel = new frmDetaljiOdjel();
            odjel.Show();
        }
    }
}
