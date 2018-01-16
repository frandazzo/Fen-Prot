using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Commands.Specifics;
using WIN.SCHEDULING_APP.GUI.Controls;

namespace WIN.SCHEDULING_APP.GUI.Commands
{
    public class OpenCommandFactory
    {
        public static IOpenCommand GetCommand(CommandType type, MainForm form)
        {
            switch (type)
            {
                case CommandType.Home:
                    return new HomeCommand(form);
                case CommandType.Labels:
                    return new LabelsCommand(form);
                case CommandType.Outcomes:
                    return new OutcomeCommand(form);
                case CommandType.Resources:
                    return new ResourcesCommand(form);
                case CommandType.Operators:
                    return new OperatorCommand(form);
                case CommandType.Contacts:
                    return new CustomerCommand(form);
                case CommandType.AppointmentReport:
                    return new AppointmentReportcommand(form);
                case CommandType.AppointmentCalendar:
                    return new CalendarCommand(form);
                case CommandType.TaskReport:
                    return new TaskReportCommand(form);
                case CommandType.DocumentTypes:
                    return new DocumentTypeCommand(form);
                case CommandType.DocumentScopes:
                    return new DocumentScopeCommand(form);
                case CommandType.DocumentReport:
                    return new DocumentReportCommand(form);
                case CommandType.Administration:
                    return new AdministrationCommand(form);
                case CommandType.BookingCalendar :
                    return new BookingCommand(form);
                case CommandType.BookingResources:
                    return new BookingResourcesCommand(form);
                case CommandType.BookingTypes:
                    return new BookingTypeCommand(form);
                case CommandType.BookingStats:
                    return new BookingStatsCommand(form);
                case CommandType.BookingBedTypes:
                    return new BookingBedTypesCommand(form);
                case CommandType.BookingReport:
                    return new BookingReportCommand(form);
                case CommandType.BookingPaymentReport:
                    return new BookingPaymentReportCommand(form);
                    
                default:
                    return null;
            }
        }

        public static IOpenCommand GetCommand(string type, MainForm form)
        {
            try
            {
                CommandType t = (CommandType)Enum.Parse(typeof(CommandType), type);
                return GetCommand(t, form);
            }
            catch (Exception)
            {
                return null;
            }
            

        }
    }
}
