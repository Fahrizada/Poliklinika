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
    public partial class frmPregledRaspored : Form
    {
        int _id;
        private readonly APIService _service = new APIService("Raspored");
        private readonly APIService _pregled = new APIService("Pregled");
        private readonly APIService _odjel = new APIService("Odjel");
        private readonly APIService _osoblje = new APIService("Osoblje");

        public frmPregledRaspored(int rasporedID)
        {
            InitializeComponent();
            _id = rasporedID;
        }

        private async void frmPregledRaspored_Load(object sender, EventArgs e)
        {
            var raspored = await _service.GetById<RasporedVM>(_id);
            var pregled = await _pregled.GetById<PregledVM>(raspored.PregledID);
            var odjel = await _odjel.GetById<OdjelVM>(pregled.OdjelID);

            lblDatum.Text = raspored.Datum.ToString();
            lblOdjel.Text = odjel.Naziv;

            dtpPocetak.Text = raspored.Vrijeme.Split("-")[0];
            dtpPocetak.Enabled = false;

            dtpKraj.Text = raspored.Vrijeme.Split("-")[1];
            dtpKraj.Enabled = false;

            var dr = await _osoblje.GetById<OsobljeVM>(raspored.DoktorID);
            var teh = await _osoblje.GetById<OsobljeVM>(raspored.TehnicarID);

            lblDoktor.Text = $"{dr.Ime} {dr.Prezime}";
            lblTehnicar.Text = $"{teh.Ime} {teh.Prezime}";
        }
    }
}
