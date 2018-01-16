using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using System.ComponentModel;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class TesseramentoHandler : SimpletHandler
    {
        public override string ObjectTypeName
        {
            get { return "Tesseramento"; }
        }


        public  IBindingList GetAllAsBinbingList()
        {
            IList ll =  _ps.GetAllObjects(ObjectTypeName);

            IBindingList res = new BindingList<Tesseramento>();

            //creo la binding list
            foreach (Tesseramento item in ll)
            {
                res.Add(item);
            }

            return res;
        }


        public Tesseramento GetCompleteTesseramentoByAnno(int anno)
        {
            Query q = _ps.CreateNewQuery("MapperTesseramento");

            q.AddWhereClause(Criteria.Equal("Anno", anno.ToString()));


            IList l = q.Execute(_ps);


            if (l.Count != 1)
                return null;

            //recupero il tesseramento
            Tesseramento t = l[0] as Tesseramento;

            //lo valorizzo con il versato  da perte delle strutture territoriali
            FillTesseramentoData(t, anno);


           


            return t;
        }

        private void FillTesseramentoData(Tesseramento t, int anno)
        {
            //recupero i dati sul riepilogo del tesseramento
            RiepilogoTesseramentoHandler h = new RiepilogoTesseramentoHandler();

            IList riepilighi = h.GetRiepilogoTesseramento(anno);

            float totaleVersato = GetTotaleVersato(riepilighi);
            float totaleDaVersare = GetTotaleDaVersare(riepilighi);

            t.TotaleSommeVersate = totaleVersato;
            t.Residuo = totaleDaVersare;

            //Recupero i dati sui pagamenti alla UIL
            float pag = GetTotalePagamenti(anno);
            t.TotalePagamenti = pag;

        }

        private float GetTotalePagamenti(int anno)
        {
            string query = "select sum(Importo) as importo from amm_pagamentitesseramento where year(Data) = {0} group by year(Data)";



            object result = _ps.ExecuteScalar(string.Format(query,anno));


            float p = TryParseResult(result);

            return p;
        }

        private float TryParseResult(object result)
        {
            try
            {
                return (float)System.Convert.ToDecimal(result);
            }
            catch (Exception)
            {
                return 0;
            }
        }



        private float GetTotaleDaVersare(IList riepilighi)
        {
            float res = 0;

            foreach (RiepilogoTesseramento  item in riepilighi)
            {
                res = res + item.DaVersare;
            }

            return res;
        }

        private float GetTotaleVersato(IList riepilighi)
        {
            float res = 0;

            foreach (RiepilogoTesseramento item in riepilighi)
            {
                res = res + item.ImportoVersato;
            }

            return res;
        }



    }



}