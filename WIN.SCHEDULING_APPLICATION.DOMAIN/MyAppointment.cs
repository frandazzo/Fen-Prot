using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class MyAppointment : AbstractPersistenceObject
    {
        private int _daysAfterDeadline;
        private int _daysBeforeDeadline;
        private AppointmentState _state  = AppointmentState.Pianificato;
        private string _deadlineNotes = "";


        //private int _objectId = -1;

        //public int ObjectId
        //{
        //    get
        //    {
        //        return _objectId;
        //    }
        //    set
        //    {
        //        _objectId = value;
                
        //    }
        //}


        public AppointmentState State
        {
            get
            {
                return _state;
            }
           
        }

        public string StateToString
        {
            get
            {
                return _state.ToString();
            }

        }


        //public string CustomerContats
        //{
        //    get
        //    {
        //        if (_customer != null)
        //            return _customer.Comunicazione.ToString();
        //        return string.Empty;
        //        //return "ciao \r\n pippo";
        //    }
        //}

        public int DaysBeforeDeadline
        {
            get
            {
                return _daysBeforeDeadline;
            }
          
        }

                                       
        public int DaysAfterDeadline
        {
            get
            {
                return _daysAfterDeadline;
            }
           
        }


        /// <summary>
        /// Calculates the appointmentState and the days before and after the deadline
        /// if the apppointment is not closed or executed
        /// </summary>
        /// <param name="daysBeforeDeadline"></param>
        public void CalculateAppointmentInfo(int daysBeforeDeadline)
        {
            _deadlineNotes = "";
            _daysAfterDeadline = 0;
            _daysBeforeDeadline = 0;
            _state = AppointmentState.Pianificato;

            if (_isClosed)
                _state = AppointmentState.Concluso;
            else if (_outcomeCreated)
                _state = AppointmentState.Eseguito;
            else
                _state = CalculateState(daysBeforeDeadline);
           
        }

        private AppointmentState CalculateState(int daysBeforeDeadline)
        {
            AppointmentState s;
            if (DateTime.Now.Date == _endDate.Date)
                s = AppointmentState.Scade_Oggi ;
            else if (DateTime.Now > _endDate)
                s = AppointmentState.Scaduto;
            else if (DateTime.Now.AddDays(daysBeforeDeadline).Date >= _endDate.Date && DateTime.Now < _endDate)
                s = AppointmentState.In_Scadenza;
            else
                s = AppointmentState.Pianificato;

            if (s == AppointmentState.Scaduto)
            {
                _daysAfterDeadline = new TimeSpan(DateTime.Now.Ticks - _endDate.Ticks).Days;
                _deadlineNotes = string.Format("ATTENZIONE!! Appuntamento scaduto da {0} giorni!", _daysAfterDeadline.ToString());

            }
            else if (s == AppointmentState.Scade_Oggi)
            {
                _deadlineNotes = "ATTENZIONE!! L'appuntamento scade oggi!";
            }
            else
            {
                _daysBeforeDeadline = new TimeSpan(_endDate.Ticks - DateTime.Now.Ticks).Days + 1;
                _deadlineNotes = string.Format("L'appuntamento scadrà tra {0} giorni!", _daysBeforeDeadline.ToString());
            }

            return s;
        }


        public string DeadlineNotes
        {
            get
            {
                return _deadlineNotes;
            }
        }
        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(_subject))
                ValidationErrors.Add("Inserire un oggetto valido per l'appuntamento");

            if (_label == null)
                ValidationErrors.Add("Inserire una causale valida per l'appuntamento");


            if (_resource == null)
                ValidationErrors.Add("Inserire una risorsa valida per l'appuntamento");


            if (_endDate == DateTime.MinValue || _endDate == DateTime.MaxValue)
                ValidationErrors.Add("Inserire una data fine valida per l'appuntamento");


            if (_startDate == DateTime.MinValue || _startDate == DateTime.MaxValue)
                ValidationErrors.Add("Inserire una data inizio valida per l'appuntamento");


            if (_startDate > _endDate)
                ValidationErrors.Add("Inserire un intervallo di tempo corretto per l'appuntamento");


            //prevengo la compilazione erronea di alcuni parametri
            if (!_outcomeCreated)
            {
                CancelRapporto();
            }

            if (OutcomeCreated)
                if (OutcomeDate == DateTime.MinValue)
                    ValidationErrors.Add("Inserire una data corretta per il rapporto dell'appuntamento");

        }





         private int _appointmentType;
         private DateTime _startDate;
         private DateTime _endDate;
         private DateTime _outcomeDate;
         private bool _isClosed;

         private bool _outcomeCreated;


         public bool IsClosed
         {
             get
             {
                 return _isClosed;
             }
             set
             {
                 _isClosed = value;
             }
         }

         private bool _allDay;
         private string _subject;
         private string _location;
         private string _description;
         private string _outcomeDescription;


        //ricorrenze e alert
         private string _recurrenceInfo;
         private string _reminderInfo;

        //campi identificati con id
         private int _resourceId;
         private long _labelId;
         private int _statusId;

        //oggetti
         private Customer _customer = null;
         private Operator _operator = null;
         private Outcome _outcome = null;
         private Label _label = null;
        private Resource _resource = null;
         
     
         public MyAppointment()
         {
             
         }


         public bool AllDay
         {
             get
             {
                 return _allDay;
             }
             set
             {
                 _allDay = value;
             }
         }
         public int AppointmentType
        {
		        get
		        {
				        return _appointmentType;
		        }
		        set
		        {
				        _appointmentType = value;
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
         public string Description
         {
             get
             {
                 return _description;
             }
             set
             {
                 _description = value;
             }
         }
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
         public long LabelId
         {
             get
             {
                 return _labelId;
             }
             set
             {
                 _labelId = value;
             }
         }
         public Label Label
         {
             get
             {
                 return _label;
             }
             set
             {
                 _label = value;
             }
         }
         public string Location
         {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
         public Operator Operator
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
         public Outcome Outcome
         {
             get
             {
                 return _outcome;
             }
             set
             {
                 _outcome = value;
             }
         }
         public bool OutcomeCreated
         {
             get
             {
                 return _outcomeCreated;
             }
             set
             {
                 _outcomeCreated = value;
             }
         }
         public DateTime OutcomeDate
         {
             get
             {
                 return _outcomeDate;
             }
             set
             {
                 _outcomeDate = value;
             }
         }
         public string OutcomeDescription
         {
             get
             {
                 return _outcomeDescription;
             }
             set
             {
                 _outcomeDescription = value;
             }
         }
         public string RecurrenceInfo
         {
             get
             {
                 return _recurrenceInfo;
             }
             set
             {
                 _recurrenceInfo = value;
             }
         }
         public string ReminderInfo
         {
             get
             {
                 return _reminderInfo;
             }
             set
             {
                 _reminderInfo = value;
             }
         }
         public Resource Resource
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
        public int StatusId
        {
            get
            {
                return _statusId;
            }
            set
            {
                _statusId = value;
            }
        }
        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }



        public void CancelRapporto()
        {
            _outcomeCreated = false;
            _outcomeDate = DateTime.MinValue;
            _outcomeDescription = "";
            _outcome = null;
            _isClosed = false;
        }

        public void CreateRapporto()
        {
            _outcomeCreated = true;
            _outcomeDate = DateTime.Now;
            _outcomeDescription = "";
            _outcome = null;
            _isClosed = false;
            
        }
        
    }
}
