using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class BookingPayment: AbstractPersistenceObject
    {
        private DateTime _accontData = DateTime.MinValue;
        private PaymentType _accountPaymentType;
        private float _accont;
 
        private float _total;

       private DateTime _restOfPaymentData;
       private float _restOfPayment;
       private PaymentType _restOfPaymentPaymentType;
       private float _stayTax;

       private IBooking _booking;


       private bool _accontSet = false;
       private bool _restOfPaymentSet = false;


       protected override void DoValidation()
       {
           if (_booking == null)
               ValidationErrors.Add("Prenotazione di riferimento mancante");

           if (_total <= 0)
               ValidationErrors.Add("Totale prenotazione mancante");


           if (_accont != 0)
           {
               if (_accontData == DateTime.MinValue)
                   ValidationErrors.Add("Data pagamento acconto mancante");
               if (_accountPaymentType == null)
                   ValidationErrors.Add("Modalità di pagamento acconto mancante");
           }
           else
               RemoveAccount();


           if (_restOfPayment != 0)
           {
               if (_restOfPaymentData == DateTime.MinValue)
                   ValidationErrors.Add("Data pagamento saldo mancante");
               if (_restOfPaymentPaymentType == null)
                   ValidationErrors.Add("Modalità di pagamento saldo mancante");
           }
           else
               RemoveRestOfPayment();



           if (_restOfPaymentSet)
               if (CheckTotal() == false)
                   ValidationErrors.Add("Totale non corretto correggere!");




       }

       public bool CheckTotal()
       {
           return GetTotal() == _total;

       }

       public float GetTotal()
       {
           return _restOfPayment + _accont;
       }

       private void RemoveRestOfPayment()
       {
           _restOfPaymentSet = false;
           _restOfPayment = 0;
           _restOfPaymentData = DateTime.MinValue;
           _restOfPaymentPaymentType = null;
       }

       private void RemoveAccount()
       {
           _accontSet = false;
           _accont = 0;
           _accontData = DateTime.MinValue;
           _accountPaymentType = null;
       }

       public void SetAccount(DateTime date, float account, PaymentType type)
       {
           if (account == 0)
           {
               RemoveAccount();
               return;
           }

           if (date == null)
               throw new ArgumentException("Data acconto mancante");
           if (account == 0)
               throw new ArgumentException("Acconto mancante");
           if (type == null)
               throw new ArgumentException("Modalità pagamento acconto mancante");
           _accontData = date;
           _accountPaymentType = type;
           _accont = account;
           _accontSet = true;

       }

       public bool AccountSet
       {

           get
           {

               return _accontSet;
           }
       }


       public bool RestOfPaymentSet
       {

           get
           {

               return _restOfPaymentSet;
           }
       }


       public DateTime AccontData
       {
           get
           {
               return _accontData;
           }
       }


        public float Accont
        {
            get
            {
                return _accont;
            }
        }

        public PaymentType AccountPaymentType
        {
            get
            {
                return _accountPaymentType;
            }
        }

        public float Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        
        public DateTime RestOfPaymentData
        {
            get
            {
                return _restOfPaymentData;
            }
        }
        public float ToPay
        {
            get
            {
                return _total - _accont - _restOfPayment;
            }
        }


        public float RestOfPayment
        {
            get
            {
                return _restOfPayment;
            }

        }

        public PaymentType RestOfPaymentPaymentType
        {
            get
            {
                return _restOfPaymentPaymentType;
            }
        }


        public void SetRestOfTypePayment(DateTime date, float restOfPayment, PaymentType type)
        {
            if (restOfPayment == 0)
            {
                RemoveRestOfPayment();
                return;
            }
            if (date == null)
                throw new ArgumentException("Data saldo mancante");
            if (restOfPayment == 0)
                throw new ArgumentException("Saldo mancante");
            if (type == null)
                throw new ArgumentException("Modalità pagamento saldo mancante");
            _restOfPaymentData = date;
            _restOfPayment = restOfPayment;
            _restOfPaymentPaymentType = type;
            _restOfPaymentSet = true;
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



        public float StayTax
        {
            get
            {
                return _stayTax;
            }
            set
            {
                _stayTax = value;
            }
        }


    }
}
