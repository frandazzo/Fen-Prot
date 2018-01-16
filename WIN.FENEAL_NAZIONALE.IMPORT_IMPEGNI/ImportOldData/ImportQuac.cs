using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData
{
    class ImportQuac : abstractImporter
    {

        public ImportQuac(string connectioonString, string inputDb):base(connectioonString,inputDb)
        {
            _tableName = "[Riepilogo generale]";
            _sqlTableName = "Amm_Quac";
        }



        protected override void DoImport(movimento item)
        {
            string query = String.Format("Insert into {0} (Data, Importo, Id_Provincia, NomeProvincia, Id_Regione, Nomeregione, Id_CausaleAmministrazione) values ('{1}',{2},{3},'{4}',{5},'{6}',{7})", _sqlTableName, item.Data.ToShortDateString(), item.Importo.ToString().Replace(",", "."), item.Localita.IdProvincia, item.Localita.Provincia.Replace("'", "''"), item.Localita.IdRegione, item.Localita.Regione.Replace("'", "''"), item.CausaleAmministrativa.IdCausale);

            SqlConnection c = new SqlConnection(_sqlConnectionString);
            c.Open();

            SqlCommand cmd = new SqlCommand(query, c);

            cmd.ExecuteScalar();

            c.Close();


        }

        protected override void DoLoadMovimenti(System.Data.IDataReader r, IList<movimento> movimenti)
        {
            movimento m = new movimento();
            //    int id = r.IsDBNull(0) ? -1 : (int)r.GetValue(0);
            string descrizioneProvincia = r.IsDBNull(1) ? "" : (string)r.GetValue(1);
            int idCausale = r.IsDBNull(2) ? -1 : Convert.ToInt32(r.GetValue(2));
            DateTime data = r.IsDBNull(3) ? DateTime.MinValue :(DateTime)r.GetValue(3);
            decimal importo = r.IsDBNull(4) ? 0 : (decimal)r.GetValue(4);

            m.Causale = idCausale;
            m.Provincia = descrizioneProvincia;
            m.Data = data;
            m.Importo = importo;

            movimenti.Add(m);
        }

        protected override bool ValidateItem(movimento item)
        {
            
                Localita l = TransCodeGetter.GetLocalita(_sqlConnectionString, item.Provincia);
                Causale c = TransCodeGetter.GetCausale(_sqlConnectionString, item.DescrizioneCausale);


                if (l == null)
                    return false;

                if (c == null)
                    return false;



                item.Localita = l;
                item.CausaleAmministrativa = c;
                return true;
            
        }

        protected override void LogInvalidItem(movimento item, int anno, StringBuilder log)
        {
            string result = string.Format("Movimento non corretto! Provincia:{0}, Causale:{1}, Data:{2}, Importo:{3}", item.Provincia, item.Causale, item.Data.ToShortDateString(), item.Importo);

            log.AppendLine(result);

        }
    }
}
