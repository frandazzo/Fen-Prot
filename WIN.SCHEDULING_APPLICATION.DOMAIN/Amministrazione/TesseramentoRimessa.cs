using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class TesseramentoRimessa : AbstractMovimentoContabile
    {
        protected override void DoValidation()
        {
            base.DoValidation();

            if (_regione.Descrizione == "" || _provincia.Descrizione == "")
                ValidationErrors.Add("Regione o Provincia mancanti per la rimessa");


            

        }
    }
}
