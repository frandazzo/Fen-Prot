using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class OutlookDeadLineStateFactory
    {
        public static OutlookDeadLineState GetState(AppointmentState state, int daysbeforeDeadLine)
        {
            switch (state)
            {
                case AppointmentState.Pianificato:
                    return GetInternalState(daysbeforeDeadLine);
                case AppointmentState.In_Scadenza:
                    return GetInternalState(daysbeforeDeadLine);
                case AppointmentState.Scade_Oggi:
                    return OutlookDeadLineState.SuperRedFlag;
                case AppointmentState.Scaduto:
                    return OutlookDeadLineState.SuperRedFlag;
                case AppointmentState.Eseguito:
                    return OutlookDeadLineState.CompleteFlag;
                case AppointmentState.Concluso:
                    return OutlookDeadLineState.CompleteFlag;
                default:
                    return OutlookDeadLineState.CompleteFlag;
            }
        }

        private static OutlookDeadLineState GetInternalState(int daysbeforeDeadLine)
        {
            if (daysbeforeDeadLine <= 0)
                return OutlookDeadLineState.CompleteFlag;

            if (daysbeforeDeadLine == 1)
                return OutlookDeadLineState.RedFlag;
            else if (daysbeforeDeadLine <= 7)
                return OutlookDeadLineState.MinorRedFlag;
            else
                return OutlookDeadLineState.EmptyFlag;
        }
    }

    public enum OutlookDeadLineState
    {
        CompleteFlag,
        SuperRedFlag,
        RedFlag,
        MinorRedFlag,
        EmptyFlag
    }
}
