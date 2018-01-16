using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class Checkin : AbstractPersistenceObject
    {
        private Customer _customer;
        private DateTime _data;
        private Assignment _assignment;


        public override string ToString()
        {
            if (_customer == null)
                return "";
            if (_data == DateTime.MinValue)
                return "";

            return string.Format("{0} ({1})",_customer.CompleteName, _data.ToShortDateString());
        }

        protected override void DoValidation()
        {

            if (_data == DateTime.MinValue)
                ValidationErrors.Add("Data checkin non impostata");

            if (_customer== null)
                ValidationErrors.Add("Ospite non impostato");

            if (_assignment  == null)
                ValidationErrors.Add("Assegnazione camera non impostata");
        }

        public Assignment Assignment
        {
            get
            {
                return _assignment;
            }
            set
            {
                _assignment = value;
            }
        }
        public DateTime Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }



        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }

    }
}
