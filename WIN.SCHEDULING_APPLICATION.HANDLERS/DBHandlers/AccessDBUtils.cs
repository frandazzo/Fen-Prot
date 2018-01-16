using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;
using System.IO;
using System.Reflection;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.DBHandlers
{
    public class AccessDBUtils
    {


        public static void BackupDB()
        {
            DateTime now = DateTime.Now;


            string filename = DBName;

            string db = new FileInfo(filename).Name;

            string backPath = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "")).DirectoryName + "\\DBBack\\";

            if (!Directory.Exists(backPath))
            {
                Directory.CreateDirectory(backPath);
            }

            string backFileName = String.Format("{0}{1}_{2}_{3}_{4}", backPath, now.Year, now.Month, now.Day, db);


            File.Copy(filename, backFileName, true);

        }

        private static string DBName
        {
            get
            {
                string res = DataAccessServices.Instance().ConnectionString;
                string[] par = new string[] { ";" };
                string[] arr = res.Split(par, StringSplitOptions.None);

                foreach (string item in arr)
                {
                    if (item.StartsWith("Data Source="))
                    {
                        //rimuovo la scrittta source dal db
                        string d = item.Substring(12, item.Length - 12);
                        return d; ;
                    }
                    
                }

                return "";

            }
        }


        public static void CompactAccessDB()
        {

            string tempPath = Path.Combine(Path.GetTempPath(), "tempxxx.mdb");
            if (File.Exists(tempPath))
                File.Delete(tempPath);

            object[] oParams;

            //create an inctance of a Jet Replication Object
            object objJRO =
              Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));

            //filling Parameters array
            //cnahge "Jet OLEDB:Engine Type=5" to an appropriate value
            // or leave it as is if you db is JET4X format (access 2000,2002)
            //(yes, jetengine5 is for JET4X, no misprint here)
            oParams = new object[] {
        DataAccessServices.Instance().ConnectionString,
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + tempPath +
        ";Jet OLEDB:Engine Type=5"};

            //invoke a CompactDatabase method of a JRO object
            //pass Parameters array
            objJRO.GetType().InvokeMember("CompactDatabase",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                objJRO,
                oParams);

            //database is compacted now
            //to a new file C:\\tempdb.mdw
            //let's copy it over an old one and delete it

            System.IO.File.Delete(DBName);
            System.IO.File.Move(tempPath, DBName);

            //clean up (just in case)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
            objJRO = null;
        }
    }
}
