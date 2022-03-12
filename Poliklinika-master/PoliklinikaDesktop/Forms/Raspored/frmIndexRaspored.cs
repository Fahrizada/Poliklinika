using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Raspored
{
    public partial class frmIndexRaspored : Form
    {
        private readonly APIService _service = new APIService("Raspored");
        public frmIndexRaspored()
        {
            InitializeComponent();
        }

        private async void frmIndexRaspored_Load(object sender, EventArgs e)
        {
            var raspored = new RasporedVM();

            if (CurrentUser.Role == "Doktor")
                raspored.DoktorID = CurrentUser.User.Id;
            else
                raspored.TehnicarID = CurrentUser.User.Id;

            var result = await _service.Get<List<RasporedVM>>(raspored);

            dgvRaspored.AutoGenerateColumns = false;
            dgvRaspored.DataSource = result;
        }

        private void dgvRaspored_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvRaspored.CurrentCell.ColumnIndex;
            if (columnIndex == 2)
            {
                var id = dgvRaspored.CurrentRow.Cells[0].Value;
                frmPregledRaspored detalji = new frmPregledRaspored(int.Parse(id.ToString()));
                detalji.Show();
            }
        }
    }
}
