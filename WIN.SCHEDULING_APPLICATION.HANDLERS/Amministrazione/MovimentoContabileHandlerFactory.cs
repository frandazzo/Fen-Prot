using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class MovimentoContabileHandlerFactory
    {
        public static AbstractAmministrazioneHandler GetMovimentoHandler(TipoMovimernto type)
        {
            switch (type)
            {
                case TipoMovimernto.IncassoTesseramento:
                    return new IncassiTesseramentoHandler();

                case TipoMovimernto.PagamentoTesseramento:
                    return new PagamentiTesseramentoHandler();
                case TipoMovimernto.RimessaTesseramento:
                    return new RimesseTesseramentoHandler();
                case TipoMovimernto.Contribuzione:
                    return new ContributiHandler();
                case TipoMovimernto.Quac:
                    return new QuacHandler();
                default:
                    throw new InvalidProgramException();
            }
        }
    }
}
