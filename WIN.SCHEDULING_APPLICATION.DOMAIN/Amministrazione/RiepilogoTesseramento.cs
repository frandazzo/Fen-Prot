using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class RiepilogoTesseramento : AbstractPersistenceObject
    {
        public int NumeroQuote { get; set; }

        public Regione Regione { get; set; }

        public Provincia Provincia { get; set; }

        public int TessereRichieste { get; set; }

        protected float _importoVersato = 0;

        public float ImportoVersato
        {
            get
            {
                return _importoVersato;
            }
            set
            {
                _importoVersato = value;
            }
        }

        protected float _totale = 0;

        public float Totale
        {
            get
            {
                return _totale;
            }
            set
            {
                _totale = value;
            }
        }

        protected float _daVersare = 0;

        public float DaVersare
        {
            get
            {
                return _daVersare;
            }
            set
            {
                _daVersare = value;
            }
        }
     

    }
}
