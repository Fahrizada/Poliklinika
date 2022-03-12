using AutoMapper;
using Poliklinika.Model;
using PoliklinikaAPI.ViewModels;
using PoliklinikaDesktop.Forms.Administrator;
using PoliklinikaDesktop.Forms.Doktor;
using PoliklinikaDesktop.Forms.Tehnicar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms
{
    public partial class frmLogin : Form
    {
        private readonly APIService _service = new APIService("Authentication");
        //private readonly APIService _userService = new APIService("Osoblje");
        private readonly IMapper _mapper;

        public frmLogin(IMapper mapper)
        {
            InitializeComponent();
            _mapper = mapper;
        }

        AuthenticateRequest request = new AuthenticateRequest();

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {

                AuthenticateResponse result = null;

                try
                {
                    request.Email = textEmail.Text;
                    request.Password = textPassword.Text;

                    APIService.Username = textEmail.Text;
                    APIService.Password = textPassword.Text;

                    result = await _service.Insert<AuthenticateResponse>(request);

                    if (result == null)
                        throw new Exception("Netačan email ili šifra");
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message, "Neuspješan login",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var user = new User();

                if (result.Role == "Doktor")
                {
                    APIService _userService = new APIService("Doktor");
                    user = _mapper.Map<Poliklinika.Model.Doktor>(await _userService.GetById<DoktorVM>(result.Id));
                    SetUser(result, user);
                    frmIndexDoktor forma = new frmIndexDoktor();
                    forma.Show();
                }
                else if (result.Role == "Tehnicar")
                {
                    APIService _userService = new APIService("Tehnicar");
                    user = _mapper.Map<Poliklinika.Model.Tehnicar>(await _userService.GetById<TehnicarVM>(result.Id));
                    SetUser(result, user);
                    frmIndexTehnicar forma = new frmIndexTehnicar();
                    forma.Show();
                }
                else if (result.Role == "Admin")
                {
                    APIService _userService = new APIService("Admin");
                    user = await _userService.GetById<User>(result.Id);
                    SetUser(result, user);
                    frmIndexAmin forma = new frmIndexAmin();
                    forma.Show();
                }
                else
                {
                    MessageBox.Show("Korisnika nije moguće ulogovati", "Neuspješan login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetUser(AuthenticateResponse result, User user)
        {

            CurrentUser.Role = result.Role;
            CurrentUser.JWT = result.Token;
            CurrentUser.User = user;
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(textEmail);
        }

        private void textPassword_Validating(object sender, CancelEventArgs e)
        {
            var _validator = new Validatori(sender, e, errorProvider);
            _validator.ValidacijaPraznogStringa(textPassword);
        }
    }
}
