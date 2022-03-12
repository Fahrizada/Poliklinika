using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Odjel
{
    public partial class frmDetaljiOdjel : Form
    {
        private readonly APIService _service = new APIService("Odjel");
        private int? _id = null;
        public frmDetaljiOdjel(int? odjelid = null)
        {
            InitializeComponent();
            _id = odjelid;
        }
        OdjelVM request = new OdjelVM();
        private async void frmDetaljiOdjel_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var odjel = await _service.GetById<Poliklinika.Model.Odjel>(_id);
                txtNaziv.Text = odjel.Naziv;
                txtOpis.Text = odjel.Opis;
            }
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
           
            if (this.ValidateChildren())
            {
                request.Naziv = txtNaziv.Text;
                request.Opis = txtOpis.Text;
                
              
                if (_id.HasValue)
                {
                    var odjel = await _service.GetById<OdjelVM>(_id);
                    odjel.Naziv = txtNaziv.Text;
                    odjel.Opis = txtOpis.Text;

                    await _service.Update<OdjelVM>(odjel);
                
                }
                else
                {
                    var user = CurrentUser.User;
                    var role = CurrentUser.Role;
                    await _service.Insert<OdjelVM>(request);
                   
                }
                MessageBox.Show("Operacija uspješna");
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtNaziv);
        }
        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(txtOpis);
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
           var result= openFileDialog.ShowDialog();
            if (result==DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);
                request.Slika = file;
                txtSlikaInput.Text = fileName;
                Image image = Image.FromFile(fileName);
                picSlika.Image = image;
            }
        }
    }

}

   
