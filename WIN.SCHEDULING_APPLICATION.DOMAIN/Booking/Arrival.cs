using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class Arrival
    {
        private readonly Assignment _assignment;

        public Arrival(Assignment assignment)
        {
            _assignment= assignment;

        }

        public string Stanza
        {
            get
            {
                return _assignment.Resource.Descrizione;
            }
        }

        public double GiorniPermanenza
        {
            get
            {
                return _assignment.TotalDays;
            }
        }

        public string Letti
        {
            get
            {
                return _assignment.BedType.Descrizione;
            }
        }

        public string Nominativo
        {
            get
            {
                return _assignment.Booking.Notes;
            }
        }


        public string Note
        {
            get
            {
                return _assignment.Notes;
            }
        }

    }
}
