using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.localhost;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
    public class ExcelReader 
    {
       
        ExcelRecordReader r;
        ArrayList _data = new ArrayList ();

        public ExcelReader( string fileName, bool organizzative)
        {

            r = new ExcelRecordReader(fileName, organizzative);
            r.BeginParse += new WIN.BASEREUSE.BaseExcelReader.BeginParseEventHandler(r_BeginParse);
            r.BeginRetrieving += new WIN.BASEREUSE.BaseExcelReader.BeginRetrievingEventHandler(r_BeginRetrieving);
            r.EndParse += new WIN.BASEREUSE.BaseExcelReader.EndParseEventHandler(r_EndParse);
            r.EndRetrieving += new WIN.BASEREUSE.BaseExcelReader.EndRetrievingEventHandler(r_EndRetrieving);
            r.RetrievingRecord += new WIN.BASEREUSE.BaseExcelReader.RetrievingRecordEventHandler(r_RetrievingRecord);

        }


        #region IExportReader Membri di

        public List<IMPORT_IMPEGNI.localhost.OrganizativeRecord> ReadOrganizzativeData()
        {
            try
            {
                //Apro excel
                r.OpenExcel();
                //eseguo un parsing dei dati
                r.ParseData();
                //li recupero
                _data = r.RetrieveData();

                return CreateListaOrganizativeRecords();

            }
            finally
            {
                DisposeExcelApp();
            }
        }

        public List<IMPORT_IMPEGNI.localhost.AdministrativeRecord> ReadAdministrativeData()
        {
            try
            {
                //Apro excel
                r.OpenExcel();
                //eseguo un parsing dei dati
                r.ParseData();
                //li recupero
                _data = r.RetrieveData();

                return CreateListaAdministrativeRecords();

            }
            finally
            {
                DisposeExcelApp();
            }
        }

        private List<localhost.AdministrativeRecord> CreateListaAdministrativeRecords()
        {
            int i = 0;

            List<localhost.AdministrativeRecord> d = new List<localhost.AdministrativeRecord>();

            foreach (Hashtable item in _data)
            {
                AdministrativeRecord dto = CreateAdministrativeRecord(item);
                d.Add(dto);
                i++;
            }

            return d;
        }

        private AdministrativeRecord CreateAdministrativeRecord(Hashtable item)
        {
            AdministrativeRecord dto = new AdministrativeRecord();

            dto.Year = TryIntCast(item["ANNO"]);
            dto.Region = item["REGIONE"] as string;
            dto.Province = item["PROVINCIA"] as string;
            dto.Bilateral = item["ENTE BILATERALE"] as string;
            dto.SpecificBilateral = item["SOTTO ENTE"] as string;
            dto.Workers = TryIntCast(item["ADDETTI  ATTIVI"]);
            dto.Companies = TryIntCast(item["AZIENDE"]);
            dto.DeclaredSalary = TryIntCast(item["MONTE SALARI DENUNCIATO"]);
            dto.GivenSalary = TryIntCast(item["MONTE SALARI VERSATO"]);
            dto.QACN = TryIntCast(item["Importo Q.A.C.N."]);
            dto.QACR = TryIntCast(item["Importo Q.A.C.R."]);
            dto.QACP = TryIntCast(item["Importo Q.A.C.P."]);
            dto.DelegheAmount = TryIntCast(item["IMPORTO DELEGHE FeNEAL"]);
            dto.Pending = TryIntCast(item["SALDI E/O ARRETRATI VERSO FENEAL NAZ"]);
            
            return dto;
        }
        


        private List<localhost.OrganizativeRecord> CreateListaOrganizativeRecords()
        {
            int i = 0;

            List<localhost.OrganizativeRecord> d = new List<localhost.OrganizativeRecord>();

            foreach (Hashtable item in _data)
            {
                OrganizativeRecord dto = CreateOrganizativeRecord(item);
                d.Add(dto);
                i++;
            }

            return d;
        }

        private OrganizativeRecord CreateOrganizativeRecord(Hashtable item)
        {
            OrganizativeRecord dto = new OrganizativeRecord();

            dto.Year = TryIntCast(item["ANNO"]);
            dto.Region = item["REGIONE"] as string;
            dto.Province = item["PROVINCIA"] as string;
            dto.Bilateral = item["ENTE BILATERALE"] as string;
            dto.SpecificBilateral = item["SOTTOENTE"] as string;
            dto.TotalWorkers = TryIntCast(item["ADDETTI  ATTIVI"]);
            dto.TotalCompanies = TryIntCast(item["AZIENDE ATTIVE"]);
            dto.TotalSindacalizedWorkers = TryIntCast(item["TOT ISCRITTI O.O.S.S."]);
            dto.FenealWorkers = TryIntCast(item["FENEAL"]);
            dto.FilcaWorkers = TryIntCast(item["FILCA"]);
            dto.FilleaWorkers = TryIntCast(item["FILLEA"]);
            

            return dto;
        }

        

        //private Impegno CreateImpegno(Hashtable item, int rownumber)
        //{

        //    Impegno dto = new Impegno();

        //    //verifico i dati utente provenienti da excel
        //    if (item["Province"] == null) item["Province"] = "";
        //    if (item["Tessere"] == null) item["Tessere"] = "";
        //    if (item["Impegno"] == null) item["Impegno"] = "";
        //    if (item["Rate"] == null) item["Rate"] = "";
        //    if (item["gen"] == null) item["gen"] = "";
        //    if (item["feb"] == null) item["feb"] = "";
        //    if (item["mar"] == null) item["mar"] = "";
        //    if (item["apr"] == null) item["apr"] = "";
        //    if (item["mag"] == null) item["mag"] = "";
        //    if (item["giu"] == null) item["giu"] = "";
        //    if (item["lug"] == null) item["lug"] = "";
        //    if (item["ago"] == null) item["ago"] = "";
        //    if (item["set"] == null) item["set"] = "";
        //    if (item["ott"] == null) item["ott"] = "";
        //    if (item["nov"] == null) item["nov"] = "";
        //    if (item["dic"] == null) item["dic"] = "";

           
            
        //    dto.Tessere = TryIntCast(item["Tessere"].ToString());
        //    dto.ImpegnoTotale = TryDecimalCast(item["Impegno"].ToString());
        //   // dto.Rate = TryIntCast(item["Rate"].ToString());
        //    dto.Provincia = item["Province"].ToString();


        //    dto.gen = TryDecimalCast(item["gen"].ToString());
        //    dto.feb = TryDecimalCast(item["feb"].ToString());
        //    dto.mar = TryDecimalCast(item["mar"].ToString());
        //    dto.apr = TryDecimalCast(item["apr"].ToString());
        //    dto.mag = TryDecimalCast(item["mag"].ToString());
        //    dto.giu = TryDecimalCast(item["giu"].ToString());
        //    dto.lug = TryDecimalCast(item["lug"].ToString());
        //    dto.ago = TryDecimalCast(item["ago"].ToString());
        //    dto.set = TryDecimalCast(item["set"].ToString());
        //    dto.ott = TryDecimalCast(item["ott"].ToString());
        //    dto.nov = TryDecimalCast(item["nov"].ToString());
        //    dto.dic = TryDecimalCast(item["dic"].ToString());

         
        //    return dto;
        //}


        private DateTime TryDateCast(object o)
        {
            try
            {
                return Convert.ToDateTime(o);
            }
            catch (Exception)
            {
                return new DateTime(1900, 1, 1);
            }
        }



        private double  TryDoubleCast(object o)
        {
            try
            {
                return Convert.ToDouble(o);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        private int TryIntCast(object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void DisposeExcelApp()
        {
            try
            {
                r.Dispose();
            }
            catch (Exception)
            {
                //non fa nulla
            }
        }

        void r_RetrievingRecord(int IdRecord)
        {
           Trace.WriteLine("Recupero del record " + IdRecord.ToString());
        }

        void r_EndRetrieving(int NumberOfRecords)
        {
           Trace.WriteLine("Termine recupero dati file.");
        }

        void r_EndParse(int NumberOfRecords, int NumberOfFields)
        {
           Trace.WriteLine("Termine analisi formato file. Trovati " + NumberOfRecords.ToString () + " records");
        }

        void r_BeginRetrieving()
        {
           Trace.WriteLine("Iniziato recupero dati dal file");
        }

        void r_BeginParse()
        {
           Trace.WriteLine("Iniziata analisi formato file");
        }

        #endregion
    }
}

