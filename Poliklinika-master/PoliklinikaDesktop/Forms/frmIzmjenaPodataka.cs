using Poliklinika.Model;
using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms
{
    public partial class frmIzmjenaPodataka : Form
    {
        private readonly APIService _doktor = new APIService("Doktor");
        private readonly APIService _tehnicar = new APIService("Tehnicar");
        private readonly APIService _admin = new APIService("Admin");

        public frmIzmjenaPodataka()
        {
            InitializeComponent();
        }

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (CurrentUser.Role == "Doktor")
            {
                var doc = await _doktor.GetById<DoktorVM>(CurrentUser.User.Id);

                if (txtEmail.Text != null && txtEmail.Text != "")
                    doc.Email = txtEmail.Text;
                    

                if(txtPassword.Text != null && txtPassword.Text != "")
                {
                    var update = new UpdatePasswordVM
                    {
                        password = txtPassword.Text,
                        UserId =  doc.ID
                    };
                    _doktor.UpdatePassword<UpdatePasswordVM>(update);
                }

                await _doktor.Update<DoktorVM>(doc);
            }
            else if(CurrentUser.Role == "Tehnicar")
            {
                var teh = await _tehnicar.GetById<TehnicarVM>(CurrentUser.User.Id);

                if (txtEmail.Text != null && txtEmail.Text != "")
                    teh.Email = txtEmail.Text;


                if (txtPassword.Text != null && txtPassword.Text != "")
                {
                    var update = new UpdatePasswordVM
                    {
                        password = txtPassword.Text,
                        UserId = teh.ID
                    };
                    _tehnicar.UpdatePassword<UpdatePasswordVM>(update);
                }

                await _tehnicar.Update<TehnicarVM>(teh);
            }
            else
            {
                var admin = await _admin.GetById<Admin>(CurrentUser.User.Id);

                if (txtEmail.Text != null && txtEmail.Text != "")
                    admin.Email = txtEmail.Text;


                if (txtPassword.Text != null && txtPassword.Text != "")
                {
                    var update = new UpdatePasswordVM
                    {
                        password = txtPassword.Text,
                        UserId = admin.Id
                    };

                    _admin.UpdatePassword<UpdatePasswordVM>(update);
                }

                await _admin.Update<Admin>(admin);
            }

            MessageBox.Show("Operacija uspješna");
        }
    }
}
