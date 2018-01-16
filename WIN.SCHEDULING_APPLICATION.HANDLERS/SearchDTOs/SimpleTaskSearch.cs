using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class SimpleTaskSearch : IsearchDTO
    {

        private string _subject;
        private string _priority;
        private DataRange _range;
        private readonly bool _Non_iniziata;
        private readonly bool _In_corso;
        private readonly bool _Completata;
        private readonly bool _In_attesa;
        private readonly bool _Rinviata;
        private bool _scaduti;
        private DateTime _allaData;

        public SimpleTaskSearch(string subject, string priority, DataRange range, bool non_iniziata, bool in_corso, bool completata, bool in_attesa, bool rinviata,  bool scaduti, DateTime allaData )
        {
            _scaduti = scaduti;
            _allaData = allaData;
            _Rinviata = rinviata;
            _In_attesa = in_attesa;
            _Completata = completata;
            _In_corso = in_corso;
            _Non_iniziata = non_iniziata;
            _subject = subject;
            _priority = priority;
            _range = range;


        }

        #region IsearchDTO Membri di

        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {
            bool modified = false;
            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);


            if (!string.IsNullOrEmpty(_subject))
            {
                c.AddCriteria(Criteria.Matches("Subject", _subject, DataAccessServices.Instance().PersistenceFacade.DBType));
                modified = true;
            }

            if (!string.IsNullOrEmpty(_priority))
            {
                PriorityType t = (PriorityType)Enum.Parse(typeof(PriorityType),_priority);
                c.AddCriteria(Criteria.Equal("Priority", Convert.ToInt32(t).ToString()));
                modified = true;
            }

            if (!_range.IsEmpty())
            {
                DataRange r = AppointmentUtils.CreateRangeForQuery(_range);
                c.AddCriteria(Criteria.DateTimeContained("OutcomeDate", r.Start , r.Finish, DataAccessServices.Instance().PersistenceFacade.DBType));
                modified = true;
            }


            CompositeCriteria c1 = CreateStapeCriteria();

            if (c1 != null)
            {
                c.AddCriteria(c1);
                modified = true;
            }
          

            if (modified)
                return c;
            return null;

        }

        private CompositeCriteria CreateStapeCriteria()
        {

            if (_scaduti)
            {
                return CreateScadutiCriteria();
                
            }



            if (_Non_iniziata == false && _In_corso == false && _Completata == false && _In_attesa == false && _Rinviata == false)
                return null;

            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);

            if (_Non_iniziata)
                c.AddCriteria(Criteria.Equal("Status", "0"));

            if (_In_corso)
                c.AddCriteria(Criteria.Equal("Status", "1"));

            if (_Completata)
                c.AddCriteria(Criteria.Equal("Status", "2"));

            if (_In_attesa)
                c.AddCriteria(Criteria.Equal("Status", "3"));

            if (_Rinviata)
                c.AddCriteria(Criteria.Equal("Status", "4"));


            return c;

        }

        private CompositeCriteria CreateScadutiCriteria()
        {
            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
            
            c.AddCriteria(Criteria.Equal("Status", "0"));

            c.AddCriteria(Criteria.Equal("Status", "1"));

            c.AddCriteria(Criteria.Equal("Status", "3"));

            c.AddCriteria(Criteria.Equal("Status", "4"));




            if (_allaData != DateTime.MinValue)
            {
                AndExp a = new AndExp(c, Criteria.DateTimeContained("EndDate", new DateTime(1900, 1, 1), _allaData.AddDays(1).Date, DataAccessServices.Instance().PersistenceFacade.DBType));
                return a;
            }

            return c;
        }
   

        #endregion
    }
}
