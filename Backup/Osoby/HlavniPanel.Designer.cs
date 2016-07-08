using System.Windows.Forms;
namespace Osoby

{
    partial class HlavniPanel
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

        //#region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitComponent()
        {
            //udelal jsem si to po svem v druhe partial
            /*
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HlavniPanel));
            this.bKonec = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bNovy = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.tabulkaOsob = new MyDataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPaneltl = new TableLayoutPanel();
            //((System.ComponentModel.ISupportInitialize)(this.tabulkaOsob)).BeginInit();
            //this.tableLayoutPanel1.SuspendLayout();
            //this.tableLayoutPaneltl.SuspendLayout();
            this.SuspendLayout();
            // 
            // bKonec
            // 
            this.bKonec.Image = ((System.Drawing.Image)(resources.GetObject("bKonec.Image")));
            //this.bKonec.Location = new System.Drawing.Point(63, 3);
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
            //this.bEdit.Location = new System.Drawing.Point(23, 3);
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
            //this.bNovy.Location = new System.Drawing.Point(3, 3);
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
            //this.bDelete.Location = new System.Drawing.Point(43, 3);
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
            //this.tabulkaOsob.Dock = System.Windows.Forms.DockStyle.Bottom;
            //this.tabulkaOsob.Location = new System.Drawing.Point(3, 146);
            tabulkaOsob.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.tabulkaOsob.MultiSelect = false;
            this.tabulkaOsob.Name = "tabulkaOsob";
            this.tabulkaOsob.ReadOnly = true;
            this.tabulkaOsob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabulkaOsob.Size = new System.Drawing.Size(655, 245);
            this.tabulkaOsob.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            //this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            //this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPaneltl);
            this.tableLayoutPanel1.Controls.Add(this.tabulkaOsob);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            //this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            //this.tableLayoutPanel1.Size = new System.Drawing.Size(655, 394);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPaneltl
            // 
            this.tableLayoutPaneltl.ColumnCount = 4;
            
            this.tableLayoutPaneltl.Controls.Add(this.bNovy);
            this.tableLayoutPaneltl.Controls.Add(this.bEdit);
            this.tableLayoutPaneltl.Controls.Add(this.bDelete);
            this.tableLayoutPaneltl.Controls.Add(this.bKonec);
            this.tableLayoutPaneltl.Anchor = AnchorStyles.Right;
            //this.tableLayoutPaneltl.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.tableLayoutPaneltl.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPaneltl.Name = "tableLayoutPaneltl";
            //this.tableLayoutPaneltl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            //this.tableLayoutPaneltl.Size = new System.Drawing.Size(655, 129);
            //this.tableLayoutPaneltl.TabIndex = 0;
            // 
            // HlavniPanel
            // 
            this.AcceptButton = this.bNovy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 394);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HlavniPanel";
            this.Text = "Databáze osob - hlavní panel";
            //((System.ComponentModel.ISupportInitialize)(this.tabulkaOsob)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            //this.tableLayoutPaneltl.ResumeLayout(false);
            this.ResumeLayout(false);
            */

    }


        




        //#endregion

        private System.Windows.Forms.Button bKonec;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bNovy;
        private System.Windows.Forms.Button bDelete;
        //private System.Windows.Forms.DataGridView tabulkaOsob;
        private DataGridView tabulkaOsob;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPaneltl;
    }
}