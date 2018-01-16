using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class Tesseramento : AbstractPersistenceObject
    {
        public int TessereNonDistribuite
        {
            get
            {
                return TesseraAcquistate - TessereDaDistribuire;
            }
        }


        public int TessereDaDistribuire { get; set; }
        public float TotaleValoreTessereNonDistribuite
        {
            get
            {
                return TessereNonDistribuite * this.CostoTessera;
            }
        }
        public int Anno { get; set; }
        public int TesseraAcquistate { get; set; }
        public float CostoTessera { get; set; }
        public float QuotaUIL { get; set; }

        public float CostoTessere
        {
            get
            {
                return TesseraAcquistate * CostoTessera;
            }
           
        }

        public float TotaleSommeVersate { get; set; }
        public float TotalePagamenti { get; set; }

        public float Residuo { get; set; }

        protected override void DoValidation()
        {
            if (Anno < 0)
                ValidationErrors.Add("Anno non corretto");

            if (TesseraAcquistate < 0)
                ValidationErrors.Add("Numero tessere acquistate non corretto");

            if (CostoTessera < 0)
                ValidationErrors.Add("Costo tessera non corretto");

            if (QuotaUIL < 0)
                ValidationErrors.Add("Quota UIL non corretta");
        }

    }
}
