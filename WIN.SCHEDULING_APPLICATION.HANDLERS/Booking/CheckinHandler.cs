using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Booking
{
    public class CheckinHandler
    {
        public IList GetCheckins(DateTime date)
        {
            IList result = null;
            IPersistenceFacade _ps = DataAccessServices.Instance().PersistenceFacade;

            Query q = _ps.CreateNewQuery("MapperCheckin");

            AbstractBoolCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
            c.AddCriteria(Criteria.DateTimeContained ("Checkin", date.Date, date.AddDays(1).Date.AddSeconds(-1),_ps.DBType));
          

            q.AddWhereClause(c);

            string p = q.CreateQuery(_ps);

            result = q.Execute(_ps);

            IList result1 = new ArrayList();

            foreach (Checkin item in result)
            {
                result1.Add( new ArrivedPerson(item));
                
            }

            return result1;

        }
    }
}
