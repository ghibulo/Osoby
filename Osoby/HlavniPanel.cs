using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Osoby
{
    public partial class HlavniPanel : Form
    {
      
        //reference na statickou instanci z Osoby.cs
        Driver data;
      

        public HlavniPanel(Driver dt)
        {
            mojeInitComponent();
            

            this.data = dt;
            obnovTabulku();
            
        }
        /// <summary>
        /// nastavi data do tabulky a schova zbytecny sloupce
        /// </summary>
        private void obnovTabulku()
        {
            tabulkaOsob.DataSource = data.sestavaOsob();
            for (int i = 0; i < 4; i++) tabulkaOsob.Columns[i].Visible = false; //první 4 sloupce schovám
            
        }

        private void bKonec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void bNovy_Click(object sender, EventArgs e)
        {
            
           
            OsobaPanel koho = new OsobaPanel(data,'n');
            koho.ShowDialog();
            if (koho.Zmeneno)
            {
                tabulkaOsob.DataSource = data.sestavaOsob();
                tabulkaOsob.CurrentCell = tabulkaOsob["Jméno", tabulkaOsob.RowCount-1];
            }
           
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (tabulkaOsob.Rows.Count > 0)
            {
                int aktRadka = tabulkaOsob.CurrentCell.RowIndex;
                data.IdVybraneOsoby = (int)(tabulkaOsob["id", tabulkaOsob.SelectedRows[0].Index].Value);//nulty sloupec je id
                OsobaPanel koho = new OsobaPanel(data, 'd');
                koho.ShowDialog();
                if (koho.Zmeneno)
                {
                    tabulkaOsob.DataSource = data.sestavaOsob();


                    tabulkaOsob.CurrentCell = tabulkaOsob["Jméno", aktRadka > tabulkaOsob.RowCount ? tabulkaOsob.RowCount - 1 : aktRadka - 1];
                }
            }
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (tabulkaOsob.Rows.Count > 0)
            {
                data.IdVybraneOsoby = (int)(tabulkaOsob["id", tabulkaOsob.SelectedRows[0].Index].Value);//nulty sloupec je id
                int aktRadka = tabulkaOsob.CurrentCell.RowIndex;
                OsobaPanel koho = new OsobaPanel(data, 'u');
                koho.ShowDialog();
                if (koho.Zmeneno)
                {
                    tabulkaOsob.DataSource = data.sestavaOsob();


                    tabulkaOsob.CurrentCell = tabulkaOsob["Jméno", aktRadka];
                }
            }

        }

        /// <summary>
        /// upravena kopie prostredim vygenerovanych inicializaci komponent
        /// </summary>
        private void mojeInitComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HlavniPanel));
            this.bKonec = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bNovy = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.tabulkaOsob = new DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPaneltl = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaOsob)).BeginInit();
            
            
            // 
            // bKonec
            // 
            this.bKonec.Image = ((System.Drawing.Image)(resources.GetObject("bKonec.Image")));
            
            this.bKonec.Name = "bKonec";
            this.bKonec.Size = new System.Drawing.Size(86, 85);
            this.bKonec.TabIndex = 0;
            this.bKonec.Text = "Konec";
            this.bKonec.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bKonec.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bKonec.UseVisualStyleBackColor = true;
            this.bKonec.Click += new System.EventHandler(this.bKonec_Click);
            // 
            // bEdit
            // 
            this.bEdit.Image = ((System.Drawing.Image)(resources.GetObject("bEdit.Image")));
            
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(86, 85);
            this.bEdit.TabIndex = 0;
            this.bEdit.Text = "Uprav";
            this.bEdit.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bNovy
            // 
            this.bNovy.Image = ((System.Drawing.Image)(resources.GetObject("bNovy.Image")));
            
            this.bNovy.Name = "bNovy";
            this.bNovy.Size = new System.Drawing.Size(86, 85);
            this.bNovy.TabIndex = 0;
            this.bNovy.Text = "Nová osoba";
            this.bNovy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bNovy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bNovy.UseVisualStyleBackColor = true;
            this.bNovy.Click += new System.EventHandler(this.bNovy_Click);
            // 
            // bDelete
            // 
            this.bDelete.Image = ((System.Drawing.Image)(resources.GetObject("bDelete.Image")));
            
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(86, 85);
            this.bDelete.TabIndex = 0;
            this.bDelete.Text = "Vymaž";
            this.bDelete.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // tabulkaOsob
            // 
            this.tabulkaOsob.AllowUserToAddRows = false;
            this.tabulkaOsob.AllowUserToDeleteRows = false;
            this.tabulkaOsob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabulkaOsob.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.tabulkaOsob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            
            tabulkaOsob.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.tabulkaOsob.MultiSelect = false;
            this.tabulkaOsob.Name = "tabulkaOsob";
            this.tabulkaOsob.ReadOnly = true;
            this.tabulkaOsob.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.tabulkaOsob.Size = new System.Drawing.Size(655, 245);
            this.tabulkaOsob.TabIndex = 1;
            // 
            // tableLayoutPaneltl
            // 
            this.tableLayoutPaneltl.ColumnCount = 4;

            this.tableLayoutPaneltl.Controls.Add(this.bNovy);
            this.tableLayoutPaneltl.Controls.Add(this.bEdit);
            this.tableLayoutPaneltl.Controls.Add(this.bDelete);
            this.tableLayoutPaneltl.Controls.Add(this.bKonec);
            this.tableLayoutPaneltl.Anchor = AnchorStyles.Right;
            tableLayoutPaneltl.Size = new System.Drawing.Size(400, 120);
            this.tableLayoutPaneltl.Name = "tableLayoutPaneltl";

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPaneltl);
            this.tableLayoutPanel1.Controls.Add(this.tabulkaOsob);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            
            this.tableLayoutPanel1.TabIndex = 2;
            
            // 
            // HlavniPanel
            // 
            this.AcceptButton = this.bNovy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 394);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HlavniPanel";
            this.Text = "Databáze osob - hlavní panel";
            ((System.ComponentModel.ISupportInitialize)(this.tabulkaOsob)).EndInit();

        }






    }
}
