using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class SimpleAppointmentSearch : IsearchDTO
    {

        private IList<Label> _labels = new List<Label>();
        private IList<Resource> _resources = new List<Resource>();
        private IList<Operator> _operators = new List<Operator>();
        private  string _subject;
        private  string _location;


        public SimpleAppointmentSearch(IList<Resource> resources, IList<Label> labels, IList<Operator> operators, string subject, string location)
        {
            _location = location;
            _subject = subject;
            _operators = operators;
            _resources = resources;
            _labels = labels;
        }

        #region IsearchDTO Membri di


        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {
            bool modified = false;
            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);


            if (!string.IsNullOrEmpty(_subject))
            {
                c.AddCriteria(Criteria.Matches("Subject", _subject, DataAccessServices.Instance().PersistenceFacade.DBType));
                modified = true;
            }

            if (!string.IsNullOrEmpty(_location))
            {
                c.AddCriteria(Criteria.Matches("Location", _location, DataAccessServices.Instance().PersistenceFacade.DBType));
                modified = true;
            }



            if (_labels.Count > 0)
            {
                CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                foreach (Label item in _labels)
                {
                    if (item != null)
                        c1.AddCriteria(Criteria.Equal("LabelID", item.Id.ToString()));
                }
                c.AddCriteria(c1);
                modified = true;
            }

            if (_resources.Count > 0)
            {
                CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                foreach (Resource item in _resources)
                {
                    if (item != null)
                        c1.AddCriteria(Criteria.Equal("ResourceID", item.Id.ToString()));
                }
                c.AddCriteria(c1);
                modified = true;
            }

            if (_operators.Count > 0)
            {
                CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                foreach (Operator item in _operators)
                {
                    if (item != null)
                        c1.AddCriteria(Criteria.Equal("OperatorID", item.Id.ToString()));
                }
                c.AddCriteria(c1);
                modified = true;
            }

            if (modified)
                return c;
            return null;

            
        }

        #endregion    }
    }
}
