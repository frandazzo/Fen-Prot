using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler;

namespace WIN.SCHEDULING_APP.GUI.Controls.CalendarUtils
{
    public class CalendarProperties
    {
        public static SchedulerViewType GetViewType(string property)
        {
            switch (property)
            {
                case "Giornaliera":
                    return SchedulerViewType.Day;
                case "Settimana lavorativa":
                    return SchedulerViewType.WorkWeek;
                case "Settimanale":
                    return SchedulerViewType.Week ;
                case "Mensile":
                    return SchedulerViewType.Month;

                default:
                    return SchedulerViewType.Day;
            }
        }
    }
}
