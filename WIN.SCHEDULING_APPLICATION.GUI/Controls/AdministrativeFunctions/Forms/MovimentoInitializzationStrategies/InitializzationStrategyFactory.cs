using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.MovimentoInitializzationStrategies
{
    public class InitializzationStrategyFactory
    {
        public static IInitializzationStrategy GetInitializator(TipoMovimernto type)
        {
            switch (type)
            {
                case TipoMovimernto.IncassoTesseramento:
                    return new InitializeIncassiTesseramentoStrategy();
                    
                case TipoMovimernto.PagamentoTesseramento:
                    return new InitializePagamentiTesseramentoStrategy();
                case TipoMovimernto.RimessaTesseramento:
                    return new InitializeRimesseTesseramentoStrategy();
                case TipoMovimernto.Contribuzione:
                    return new InitializeContributoStrategy();
                case TipoMovimernto.Quac:
                    return new InitializeQuacStrategy();
                default:
                    throw new InvalidProgramException();
            }
        }

    }
}
