using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using System.Collections;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class Assignment: AbstractPersistenceObject
    {

        private DateTime _startDate = DateTime.Now .Date;
        private DateTime _endDate = DateTime.Now.Date;
        private string _notes = "";
        private BookingResource _resource = null;
        private IBooking _booking = null;
        private BedType _bedType = null;

        private IList _checkins = new ArrayList();

        public double TotalDays
        {
            get
            {
                try
                {
                    return (_endDate - _startDate).TotalDays;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public void AddCheckins(Checkin checkin)
        {
            if (checkin == null)
                throw new ArgumentException("Impossibile eseguire il checkin: checkin nullo");

            if (checkin.Customer == null)
                throw new ArgumentException("Impossibile eseguire il checkin: ospite nullo");

            if (checkin.Data  == DateTime.MinValue)
                throw new ArgumentException("Impossibile eseguire il checkin: Data nulla");

            CheckCustomer(checkin.Customer);

            
            checkin.Assignment = this;


            _checkins.Add(checkin);

            
        }


        public Checkin AddCheckins(DateTime date, Customer customer)
        {
            if (customer == null)
                throw new ArgumentException ("Impossibile eseguire il checkin: ospite nullo");

            if (date == DateTime .MinValue )
                throw new ArgumentException ("Impossibile eseguire il checkin: Data nulla");

            CheckCustomer(customer);

            Checkin c = new Checkin();
            c.Assignment = this;
            c.Data = date;
            c.Customer = customer;

            _checkins.Add(c);

            return c;
        }

        public void Removecheckin(Customer customer)
        {
            int j = -1;
            for (int i = 0; i < _checkins.Count ; i++)
            {
                if ((_checkins[i] as Checkin).Customer.Id == customer.Id)
                {
                    j = i;
                    break;
                }
            }

            if (j > -1)
                _checkins.RemoveAt(j);

        }

        private void CheckCustomer(Customer customer)
        {
            foreach (Checkin item in _checkins)
            {
                if (item.Customer.Id == customer.Id)
                {
                    throw new Exception("Ospite già aggiunto!");
                }
            }
        }

        public IList Checkins
        {
            get
            {
                return _checkins;
            }
        }

        public bool CheckedIn
        {
            get
            {
                return _checkins.Count > 0;
            }
        }

        public void SetCustomers(IList customers)
        {
            _checkins = customers;

        }


        public BedType BedType
        {
            get
            {
                return _bedType;
            }
            set
            {
                _bedType = value;
            }
        }


        public Assignment() { }

        public bool Overlaps(Assignment assignment)
        {
            if (assignment == null )
                throw new ArgumentException ("Invalid overlap test: assigment parameter is null");
            if (_resource == null )
                throw new Exception ("Invalid overlap test: resource is null");
               if (assignment.Resource  == null )
                throw new Exception ("Invalid overlap test: resource is null for the assigment parameter");
            if (this.Range.IsEmpty ())
                throw new Exception ("Invalid overlap test: datarange is empty");
            if (assignment.Range.IsEmpty ())
                throw new Exception ("Invalid overlap test: datarange is empty for the assigment parameter");

            if (_bedType == null)
                ValidationErrors.Add("Tipo letto non assegnato");

            if (this.Range.Overlaps(assignment.Range) && Resource.Id == assignment.Resource.Id)
            {
                if (this.Range.Finish == assignment.Range.Start || this.Range.Start == assignment.Range.Finish)
                    return false;
                else
                    return true;

            }
           

            return false;
        }
        public bool IsDayContained(DateTime date)
        {
            DateTime d = date.Date;

            if (d >= _startDate && d < _endDate)
                return true;

            return false;

        }

        internal DataRange Range
        {
            get
            {
                return new DataRange(_startDate.Date , _endDate.Date );
            }
        }


        public IBooking Booking
        {
            get
            {
                return _booking;
            }
            set
            {
                _booking = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _endDate.Date;
            }
            set
            {
                _endDate = value.Date;
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
            }
        }
        public BookingResource Resource
        {
            get
            {
                return _resource;
            }
            set
            {
                _resource = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return _startDate.Date;
            }
            set
            {
                _startDate = value.Date;
            }
        }


 
        public string Subject
        {
            get
            {
                return _booking.Notes;
            }
            set
            {
                //non fa nulla
            }
          
        }

        public BookingType BookingType
        {
            get
            {
                return _booking.BookingType;
            }
            set
            {
                //non fa nulla
            }

        }




        //public DateTime CheckOut
        //{
        //    get
        //    {
        //        return _endDate.Date.AddDays(1);
        //    }
            
        //}


        protected override void DoValidation()
        {
            if (_booking  == null)
                ValidationErrors.Add("Prenotazioner mancante per l'assegnazione");

            if (_resource == null)
                ValidationErrors.Add("Inserire una risorsa valida per l'assegnazione");


            if (_endDate == DateTime.MinValue || _endDate == DateTime.MaxValue)
                ValidationErrors.Add("Inserire una data fine valida per l'assegnazione");


            if (_startDate == DateTime.MinValue || _startDate == DateTime.MaxValue)
                ValidationErrors.Add("Inserire una data inizio valida per l'assegnazione");


            if (_startDate > _endDate)
                ValidationErrors.Add("Inserire un intervallo di tempo corretto per l'assegnazione");


            foreach (Checkin item in _checkins)
            {
                if (!item.IsValid())
                    ValidationErrors.Add(ItemErrors(item));
            }
        }

        private object ItemErrors(Checkin checkin)
        {
            StringBuilder b = new StringBuilder();
            foreach (string item in checkin.ValidationErrors)
            {
                b.AppendLine(item);
            }
            return b.ToString();
        }

        //necessario per il mapping con l'oggetto calendar
        private int _resourceId;
        public int ResourceId
        {
            get
            {
                return _resourceId;
            }
            set
            {
                _resourceId = value;
            }
        }





    }
}
