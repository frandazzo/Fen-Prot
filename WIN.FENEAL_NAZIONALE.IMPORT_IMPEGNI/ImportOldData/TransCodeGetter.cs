using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData
{
    class TransCodeGetter
    {
        public static Localita GetLocalita(string connectionString, string nomeProvincia)
        {
            if (string.IsNullOrEmpty(nomeProvincia))
                return null;

            string query = String.Format("SELECT TB_PROVINCIE.ID AS idProvincia, TB_PROVINCIE.DESCRIZIONE AS NomeProvincia, TB_PROVINCIE.ID_TB_REGIONI AS IdRegione,  TB_REGIONI.DESCRIZIONE AS nomeRegione FROM TB_PROVINCIE INNER JOIN TB_REGIONI ON TB_PROVINCIE.ID_TB_REGIONI = TB_REGIONI.ID WHERE (TB_PROVINCIE.DESCRIZIONE = '{0}')", nomeProvincia.Replace("'", "''"));


            Localita l = null;

            SqlConnection c = new SqlConnection(connectionString);
            c.Open();

            SqlCommand cmd = new SqlCommand(query, c);

            SqlDataReader rr = cmd.ExecuteReader();

            while (rr.Read())
            {
                l = new Localita();
                l.IdProvincia = rr.GetInt32(0);
                l.Provincia = rr.GetString(1);
                l.IdRegione = rr.GetInt32(2);
                l.Regione = rr.GetString(3);
            }

            rr.Close();
            c.Close();

            return l;
        }

        public static Causale GetCausale(string connectionString, string nomeCausale)
        {
            if (string.IsNullOrEmpty(nomeCausale))
                return null;

            string query = String.Format("SELECT  * from Amm_CausaliAmministrazione WHERE (DESCRIZIONE = '{0}' and TipoCausale = 4)", nomeCausale.Replace("'", "''"));


            Causale l = null;

            SqlConnection c = new SqlConnection(connectionString);
            c.Open();

            SqlCommand cmd = new SqlCommand(query, c);

            SqlDataReader rr = cmd.ExecuteReader();

            while (rr.Read())
            {
                l = new Causale();
                l.IdCausale = rr.GetInt32(0);
                l.CausaleDesc = rr.GetString(1);
               
            }

            rr.Close();
            c.Close();

            return l;

        }

    }
}
