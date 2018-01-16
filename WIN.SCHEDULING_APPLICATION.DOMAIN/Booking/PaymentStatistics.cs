using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class PaymentStatistics : AbstractPersistenceObject
    {
        public float  Incasso { get; set; }
        public float DaIncassare { get; set; }
        public int Anno { get; set; }
        public string Mese { get; set; }
        public IBooking Booking { get; set; }


        public string Operatore
        {
            get
            {
                if (Booking == null)
                    return "";
                if (Booking.Operator == null)
                    return "";
                return Booking.Operator.Descrizione;
            }

        }


        public string TipoPrenotazione
        {
            get
            {
                if (Booking == null)
                    return "";
                
                return Booking.BookingType.Descrizione;
            }

        }


    }
}
