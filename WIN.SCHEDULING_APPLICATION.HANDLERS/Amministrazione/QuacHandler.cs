using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class QuacHandler : AbstractAmministrazioneHandler
    {
        public override string ObjectTypeName
        {
            get { return "Quac"; }
        }



        public IList GetRiepilogoTesseramentoPrepProvincia(int anno, int id_causale, bool perProvincia, bool orderbyProvincia)
        {
            MapperQuac m = _ps.GetMapperByName("MapperQuac") as MapperQuac;

            return m.FindListaRiepiloghiQuac(anno, id_causale, perProvincia, orderbyProvincia);
        }


     

    }
}