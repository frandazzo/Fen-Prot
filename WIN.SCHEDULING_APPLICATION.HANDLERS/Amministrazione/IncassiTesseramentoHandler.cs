using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class IncassiTesseramentoHandler : AbstractAmministrazioneHandler 
    {
        public override string ObjectTypeName
        {
            get { return "TesseramentoIncasso"; }
        }
    }

}
