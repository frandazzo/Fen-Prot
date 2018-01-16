using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class BedType : SimpleComboElement
    {
        private int _NumeroLetti = 1;
        public int NumeroLetti
        {
            get
            {
                return _NumeroLetti;
            }
            set
            {
                _NumeroLetti = value;
            }
        }

        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty (this.Descrizione ))
                ValidationErrors.Add("Descrizione mancante");
            if (_NumeroLetti <= 0 )
            ValidationErrors.Add ("Il numeor di letti deve essere maggiore di zero");
        }

    }
}
