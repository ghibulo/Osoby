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
    public partial class PanelVyberuAdres : Form
    {
        private Driver data;
        public PanelVyberuAdres(Driver data)
        {
            this.data = data;
            InitializeComponent();
            bOk.DialogResult = DialogResult.OK;
            obnovTabulku(true);
        }


        private void obnovTabulku(bool poprve)
        {
            dataGridAdres.DataSource = data.sestavaAdres();
            if (poprve)
                dataGridAdres.Columns[0].Visible = false ; 
   
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            data.VlozVazbuOsAdr(data.IdVybraneOsoby, (int)(dataGridAdres["id", dataGridAdres.SelectedRows[0].Index].Value));
            
        }

        
    }
}
