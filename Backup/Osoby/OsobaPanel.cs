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
    public partial class OsobaPanel : Form
    {
        private Driver data;
        private char mod; // u-upravit, d-delete, n-novy
        private bool zmeneno; // false dokud nebylo nic zmeneno
        //private bool jesteNeulozeno; //aby se neulozilo 2x (pri zmene tabpage/stiskem buttonu
        public OsobaPanel(Driver data, char mod)
        {
            this.data=data;
            this.mod = mod;
            InitializeComponent();
            nastavControls();
            zmeneno = false;
            //jesteNeulozeno = true;
            
        }
        public bool Zmeneno
        {
            get { return zmeneno; }
        }


        private void obnovTabulku(bool poprve)
        {
            dataGridAdresy.DataSource = data.sestavaAdres(data.IdVybraneOsoby);
            if (poprve) 
                for (int i = 0; i < 3; i++) dataGridAdresy.Columns[i].Visible=false; //první 3 sloupce nezobrazovat
            
         
        }

        private void nastavControls()
        {
            combTitulPred.Items.AddRange(data.getTituly("Pred"));
            combTitulZa.Items.AddRange(data.getTituly("Za"));
            tbRc.Mask = "0000000000"; //povoleno 10 cifer
            obnovTabulku(true);
         
            
            if ((mod == 'u')||(mod=='d'))
            {
                this.Text = "Panel pro úpravu dat";
                tbJmeno.Text = (String)(data.getOsobaId(data.IdVybraneOsoby, "jm"));
                tbPrijmeni.Text = (String)(data.getOsobaId(data.IdVybraneOsoby, "pr"));
                combTitulPred.SelectedIndex = (int)(data.getOsobaId(data.IdVybraneOsoby, "itp"));
                combTitulZa.SelectedIndex = (int)(data.getOsobaId(data.IdVybraneOsoby, "itz"));
                tbRc.Text = (String)(data.getOsobaId(data.IdVybraneOsoby, "rc"));
                ntbPlat.Value = (int)(data.getOsobaId(data.IdVybraneOsoby, "pl"));
                tbPoznamka.Text = (String)(data.getOsobaId(data.IdVybraneOsoby, "ps"));
                
            }
            if (mod == 'n')
            {
                this.Text = "Panel pro vložení nové osoby";
            }
            if (mod == 'd')
            {
                this.Text = "Panel pro vymazání osoby";
                bOk.Text = "Vymaž";
                tbJmeno.ReadOnly = true;
                tbPrijmeni.ReadOnly = true;
                tbPoznamka.ReadOnly = true;
                ntbPlat.ReadOnly = true;
                ntbPlat.Enabled = false;
                tbRc.ReadOnly = true;
                combTitulPred.Enabled = false;
                combTitulZa.Enabled = false;
                bAddAdr.Enabled = false;
                bEditAdr.Enabled = false;
                bDelAdr.Enabled = false;
                
            }

        }

        /// <summary>
        /// kontrola rodneho cisla, pokud chybne -> vrati true
        /// </summary>
        private static bool kontrolaRc(String rc)
        {
            if (rc.Length != 10) return true;
            int mesic = Convert.ToInt16(rc.Substring(2, 2));
            mesic = (mesic > 50) ? (mesic - 50) : mesic;
            if ((mesic < 1) || (mesic > 12)) return true;
            byte den = Convert.ToByte(rc.Substring(4, 2));
            byte rok = Convert.ToByte(rc.Substring(0, 2));
            bool prestupny = ((rok % 4)==0) ? true : false;
            if (den < 1) return true;
            bool chyba = false;
            switch (mesic)
            {
                case 1: if (den > 31) chyba = true; break;
                case 2: if (((den > 28) && (!prestupny)) || ((den > 29) && (prestupny))) chyba = true; break;
                case 3: 
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: if (den > 31) chyba = true; break;

                default: if (den > 30) chyba = true; break;
            }
            return chyba;
        }

        /// <summary>
        /// handler kdyz opustim texbox rodneho cisla tbRc
        /// </summary>  
        private void zkontrolujtbRc(object sender, EventArgs e)
        {
            if (kontrolaRc(tbRc.Text))
            {
                MessageBox.Show("Pozor, v rodném čísle je chyba!");
                zmeneno = true;
                //tbRc.Focus();
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            int idtp=0, idtz=0;
            
            if (mod != 'd')   //pro mod mazani je zbytecny zjistovat id titulu
            {
                //do idtp/idtz vrazi id titulu nebo 0 kdyz je nevyplneno
                idtp = (combTitulPred.Text != "") ? data.VlozTitul("Pred", combTitulPred.Text) : 0;
                //if (combTitulPred.Text != "") data.VlozTitul("Pred",combTitulPred.Text);
                idtz = (combTitulZa.Text != "") ? data.VlozTitul("Za", combTitulZa.Text) : 0;
                //if (combTitulZa.Text != "") data.VlozTitul("Za", combTitulZa.Text);

            }
            if (mod == 'n')
            {
                

                //minimalne prijmeni zadat je nutnost
                if ((tbPrijmeni.Text != ""))
                {
                    /*String[] titulyPred = data.getTituly("Pred");
                    String[] titulyZa = data.getTituly("Za");
                    */
                    zmeneno = true;
                    data.IdVybraneOsoby = 
                    data.VlozOsobu(idtp, tbJmeno.Text, tbPrijmeni.Text,idtz, tbRc.Text,
                                  (int)(ntbPlat.Value), tbPoznamka.Text);

                    //jesteNeulozeno = false;
                    
                }
            }
            if (mod == 'd')
            {
                data.VymazOsobu(data.IdVybraneOsoby);
                zmeneno = true;
            }
            if (mod == 'u')
            {
                if (zmeneno)
                {
                    data.UpravOsobu(data.IdVybraneOsoby, idtp, tbJmeno.Text, tbPrijmeni.Text,
                        /*indexVpoli(combTitulZa.Text, titulyZa)*/ idtz, tbRc.Text,
                                       (int)(ntbPlat.Value), tbPoznamka.Text);
                }
            }



        }

        private void bEditAdr_Click(object sender, EventArgs e)
        {
            
                AdresaPanel jakou = new AdresaPanel(data);
                if (DialogResult.OK == jakou.ShowDialog())
                {
                    obnovTabulku(false);
                }
            

        }

        private void bAddAdr_Click(object sender, EventArgs e)
        {
            PanelVyberuAdres vyber = new PanelVyberuAdres(data);
            if (DialogResult.OK == vyber.ShowDialog())
            {
                obnovTabulku(false);
            }

        }

        private void bDelAdr_Click(object sender, EventArgs e)
        {
            if (dataGridAdresy.Rows.Count > 0)
            {
                int idAdr = (int)(dataGridAdresy["ida", dataGridAdresy.SelectedRows[0].Index].Value);
                data.VymazVazbuOsAdr(data.IdVybraneOsoby, idAdr);
                obnovTabulku(false);
                if (!data.existujeVazba(idAdr)) data.VymazAdresu(idAdr); //nevlastni ji zadna osoba->pryc s ni
            }
        }


        private void combTitulPred_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void tbJmeno_TextChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void tbPrijmeni_TextChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void combTitulZa_SelectedIndexChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void tbRc_TextChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void ntbPlat_ValueChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void tbPoznamka_TextChanged(object sender, EventArgs e)
        {
            zmeneno = true;
        }

        private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if ((e.TabPageIndex == 0) & (mod != 'd')) //uzivatel opustil osobu, ulozit!
            {
                if ((zmeneno))
                {
                    bOk_Click(null, null);
                    obnovTabulku(false);
                    mod = 'u'; //pokud byl mod 'n', tak odted uz nejde o novy zaznam, ale upravu ulozeneho
                }
            }
        }

      
    }
}
