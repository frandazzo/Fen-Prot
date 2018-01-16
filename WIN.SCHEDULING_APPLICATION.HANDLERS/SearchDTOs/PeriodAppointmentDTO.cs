using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class PeriodAppointmentDTO : IsearchDTO
    {
        public enum PeriodAppointmentDTOEnum
        {
            Prossimi_Sei_Mesi,
            Prossimi_Tre_Mesi,
            Prossimo_Mese,
            Prossime_Due_Settimane,
            Prossima_Settimana,
            Domani,
            Oggi,
            Ultima_Settimana,
            Ultime_Due_Settimane,
            Ultimo_Mese,
            Ultimi_Tre_Mesi,
            Ultimi_Sei_Mesi,
            Periodo
        }


        private PeriodAppointmentDTOEnum _state = PeriodAppointmentDTOEnum.Oggi;
        private DataRange _range;
        private bool _findAlsoOverlappedAppointments;
        private bool _noPeriod = false;

        public PeriodAppointmentDTO(PeriodAppointmentDTOEnum state, DataRange range, bool findAlsoOverlappedAppointments,bool noPeriod)
        {
            _findAlsoOverlappedAppointments = findAlsoOverlappedAppointments;
            _state = state;
            _range = range;
            _noPeriod = noPeriod;
            if (_range == null)
                _range = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now, DateTime.Now));
            
            if (_range.IsEmpty())
                _range = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now, DateTime.Now));
        }

     

        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {


            if (_noPeriod)
                return null;

          
            DataRange r;


            switch (_state)
            {
                case PeriodAppointmentDTOEnum.Prossimi_Sei_Mesi:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddMonths(6)));
                    break;
                case PeriodAppointmentDTOEnum.Prossimi_Tre_Mesi:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddMonths(3)));
                    break;
                case PeriodAppointmentDTOEnum.Prossimo_Mese:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddMonths(1)));
                    break;
                case PeriodAppointmentDTOEnum.Prossime_Due_Settimane:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(15)));
                    break;
                case PeriodAppointmentDTOEnum.Prossima_Settimana:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(8)));
                    break;
                case PeriodAppointmentDTOEnum.Domani:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1)));
                    break;
                case PeriodAppointmentDTOEnum.Oggi:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now, DateTime.Now));
                    break;
                case PeriodAppointmentDTOEnum.Ultima_Settimana:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-1)));
                    break;
                case PeriodAppointmentDTOEnum.Ultime_Due_Settimane:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-1)));
                    break;
                case PeriodAppointmentDTOEnum.Ultimo_Mese:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(-1).AddMonths(-1), DateTime.Now.AddDays(-1)));
                    break;
                case PeriodAppointmentDTOEnum.Ultimi_Tre_Mesi:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(-1).AddMonths(-3), DateTime.Now.AddDays(-1)));
                    break;
                case PeriodAppointmentDTOEnum.Ultimi_Sei_Mesi:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now.AddDays(-1).AddMonths(-6), DateTime.Now.AddDays(-1)));
                    break;
                case PeriodAppointmentDTOEnum.Periodo:
                    r = AppointmentUtils.CreateRangeForQuery(_range);
                    break;

                default:
                    r = AppointmentUtils.CreateRangeForQuery(new DataRange(DateTime.Now, DateTime.Now));
                    break;
            }

            if (_findAlsoOverlappedAppointments)
            {
                CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
                c.AddCriteria(Criteria.DateRangeIntersects("StartDate", "EndDate", r.Start, r.Finish, DataAccessServices.Instance().PersistenceFacade.DBType));
                return c;
            }
            else
            {
                CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
                c.AddCriteria(Criteria.DateTimeContained("StartDate", r.Start, r.Finish, DataAccessServices.Instance().PersistenceFacade.DBType));
                return c;
            }
            
        }

    }
}
