using PoliklinikaDesktop.Forms.Nalaz;
using PoliklinikaDesktop.Forms.Obaveza;
using PoliklinikaDesktop.Forms.Raspored;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Doktor
{
    public partial class frmIndexDoktor : Form
    {
        public frmIndexDoktor()
        {
            InitializeComponent();
        }

        private void picNalaz_Click(object sender, EventArgs e)
        {
            frmIndexNalaz nalaz = new frmIndexNalaz();
            nalaz.Show();
        }


        private void picObaveza_Click(object sender, EventArgs e)
        {
            frmIndexOsobljeObaveza obaveza = new frmIndexOsobljeObaveza();
            obaveza.Show();
        }
        private void TrenutniUser_Click(object sender, EventArgs e)
        {
            frmIzmjenaPodataka profil = new frmIzmjenaPodataka();
            profil.Show();
        }

        private void frmIndexDoktor_Load(object sender, EventArgs e)
        {
            lblTrenutniUser.Text = $"{ CurrentUser.User.Ime} {CurrentUser.User.Prezime}";
        }

        private void picIzvjestaj_Click(object sender, EventArgs e)
        {
            frmIndexIzvjestajaDoktor izv = new frmIndexIzvjestajaDoktor();
            izv.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmIndexRaspored raspored = new frmIndexRaspored();
            raspored.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            CurrentUser.Role = null;
            CurrentUser.JWT = null;

            Application.Exit();
        }

        private void picPoruke_Click(object sender, EventArgs e)
        {
            frmChatIndex raspored = new frmChatIndex();
            raspored.Show();
        }
    }
}
