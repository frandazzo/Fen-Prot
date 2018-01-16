using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class PagamentiTesseramentoHandler : AbstractAmministrazioneHandler
    {
        public override string ObjectTypeName
        {
            get { return "TesseramentoPagamento"; }
        }
    }
}