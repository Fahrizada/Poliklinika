
namespace PoliklinikaDesktop.Forms.Administrator
{
    partial class frmOdabirZaposlenog
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
            this.picDodajDoktora = new System.Windows.Forms.PictureBox();
            this.picDodajTehnicara = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOsoblje = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewImageColumn();
            this.Izbrisi = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picDodajDoktora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDodajTehnicara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOsoblje)).BeginInit();
            this.SuspendLayout();
            // 
            // picDodajDoktora
            // 
            this.picDodajDoktora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picDodajDoktora.Image = global::PoliklinikaDesktop.Properties.Resources.doktor;
            this.picDodajDoktora.Location = new System.Drawing.Point(558, 10);
            this.picDodajDoktora.Name = "picDodajDoktora";
            this.picDodajDoktora.Size = new System.Drawing.Size(206, 186);
            this.picDodajDoktora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDodajDoktora.TabIndex = 6;
            this.picDodajDoktora.TabStop = false;
            this.picDodajDoktora.Click += new System.EventHandler(this.picDodajDoktora_Click);
            // 
            // picDodajTehnicara
            // 
            this.picDodajTehnicara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picDodajTehnicara.Image = global::PoliklinikaDesktop.Properties.Resources.sestrica1;
            this.picDodajTehnicara.Location = new System.Drawing.Point(833, 10);
            this.picDodajTehnicara.Name = "picDodajTehnicara";
            this.picDodajTehnicara.Size = new System.Drawing.Size(206, 186);
            this.picDodajTehnicara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDodajTehnicara.TabIndex = 7;
            this.picDodajTehnicara.TabStop = false;
            this.picDodajTehnicara.Click += new System.EventHandler(this.picDodajTehnicara_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(590, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dodaj doktora";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(812, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 60);
            this.label2.TabIndex = 9;
            this.label2.Text = "Dodaj medicinsku sestru/\r\ntehničara\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PoliklinikaDesktop.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOsoblje);
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 263);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // dgvOsoblje
            // 
            this.dgvOsoblje.AllowUserToAddRows = false;
            this.dgvOsoblje.AllowUserToDeleteRows = false;
            this.dgvOsoblje.BackgroundColor = System.Drawing.Color.White;
            this.dgvOsoblje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOsoblje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ime,
            this.Prezime,
            this.Role,
            this.Detalji,
            this.Izbrisi});
            this.dgvOsoblje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOsoblje.Location = new System.Drawing.Point(3, 19);
            this.dgvOsoblje.Name = "dgvOsoblje";
            this.dgvOsoblje.ReadOnly = true;
            this.dgvOsoblje.RowTemplate.Height = 25;
            this.dgvOsoblje.Size = new System.Drawing.Size(541, 241);
            this.dgvOsoblje.TabIndex = 0;
            this.dgvOsoblje.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOsoblje_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime ";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // Role
            // 
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "Zanimanje";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Image = global::PoliklinikaDesktop.Properties.Resources.detalji;
            this.Detalji.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            // 
            // Izbrisi
            // 
            this.Izbrisi.DataPropertyName = "Izbrisi";
            this.Izbrisi.HeaderText = "Izbrisi";
            this.Izbrisi.Image = global::PoliklinikaDesktop.Properties.Resources.izbrisi;
            this.Izbrisi.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Izbrisi.Name = "Izbrisi";
            this.Izbrisi.ReadOnly = true;
            // 
            // frmOdabirZaposlenog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1071, 477);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDodajTehnicara);
            this.Controls.Add(this.picDodajDoktora);
            this.Name = "frmOdabirZaposlenog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOdabirZaposlenog";
            this.Load += new System.EventHandler(this.frmOdabirZaposlenog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDodajDoktora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDodajTehnicara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOsoblje)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picDodajDoktora;
        private System.Windows.Forms.PictureBox picDodajTehnicara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvOsoblje;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewImageColumn Detalji;
        private System.Windows.Forms.DataGridViewImageColumn Izbrisi;
    }
}