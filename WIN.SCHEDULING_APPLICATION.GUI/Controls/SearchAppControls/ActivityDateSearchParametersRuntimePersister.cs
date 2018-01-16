using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    internal class ActivityDateSearchParametersRuntimePersister
    {

        internal static bool Initialized = false;

        internal static bool OverlappedSelected = true;

        internal static bool NoSelectedPeriod = false;

        internal static DateTime Start = DateTime.Now;

        internal static DateTime End = DateTime.Now;

        internal static WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum Status = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Oggi;


        internal static void SetPersistedParameters(AppointmentDateSearchControl control)
        {
            control.AssignDate(Start, End);
            control.AssignOverlappedSelected = OverlappedSelected;
            control.AssignNoSelectedPeriod = NoSelectedPeriod;
            control.AssignCheckFromStatus(Status);
        }

    }
}
