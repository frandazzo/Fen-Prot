using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData
{
    class ImportRimesse : abstractImporter
    {



        public ImportRimesse(string connectioonString, string inputDb)
            : base(connectioonString, inputDb)
        {
            _tableName = "[Versamenti quote provinciali]";
            _sqlTableName = "Amm_QuoteTesseramento";
        }


        

        protected override void DoImport(movimento item)
        {
            string query = String.Format("Insert into {0} (Data, Importo, Id_Provincia, NomeProvincia, Id_Regione, Nomeregione) values ('{1}',{2},{3},'{4}',{5},'{6}')", _sqlTableName, item.Data.ToShortDateString(),item.Importo.ToString().Replace(",","."), item.Localita.IdProvincia, item.Localita.Provincia.Replace("'","''"),item.Localita.IdRegione, item.Localita.Regione.Replace("'","''"));

            SqlConnection c = new SqlConnection(_sqlConnectionString);
            c.Open();

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.ExecuteScalar();

            c.Close();
        }

        protected override void DoLoadMovimenti(System.Data.IDataReader r, IList<movimento> movimenti)
        {
            movimento m = new movimento();
            string descrizioneProvincia = r.IsDBNull(2) ? "" : (string)r.GetValue(2);
            DateTime data = r.IsDBNull(3) ? DateTime.MinValue : (DateTime)r.GetValue(3);
            decimal importo = r.IsDBNull(4) ? 0 : (decimal)r.GetValue(4);
            int idCausale = 0;

            m.Causale = idCausale;
            m.Provincia = descrizioneProvincia;
            m.Data = data;
            m.Importo = importo;

            movimenti.Add(m);
        }

        protected override bool ValidateItem(movimento item)
        {
            Localita l = TransCodeGetter.GetLocalita(_sqlConnectionString, item.Provincia);
           

            if (l == null)
                return false;


            item.Localita = l;
            return true;
        }

        protected override void LogInvalidItem(movimento item, int anno, StringBuilder log)
        {
            string result = string.Format("Movimento non corretto! Provincia:{0}, Data:{1}, Importo:{2}", item.Provincia, item.Data.ToShortDateString(), item.Importo);

            log.AppendLine(result);

        }
    }
}
