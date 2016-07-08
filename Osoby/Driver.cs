using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace Osoby
{
    public class Driver
    {
        SqlConnection connection;
        SqlDataAdapter adptTitulyPred, adptTitulyZa, adptOsoby, adptAdresy, adptOs_adr, adptOnlyAdr;
        DataSet ds;
        int idVybraneOsoby;  //v hlavnim panelu id osoby vybrane pri stisku akcniho buttonu



        /// <summary>
        /// Konstruktor otevre spojeni, nastavi adaptery, nacte data a nastavi relace
        /// </summary>
        public Driver()
        {
            //jestli v MSSQL jeste neni database DatabazeOsob, tak ji zaloz
            if (!existujeDatabase()) createDatabaseOsob();
            
            string connectionstr = System.Configuration.ConfigurationSettings.AppSettings["Osoby"];
            connection = new SqlConnection(connectionstr);

            //adaptery a data       
            adptTitulyPred= new SqlDataAdapter();
            adptTitulyZa= new SqlDataAdapter();
            adptOsoby= new SqlDataAdapter();
            adptAdresy = new SqlDataAdapter();
            adptOs_adr = new SqlDataAdapter();
            adptOnlyAdr = new SqlDataAdapter();

            ds = new DataSet();
            InitAdaptery();
            NacistData();
            NastavIDcka();
            //nastaveni relaci - zbytecne
            /*DataRelation rel = new DataRelation("relaceTitulPred", ds.Tables["titulyPred"].Columns["id"], ds.Tables["osoby"].Columns["id_titulPred"]);
            ds.Relations.Add(rel);
            rel = new DataRelation("relaceTitulZa", ds.Tables["titulyZa"].Columns["id"], ds.Tables["osoby"].Columns["id_titulZa"]);
            ds.Relations.Add(rel);
            */
            /*
            DataRelation rel = new DataRelation("rAdresaOsoba", ds.Tables["adresy"].Columns["id"], ds.Tables["os_adr"].Columns["ida"]);
            ds.Relations.Add(rel);
            rel = new DataRelation("rOsobaAdresa", ds.Tables["osoby"].Columns["id"], ds.Tables["os_adr"].Columns["ido"]);
            ds.Relations.Add(rel);
            */


        }

        /// <summary>
        /// Nastavi adaptery pro komunikaci DataSet-MSSQL
        /// </summary>
        private void InitAdaptery()
        {

            //TitulyPred //TitulyPred //TitulyPred //TitulyPred //TitulyPred //TitulyPred //TitulyPred 
            adptTitulyPred.SelectCommand = new SqlCommand("select id, nazev from titulyPred", connection);
            adptTitulyPred.InsertCommand = new SqlCommand("insert into titulyPred(nazev) values(@nazev)", connection);
            adptTitulyPred.DeleteCommand = new SqlCommand("delete from titulyPred where id=@id", connection);
            adptTitulyPred.InsertCommand.Parameters.Add("@nazev", SqlDbType.Char, 8, "nazev");
            adptTitulyPred.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            //TitulyZa //TitulyZa //TitulyZa //TitulyZa //TitulyZa //TitulyZa //TitulyZa //TitulyZa 
            adptTitulyZa.SelectCommand = new SqlCommand("select id, nazev from titulyZa", connection); 
            adptTitulyZa.InsertCommand = new SqlCommand("insert into titulyZa(nazev) values(@nazev)", connection);
            adptTitulyZa.DeleteCommand = new SqlCommand("delete from titulyZa where id=@id", connection);
            adptTitulyZa.InsertCommand.Parameters.Add("@nazev", SqlDbType.Char, 8, "nazev");
            adptTitulyZa.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby 
            adptOsoby.SelectCommand = new SqlCommand("select o.id, o.id_titulPred, o.poznamka, o.id_titulZa, tp.nazev , o.jmeno, o.prijmeni, tz.nazev, o.rc, o.pocatecniPlat from osoby o join titulyPred tp on tp.id=o.id_titulPred left join titulyZa tz on tz.id=o.id_titulZa", connection);
            adptOsoby.InsertCommand = new SqlCommand("insert into osoby(id_titulPred, jmeno, prijmeni, id_titulZa, rc, pocatecniPlat, poznamka) values(@id_titulPred, @jmeno, @prijmeni, @id_titulZa, @rc, @pocatecniPlat, @poznamka)", connection);
            adptOsoby.DeleteCommand = new SqlCommand("delete from osoby where id=@id", connection);
            adptOsoby.UpdateCommand = new SqlCommand("update osoby set id_titulPred=@id_titulPred, jmeno=@jmeno, prijmeni=@prijmeni, id_titulZa=@id_titulZa, rc=@rc, pocatecniPlat=@pocatecniPlat, poznamka=@poznamka where id=@id", connection);
            
            adptOsoby.InsertCommand.Parameters.Add("@id_titulPred", SqlDbType.Int, 4, "id_titulPred");
            adptOsoby.InsertCommand.Parameters.Add("@jmeno", SqlDbType.Char, 20, "jmeno");
            adptOsoby.InsertCommand.Parameters.Add("@prijmeni", SqlDbType.Char, 30, "prijmeni");
            adptOsoby.InsertCommand.Parameters.Add("@id_titulZa", SqlDbType.Int, 4, "id_titulZa");
            adptOsoby.InsertCommand.Parameters.Add("@rc", SqlDbType.Char, 10, "rc");
            adptOsoby.InsertCommand.Parameters.Add("@pocatecniPlat", SqlDbType.Int, 4, "pocatecniPlat");
            adptOsoby.InsertCommand.Parameters.Add("@poznamka", SqlDbType.VarChar, 100, "poznamka");
            adptOsoby.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            adptOsoby.UpdateCommand.Parameters.Add("@id_titulPred", SqlDbType.Int, 4, "id_titulPred");
            adptOsoby.UpdateCommand.Parameters.Add("@jmeno", SqlDbType.Char, 20, "jmeno");
            adptOsoby.UpdateCommand.Parameters.Add("@prijmeni", SqlDbType.Char, 30, "prijmeni");
            adptOsoby.UpdateCommand.Parameters.Add("@id_titulZa", SqlDbType.Int, 4, "id_titulZa");
            adptOsoby.UpdateCommand.Parameters.Add("@rc", SqlDbType.Char, 10, "rc");
            adptOsoby.UpdateCommand.Parameters.Add("@pocatecniPlat", SqlDbType.Int, 4, "pocatecniPlat");
            adptOsoby.UpdateCommand.Parameters.Add("@poznamka", SqlDbType.VarChar, 100, "poznamka");
            adptOsoby.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");


            //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy 
            adptAdresy.SelectCommand = new SqlCommand("select v.ida, v.ido, v.id, a.ulice, a.mesto, a.psc, a.stat from os_adr v join  adresy a  on v.ida=a.id", connection);
            adptAdresy.InsertCommand = new SqlCommand("insert into adresy(ulice, mesto, psc, stat) values(@ulice, @mesto, @psc, @stat)", connection);
            adptAdresy.DeleteCommand = new SqlCommand("delete from adresy where id=@id", connection);
            
            adptAdresy.InsertCommand.Parameters.Add("@ulice", SqlDbType.VarChar, 60, "ulice");
            adptAdresy.InsertCommand.Parameters.Add("@mesto", SqlDbType.VarChar, 50, "mesto");
            adptAdresy.InsertCommand.Parameters.Add("@psc", SqlDbType.Char, 10, "psc");
            adptAdresy.InsertCommand.Parameters.Add("@stat", SqlDbType.VarChar, 30, "stat");
            adptAdresy.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");

            adptOnlyAdr.SelectCommand = new SqlCommand("select id, ulice, mesto, psc, stat from adresy", connection);
            adptOnlyAdr.InsertCommand = new SqlCommand("insert into adresy(ulice, mesto, psc, stat) values(@ulice, @mesto, @psc, @stat)", connection);
            adptOnlyAdr.DeleteCommand = new SqlCommand("delete from adresy where id=@id", connection);

            adptOnlyAdr.InsertCommand.Parameters.Add("@ulice", SqlDbType.VarChar, 60, "ulice");
            adptOnlyAdr.InsertCommand.Parameters.Add("@mesto", SqlDbType.VarChar, 50, "mesto");
            adptOnlyAdr.InsertCommand.Parameters.Add("@psc", SqlDbType.Char, 10, "psc");
            adptOnlyAdr.InsertCommand.Parameters.Add("@stat", SqlDbType.VarChar, 30, "stat");
            adptOnlyAdr.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");




            //create table os_adr(id int not null primary key identity(0,1), ido int, ida int )
            adptOs_adr.SelectCommand = new SqlCommand("select id, ido, ida from os_adr", connection);
            adptOs_adr.InsertCommand = new SqlCommand("insert into os_adr(ido, ida) values(@ido, @ida)", connection);
            adptOs_adr.DeleteCommand = new SqlCommand("delete from os_adr where id=@id", connection);
            adptOs_adr.InsertCommand.Parameters.Add("@ido", SqlDbType.Int, 4, "ido");
            adptOs_adr.InsertCommand.Parameters.Add("@ida", SqlDbType.Int, 4, "ida");
            adptOs_adr.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "id");
            

        
        
        }

        /// <summary>
        /// Nacte data do DataSetu
        /// </summary>
        public void NacistData()
        {
            if (adptTitulyPred != null)
            {
                adptTitulyPred.Fill(ds, "titulyPred");
            }
            if (adptTitulyZa != null)
            {
                adptTitulyZa.Fill(ds, "titulyZa");
            }
            if (adptOsoby != null)
            {
                adptOsoby.Fill(ds, "osoby");
            }
            if (adptAdresy != null)
            {
                adptAdresy.Fill(ds, "adresy");
            }
            if (adptOs_adr != null)
            {
                adptOs_adr.Fill(ds, "os_adr");
            }
            if (adptOnlyAdr != null)
            {
                adptOnlyAdr.Fill(ds, "adresy");
            }

        }

        /// <summary>
        /// Nastavi sloupce ID jako autoincrement a bez moznosti NULL
        /// </summary>
        private void NastavIDcka()
        {
            foreach (DataTable t in ds.Tables)
            {
                
                t.Columns["id"].AutoIncrement = true;
                //nejdriv step, pak seed!
                t.Columns["id"].AutoIncrementStep = 1;
                //pocatecni hodnota o 1 vetsi nez max.id (ktere je na posledni radce)
                t.Columns["id"].AutoIncrementSeed = t.Rows.Count>0?(int)(t.Rows[t.Rows.Count - 1]["id"]) + 1:0;
                t.Columns["id"].AllowDBNull = false;
                //if (t.TableName!="adresy") t.Columns["id"].Unique = true;
                t.Columns["id"].ReadOnly = true;
            }

        }

        //Tituly //Tituly //Tituly //Tituly //Tituly //Tituly //Tituly //Tituly //Tituly //Tituly //Tituly 

        //getTituly("Za")
        //getTituly("Pred")
        public String[] getTituly(String ktere)
        {
            
            DataTable lTable = ds.Tables["tituly"+ktere];
            String[] tituly = new String[lTable.Rows.Count];
  
            int i=0;
            foreach (DataRow lRow in lTable.Rows)
            {
                tituly[i++] = (String)(lRow[1]);
            }
            return tituly;
        }



        //existujeTitul("Pred","ing")
        //existujeTitul("Za","ing")
        //vrati 0 kdyz jeste nebyl, jinak jeho id
        public int existujeTitul(String ktery, String jaky)
        {
            DataTable lTable = ds.Tables["tituly"+ktery];
            foreach (DataRow lRow in lTable.Rows)
            {
                if (jaky.Trim().Equals(lRow[1].ToString().Trim()))
                {
                    return (int)(lRow[0]);
                }
            }
            return -1;
        }

        //VlozTitul("Pred","ing")
        //VlozTitul("Za","ing")
        /// <summary>
        /// kdyz jeste neni tak ho tam vrazi a v kazdem pripade vrati jeho id
        /// </summary>
        public int VlozTitul(String ktery, string nazev)
        {
            int exs = existujeTitul(ktery, nazev);
            if (exs == -1)
            {
                DataRow record = ds.Tables["tituly" + ktery].NewRow();
                record["nazev"] = nazev;

                ds.Tables["tituly" + ktery].Rows.Add(record);
                if (ktery.Equals("Pred"))
                    adptTitulyPred.Update(ds, "tituly" + ktery);
                else
                    adptTitulyZa.Update(ds, "tituly" + ktery);
                //ted uz by tam mel byt, vrat jeho id
                return existujeTitul(ktery, nazev);
            }
            //uz tam byl, vrat jeho id
            return exs;

        }


        //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby //Osoby 

        //o.id, o.id_titulPred, o.poznamka, o.id_titulZa, tp.nazev , 
        //o.jmeno, o.prijmeni, tz.nazev, o.rc, o.pocatecniPlat 


        /// <summary>
        /// zadas id osoby a vrati jeji pozadovanou vlastnost (co) 
        /// </summary>
        public Object getOsobaId(int id, String co)
        {
            DataTable lTable = ds.Tables["osoby"];
            
            foreach (DataRow radek in lTable.Rows)
            {
                if ((int)radek[0]==id) {
                    switch (co)
                    {
                        case "jm": return radek["jmeno"];
                        case "tp": return radek[4];
                        case "tz": return radek[7];
                        case "pr": return radek["prijmeni"];
                        case "rc": return radek["rc"];
                        case "pl": return radek["pocatecniPlat"];
                        case "ps": return radek["poznamka"];
                        case "itp": return radek[1];
                        case "itz": return radek[3];

                    }
                }
            }
            return null;
        }



        /// <summary>
        /// vlozi osobu se vsim vsudy a vrati jeji id
        /// </summary>
        public int VlozOsobu(int id_titulPred, String jmeno, String prijmeni, int id_titulZa, String rc, int pocatecniPlat, String poznamka)
        {
                DataRow record = ds.Tables["osoby"].NewRow();
                record["id_titulPred"] = id_titulPred;
                record["jmeno"] = jmeno;
                record["prijmeni"] = prijmeni;
                record["id_titulZa"] = id_titulZa;
                record["rc"] = rc;
                record["pocatecniPlat"] = pocatecniPlat;
                record["poznamka"] = poznamka;
            
                ds.Tables["osoby"].Rows.Add(record);
                //ds.AcceptChanges();
                adptOsoby.Update(ds, "osoby");
                return (int)(record["id"]);
        }


        /// <summary>
        /// metoda pro naplneni tabulky osob v hlavnim panelu
        /// </summary>
        public DataTable sestavaOsob()
        {
            DataTable lTable = new DataTable();
            adptOsoby.Fill(lTable);
            //lTable.Columns.RemoveAt(0); // vymazat sloupec id

            //o.id, o.id_titulPred, o.poznamka, o.id_titulZa,  ---ty budou schované
            //tp.nazev , o.jmeno, o.prijmeni, tz.nazev, o.rc, o.pocatecniPlat --- ty pojmenuju
            //názvy sloupců
            lTable.Columns[4].ColumnName = "První titul";
            lTable.Columns[5].ColumnName = "Jméno";
            lTable.Columns[6].ColumnName = "Příjmení";
            lTable.Columns[7].ColumnName = "Druhý titul";
            lTable.Columns[8].ColumnName = "Rodné číslo";
            lTable.Columns[9].ColumnName = "Plat";
            return lTable;

        }



        /// <summary>
        /// vymaze osobu daneho id
        /// </summary>
        public void VymazOsobu(int id)
        {
            string selectExpr = String.Format("id={0}", id);
            DataTable t = ds.Tables["osoby"];
            DataRow[] result = t.Select(selectExpr);
            if (result.Length != 0)
            {
                result[0].Delete();
            }
            adptOsoby.Update(ds, "osoby");
            VymazVazbuOsAdr(id, -1);
        }

        /// <summary>
        /// u osoby daneho id (idKterou) zmeni vsechno mozny...
        /// </summary>
        public void UpravOsobu(int idKterou, int id_titulPred, String jmeno, String prijmeni, int id_titulZa, String rc, int pocatecniPlat, String poznamka)
        {
            string selectExpr = String.Format("id={0}", idKterou);
            DataTable t = ds.Tables["osoby"];
            DataRow[] result = t.Select(selectExpr);
            if (result.Length != 0) //mel by najit prave jeden zaznam
            {
                result[0].BeginEdit();
                result[0]["id_titulPred"] = id_titulPred;
                result[0]["jmeno"] = jmeno;
                result[0]["prijmeni"] = prijmeni;
                result[0]["id_titulZa"] = id_titulZa;
                result[0]["rc"] = rc;
                result[0]["pocatecniPlat"] = pocatecniPlat;
                result[0]["poznamka"] = poznamka;
                result[0].EndEdit();   
                //t.AcceptChanges();
                adptOsoby.Update(ds, "osoby");
                
            }
            
        }

        /// <summary>
        /// v ruznych formularich se hodi vedet, se kterou osobou se vlastne pracuje (vybrana v hlavni formulari)
        /// </summary>
        public int IdVybraneOsoby
        {
            get { return idVybraneOsoby; }
            set { idVybraneOsoby = value; }
        }


        //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy //Adresy 

        
        /// <summary>
        /// vlozi novou adresu a vrati jeji id
        /// </summary>
        public int VlozAdresu(int id, String ulice, String mesto, String psc, String stat)
        {
            DataRow record = ds.Tables["adresy"].NewRow();
            record["ulice"] = ulice;
            record["mesto"] = mesto;
            record["psc"] = psc;
            record["stat"] = stat;
            ds.Tables["adresy"].Rows.Add(record);
            adptAdresy.Update(ds, "adresy");
            //vazba na osobu
            VlozVazbuOsAdr(id, (int)(record["id"])); //nahradilo nasledujici komentar
            /*
            DataRow record2 = ds.Tables["os_adr"].NewRow();
            record2["ido"] = id;
            record2["ida"] = record["id"];
            ds.Tables["os_adr"].Rows.Add(record2);
            adptOs_adr.Update(ds, "os_adr");
            */
            return (int)record["id"];
             
        }

        public void VymazAdresu(int idJakou)
        {
            string selectExpr = String.Format("id={0}", idJakou);
            DataTable t = ds.Tables["adresy"];
            DataRow[] result = t.Select(selectExpr);
            if (result.Length != 0)
            {
                result[0].Delete();
            }
            adptOnlyAdr.Update(ds, "adresy");

        }

        /// <summary>
        /// vlozi zaznam (vazbu osoba - adresa) do tabulky os_adr
        /// </summary>
        public void VlozVazbuOsAdr(int ido, int ida)
        {
            DataRow record = ds.Tables["os_adr"].NewRow();
            record["ido"] = ido;
            record["ida"] = ida;
            ds.Tables["os_adr"].Rows.Add(record);
            adptOs_adr.Update(ds, "os_adr");
        }

        /// <summary>
        /// vymaze zaznam (vazbu osoba - adresa) z tabulky os_adr ... asi zbytecna metoda
        /// </summary>
        private void VymazVazbuOsAdr(int idKterou)
        {

            string selectExpr = String.Format("id={0}", idKterou);
            DataTable t = ds.Tables["os_adr"];
            DataRow[] result = t.Select(selectExpr);
            if (result.Length != 0)
            {
                result[0].Delete();
            }
            adptOs_adr.Update(ds, "os_adr");
        }

        /// <summary>
        /// vymaze zaznam (vazbu osoba - adresa) z tabulky os_adr
        /// kdyz je ido/ida zaporne, je splneno pro vsechny hodnoty
        /// </summary>
        public void VymazVazbuOsAdr(int ido, int ida)
        {
            DataTable lTable = ds.Tables["os_adr"];
            int idosoby;
            int idadresy;
            foreach (DataRow radek in lTable.Rows)
            {
                //pred testem vynulovani dane podminky, pokud vstup byl zapornej
                idosoby = ido >= 0 ? ido : (int)radek["ido"];
                idadresy = ida >= 0 ? ida : (int)radek["ida"];
                if (((int)radek["ido"] == idosoby) && ((int)radek["ida"] == idadresy))
                {
                    radek.Delete();   
                }
            }
            adptOs_adr.Update(ds, "os_adr");
        }

        public bool existujeVazba(int idAdresy)
        {
            DataTable lTable = ds.Tables["os_adr"];
            foreach (DataRow lRow in lTable.Rows)
            {
                if ((int)(lRow["ida"]) ==idAdresy)
                {
                    return true;
                }
            }
            return false;
        }

        //select v.id, v.ido, v.ida, a.ulice, a.mesto, a.psc, a.stat from os_adr v join adresy a on v.ida=a.id

        /// <summary>
        /// sestavi tabulku pro datagridview vsech adres, ktere patri k dane osobe
        /// </summary>
        public DataTable sestavaAdres(int idKoho)
        {
            DataTable lTable = new DataTable();
            adptAdresy.Fill(lTable);
            
            DataView vybraneRadky = new DataView(lTable);
            vybraneRadky.RowFilter = string.Format("ido={0} ", idKoho);
            DataTable vystup = vybraneRadky.ToTable();
            
            vystup.Columns[3].ColumnName = "Ulice";
            vystup.Columns[4].ColumnName = "Město";
            vystup.Columns[5].ColumnName = "PSČ";
            vystup.Columns[6].ColumnName = "Stát";
            
            return vystup;

        }

        /// <summary>
        /// sestavi tabulku vsech adres pro datagridview 
        /// </summary>
        public DataTable sestavaAdres()
        {
            
            DataTable lTable = new DataTable();
            adptOnlyAdr.Fill(lTable);
            return lTable;
            
        }




        static void Main(string[] args)
        {
            //createDatabaseOsob();
            //Console.WriteLine(doCommand("SELECT COUNT(*) FROM [titulyPred]"));
            //Console.WriteLine(doCommand("SELECT id FROM [titulyPred] where nazev='Mgr'"));
            /*
            ArrayList v = doCommandReader("select * from titulyPred");
            foreach(Object[] rec in v) 
            {
                Console.WriteLine("{0} - {1}", (SqlInt32)rec[0], (SqlString)rec[1]);
            }
            Application.Run(new HlavniPanel());
             */
            //createDatabaseOsob();
            //Driver pokus = new Driver();

            /*pokus.VlozTitulPred("ing");
            pokus.VlozTitulPred("Mgr");
            pokus.PrintTitulyPred();
            pokus.VlozTitulPred("dr");
            Console.WriteLine("-----------------");
            pokus.PrintTitulyPred();
            Console.WriteLine("-----------------");
            pokus.VymazTitulPred("Mgr");
            pokus.PrintTitulyPred();
            */

            
            
            Driver pokus = new Driver();
            //pokus.PrintOsoby();
            Console.WriteLine("-----------------");
            /*pokus.PrintTitulyPred();
            pokus.VlozTitulPred("dr");
            Console.WriteLine("-----------------");
            pokus.PrintTitulyPred();
            */

        }

        /// <summary>
        /// nevyuzito... budu pracovat pres odpojenou vrstvu
        /// </summary>
        static private int doCommand(string comm)
        {
            string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["Osoby"];
            SqlConnection sqlConnection = new SqlConnection(ConnectionString); 
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(comm, sqlConnection);

            Object oVystup = (sqlCommand.ExecuteScalar());
            int vystup = -1; //kdyz nenajde
            if (oVystup!=null) {
                vystup = (int)oVystup; //nasel
            }

            sqlConnection.Close();
            return vystup;
         }

        /// <summary>
        /// nevyuzito... budu pracovat pres odpojenou vrstvu
        /// </summary>
        static private ArrayList doCommandReader(string comm)
        {
            string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["Osoby"];
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(comm, sqlConnection);

            SqlDataReader v = (sqlCommand.ExecuteReader());
            ArrayList vystup = new ArrayList();
            int pocetSl = v.FieldCount;
            while (v.Read())
            {
                Object[] rec = new Object[pocetSl];
                for (int i = 0; i < pocetSl; i++)
                {
                    rec[i] = v.GetSqlValue(i);
                }
                vystup.Add(rec);
            }

            sqlConnection.Close();
            return vystup;
        }



        /// <summary>
        /// zjistuji, esli se bude vytvaret nova database
        /// </summary>
        static public bool existujeDatabase()
        {
            //nacist pripojovaci retezec pro vytvoreni nove databaze
            //mozne v budoucnu pridelat nacteni nazvu databaze z App.config
            string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["OsobyNove"];
            SqlConnection sqlConnection = new SqlConnection(ConnectionString); // inicializace objektu spojení na databázi
            sqlConnection.Open();

            //Console.WriteLine(String.Format("Verze serveru: {0}", sqlConnection.ServerVersion)); // zjištění verze serveru
            //Console.WriteLine(String.Format("Identifikace serveru: {0}", sqlConnection.WorkstationId)); // a ID počítače na kterém běží

            //smazat pokud existuje a vytvorit novou databazi DatabazeOsob
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*)	FROM sys.databases WHERE name = 'DatabazeOsob';", sqlConnection);
            
            int v = (int)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            return v == 0 ? false : true;
        }


        /// <summary>
        /// zalozeni nove database
        /// </summary>
        static public void createDatabaseOsob()
        {
            //nacist pripojovaci retezec pro vytvoreni nove databaze
            //mozne v budoucnu pridelat nacteni nazvu databaze z App.config
            string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["OsobyNove"];
            SqlConnection sqlConnection = new SqlConnection(ConnectionString); // inicializace objektu spojení na databázi
            sqlConnection.Open(); 
            
            //Console.WriteLine(String.Format("Verze serveru: {0}", sqlConnection.ServerVersion)); // zjištění verze serveru
            //Console.WriteLine(String.Format("Identifikace serveru: {0}", sqlConnection.WorkstationId)); // a ID počítače na kterém běží

            //smazat pokud existuje a vytvorit novou databazi DatabazeOsob
            SqlCommand sqlCommand = new SqlCommand("IF  EXISTS (SELECT name	FROM sys.databases WHERE name = 'DatabazeOsob') DROP DATABASE DatabazeOsob;", sqlConnection); 
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand("create database DatabazeOsob;", sqlConnection); 
            sqlCommand.ExecuteNonQuery();

            //vytvoreni tabulek v databazi DatabazeOsob
            sqlCommand = new SqlCommand("use DatabazeOsob;", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            
            sqlCommand = new SqlCommand("create table osoby(id int not null primary key identity(0,1), id_titulPred int, jmeno char(20), prijmeni char(30), id_titulZa int, poznamka varchar(100), rc char(10), pocatecniPlat int)", sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlCommand = new SqlCommand("create table titulyPred(id int not null primary key identity(0,1), nazev char(8))", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand("insert into titulyPred(nazev) values('-')", sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlCommand = new SqlCommand("create table titulyZa(id int not null primary key identity(0,1), nazev char(8))", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand("insert into titulyZa(nazev) values('-')", sqlConnection);
            sqlCommand.ExecuteNonQuery();


            sqlCommand = new SqlCommand("create table adresy(id int not null primary key identity(0,1), ulice varchar(60), mesto varchar(50), psc char(10), stat varchar(30))", sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sqlCommand = new SqlCommand("create table os_adr(id int not null primary key identity(0,1), ido int, ida int )", sqlConnection);
            sqlCommand.ExecuteNonQuery();



            sqlConnection.Close(); // a zase uzavřeme

            
            
            /*
            SqlConnection sqlConnection = new SqlConnection(ConnectionString); // inicializace objektu spojení na databázi
            sqlConnection.Open(); // pomocí dat z ConnectionStringu spojení otevřeme
            Console.WriteLine(String.Format("Verze serveru: {0}", sqlConnection.ServerVersion)); // zjištění verze serveru
            Console.WriteLine(String.Format("Identifikace serveru: {0}", sqlConnection.WorkstationId)); // a ID počítače na kterém běží
            sqlConnection.Close(); // a zase uzavřeme

            //--------------------
            
            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM [SeznamKamaradu]", sqlConnection); // vytvoření dotazu a předání připojení
            sqlConnection.Open(); // pomocí dat z ConnectionStringu spojení otevřeme
            Console.WriteLine(String.Format("Počet kamarádů: {0}", (int)(sqlCommand.ExecuteScalar()))); // provedení příkazu
            sqlConnection.Close(); // a zase uzavřeme

            //--------------------
            sqlCommand = new SqlCommand("SELECT [Jmeno],[Mesto] FROM [SeznamKamaradu]", sqlConnection); // vytvoření dotazu a předání připojení

            sqlConnection.Open(); // pomocí dat z ConnectionStringu spojení otevřeme
            SqlDataReader dataReader = sqlCommand.ExecuteReader(); // spuštění dotazu a vytvoření objektu na čtení řádků

            // smyčka na čtení záznamů
            while (dataReader.Read()) // posun na další řádky, dokud jsou k dispozici
            {
                Console.WriteLine(String.Format("Záznam: {0} ({1})", dataReader["Jmeno"], dataReader["Mesto"])); // zobrazí záznam
            }

            dataReader.Close(); // nejdříve uzavřeme aktuální dotaz
            sqlConnection.Close(); // a pak i spojení



            //--------------------
            sqlCommand = new SqlCommand("SELECT [Jmeno],[Mesto] FROM [SeznamKamaradu] WHERE [Mesto]=@Mesto", sqlConnection); // vytvoření dotazu a předání připojení

            Console.Write("Zadejte město: "); // vyzvat k zadání
            sqlCommand.Parameters.AddWithValue("@Mesto", Console.ReadLine()); // přidat parametr do dotazu

            sqlConnection.Open(); // pomocí dat z ConnectionStringu spojení otevřeme
            dataReader = sqlCommand.ExecuteReader(); // spuštění dotazu a vytvoření objektu na čtení řádků

            // smyčka na čtení záznamů
            while (dataReader.Read()) // posun na další řádky, dokud jsou k dispozici
            {
                Console.WriteLine(String.Format("Záznam: {0} ({1})", dataReader["Jmeno"], dataReader["Mesto"])); // zobrazí záznam
            }

            dataReader.Close(); // nejdříve uzavřeme aktuální dotaz
            sqlConnection.Close(); // a pak i spojení

*/

        }//metoda createDatabaseOsob


    } //class Driver
}//namespace
