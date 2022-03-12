
namespace PoliklinikaDesktop.Forms.Doktor
{
    partial class FrmChat
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
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tblChat = new System.Windows.Forms.TableLayoutPanel();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.txtPoruka = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tblLayout
            // 
            this.tblLayout.AutoScroll = true;
            this.tblLayout.ColumnCount = 1;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout.Location = new System.Drawing.Point(0, 90);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayout.Size = new System.Drawing.Size(200, 10);
            this.tblLayout.TabIndex = 0;
            // 
            // tblChat
            // 
            this.tblChat.AutoScroll = true;
            this.tblChat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tblChat.ColumnCount = 1;
            this.tblChat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblChat.Location = new System.Drawing.Point(10, 9);
            this.tblChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblChat.Name = "tblChat";
            this.tblChat.RowCount = 1;
            this.tblChat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblChat.Size = new System.Drawing.Size(771, 342);
            this.tblChat.TabIndex = 6;
            // 
            // btnPosalji
            // 
            this.btnPosalji.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPosalji.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosalji.Location = new System.Drawing.Point(693, 375);
            this.btnPosalji.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(88, 30);
            this.btnPosalji.TabIndex = 5;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = false;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // txtPoruka
            // 
            this.txtPoruka.Location = new System.Drawing.Point(10, 369);
            this.txtPoruka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPoruka.Name = "txtPoruka";
            this.txtPoruka.Size = new System.Drawing.Size(658, 48);
            this.txtPoruka.TabIndex = 4;
            this.txtPoruka.Text = "";
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 436);
            this.Controls.Add(this.tblChat);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.txtPoruka);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmChat";
            this.Text = "FrmChat";
            this.Load += new System.EventHandler(this.FrmChat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.TableLayoutPanel tblChat;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.RichTextBox txtPoruka;
    }
}