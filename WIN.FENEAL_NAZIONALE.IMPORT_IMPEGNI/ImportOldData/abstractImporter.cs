using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData
{
   abstract class  abstractImporter 
    {
        protected StringBuilder _log;
        protected string _connStringAccessDB = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|;Persist Security Info=True";
       protected string _sqlConnectionString = "";
        protected  string _tableName = "";
       protected  string _sqlTableName = "";

        public string Log
        {
            get { return _log.ToString(); }
        }


        public abstractImporter(string connectioonString, string inputDb)
        {
            _sqlConnectionString = connectioonString;
            _connStringAccessDB = _connStringAccessDB.Replace("|DataDirectory|", inputDb);
            _log = new StringBuilder();
        }

        public void Import(int anno)
        {
            IList<movimento> list = GetDataFromAccessDB(anno);
            Import(list, anno);
        }

        protected void Import(IList<movimento> list, int anno)
        {
            
                if (list.Count == 0)
                {
                    _log.AppendLine("Nessun elemento importato poichè nessun elemento è stato trovato per i parametri immessi");
                    return;
                }

                try
                {
                    //per prima cosa elimino tutti i dati per l'anno selezionato
                    DeleteExistingData(anno);
                }
                catch (Exception ex)
                {
                    _log.AppendLine("Errore nell'eliminazione dei record per l'anno selezionato");
                    _log.AppendLine(ex.Message);
                    return;
                }
                
                foreach (movimento item in list)
                {
                    try
                    {
                        if (ValidateItem(item))
                            DoImport(item);
                        else
                            LogInvalidItem(item, anno,_log);
                    }
                    catch (Exception ex)
                    {
                        _log.AppendLine(ex.Message);
                    }
                }
        }

        protected abstract bool ValidateItem(movimento item);
      

        protected abstract void LogInvalidItem(movimento item,int anno, StringBuilder log);
        

        protected void DeleteExistingData(int anno)
        {
 	        string deleteQuery = String.Format("Delete from {0} where year(data) = {1}", _sqlTableName, anno);

            SqlConnection c = new SqlConnection(_sqlConnectionString);
            c.Open();

            SqlCommand cmd = new SqlCommand(deleteQuery, c);

            cmd.ExecuteScalar();

            c.Close();

        }

        protected abstract void DoImport(movimento item);
        

        protected  IList<movimento> GetDataFromAccessDB(int anno)
        {
            return Read(anno);
        }

        protected abstract void DoLoadMovimenti(System.Data.IDataReader reader, IList<movimento> movimenti);
           

        protected IList<movimento> Read(int anno)
        {
            
            string query = "SELECT * from " + _tableName + " where anno = " + anno.ToString();



            System.Data.OleDb.OleDbConnection c = new System.Data.OleDb.OleDbConnection(_connStringAccessDB);
            c.Open();
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, c);
            System.Data.OleDb.OleDbDataReader r = cmd.ExecuteReader();

            IList<movimento> movimenti = new List<movimento>();

            while (r.Read())
            {
                DoLoadMovimenti(r,movimenti);
            }

            r.Close();
            c.Close();

            return movimenti;
        }


        
    }
}
