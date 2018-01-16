using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class RiepilogoTesseramentoHandler
    {

        IPersistenceFacade _ps = DataAccessServices.Instance().PersistenceFacade;

        public IList GetRiepilogoTesseramento(int anno)
        {
            

            RiepilogoTesseramentoMapper m = _ps.GetMapperByName("RiepilogoTesseramentoMapper") as RiepilogoTesseramentoMapper;



            return m.FindListaRiepiloghiPerAnno(anno);
        }


        public IList GetRiepilogoTesseramento(int anno, int id_provincia)
        {
            RiepilogoTesseramentoMapper m = _ps.GetMapperByName("RiepilogoTesseramentoMapper") as RiepilogoTesseramentoMapper;



            return m.FindListaRiepiloghiPerAnnoProvincia(anno, id_provincia);
        }




    }
}
