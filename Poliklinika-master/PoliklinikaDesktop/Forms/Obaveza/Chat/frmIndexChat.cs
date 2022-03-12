using PoliklinikaAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PoliklinikaDesktop.Forms.Obaveza.Chat
{
    public partial class frmIndexChat : Form
    {
        private readonly APIService _service = new APIService("ChatPoruka");
        private int _id;

        public frmIndexChat(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmIndexChat_Load(object sender, EventArgs e)
        {
            tblLayout.AutoScroll = false;
            tblLayout.HorizontalScroll.Enabled = false;
            tblLayout.HorizontalScroll.Visible = false;
            tblLayout.AutoScroll = true;

            var chatObaveza = new ChatObavezaVM { ID = int.Parse(_id.ToString()) };
            var poruke = await _service.Get<List<ChatPorukaVM>>(chatObaveza);

            foreach (var i in poruke)
            {
                var lbl = new Label { Text = i.Poruka };
                lbl.Font = new Font("Arial", 12, FontStyle.Regular);
                lbl.MaximumSize = new Size(500, int.MaxValue);
                lbl.AutoSize = true;
                lbl.BorderStyle = BorderStyle.FixedSingle;

                if(CurrentUser.User.Id == i.OsobljeID)
                {
                    lbl.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                    lbl.Padding = new Padding { Right = 50 };
                }
                else
                {
                    lbl.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    lbl.Padding = new Padding { Left = 50 };
                }
                tblLayout.Controls.Add(lbl);
            }
        }

        private async void btnPosalji_Click(object sender, EventArgs e)
        {
            
            var poruka = await _service.Insert<ChatPorukaVM>(new ChatPorukaVM { 
                Poruka = txtPoruka.Text,
                OsobljeID = CurrentUser.User.Id,
                ChatObavezaID = _id
            });

            this.Refresh();
        }
    }
}
