namespace PoliklinikaDesktop.Forms.Odjel
{
    partial class frmIndexOdjel
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
            this.Odjeli = new System.Windows.Forms.GroupBox();
            this.dgvOdjeli = new System.Windows.Forms.DataGridView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewImageColumn();
            this.Izbrisi = new System.Windows.Forms.DataGridViewImageColumn();
            this.Odjeli.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdjeli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Odjeli
            // 
            this.Odjeli.Controls.Add(this.dgvOdjeli);
            this.Odjeli.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Odjeli.Location = new System.Drawing.Point(2, 161);
            this.Odjeli.Name = "Odjeli";
            this.Odjeli.Size = new System.Drawing.Size(362, 288);
            this.Odjeli.TabIndex = 0;
            this.Odjeli.TabStop = false;
            this.Odjeli.Text = "Odjeli";
            // 
            // dgvOdjeli
            // 
            this.dgvOdjeli.AllowUserToAddRows = false;
            this.dgvOdjeli.AllowUserToDeleteRows = false;
            this.dgvOdjeli.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvOdjeli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdjeli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Naziv,
            this.Detalji,
            this.Izbrisi});
            this.dgvOdjeli.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOdjeli.Location = new System.Drawing.Point(3, 25);
            this.dgvOdjeli.Name = "dgvOdjeli";
            this.dgvOdjeli.ReadOnly = true;
            this.dgvOdjeli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOdjeli.Size = new System.Drawing.Size(356, 260);
            this.dgvOdjeli.TabIndex = 0;
            this.dgvOdjeli.Text = "dataGridView1";
            this.dgvOdjeli.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOdjeli_CellClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PoliklinikaDesktop.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(282, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pregled odjela";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(440, 258);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(97, 42);
            this.btnDodaj.TabIndex = 8;
            this.btnDodaj.Text = "Dodaj novi";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.Image = global::PoliklinikaDesktop.Properties.Resources.detalji;
            this.Detalji.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Detalji.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Izbrisi
            // 
            this.Izbrisi.DataPropertyName = "Izbrisi";
            this.Izbrisi.HeaderText = "Izbrisi";
            this.Izbrisi.Image = global::PoliklinikaDesktop.Properties.Resources.izbrisi;
            this.Izbrisi.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Izbrisi.Name = "Izbrisi";
            this.Izbrisi.ReadOnly = true;
            this.Izbrisi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Izbrisi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmIndexOdjel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(639, 469);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Odjeli);
            this.Name = "frmIndexOdjel";
            this.Text = "frmIndexOdjel";
            this.Load += new System.EventHandler(this.frmIndexOdjel_Load);
            this.Odjeli.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdjeli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Odjeli;
        private System.Windows.Forms.DataGridView dgvOdjeli;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewImageColumn Detalji;
        private System.Windows.Forms.DataGridViewImageColumn Izbrisi;
    }
}