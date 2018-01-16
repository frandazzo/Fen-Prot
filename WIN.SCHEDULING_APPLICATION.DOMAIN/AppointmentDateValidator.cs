using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class AppointmentDateValidator
    {
        private DateTime _startDate;
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }




        public bool IsIntervalValid()
        {
            return _endDate >= _startDate;
        }

        public bool IsOnSameDay()
        {
            if (!IsIntervalValid())
                throw new Exception("Intervallo date non valido");
            return _endDate.Day != _startDate.Day;
        }

    }
}
