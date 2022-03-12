namespace PoliklinikaDesktop.Forms.Tehnicar
{
    partial class frmIndexTehnicar
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
            this.picObaveze = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTrenutniUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picObaveze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // picObaveze
            // 
            this.picObaveze.Image = global::PoliklinikaDesktop.Properties.Resources.obaveze;
            this.picObaveze.Location = new System.Drawing.Point(151, 252);
            this.picObaveze.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picObaveze.Name = "picObaveze";
            this.picObaveze.Size = new System.Drawing.Size(231, 280);
            this.picObaveze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picObaveze.TabIndex = 0;
            this.picObaveze.TabStop = false;
            this.picObaveze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picObaveze_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PoliklinikaDesktop.Properties.Resources.poslovne3;
            this.pictureBox2.Location = new System.Drawing.Point(514, 252);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(231, 280);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(174, 548);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "Pregled obaveza";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(526, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pregled rasporeda";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PoliklinikaDesktop.Properties.Resources.logo;
            this.pictureBox5.Location = new System.Drawing.Point(115, 49);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(665, 159);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(843, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 28);
            this.label6.TabIndex = 9;
            this.label6.Text = "Logout";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblTrenutniUser
            // 
            this.lblTrenutniUser.AutoSize = true;
            this.lblTrenutniUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTrenutniUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTrenutniUser.Location = new System.Drawing.Point(843, 53);
            this.lblTrenutniUser.Name = "lblTrenutniUser";
            this.lblTrenutniUser.Size = new System.Drawing.Size(65, 28);
            this.lblTrenutniUser.TabIndex = 8;
            this.lblTrenutniUser.Text = "label5";
            this.lblTrenutniUser.Click += new System.EventHandler(this.lblTrenutniUser_Click);
            // 
            // frmIndexTehnicar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(976, 600);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTrenutniUser);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picObaveze);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmIndexTehnicar";
            this.Text = "frmIndexTehnicar";
            this.Load += new System.EventHandler(this.frmIndexTehnicar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picObaveze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picObaveze;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTrenutniUser;
    }
}