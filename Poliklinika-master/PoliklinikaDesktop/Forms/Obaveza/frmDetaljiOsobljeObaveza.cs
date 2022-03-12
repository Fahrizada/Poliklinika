using PoliklinikaAPI.ViewModels;
using PoliklinikaDesktop.Forms.Obaveza.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Obaveza
{
    public partial class frmDetaljiOsobljeObaveza : Form
    {
        private readonly APIService _service = new APIService("Obaveza");
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _chat = new APIService("ChatObaveza");
        private readonly APIService _admin = new APIService("Admin");
        private readonly APIService _osoblje = new APIService("Osoblje");

        private int _id;

        public frmDetaljiOsobljeObaveza(int ObavezaID)
        {
            InitializeComponent();
            _id = ObavezaID;
        }

        private async void frmDetaljiOsobljeObaveza_Load(object sender, EventArgs e)
        {
            var Obaveza = await _service.GetById<ObavezaVM>(_id);
            var Odjel = await _odjel.GetById<OdjelVM>(Obaveza.OdjelID);
            var osoblje = await _osoblje.GetById<OsobljeVM>(Obaveza.OsobljeID);

            lblOpis.MaximumSize = new Size(400, 1000);

            lblOpis.Text = Obaveza.Opis;
            lblDatum.Text = Obaveza.Datum.ToString();
            lblOdjel.Text = Odjel.Naziv;
            lblZaposlenik.Text = $"{osoblje.Ime} { osoblje.Prezime}";

            if (!Obaveza.Aktivna)
                btnChat.Visible = false;
        }

        private async void btnChat_Click(object sender, EventArgs e)
        {
            var admin = await _admin.Get<Poliklinika.Model.Admin>(null);
            var obaveza = await _service.GetById<ObavezaVM>(_id);
            var chat = await _chat.GetById<ChatObavezaVM>(obaveza.ChatID);

            if (chat == null)
            {
                if (CurrentUser.Role == "Admin")
                {
                    MessageBox.Show("Poruke za ovu obavezu ne postoje.");
                    return;
                }
                chat = await _chat.Insert<ChatObavezaVM>(new ChatObavezaVM
                {
                    OsobljeID = CurrentUser.User.Id,
                    ObavezaID = _id,
                    AdminID = admin.Id
                });
            }

            var frmChat = new frmIndexChat(chat.ID);
            frmChat.Show();
        }

        private async void btnZavrsi_MouseClick(object sender, MouseEventArgs e)
        {
            var obaveza = await _service.GetById<ObavezaVM>(_id);

            obaveza.Aktivna = false;

            await _service.Update<ObavezaVM>(obaveza);
            MessageBox.Show("Operacija uspješna");
        }
    }
}
