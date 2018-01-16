using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Booking
{
    public class StatisticsHandler
    {
        public IList GetBookingStatistics(int year)
        {
            IPersistenceFacade _ps = DataAccessServices.Instance().PersistenceFacade;

            Query q =  _ps.CreateNewQuery("MapperBookingStatistics");

            q.SetTable(string.Format("dbo.GetBookingStatisticsByYear({0})", year.ToString () ));

            return q.Execute(_ps);
        }


        public IList GetPaymentStatistics(int year)
        {
            IPersistenceFacade _ps = DataAccessServices.Instance().PersistenceFacade;

            Query q = _ps.CreateNewQuery("MapperPaymentStatistics");

            q.SetTable(string.Format("dbo.GetCollectsByYear({0})", year.ToString()));

            return q.Execute(_ps);
        }
    }
}
