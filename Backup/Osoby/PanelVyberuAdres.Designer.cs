using System.Windows.Forms;
namespace Osoby
{
    partial class PanelVyberuAdres
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
            this.dataGridAdres = new System.Windows.Forms.DataGridView();
            this.bOk = new System.Windows.Forms.Button();
            this.bZpet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdres)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAdres
            // 
            this.dataGridAdres.AllowUserToAddRows = false;
            this.dataGridAdres.AllowUserToDeleteRows = false;
            this.dataGridAdres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAdres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAdres.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridAdres.Location = new System.Drawing.Point(0, 0);
            this.dataGridAdres.Name = "dataGridAdres";
            this.dataGridAdres.ReadOnly = true;
            this.dataGridAdres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAdres.Size = new System.Drawing.Size(575, 231);
            this.dataGridAdres.TabIndex = 0;
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(347, 249);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 1;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bZpet
            // 
            this.bZpet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bZpet.Location = new System.Drawing.Point(463, 249);
            this.bZpet.Name = "bZpet";
            this.bZpet.Size = new System.Drawing.Size(75, 23);
            this.bZpet.TabIndex = 2;
            this.bZpet.Text = "Zpět";
            this.bZpet.UseVisualStyleBackColor = true;
            // 
            // PanelVyberuAdres
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bZpet;
            this.ClientSize = new System.Drawing.Size(575, 284);
            this.Controls.Add(this.bZpet);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.dataGridAdres);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PanelVyberuAdres";
            this.ShowInTaskbar = false;
            this.Text = "Výběr z již použitých adres...";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bZpet;
        private System.Windows.Forms.DataGridView dataGridAdres;
    }
}