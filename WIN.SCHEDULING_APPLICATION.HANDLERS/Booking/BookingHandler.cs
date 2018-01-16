using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Booking
{
    public class BookingHandler : SimpletHandler
    {

        private IBindingList _bindableResults = new BindingList<DOMAIN.Booking .Booking>();


        public IBindingList BindableResults
        {
            get
            {
                return _bindableResults;
            }
        }

        public override string ObjectTypeName
        {
            get { return "Booking"; }
        }





        public IList ExecuteQuery(IList<IsearchDTO> criterias, int maxQueryresult)
        {
            _bindableResults = new BindingList<DOMAIN.Booking.Booking>();

            Query q = _ps.CreateNewQuery("MapperBooking");

            q.SetTable("Book_Booking");
            if (maxQueryresult > 0)
                q.SetMaxNumberOfReturnedRecords(maxQueryresult);

            if (criterias.Count > 0)
            {
                CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
                foreach (IsearchDTO item in criterias)
                {

                    if (item != null)
                    {
                        AbstractBoolCriteria crit = item.GenerateSql();
                        if (crit != null)
                            c.AddCriteria(crit);
                    }
                }
                q.AddWhereClause(c);
            }

            string a = q.CreateQuery(_ps);

            IList l = q.Execute(_ps);


            //calcolo lo stato per ogni appp ritornato
            foreach (DOMAIN.Booking.Booking item in l)
            {
               
                _bindableResults.Add(item);
            }

            return l;

        }


        public IList GetBookings(DataRange period)
        {
           

            if (period == null)
                throw new Exception("Periodo non valido!");

            if (period.IsEmpty())
                throw new Exception("Periodo non valido!");

            Query q = _ps.CreateNewQuery("MapperBooking");

            AbstractBoolCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);

            c.AddCriteria(Criteria.DateTimeContained("Date", period.Start.Date, period.Finish.Date.AddDays(1).AddSeconds(-1),_ps.DBType));

           
            q.AddWhereClause(c);

            string sss = q.CreateQuery(_ps);
           return q.Execute(_ps);

           

        }
    }
}

