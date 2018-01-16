using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
    public class Impegno
    {
        public Impegno()
        {
            IdProvincia = -1;
        }

        public int IdProvincia { get; set; }
        public string Provincia { get; set; }


        //dati regione ****
        public int IdRegione { get; set; }
        public string Regione { get; set; }
      

   //     public int Rate { get; set; }


        public decimal gen { get; set; }
        public decimal feb { get; set; }
        public decimal mar { get; set; }
        public decimal apr { get; set; }
        public decimal mag { get; set; }
        public decimal giu { get; set; }
        public decimal lug { get; set; }
        public decimal ago { get; set; }
        public decimal set { get; set; }
        public decimal ott { get; set; }
        public decimal nov { get; set; }
        public decimal dic { get; set; }
        //altre date per l'impegno ****
        public decimal altreDate { get; set; }
        //totale dell'impegno
        public decimal ImpegnoTotale { get; set; }
        //tessere richieste
        public int Tessere { get; set; }
        //anno****
        public int Anno { get; set; }
    }
}
