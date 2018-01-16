using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class ImpegnoHandler : SimpletHandler
    {

        private Tesseramento _tesseramento = null;

        public override string ObjectTypeName
        {
            get { return "Impegno"; }
        
        }

        public Tesseramento Tesseramento
        {
            get
            {
                return _tesseramento;
            }
        }

        


        public IList ImpegniTesseramento(int anno)
        {
            _tesseramento = null;

            Query q = _ps.CreateNewQuery("MapperImpegno");

            q.AddWhereClause(Criteria.Equal("Anno", anno.ToString()));

            IList impegni = q.Execute(_ps);


            _tesseramento = GetTesseramento(impegni, anno);


            return impegni;

        }

        private DOMAIN.Amministrazione.Tesseramento GetTesseramento(IList impegni,int anno)
        {
            TesseramentoHandler h = new TesseramentoHandler();


            Tesseramento t = h.GetCompleteTesseramentoByAnno(anno);

            if (t == null)
                t = new Tesseramento();


            //recupero il totale delle tesssere acquistate
            int totaleTessereRichiestaImpegni = GetTotale(impegni);

            t.TessereDaDistribuire = totaleTessereRichiestaImpegni;


            return t;

        }

        private int GetTotale(IList impegni)
        {
            int res = 0;
            foreach (Impegno item in impegni)
            {
                res = res + item.TessereRichieste;
            }

            return res;
        }

    }
}