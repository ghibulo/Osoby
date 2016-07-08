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
    public partial class AdresaPanel : Form
    {
        private Driver data;
        public AdresaPanel(Driver data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            data.VlozAdresu(data.IdVybraneOsoby, tbUlice.Text, tbMesto.Text, tbPsc.Text, tbStat.Text);
        }
    }
}
