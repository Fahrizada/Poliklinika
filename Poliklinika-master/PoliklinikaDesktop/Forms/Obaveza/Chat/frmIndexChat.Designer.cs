
namespace PoliklinikaDesktop.Forms.Obaveza.Chat
{
    partial class frmIndexChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPoruka = new System.Windows.Forms.RichTextBox();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // txtPoruka
            // 
            this.txtPoruka.Location = new System.Drawing.Point(12, 492);
            this.txtPoruka.Name = "txtPoruka";
            this.txtPoruka.Size = new System.Drawing.Size(751, 62);
            this.txtPoruka.TabIndex = 0;
            this.txtPoruka.Text = "";
            // 
            // btnPosalji
            // 
            this.btnPosalji.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPosalji.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosalji.Location = new System.Drawing.Point(792, 500);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(101, 40);
            this.btnPosalji.TabIndex = 1;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = false;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // tblLayout
            // 
            this.tblLayout.AutoScroll = true;
            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Location = new System.Drawing.Point(12, 12);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayout.Size = new System.Drawing.Size(881, 456);
            this.tblLayout.TabIndex = 3;
            // 
            // frmIndexChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(924, 567);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.txtPoruka);
            this.Name = "frmIndexChat";
            this.Text = "frmIndexChat";
            this.Load += new System.EventHandler(this.frmIndexChat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtPoruka;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
    }
}