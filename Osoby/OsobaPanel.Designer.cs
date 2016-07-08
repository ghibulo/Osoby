namespace Osoby
{
    partial class OsobaPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OsobaPanel));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOsoba = new System.Windows.Forms.TabPage();
            this.tbRc = new System.Windows.Forms.MaskedTextBox();
            this.bZpet = new System.Windows.Forms.Button();
            this.bOk = new System.Windows.Forms.Button();
            this.ntbPlat = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPoznamka = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPrijmeni = new System.Windows.Forms.TextBox();
            this.tbJmeno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combTitulZa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combTitulPred = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAdresy = new System.Windows.Forms.TabPage();
            this.bDelAdr = new System.Windows.Forms.Button();
            this.bEditAdr = new System.Windows.Forms.Button();
            this.bAddAdr = new System.Windows.Forms.Button();
            this.dataGridAdresy = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabPageOsoba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntbPlat)).BeginInit();
            this.tabPageAdresy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdresy)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOsoba);
            this.tabControl.Controls.Add(this.tabPageAdresy);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(520, 372);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 0;
            this.tabControl.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Deselecting);
            // 
            // tabPageOsoba
            // 
            this.tabPageOsoba.Controls.Add(this.tbRc);
            this.tabPageOsoba.Controls.Add(this.bZpet);
            this.tabPageOsoba.Controls.Add(this.bOk);
            this.tabPageOsoba.Controls.Add(this.ntbPlat);
            this.tabPageOsoba.Controls.Add(this.label7);
            this.tabPageOsoba.Controls.Add(this.tbPoznamka);
            this.tabPageOsoba.Controls.Add(this.label6);
            this.tabPageOsoba.Controls.Add(this.label5);
            this.tabPageOsoba.Controls.Add(this.tbPrijmeni);
            this.tabPageOsoba.Controls.Add(this.tbJmeno);
            this.tabPageOsoba.Controls.Add(this.label3);
            this.tabPageOsoba.Controls.Add(this.label2);
            this.tabPageOsoba.Controls.Add(this.combTitulZa);
            this.tabPageOsoba.Controls.Add(this.label4);
            this.tabPageOsoba.Controls.Add(this.combTitulPred);
            this.tabPageOsoba.Controls.Add(this.label1);
            this.tabPageOsoba.Location = new System.Drawing.Point(4, 22);
            this.tabPageOsoba.Name = "tabPageOsoba";
            this.tabPageOsoba.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOsoba.Size = new System.Drawing.Size(512, 346);
            this.tabPageOsoba.TabIndex = 0;
            this.tabPageOsoba.Text = "Osoba";
            this.tabPageOsoba.UseVisualStyleBackColor = true;
            // 
            // tbRc
            // 
            this.tbRc.Location = new System.Drawing.Point(8, 101);
            this.tbRc.Name = "tbRc";
            this.tbRc.Size = new System.Drawing.Size(100, 20);
            this.tbRc.TabIndex = 5;
            this.tbRc.Leave += new System.EventHandler(this.zkontrolujtbRc);
            this.tbRc.TextChanged += new System.EventHandler(this.tbRc_TextChanged);
            // 
            // bZpet
            // 
            this.bZpet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bZpet.Location = new System.Drawing.Point(420, 307);
            this.bZpet.Name = "bZpet";
            this.bZpet.Size = new System.Drawing.Size(75, 23);
            this.bZpet.TabIndex = 9;
            this.bZpet.Text = "Zpět";
            this.bZpet.UseVisualStyleBackColor = true;
            // 
            // bOk
            // 
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(327, 307);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 8;
            this.bOk.Text = "OK";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // ntbPlat
            // 
            this.ntbPlat.DecimalPlaces = 1;
            this.ntbPlat.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ntbPlat.Location = new System.Drawing.Point(135, 101);
            this.ntbPlat.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ntbPlat.Name = "ntbPlat";
            this.ntbPlat.Size = new System.Drawing.Size(120, 20);
            this.ntbPlat.TabIndex = 6;
            this.ntbPlat.ThousandsSeparator = true;
            this.ntbPlat.ValueChanged += new System.EventHandler(this.ntbPlat_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Poznámka:";
            // 
            // tbPoznamka
            // 
            this.tbPoznamka.Location = new System.Drawing.Point(8, 163);
            this.tbPoznamka.Multiline = true;
            this.tbPoznamka.Name = "tbPoznamka";
            this.tbPoznamka.Size = new System.Drawing.Size(484, 104);
            this.tbPoznamka.TabIndex = 7;
            this.tbPoznamka.TextChanged += new System.EventHandler(this.tbPoznamka_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dosažený plat:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rodné číslo:";
            // 
            // tbPrijmeni
            // 
            this.tbPrijmeni.Location = new System.Drawing.Point(221, 44);
            this.tbPrijmeni.Name = "tbPrijmeni";
            this.tbPrijmeni.Size = new System.Drawing.Size(181, 20);
            this.tbPrijmeni.TabIndex = 3;
            this.tbPrijmeni.TextChanged += new System.EventHandler(this.tbPrijmeni_TextChanged);
            // 
            // tbJmeno
            // 
            this.tbJmeno.Location = new System.Drawing.Point(104, 45);
            this.tbJmeno.Name = "tbJmeno";
            this.tbJmeno.Size = new System.Drawing.Size(111, 20);
            this.tbJmeno.TabIndex = 2;
            this.tbJmeno.TextChanged += new System.EventHandler(this.tbJmeno_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Přijmení:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jméno:";
            // 
            // combTitulZa
            // 
            this.combTitulZa.FormattingEnabled = true;
            this.combTitulZa.Location = new System.Drawing.Point(408, 44);
            this.combTitulZa.Name = "combTitulZa";
            this.combTitulZa.Size = new System.Drawing.Size(87, 21);
            this.combTitulZa.TabIndex = 4;
            this.combTitulZa.SelectedIndexChanged += new System.EventHandler(this.combTitulZa_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Titul:";
            // 
            // combTitulPred
            // 
            this.combTitulPred.FormattingEnabled = true;
            this.combTitulPred.Location = new System.Drawing.Point(11, 44);
            this.combTitulPred.Name = "combTitulPred";
            this.combTitulPred.Size = new System.Drawing.Size(87, 21);
            this.combTitulPred.TabIndex = 1;
            this.combTitulPred.SelectedIndexChanged += new System.EventHandler(this.combTitulPred_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titul:";
            // 
            // tabPageAdresy
            // 
            this.tabPageAdresy.Controls.Add(this.bDelAdr);
            this.tabPageAdresy.Controls.Add(this.bEditAdr);
            this.tabPageAdresy.Controls.Add(this.bAddAdr);
            this.tabPageAdresy.Controls.Add(this.dataGridAdresy);
            this.tabPageAdresy.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdresy.Name = "tabPageAdresy";
            this.tabPageAdresy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdresy.Size = new System.Drawing.Size(512, 346);
            this.tabPageAdresy.TabIndex = 1;
            this.tabPageAdresy.Text = "Adresy";
            this.tabPageAdresy.UseVisualStyleBackColor = true;
            // 
            // bDelAdr
            // 
            this.bDelAdr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bDelAdr.Image = ((System.Drawing.Image)(resources.GetObject("bDelAdr.Image")));
            this.bDelAdr.Location = new System.Drawing.Point(395, 24);
            this.bDelAdr.Name = "bDelAdr";
            this.bDelAdr.Size = new System.Drawing.Size(90, 80);
            this.bDelAdr.TabIndex = 3;
            this.bDelAdr.Text = "Vymaž adresu";
            this.bDelAdr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bDelAdr.UseVisualStyleBackColor = true;
            this.bDelAdr.Click += new System.EventHandler(this.bDelAdr_Click);
            // 
            // bEditAdr
            // 
            this.bEditAdr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bEditAdr.Image = ((System.Drawing.Image)(resources.GetObject("bEditAdr.Image")));
            this.bEditAdr.Location = new System.Drawing.Point(284, 24);
            this.bEditAdr.Name = "bEditAdr";
            this.bEditAdr.Size = new System.Drawing.Size(90, 80);
            this.bEditAdr.TabIndex = 2;
            this.bEditAdr.Text = "Novou adresu";
            this.bEditAdr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bEditAdr.UseVisualStyleBackColor = true;
            this.bEditAdr.Click += new System.EventHandler(this.bEditAdr_Click);
            // 
            // bAddAdr
            // 
            this.bAddAdr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bAddAdr.Image = ((System.Drawing.Image)(resources.GetObject("bAddAdr.Image")));
            this.bAddAdr.Location = new System.Drawing.Point(179, 24);
            this.bAddAdr.Name = "bAddAdr";
            this.bAddAdr.Size = new System.Drawing.Size(90, 80);
            this.bAddAdr.TabIndex = 1;
            this.bAddAdr.Text = "Přidej adresu";
            this.bAddAdr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bAddAdr.UseVisualStyleBackColor = true;
            this.bAddAdr.Click += new System.EventHandler(this.bAddAdr_Click);
            // 
            // dataGridAdresy
            // 
            this.dataGridAdresy.AllowUserToAddRows = false;
            this.dataGridAdresy.AllowUserToDeleteRows = false;
            this.dataGridAdresy.AllowUserToResizeRows = false;
            this.dataGridAdresy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAdresy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAdresy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridAdresy.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridAdresy.Location = new System.Drawing.Point(3, 119);
            this.dataGridAdresy.MultiSelect = false;
            this.dataGridAdresy.Name = "dataGridAdresy";
            this.dataGridAdresy.ReadOnly = true;
            this.dataGridAdresy.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridAdresy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAdresy.Size = new System.Drawing.Size(506, 224);
            this.dataGridAdresy.TabIndex = 0;
            // 
            // OsobaPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 372);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OsobaPanel";
            this.ShowInTaskbar = false;
            this.Text = "Panel úprav";
            this.tabControl.ResumeLayout(false);
            this.tabPageOsoba.ResumeLayout(false);
            this.tabPageOsoba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ntbPlat)).EndInit();
            this.tabPageAdresy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdresy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageOsoba;
        private System.Windows.Forms.TabPage tabPageAdresy;
        private System.Windows.Forms.DataGridView dataGridAdresy;
        private System.Windows.Forms.Button bAddAdr;
        private System.Windows.Forms.Button bEditAdr;
        private System.Windows.Forms.Button bDelAdr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combTitulPred;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combTitulZa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrijmeni;
        private System.Windows.Forms.TextBox tbJmeno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPoznamka;
        private System.Windows.Forms.NumericUpDown ntbPlat;
        private System.Windows.Forms.Button bZpet;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.MaskedTextBox tbRc;
    }
}