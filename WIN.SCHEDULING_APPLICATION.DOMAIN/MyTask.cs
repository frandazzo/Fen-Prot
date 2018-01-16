using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class MyTask : AbstractPersistenceObject
    {
        private int _daysAfterDeadline;
        private int _daysBeforeDeadline;
        private AppointmentState _activityDeadlineState = AppointmentState.Pianificato;
        private string _deadlineNotes = "";
        private OutlookDeadLineState _outlookDeadLineState = OutlookDeadLineState.SuperRedFlag;

     

        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _outcomeDate;
       
        private string _subject;
      
        private string _description;
        private string _outcomeDescription;


        private int _completeness = 0;
        private PriorityType _priority = PriorityType.Normale;
        private ActivityState _activityState = ActivityState.Non_Iniziata;
        //oggetti
        private Customer _customer = null;
        private Outcome _outcome = null;
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


        public OutlookDeadLineState OutlookDeadLineState
        {
            get
            {
                return _outlookDeadLineState;
            }
        }

        public string OutlookDeadLineStateToString
        {
            get
            {
                return _outlookDeadLineState.ToString();
            }
        }


        public PriorityType Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        public string PriorityToString
        {
            get
            {
                return _priority.ToString();
            }
            
        }



        public MyTask()
        {

        }




        public AppointmentState ActivityDeadlineState
        {
            get
            {
                return _activityDeadlineState;
            }
        }

        public string ActivityDeadlineStateToString
        {
            get
            {
                return _activityDeadlineState.ToString();
            }

        }

        public string ActivityStateToString
        {
            get
            {
                return _activityState.ToString();
            }

        }

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
        /// Calculates the activityDeadlineState and the days before and after the deadline
        /// if the activity is not completed
        /// </summary>
        /// <param name="daysBeforeDeadline"></param>
        public void CalculateAppointmentInfo(int daysBeforeDeadline)
        {
            _deadlineNotes = "";
            _daysAfterDeadline = 0;
            _daysBeforeDeadline = 0;
            _activityDeadlineState = AppointmentState.Pianificato;

            if (_activityState == ActivityState.Completata)
            {
                _activityDeadlineState = AppointmentState.Concluso;

                _deadlineNotes = string.Format("Attività completata {0}", _outcomeDate.Date.ToLongDateString());
            }

            else
                _activityDeadlineState = CalculateState(daysBeforeDeadline);




            _outlookDeadLineState = OutlookDeadLineStateFactory.GetState(_activityDeadlineState, _daysBeforeDeadline);
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
                _deadlineNotes = string.Format("ATTENZIONE. Attività scaduta da {0} giorni!", _daysAfterDeadline.ToString());

            }
            else if (s == AppointmentState.Scade_Oggi)
            {
                _deadlineNotes = "ATTENZIONE!! L'attività scade oggi!";
            }
            else
            {
                _daysBeforeDeadline = new TimeSpan(_endDate.Ticks - DateTime.Now.Ticks).Days + 1;
                _deadlineNotes = string.Format("L'attività scadrà tra {0} giorni!", _daysBeforeDeadline.ToString());
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
                ValidationErrors.Add("Inserire un oggetto valido per l'attività");

            if (_endDate == DateTime.MinValue || _endDate == DateTime.MaxValue)
                ValidationErrors.Add("Inserire una data fine valida per l'attività");


            if (_startDate == DateTime.MinValue || _startDate == DateTime.MaxValue)
                ValidationErrors.Add("Inserire una data inizio valida per l'attività");


            if (_startDate > _endDate)
                ValidationErrors.Add("Inserire un intervallo di tempo corretto per l'attività");


            if (OutcomeDate > DateTime.MinValue)
            {
                if (_activityState != ActivityState.Completata)
                    ValidationErrors.Add("Lo stato dell'attività deve essere necessariamente posto su 'Completata' poichè è stata impostata una data di completamento attività ");
                if (_completeness != 100)
                    ValidationErrors.Add("Percentuale di completamento attività diverso da 100");
            }

            if (_activityState == ActivityState.Completata && _completeness != 100)
                ValidationErrors.Add("Percentuale di completamento attività diverso da 100");
            if (_activityState != ActivityState.Completata && _completeness == 100)
                ValidationErrors.Add("Lo stato dell'attività deve essere necessariamente posto su 'Completata' poichè è stata impostata una data di completamento attività ");

            if (_activityState == ActivityState.Non_Iniziata && _completeness != 0)
                ValidationErrors.Add("Percentuale di completamento attività diverso da 0");
           


            if (_completeness <0 || _completeness >100)
                ValidationErrors.Add("Inserire una percentuale di completamento attività valida (compresa tra 0 e 100)");



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

         public void SetActivityCompleted()
         {
             _activityState = ActivityState.Completata;
             _completeness = 100;
             _outcomeDate = DateTime.Now;
         }

         //public void SetActivityAsInitialized()
         //{
         //    _activityState = ActivityState.Non_Iniziata;
         //    _completeness = 0;
         //    _outcomeDate = DateTime.MinValue;
         //}





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
        public int PercentageCompleteness
        {
            get
            {
                return _completeness;
            }
            set
            {
                _completeness = value;
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


        public ActivityState ActivityState
        {
            get { return _activityState; }
            set { _activityState = value; }
        }

    }
}
//public int ResourceId
//{
//    get
//    {
//        return _resourceId;
//    }
//    set
//    {
//        _resourceId = value;
//    }
//}

//public void CancelRapporto()
//{
//    //_outcomeCreated = false;
//    _outcomeDate = DateTime.MinValue;
//    _outcomeDescription = "";
//    //_outcome = null;
//    //_isClosed = false;
//}

//public void CreateRapporto()
//{
//    //_outcomeCreated = true;
//    _outcomeDate = DateTime.Now;
//    _outcomeDescription = "";
//   // _outcome = null;
//    //_isClosed = false;

//}
        

//private bool _isClosed; 
//private string _location;
//private bool _outcomeCreated;
//private int _resourceId;
//private long _labelId;


//public bool IsClosed
//{
//    get
//    {
//        return _isClosed;
//    }
//    set
//    {
//        _isClosed = value;
//    }
//}



//public long LabelId
//{
//    get
//    {
//        return _labelId;
//    }
//    set
//    {
//        _labelId = value;
//    }
//}

// public string Location
// {
//    get
//    {
//        return _location;
//    }
//    set
//    {
//        _location = value;
//    }
//}

//public bool OutcomeCreated
//{
//    get
//    {
//        return _outcomeCreated;
//    }
//    set
//    {
//        _outcomeCreated = value;
//    }
//}
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

////ricorrenze e alert
//private int _appointmentType;
// private bool _allDay;
// private string _recurrenceInfo;
// private string _reminderInfo;
//private Operator _operator = null;
//private Label _label = null;
//private Resource _resource = null;


// public bool AllDay
// {
//     get
//     {
//         return _allDay;
//     }
//     set
//     {
//         _allDay = value;
//     }
// }
// public int AppointmentType
//{
//        get
//        {
//                return _appointmentType;
//        }
//        set
//        {
//                _appointmentType = value;
//        }
//}
//public Label Label
//{
//    get
//    {
//        return _label;
//    }
//    set
//    {
//        _label = value;
//    }
//}
//public Operator Operator
//{
//    get
//    {
//        return _operator;
//    }
//    set
//    {
//        _operator = value;
//    }
//}
//public string RecurrenceInfo
//{
//    get
//    {
//        return _recurrenceInfo;
//    }
//    set
//    {
//        _recurrenceInfo = value;
//    }
//}
//public string ReminderInfo
//{
//    get
//    {
//        return _reminderInfo;
//    }
//    set
//    {
//        _reminderInfo = value;
//    }
//}
//public Resource Resource
//{
//    get
//    {
//        return _resource;
//    }
//    set
//    {
//        _resource = value;
//    }
//}
