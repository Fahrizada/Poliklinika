using PoliklinikaAPI.ViewModels;
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
    public partial class frmChatIndex : Form
    {
        private readonly APIService _poruke = new APIService("Konsultacije");
        private readonly APIService _korisnik = new APIService("Korisnik");

        public frmChatIndex()
        {
            InitializeComponent();
        }

        private async void frmChatIndex_Load(object sender, EventArgs e)
        {
            var poruke = await _poruke.Get<List<KonsultacijeVM>>(null);

            poruke = poruke.Where(x => x.DoktorID == CurrentUser.User.Id).ToList();

            dgvPoruke.AutoGenerateColumns = false;
            dgvPoruke.DataSource = poruke;

            foreach (DataGridViewRow i in dgvPoruke.Rows)
            {
                var korisnik = await _korisnik.GetById<KorisnikVM>(poruke[i.Index].KorisnikID);
                i.Cells[1].Value = korisnik.Prezime;
                i.Cells[2].Value = korisnik.Ime;
            }
        }

        private async void dgvPoruke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dgvPoruke.CurrentCell.ColumnIndex;
            if (columnIndex == 3)
            {
                var id = int.Parse(dgvPoruke.CurrentRow.Cells[0].Value.ToString());
                var cht = await _poruke.GetById<KonsultacijeVM>(id);
                
                FrmChat chat = new FrmChat(cht.ID);
                chat.Show();
            }
        }
    }
}
