using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class BookingStatistics : AbstractPersistenceObject
    {
        public string Stanza { get; set; }
        public int Vendite { get; set; }
        public string Mese { get; set; }
        public int Anno { get; set; }
        public string Tipo { get; set; }
        private int _GiornateMese = 30;
        public int GiornateMese
        {
            get
            {
                return _GiornateMese;
            }
            set
            {
                _GiornateMese = value;
            }
        }
        
        public double PercentualeCopertura
        {
            get
            {
                return (double)Vendite / (double )GiornateMese ;
            }
        
        }


    }
}
