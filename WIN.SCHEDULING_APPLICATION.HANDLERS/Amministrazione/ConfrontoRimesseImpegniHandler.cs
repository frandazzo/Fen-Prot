using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class ConfrontoRimesseImpegniHandler
    {

        public IList<ConfrontoRimessaImpegno> GetListaConfronti(int anno, int mese)
        {
            IList<ConfrontoRimessaImpegno> result = new List<ConfrontoRimessaImpegno>();
            //ottengo la lista degli impegni
            ImpegnoHandler h = new ImpegnoHandler();
            IList impegni = h.ImpegniTesseramento(anno);


            //ottengo la lista delle rimesse dell'anno
            RimesseTesseramentoHandler h1 = new RimesseTesseramentoHandler();
            MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(anno, null, null, null, true);

            IList<IsearchDTO> listDto = new List<IsearchDTO>();
            listDto.Add(dto);


            IList rimesse = h1.ExecuteQuery(listDto);
            //asdesso devo filtrare le rimesse e sul mese corretto
            IList filteredRimesse = FilterRimesse(anno, mese, rimesse);

            //adesso che ho ottenuto le rimesse e gli impegni in base al mese costruisco la lista dei confronti
            foreach (Impegno item in impegni)
            {
                ConfrontoRimessaImpegno c = new ConfrontoRimessaImpegno();
                c.Regione = item.Regione.Descrizione;
                c.RegioneId = item.Regione.Id;
                c.Provincia = item.Provincia.Descrizione;
                c.ImportoImpegno = item.GetImpegnoByMyNumMese(mese);

                result.Add(c);
            }

            //adesso devo valorizzare l'importo delle rimesse per il mese selezionato
            foreach (ConfrontoRimessaImpegno item in result)
            {
                double importo = GetTotalImportForProvincia(item.Provincia, filteredRimesse);
                item.ImportoRimessa = importo;
            }


            return result;

        }

        private double GetTotalImportForProvincia(string provincia, IList filteredRimesse)
        {
            //ottango la lista delle rimesse per quella provincia
            IList rimesse = GetRimesseForProvincia(provincia, filteredRimesse);

            double importo = 0;

            foreach (TesseramentoRimessa item in rimesse)
            {
                importo = importo + item.Importo;
            }

            return importo;
        }

        private IList GetRimesseForProvincia(string provincia, IList filteredRimesse)
        {
            IList r = new ArrayList();
            foreach (TesseramentoRimessa item in filteredRimesse)
            {
                if (item.Provincia.Descrizione.Equals(provincia))
                    r.Add(item);
            }


            return r;
        }

        private IList FilterRimesse(int anno, int mese, IList rimesse)
        {
            IList res = new ArrayList();

            foreach (TesseramentoRimessa item in rimesse)
            {
                //se il mese è minore = 12
                //devo verificare che la data della rimessa abbia lo stesso messe e lo stesso anno
                //altrimenti deve avere lo stesso mese e l'ann o piu un
                if (mese <= 12) {

                    if (item.Data.Month == mese && item.Data.Year == anno)
                        res.Add(item);

                }
                else if (mese >= 13 && mese <= 18)
                {
                    if (item.Data.Month == mese -12 && item.Data.Year == anno + 1)
                        res.Add(item);
                }


            }



            return res;
        }


        public IList<ConfrontoRimessaImpegno> GetListaConfrontiDaInizioAnno(int anno, int mese)
        {
            IList<ConfrontoRimessaImpegno> result = new List<ConfrontoRimessaImpegno>();
            //ottengo la lista degli impegni
            ImpegnoHandler h = new ImpegnoHandler();
            IList impegni = h.ImpegniTesseramento(anno);


            //ottengo la lista delle rimesse dell'anno
            RimesseTesseramentoHandler h1 = new RimesseTesseramentoHandler();
            MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(anno, null, null, null, true);

            IList<IsearchDTO> listDto = new List<IsearchDTO>();
            listDto.Add(dto);


            IList rimesse = h1.ExecuteQuery(listDto);
            //asdesso devo filtrare le rimesse e da inizio anno fino al mese corretto
            IList filteredRimesse = FilterRimesseUntinMonth(anno, mese, rimesse);

            //adesso che ho ottenuto le rimesse e gli impegni in base al mese costruisco la lista dei confronti
            foreach (Impegno item in impegni)
            {
                ConfrontoRimessaImpegno c = new ConfrontoRimessaImpegno();
                c.Regione = item.Regione.Descrizione;
                c.RegioneId = item.Regione.Id;
                c.Provincia = item.Provincia.Descrizione;
                c.ImportoImpegno = item.GetImpegnoUntilMese(mese);

                result.Add(c);
            }

            //adesso devo valorizzare l'importo delle rimesse per il mese selezionato
            foreach (ConfrontoRimessaImpegno item in result)
            {
                double importo = GetTotalImportForProvincia(item.Provincia, filteredRimesse);
                item.ImportoRimessa = importo;
            }


            return result;
        }

        private IList FilterRimesseUntinMonth(int anno, int mese, IList rimesse)
        {
            IList res = new ArrayList();

            foreach (TesseramentoRimessa item in rimesse)
            {
                //se il mese è minore = 12
                //devo verificare che la data della rimessa abbia lo stesso anno  e il mese minore o uguale a quello del parametro di input
                //altrimenti deve avere lo stesso mese e l'ann o piu un
                if (mese <= 12)
                {

                    if (item.Data.Month <= mese && item.Data.Year == anno)
                        res.Add(item);

                }
                else if (mese >= 13 && mese <= 18)
                {
                    if ((item.Data.Month <= mese - 12 && item.Data.Year == anno + 1) || item.Data.Year == anno)
                        res.Add(item);
                }


            }



            return res;
        }
    }
}
