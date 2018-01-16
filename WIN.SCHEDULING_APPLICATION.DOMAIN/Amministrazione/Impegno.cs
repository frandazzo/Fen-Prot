using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class Impegno : AbstractPersistenceObject
    {
        public Impegno()
        {
            
        }

        private Regione _regione;
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
        private Provincia _provincia;
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


        private int _tessereRichieste;
        public int TessereRichieste
        {
            get
            {
                return _tessereRichieste;
            }
            set
            {
                _tessereRichieste = value;
            }
        } 
        
        public decimal ImpegnoTotale { get; set; }

        public int Anno { get; set; }

        public float GetImpegnoByMyNumMese(int mese)
        {
            if (mese == 1)
                return (float)gen;
            else if (mese == 2)
                return (float)feb;
            else if (mese == 3)
                return (float)mar;
            else if (mese == 4)
                return (float)apr;
            else if (mese == 5)
                return (float)mag;
            else if (mese == 6)
                return (float)giu;
            else if (mese == 7)
                return (float)lug;
            else if (mese == 8)
                return (float)ago;
            else if (mese == 9)
                return (float)set;
            else if (mese == 10)
                return (float)ott;
            else if (mese == 11)
                return (float)nov;
            else if (mese == 12)
                return (float)dic;
            else if (mese == 13)
                return (float)genas;
            else if (mese == 14)
                return (float)febas;
            else if (mese == 15)
                return (float)maras;
            else if (mese == 16)
                return (float)apras;
            else if (mese == 17)
                return (float)magas;
            else
                return (float)giuas;
 


        }

        public float GetImpegnoUntilMese(int mese)
        {
            if (mese == 1)
                return (float)gen;
            else if (mese == 2)
                return (float)(gen + feb);
            else if (mese == 3)
                return (float)(gen + feb + mar);
            else if (mese == 4)
                return (float)(gen + feb + mar + apr);
            else if (mese == 5)
                return (float)(gen + feb + mar + apr + mag);
            else if (mese == 6)
                return (float)(gen + feb + mar + apr + mag + giu);
            else if (mese == 7)
                return (float)(gen + feb + mar + apr + mag + giu + lug);
            else if (mese == 8)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago);
            else if (mese == 9)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set);
            else if (mese == 10)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott);
            else if (mese == 11)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov);
            else if (mese == 12)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic);
            else if (mese == 13)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas);
            else if (mese == 14)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas + febas);
            else if (mese == 15)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas + febas + maras);
            else if (mese == 16)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas + febas + maras + apras);
            else if (mese == 17)
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas + febas + maras + apras + magas);
            else
                return (float)(gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas + febas + maras + apras + magas + giuas);



        }



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

        public decimal genas { get; set; }
        public decimal febas { get; set; }
        public decimal maras { get; set; }
        public decimal apras { get; set; }
        public decimal magas { get; set; }
        public decimal giuas { get; set; }

        public decimal altreDate { get; set; }


        public decimal ImpegnoCalcolato
        {
            get { return gen + feb + mar + apr + mag + giu + lug + ago + set + ott + nov + dic + genas + febas + maras + apras + magas + giuas; }
        }

        public int Rate
        {
            get
            {
                int res = 0;

                if (gen > 0) res++;
                if (feb > 0) res++;
                if (mar > 0) res++;
                if (apr > 0) res++;
                if (mag > 0) res++;
                if (giu > 0) res++;
                if (lug > 0) res++;
                if (ago > 0) res++;
                if (set > 0) res++;
                if (ott > 0) res++;
                if (nov > 0) res++;
                if (dic > 0) res++;
                if (genas > 0) res++;
                if (febas > 0) res++;
                if (maras > 0) res++;
                if (apras > 0) res++;
                if (magas > 0) res++;
                if (giuas > 0) res++;


                return res;
            }
        }


        protected override void DoValidation()
        {
            if (_provincia.Descrizione == "" || _regione.Descrizione == "")
                ValidationErrors.Add("Provincia o regione non impostati");
            if (_tessereRichieste < 0)
                ValidationErrors.Add("Tessere richieste non specificate");

            if (Anno < 0)
                ValidationErrors.Add("Anno non corretto");
        }
    }
}
