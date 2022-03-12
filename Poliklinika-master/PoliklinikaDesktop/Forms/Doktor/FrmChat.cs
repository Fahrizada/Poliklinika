using Poliklinika.Model;
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
    public partial class FrmChat : Form
    {
        private readonly int _chatID;
        private readonly APIService _service = new APIService("KonsultacijePoruka");

        public FrmChat(int chatID)
        {
            _chatID = chatID;
            InitializeComponent();
        }

        private async void FrmChat_Load(object sender, EventArgs e)
        {
            tblChat.AutoScroll = false;
            tblChat.HorizontalScroll.Enabled = false;
            tblChat.HorizontalScroll.Visible = false;
            tblChat.AutoScroll = true;

            var poruke = await _service.Get<List<KonsultacijePorukaVM>>(null);
            poruke = poruke.Where(x => x.KonsultacijeID == _chatID).ToList();

            foreach (var i in poruke)
            {
                var lbl = new Label { Text = i.Poruka };
                lbl.Font = new Font("Arial", 12, FontStyle.Regular);
                lbl.MaximumSize = new Size(500, int.MaxValue);
                lbl.AutoSize = true;
                lbl.BorderStyle = BorderStyle.FixedSingle;

                if (CurrentUser.User.Id == i.UserID)
                {
                    lbl.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                    lbl.Padding = new Padding { Right = 50 };
                }
                else
                {
                    lbl.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    lbl.Padding = new Padding { Left = 50 };
                }
                tblChat.Controls.Add(lbl);
            }
        }

        private async void btnPosalji_Click(object sender, EventArgs e)
        {
            var poruka = await _service.Insert<KonsultacijePorukaVM>(new KonsultacijePorukaVM
            {
                KonsultacijeID = _chatID,
                UserID = CurrentUser.User.Id,
                Poruka = txtPoruka.Text
            });

            var lbl = new Label { Text = poruka.Poruka };
            lbl.Font = new Font("Arial", 12, FontStyle.Regular);
            lbl.MaximumSize = new Size(500, int.MaxValue);
            lbl.AutoSize = true;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            lbl.Padding = new Padding { Right = 50 };
            txtPoruka.Text = "";

            tblChat.Controls.Add(lbl);
            
            this.Refresh();
        }
    }
}
