using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class Contributo : AbstractMovimentoContabile
    {
        protected override void DoValidation()
        {
            base.DoValidation();

            if (_causale == null)
                ValidationErrors.Add("Causale movimento mancante");

            if (_regione.Descrizione == "" && _provincia.Descrizione == "")
                ValidationErrors.Add("Regione o Provincia mancanti per il contributo");

        }
    }
}
