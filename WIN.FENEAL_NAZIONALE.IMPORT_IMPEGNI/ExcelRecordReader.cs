using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
  public class ExcelRecordReader : WIN.BASEREUSE.BaseExcelReader
    {
      private bool _organizzative;

      //private const string Province = "Province";
      //private const string Tessere = "Tessere";
      //private const string Impegno = "Impegno";
      //private const string Rate = "Rate";
      //private const string gen = "gen";
      //private const string feb = "feb";
      //private const string mar = "mar";
      //private const string apr = "apr";
      //private const string mag = "mag";
      //private const string giu = "giu";
      //private const string lug = "lug";
      //private const string ago = "ago";
      //private const string set = "set";
      //private const string ott = "ott";
      //private const string nov = "nov";
      //private const string dic = "dic";


   




        public override void ParseImportFile()
        {

            StringBuilder s = new StringBuilder();

            if (_organizzative)
            {
                //Campi Utente
                if (!FindField("ANNO"))
                    s.AppendLine("Formato file non valido: " + "ANNO");
                if (!FindField("REGIONE"))
                    s.AppendLine("Formato file non valido: " + "REGIONE");
                if (!FindField("PROVINCIA"))
                    s.AppendLine("Formato file non valido: " + "PROVINCIA");
                if (!FindField("ENTE BILATERALE"))
                    s.AppendLine("Formato file non valido: " + "ENTE BILATERALE");

                if (!FindField("SOTTOENTE"))
                    s.AppendLine("Formato file non valido: " + "SOTTOENTE");

                if (!FindField("ADDETTI  ATTIVI"))
                    s.AppendLine("Formato file non valido: " + "ADDETTI  ATTIVI");

                if (!FindField("AZIENDE ATTIVE"))
                    s.AppendLine("Formato file non valido: " + "AZIENDE ATTIVE");

                if (!FindField("TOT ISCRITTI O.O.S.S."))
                    s.AppendLine("Formato file non valido: " + "TOT ISCRITTI O.O.S.S.");

                if (!FindField("FENEAL"))
                    s.AppendLine("Formato file non valido: " + "FENEAL");

                if (!FindField("FILCA"))
                    s.AppendLine("Formato file non valido: " + "FILCA");

                if (!FindField("FILLEA"))
                    s.AppendLine("Formato file non valido: " + "FILLEA");


            }
            else {
                if (!FindField("ANNO"))
                    s.AppendLine("Formato file non valido: " + "ANNO");
                if (!FindField("REGIONE"))
                    s.AppendLine("Formato file non valido: " + "REGIONE");
                if (!FindField("PROVINCIA"))
                    s.AppendLine("Formato file non valido: " + "PROVINCIA");
                if (!FindField("ENTE BILATERALE"))
                    s.AppendLine("Formato file non valido: " + "ENTE BILATERALE");

                if (!FindField("SOTTO ENTE"))
                    s.AppendLine("Formato file non valido: " + "SOTTO ENTE");

                if (!FindField("ADDETTI  ATTIVI"))
                    s.AppendLine("Formato file non valido: " + "ADDETTI  ATTIVI");

                if (!FindField("AZIENDE"))
                    s.AppendLine("Formato file non valido: " + "AZIENDE");

                if (!FindField("MONTE SALARI DENUNCIATO"))
                    s.AppendLine("Formato file non valido: " + "MONTE SALARI DENUNCIATO");

                if (!FindField("MONTE SALARI VERSATO"))
                    s.AppendLine("Formato file non valido: " + "MONTE SALARI VERSATO");

                if (!FindField("Importo Q.A.C.N."))
                    s.AppendLine("Formato file non valido: " + "Importo Q.A.C.N.");

                if (!FindField("Importo Q.A.C.R."))
                    s.AppendLine("Formato file non valido: " + "Importo Q.A.C.R.");

              
                if (!FindField("Importo Q.A.C.P."))
                    s.AppendLine("Formato file non valido: " + "Importo Q.A.C.P.");

                if (!FindField("IMPORTO DELEGHE FeNEAL"))
                    s.AppendLine("Formato file non valido: " + "IMPORTO DELEGHE FeNEAL");


                if (!FindField("SALDI E/O ARRETRATI VERSO FENEAL NAZ"))
                    s.AppendLine("Formato file non valido: " + "SALDI E/O ARRETRATI VERSO FENEAL NAZ");

            
            }
            

           


            if (!string.IsNullOrEmpty (s.ToString ()))
                throw new Exception(s.ToString());
    
        }
        
        public ExcelRecordReader(string fileName, bool orgauizzative)
        {
            base.m_Filename = fileName;
            _organizzative = orgauizzative;
        }




    }
}
