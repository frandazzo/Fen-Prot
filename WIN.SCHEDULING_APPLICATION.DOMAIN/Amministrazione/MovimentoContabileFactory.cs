using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class MovimentoContabileFactory
    {
        public static AbstractMovimentoContabile GetMovimento(TipoMovimernto type)
        {
            switch (type)
            {
                case TipoMovimernto.IncassoTesseramento:
                    return new TesseramentoIncasso();

                case TipoMovimernto.PagamentoTesseramento:
                    return new TesseramentoPagamento();
                case TipoMovimernto.RimessaTesseramento:
                    return new TesseramentoRimessa ();
                case TipoMovimernto.Contribuzione:
                    return new Contributo();
                case TipoMovimernto.Quac:
                    return new Quac();
                default:
                    throw new InvalidProgramException();
            }
        }
    }
}
