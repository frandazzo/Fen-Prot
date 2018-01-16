using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class Booking: AbstractPersistenceObject, WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.IBooking
    {

        private DateTime _date = DateTime.Now ;
        private System.Collections.IList _assignments = new ArrayList();
        private string _notes = "";
        private string _notes1 = "";
        public string Notes1
        {
            get
            {
                return _notes1;
            }
            set
            {
                _notes1 = value;
            }
        }

        public string StateToString
        {
            get
            {
                switch (State)
                {
                    case BookingState.NotConfirmed:
                        return "NotConfirmed";
                    case BookingState.ConfirmedWithAccont:
                        return "ConfirmedWithAccont";
                    case BookingState.ConfimedWithoutAccount:
                        return "ConfimedWithoutAccount";
                    case BookingState.Closed:
                        return "Closed";
                    default:
                        return "";
                }
            }


        }

        private Operator _operator;
        private int _color;
        private bool _colorBookings;
        private bool _confirmed;
        private BookingPayment _payment;

        public void SetStayTax(float tax)
        {
            if (!_confirmed)
                throw new Exception("Impossibile impostare un pagamento per una prenotazione non confermata");
           
            //sono sicuro che il pagamento esiste
            if (_payment == null)
                throw new Exception("Pagamento nullo nonostante prenotazione confermata. Contattare la Noesis per la risoluzione del bug");

            _payment.StayTax = tax;


        }

         public void SetTotal(float total)
        {
            if (!_confirmed)
                throw new Exception("Impossibile impostare un pagamento per una prenotazione non confermata");
           
            //sono sicuro che il pagamento esiste
            if (_payment == null)
                throw new Exception("Pagamento nullo nonostante prenotazione confermata. Contattare la Noesis per la risoluzione del bug");

            if (total == 0)
                throw new ArgumentException("Totale mancante");


            _payment.Total = total;


        }

        public void SetAccount(DateTime date, float account, PaymentType type)
        {
            if (!_confirmed)
                throw new Exception("Impossibile impostare un pagamento per una prenotazione non confermata");

            //sono sicuro che il pagamento esiste
            if (_payment == null)
                throw new Exception("Pagamento nullo nonostante prenotazione confermata. Contattare la Noesis per la risoluzione del bug");

            _payment.SetAccount(date,account , type);

        }

        public void SetRestOfTypePayment(DateTime date, float restOfPayment, PaymentType type)
        {
            if (!_confirmed)
                throw new Exception("Impossibile impostare un pagamento per una prenotazione non confermata");

            //sono sicuro che il pagamento esiste
            if (_payment == null)
                throw new Exception("Pagamento nullo nonostante prenotazione confermata. Contattare la Noesis per la risoluzione del bug");

            _payment.SetRestOfTypePayment(date, restOfPayment, type);
        }



        protected override void DoValidation()
        {
            if (_bookingType == null)
                ValidationErrors.Add("Tipo prenotazione mancante");

            if (_color == 0)
                ValidationErrors.Add("Colore prenotazione mancante");

            if (_confirmed)
                if (_payment == null)
                    ValidationErrors.Add("Pagamento mancante");

            if (!_confirmed)
                UnConfirmBooking();

        }



        private BookingType _bookingType;

        public BookingType BookingType
        {
            get
            {
                return _bookingType;
            }
            set
            {
                _bookingType = value;
            }
        }

    

        public IList Assignments
        {
            get { return _assignments; }
            set { _assignments = value; }
        }



        public void AddAssignment(Assignment assignment)
        {
            foreach (Assignment item in _assignments)
            {
                if (assignment.Overlaps(item))
                    throw new Exception("L'assegnazione si sovrappone ad un'altra già esistente");

            }
                   

            assignment.Booking = this;
            _assignments.Add(assignment);
        }

        public void RemoveAssignment(Assignment assignment)
        {
            if (assignment == null)
                return;
            if (assignment.Key == null)
            {
                assignment.Booking = null;
                _assignments.Remove (assignment );
            }
           

            for (int i = 0; i < _assignments.Count ; i++)
			{
                Assignment item = _assignments[i] as Assignment ;
                if (item.Key != null)
                    if (item.Id == assignment.Id)
                    {
                        assignment.Booking = null;
                        _assignments.RemoveAt(i);
                        return;
                    }
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

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }




        public AbstractPersistenceObject BaseObject
        {
            get { return this; }
        }



        public ComboElements.Operator Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                _operator = value;
            }
        }


    

        public int Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

     

        public bool ColorBookings
        {
            get
            {
                return _colorBookings; ;
            }
            set
            {
                _colorBookings = value;
            }
        }


        public void ConfirmBooking()
        {
            if (_confirmed)
                return;

            _confirmed = true;
            _payment = new BookingPayment();
            _payment.Booking = this;
        }

        public void UnConfirmBooking()
        {
            _confirmed = false;
            _payment = null;
        }



        public bool Confirmed
        {
            get
            {
                return _confirmed;
            }
        }


        public BookingPayment Payment
        {
            get
            {
                return _payment;
            }
            set
            {
                _payment = value;
            }
        }

        public BookingState State
        {
            get 
            {
                if (!_confirmed)
                    return BookingState.NotConfirmed;

                if (_payment.RestOfPaymentSet)
                    return BookingState.Closed;

               
                if (_payment.AccountSet)
                    return BookingState.ConfirmedWithAccont;
                else
                    return BookingState.ConfimedWithoutAccount;
                

            }

        }


      
    }
}
