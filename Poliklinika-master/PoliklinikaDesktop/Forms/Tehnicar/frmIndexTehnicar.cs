using PoliklinikaDesktop.Forms.Obaveza;
using PoliklinikaDesktop.Forms.Raspored;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Tehnicar
{
    public partial class frmIndexTehnicar : Form
    {
        public frmIndexTehnicar()
        {
            InitializeComponent();
        }

        private void picObaveze_MouseClick(object sender, MouseEventArgs e)
        {
            var frmObaveze = new frmIndexOsobljeObaveza();
            frmObaveze.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void lblTrenutniUser_Click(object sender, EventArgs e)
        {
            frmIzmjenaPodataka profil = new frmIzmjenaPodataka();
            profil.Show();
        }

        private void frmIndexTehnicar_Load(object sender, EventArgs e)
        {
            lblTrenutniUser.Text = $"{CurrentUser.User.Ime} {CurrentUser.User.Prezime}";
        }
    }
}
