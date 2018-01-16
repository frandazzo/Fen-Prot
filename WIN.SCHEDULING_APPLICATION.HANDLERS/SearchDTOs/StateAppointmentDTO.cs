using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class StateAppointmentDTO : IsearchDTO
    {

        public enum StateAppointmentDTOEnum
        {
            Tutti,
            Eseguiti,
            Non_Eseguiti
        }


        private StateAppointmentDTOEnum _state = StateAppointmentDTOEnum.Tutti;
        private bool _conclusi;
        private IList<Outcome> _outcomes = new List<Outcome>();



        public StateAppointmentDTO(StateAppointmentDTOEnum state, bool conclusi, IList<Outcome> outcomes)
        {
            _state = state;
            _conclusi = conclusi;
            _outcomes = outcomes;
        }

        #region IsearchDTO Membri di


        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {
            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);

            if (_state == StateAppointmentDTOEnum.Non_Eseguiti)
            {
                c.AddCriteria(Criteria.Equal("OutcomeCreated", "0"));
                return c;
            }
            else if (_state == StateAppointmentDTOEnum.Tutti)
            {
                return null;
            }
            else
            {
                c.AddCriteria(Criteria.Equal("OutcomeCreated", "1"));
                //if (_conclusi)
                    //c.AddCriteria(Criteria.Equal("Closed", "1"));
                //else
                if (!_conclusi)
                    c.AddCriteria(Criteria.Equal("Closed", "0"));


                if (_outcomes.Count > 0)
                {
                    CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                    foreach (Outcome item in _outcomes)
                    {
                        if (item != null)
                            c1.AddCriteria(Criteria.Equal("OutcomeID",item.Id.ToString()));
                    }
                    c.AddCriteria(c1);
                }

                return c;
            }
        }

        #endregion
    }
}
