using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Tehnicar
{
    public partial class frmDetaljiTehnicar : Form
    {
        private readonly APIService _service = new APIService("Tehnicar");
        private int? _id = null;
        public frmDetaljiTehnicar(int? tehnicarid = null)
        {
            InitializeComponent();
            _id = tehnicarid;
        }
        CreateTehnicarVM request = new CreateTehnicarVM();
        TehnicarVM tehnicar = new TehnicarVM();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                request.Ime = txtIme.Text;
                request.Prezime = txtPrezime.Text;
                request.StrucnaSprema = txtstrucna.Text;
                request.BrojRadneKnjizice = txtBrRadneKnjizice.Text;

                if (_id.HasValue)
                {
                    tehnicar = await _service.GetById<TehnicarVM>(_id);

                    tehnicar.Ime = txtIme.Text;
                    tehnicar.Prezime = txtPrezime.Text;
                    tehnicar.BrojRadneKnjizice = txtBrRadneKnjizice.Text;
                    tehnicar.StrucnaSprema = txtstrucna.Text;

                    await _service.Update<TehnicarVM>(request);
                    MessageBox.Show("Operacija uspješna");
                }
                else
                {
                    try
                    {
                        request.Password = txtPassword.Text;
                        request.Email = txtEmail.Text;
                        await _service.Insert<TehnicarVM>(request);

                        MessageBox.Show("Operacija uspješna");
                    }
                    catch
                    {
                        MessageBox.Show("Email ili Password format nije ispravan\n(Password mora imati slova, brojeve i znakove)");
                    }
                }
            }
        }

        private void cmbSpol_SelectedIndexChanged(object sender, EventArgs e)
        {  
            request.Spol = cmbSpol.SelectedItem.ToString();
            if (_id.HasValue)
                tehnicar.Spol = cmbSpol.SelectedItem.ToString();
        }

        private async void frmDetaljiTehnicar_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var teh = await _service.GetById<TehnicarVM>(_id);
                txtIme.Text = teh.Ime;
                txtPrezime.Text = teh.Prezime;
                txtstrucna.Text = teh.StrucnaSprema;
                txtBrRadneKnjizice.Text = teh.BrojRadneKnjizice;
                cmbSpol.SelectedItem = teh.Spol;
                txtEmail.Hide();
                txtPassword.Hide();
                lblEmail.Hide();
                lblPassword.Hide();
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtIme);
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtPrezime);
        }

        private void txtBrRadneKnjizice_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtBrRadneKnjizice);
        }

        private void txtstrucna_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtstrucna);
        }

        private void cmbSpol_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringacmb(cmbSpol);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (_id == null)
            {
                var _validator = new Validatori(sender, e, errorProvider);
                _validator.ValidacijaPraznogStringa(txtEmail);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_id == null)
            {
                var _validator = new Validatori(sender, e, errorProvider);
                _validator.ValidacijaPraznogStringa(txtPassword);
            }
        }
    }
}
