using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using System.ComponentModel;
using System.Collections;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class AbstractMovimentoContabile : AbstractPersistenceObject
    {
     
        //protected int _numeroQuote;
        //public int NumeroQuote
        //{
        //    get
        //    {
        //        return _numeroQuote;
        //    }
        //    set
        //    {
        //        _numeroQuote = value;
        //    }
        //}


        public static DateTime GetLastMovivimentoDate(IList movimenti)
        {
            if (movimenti == null)
                return DateTime.Now;

            if (movimenti.Count == 0)
                return DateTime.Now;

            DateTime result = DateTime.MinValue;

            foreach (AbstractMovimentoContabile item in movimenti)
            {
                if (item.Data > result)
                    result = item.Data;
            }

            return result;

        }

        protected Regione _regione;

        public Regione Regione
        {
            get
            {
                return _regione;
            }
            set
            {
                _regione = value;
            }
        }

        protected Provincia _provincia;

        public Provincia Provincia
        {
            get
            {
                return _provincia;
            }
            set
            {
                _provincia = value;
            }
        }

        protected DateTime _data;

        public DateTime Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        protected float _importo = 0;

        public float Importo
        {
            get
            {
                return _importo;
            }
            set
            {
                _importo = value;
            }
        }

        protected string _note = "";

        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        protected CausaleAmministrativa _causale;

        public CausaleAmministrativa Causale
        {
            get
            {
                return _causale;
            }
            set
            {
                _causale = value;
            }
        }


        protected int _competenza;
        public int Competenza
        {
            get
            {
                return _competenza;
            }
            set
            {
                _competenza = value;
            } 
        }

        protected override void DoValidation()
        {

            if (_regione == null)
                _regione = new RegioneNulla();
            if (_provincia == null)
                _provincia = new ProvinciaNulla();

            if (_data == DateTime.MinValue || _data == DateTime.MaxValue)
                ValidationErrors.Add("Data mancante");

            if (_regione.Descrizione == "" && _provincia.Descrizione  != "")
                ValidationErrors.Add("Regione non impostata");

            //if (_importo < 0)
            //    ValidationErrors.Add("Importo minore di 0");

        }


    }
}
