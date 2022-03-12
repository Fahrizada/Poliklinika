
namespace PoliklinikaDesktop.Forms.Obaveza
{
    partial class frmIndexObaveza
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAktivne = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvObaveze = new System.Windows.Forms.DataGridView();
            this.IDd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Odjel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalj = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datumm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Odjell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detaljii = new System.Windows.Forms.DataGridViewImageColumn();
            this.Izbrisi = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivne)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObaveze)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PoliklinikaDesktop.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(282, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pregled obaveza";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAktivne);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(1, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 188);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aktivne obaveze";
            // 
            // dgvAktivne
            // 
            this.dgvAktivne.AllowUserToAddRows = false;
            this.dgvAktivne.AllowUserToDeleteRows = false;
            this.dgvAktivne.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAktivne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAktivne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Datumm,
            this.Odjell,
            this.Detaljii,
            this.Izbrisi});
            this.dgvAktivne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAktivne.Location = new System.Drawing.Point(3, 31);
            this.dgvAktivne.Name = "dgvAktivne";
            this.dgvAktivne.ReadOnly = true;
            this.dgvAktivne.RowTemplate.Height = 25;
            this.dgvAktivne.Size = new System.Drawing.Size(805, 154);
            this.dgvAktivne.TabIndex = 0;
            this.dgvAktivne.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAktivne_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvObaveze);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(4, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(798, 226);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kreirane obaveze";
            // 
            // dgvObaveze
            // 
            this.dgvObaveze.AllowUserToAddRows = false;
            this.dgvObaveze.AllowUserToDeleteRows = false;
            this.dgvObaveze.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvObaveze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObaveze.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDd,
            this.Datum,
            this.Odjel,
            this.Detalj});
            this.dgvObaveze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObaveze.Location = new System.Drawing.Point(3, 31);
            this.dgvObaveze.Name = "dgvObaveze";
            this.dgvObaveze.ReadOnly = true;
            this.dgvObaveze.RowTemplate.Height = 25;
            this.dgvObaveze.Size = new System.Drawing.Size(792, 192);
            this.dgvObaveze.TabIndex = 0;
            this.dgvObaveze.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObaveze_CellClick);
            // 
            // IDd
            // 
            this.IDd.DataPropertyName = "ID";
            this.IDd.HeaderText = "Id";
            this.IDd.Name = "IDd";
            this.IDd.ReadOnly = true;
            this.IDd.Visible = false;
            // 
            // Datum
            // 
            this.Datum.DataPropertyName = "Datum";
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Odjel
            // 
            this.Odjel.DataPropertyName = "Odjel";
            this.Odjel.HeaderText = "Odjel";
            this.Odjel.Name = "Odjel";
            this.Odjel.ReadOnly = true;
            // 
            // Detalj
            // 
            this.Detalj.DataPropertyName = "Detalji";
            this.Detalj.HeaderText = "Detalji";
            this.Detalj.Image = global::PoliklinikaDesktop.Properties.Resources.detalji;
            this.Detalj.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Detalj.Name = "Detalj";
            this.Detalj.ReadOnly = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(622, 61);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(152, 44);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "Dodaj novu obavezu";
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
            // Datumm
            // 
            this.Datumm.DataPropertyName = "Datum";
            this.Datumm.HeaderText = "Datum";
            this.Datumm.Name = "Datumm";
            this.Datumm.ReadOnly = true;
            // 
            // Odjell
            // 
            this.Odjell.DataPropertyName = "Odjel";
            this.Odjell.HeaderText = "Odjel";
            this.Odjell.Name = "Odjell";
            this.Odjell.ReadOnly = true;
            // 
            // Detaljii
            // 
            this.Detaljii.DataPropertyName = "Detalji";
            this.Detaljii.HeaderText = "Detalji";
            this.Detaljii.Image = global::PoliklinikaDesktop.Properties.Resources.detalji;
            this.Detaljii.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Detaljii.Name = "Detaljii";
            this.Detaljii.ReadOnly = true;
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
            // frmIndexObaveza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(812, 655);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Name = "frmIndexObaveza";
            this.Text = "frmIndexObaveza";
            this.Load += new System.EventHandler(this.frmIndexObaveza_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivne)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObaveze)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvOdgObaveze;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvObaveze;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvAktivne;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Odjel;
        private System.Windows.Forms.DataGridViewImageColumn Detalj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datumm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Odjell;
        private System.Windows.Forms.DataGridViewImageColumn Detaljii;
        private System.Windows.Forms.DataGridViewImageColumn Izbrisi;
    }
}