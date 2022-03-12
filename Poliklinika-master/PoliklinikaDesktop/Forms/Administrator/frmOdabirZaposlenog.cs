using Microsoft.AspNetCore.Identity;
using Poliklinika.Model;
using PoliklinikaAPI.ViewModels;
using PoliklinikaDesktop.Forms.Doktor;
using PoliklinikaDesktop.Forms.Tehnicar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Administrator
{
    public partial class frmOdabirZaposlenog : Form
    {
        private readonly APIService _osoblje = new APIService("Osoblje");
        public frmOdabirZaposlenog()
        {
            InitializeComponent();
        }

        private void picDodajDoktora_Click(object sender, EventArgs e)
        {
            frmDetaljiDoktor doktor = new frmDetaljiDoktor();
            doktor.Show();
        }

        private void picDodajTehnicara_Click(object sender, EventArgs e)
        {
            frmDetaljiTehnicar doktor = new frmDetaljiTehnicar();
            doktor.Show();
        }
        private async void frmOdabirZaposlenog_Load(object sender, EventArgs e)
        {
            var result = await _osoblje.Get<List<OsobljeVM>>(null);

            dgvOsoblje.AutoGenerateColumns = false;
            dgvOsoblje.DataSource = result;
        }

        private async void dgvOsoblje_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnindex = dgvOsoblje.CurrentCell.ColumnIndex;

            if (columnindex == 4)
            {
                var id = dgvOsoblje.CurrentRow.Cells[0].Value;

                var zanimanje = dgvOsoblje.CurrentRow.Cells[3]
                    .Value.ToString();
               
                if (zanimanje == "Doktor")
                {

                    frmDetaljiDoktor doktor = new frmDetaljiDoktor(int.Parse(id.ToString()));
                    doktor.Show();

                }
                if (zanimanje == "Tehnicar")
                {
                    frmDetaljiTehnicar tehnicar = new frmDetaljiTehnicar(int.Parse(id.ToString()));
                    tehnicar.Show();
                }
                
            }
            else if(columnindex == 5)
            {
                var id = dgvOsoblje.CurrentRow.Cells[0].Value;
                try
                {
                    await _osoblje.Delete<object>(id);

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
