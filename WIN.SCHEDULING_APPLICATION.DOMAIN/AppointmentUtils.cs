using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class AppointmentUtils
    {

        public static string[] GetAppointmentStates()
        {
            return Enum.GetNames(typeof(AppointmentState));
        }

        public static AppointmentDateValidator GetProposedDate()
        {
            

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour ;
            int minute = DateTime.Now.Minute ;
            int second = DateTime.Now.Second ;

            DateTime template = new DateTime(year, month, day, hour, 0, 0);

            if (minute < 30)
            {
                //aggiungo mezz'ora alla data iniziale
                template = template.AddMinutes(30);
            }
            else
            {
                //aggiungo un'ora alla data iniziale
                template = template.AddHours(1);
            }

            AppointmentDateValidator v = new AppointmentDateValidator();

            v.StartDate = template; ;
            v.EndDate = v.StartDate.AddMinutes(30);

            if (!v.IsOnSameDay())
            {
                v.StartDate = v.EndDate;
                v.EndDate = v.EndDate.AddMinutes(30);
            }
            

            return v;
        }


        public static AppointmentDateValidator GetProposedDate(DateTime date)
        {


            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            DateTime template = new DateTime(year, month, day, hour, 0, 0);

            if (minute < 30)
            {
                //aggiungo mezz'ora alla data iniziale
                template = template.AddMinutes(30);
            }
            else
            {
                //aggiungo un'ora alla data iniziale
                template = template.AddHours(1);
            }

            AppointmentDateValidator v = new AppointmentDateValidator();

            v.StartDate = template; ;
            v.EndDate = v.StartDate.AddMinutes(30);

            if (!v.IsOnSameDay())
            {
                v.StartDate = v.EndDate;
                v.EndDate = v.EndDate.AddMinutes(30);
            }


            return v;
        }







        public static DataRange CreateRangeForQuery(DataRange range)
        {
            DateTime s;
            DateTime f;

            if (range == null)
            {
                s = DateTime.Now;
                f = DateTime.Now;
            }
            else
            {
                s = range.Start;
                f = range.Finish;
            }


            DateTime start = new DateTime(s.Year, s.Month, s.Day, 0, 0, 0);
            DateTime finish = new DateTime(f.Year, f.Month, f.Day, 23, 59, 0);


            return new DataRange(start, finish);

        }

    }
}
