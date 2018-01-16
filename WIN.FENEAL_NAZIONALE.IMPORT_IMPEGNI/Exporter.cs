using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
    public class Exporter
    {
        //private string _connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|;Persist Security Info=True";
        //private  string _dbName = "";

        private string _connString = "";

        public Exporter(string connectionstring)
        {

            _connString = connectionstring;

        }

        //public Exporter(string dbName)
        //{
        //    _dbName = dbName;
        //    _connString = _connString.Replace("|DataDirectory|", _dbName);

        //}



        public string Error = "";

        public void Export(Impegno impegno, int anno)
        {
            Error = "";

            try
            {
                if (impegno.IdProvincia != -1)
                {
                    InserImpegno(impegno, anno);
                }

                Error = "";
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }

        private void InserImpegno(Impegno i, int anno)
        {
            try
            {

                i.Provincia = String.Format("'{0}'", i.Provincia.Trim().Replace("'","''"));
                i.Regione = String.Format("'{0}'", i.Regione.Trim().Replace("'", "''"));

                string insertQuery = string.Format(@"INSERT INTO Amm_ImpegniTesseramento  
                                              ( [Anno], 
                                                [Id_Provincia],  
                                                [NomeProvincia],
                                                [Id_Regione],  
                                                [NomeRegione],
                                                [TessereRichieste], 
                                                [Gennaio], 
                                                [Febbraio], 
                                                [Marzo], 
                                                [Aprile], 
                                                [Maggio], 
                                                [Giugno], 
                                                [Luglio], 
                                                [Agosto], 
                                                [Settembre], 
                                                [Ottobre], 
                                                [Novembre], 
                                                [Dicembre], 
                                                [Altro],
                                                [Totale]) 
                                                values
                                               ({0},
                                                {1},
                                                {2},
                                                {3}, 
                                                {4},
                                                {5},
                                                {6},
                                                {7},
                                                {8},
                                                {9},
                                                {10},
                                                {11},
                                                {12},
                                                {13},
                                                {14},
                                                {15},
                                                {16}, 
                                                {17}, 
                                                {18}, 
                                                {19})", 
                                                anno, 
                                                i.IdProvincia,
                                                i.Provincia   , 
                                                i.IdRegione,
                                                i.Regione , 
                                                i.Tessere,
                                                i.gen.ToString().Replace(",", "."), 
                                                i.feb.ToString().Replace(",", "."), 
                                                i.mar.ToString().Replace(",", "."), 
                                                i.apr.ToString().Replace(",", "."), 
                                                i.mag.ToString().Replace(",", "."), 
                                                i.giu.ToString().Replace(",", "."), 
                                                i.lug.ToString().Replace(",", "."), 
                                                i.ago.ToString().Replace(",", "."),
                                                i.set.ToString().Replace(",", "."), 
                                                i.ott.ToString().Replace(",", "."), 
                                                i.nov.ToString().Replace(",", "."), 
                                                i.dic.ToString().Replace(",", "."), 
                                                i.altreDate.ToString().Replace(",", "."), 
                                                i.ImpegnoTotale.ToString().Replace(",", "."));

                string deleteQuery = string.Format(@"Delete from Amm_ImpegniTesseramento where [Anno] = {0} and [Id_Provincia] = {1}", anno, i.IdProvincia);

                SqlConnection c = new SqlConnection(_connString);
                c.Open();

                SqlCommand cmd = new SqlCommand(deleteQuery, c);
                SqlCommand cmd1 = new SqlCommand(insertQuery, c);

                cmd.ExecuteScalar();
                cmd1.ExecuteScalar();

                c.Close();
            }
            catch (Exception ex)
            {
                string ex1 = ex.Message;
                throw;
            }
            
        }

        internal void CheckProvinceExistence(System.Collections.ArrayList list)
        {
            ArrayList province = GetProvince();

            foreach (Impegno item in list)
            {
                CheckProvinciaPerImpegno(province, item);
            }


        }


        private void  CheckProvinciaPerImpegno(ArrayList province, Impegno impegno)
        {
            string p = impegno.Provincia;

            foreach (Provincia item in province)
            {
                if (p.Trim().ToUpper().Equals(item.Nome.Trim().ToUpper()))
                {
                    impegno.IdProvincia = item.Id;
                    impegno.Provincia = item.Nome;
                    impegno.IdRegione = item.IdRegione;
                    impegno.Regione = item.NomeRegione;
                    break;
                }
            }


        }


        private ArrayList GetProvince()
        {

            string query = "SELECT TB_PROVINCIE.ID AS Id_Provincia, TB_PROVINCIE.DESCRIZIONE AS NomeProvincia, TB_PROVINCIE.ID_TB_REGIONI AS Id_Regione, TB_REGIONI.DESCRIZIONE AS NomeRegione FROM TB_PROVINCIE INNER JOIN TB_REGIONI ON TB_PROVINCIE.ID_TB_REGIONI = TB_REGIONI.ID";




            ArrayList province = new ArrayList();

            SqlConnection c = new SqlConnection(_connString);
            c.Open();

            SqlCommand cmd = new SqlCommand(query, c);
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {

                int id = r.IsDBNull(0) ? -1 : (int)r.GetValue(0);
                string descrizione = r.IsDBNull(1) ? "" : (string)r.GetValue(1);
                int idRegione = r.IsDBNull(2) ? -1 : (int)r.GetValue(2);
                string descrizioneRegione = r.IsDBNull(3) ? "" : (string)r.GetValue(3);



                Provincia p = new Provincia();
                p.Id = id;
                p.Nome = descrizione;
                p.IdRegione = idRegione;
                p.NomeRegione = descrizioneRegione;


                province.Add(p);

            }
            r.Close();
            c.Close();

           
            return province;
        }

    }
}
