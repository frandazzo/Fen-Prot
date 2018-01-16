using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class SimpleDocumentSearch: IsearchDTO
    {

        private IList<DocumentType> _labels = new List<DocumentType>();
        //private IList<Customer> _customers = new List<Customer>();
        private IList<DocumentScope> _scopes = new List<DocumentScope>();
        private IList<Operator> _operators = new List<Operator>();
        private  string _subject;
        private  string _protocol;
        private int _year = DateTime.Now.Year;


        public SimpleDocumentSearch(IList<DocumentScope> scopes,IList<DocumentType> labels, IList<Operator> operators, string subject, string protocol, int year)
        {
            //_customers = customers;
            _scopes = scopes; 
            _protocol = protocol;
            _subject = subject;
            _operators = operators;
            _labels = labels;
            _year = year;
        }

        #region IsearchDTO Membri di


        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {
            //bool modified = false;
            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);

            c.AddCriteria(Criteria.Equal("DocYear", _year.ToString()));

            if (!string.IsNullOrEmpty(_subject))
            {
                c.AddCriteria(Criteria.Matches("Subject", _subject, DataAccessServices.Instance().PersistenceFacade.DBType));
                //modified = true;
            }

            if (!string.IsNullOrEmpty(_protocol))
            {
                c.AddCriteria(Criteria.Matches("Protocol", _protocol, DataAccessServices.Instance().PersistenceFacade.DBType));
                //modified = true;
            }



            if (_labels.Count > 0)
            {
                CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                foreach (DocumentType item in _labels)
                {
                    if (item != null)
                        c1.AddCriteria(Criteria.Equal("DocTypeID", item.Id.ToString()));
                }
                c.AddCriteria(c1);
                //modified = true;
            }

            if (_scopes.Count > 0)
            {
                CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                foreach (DocumentScope item in _scopes )
                {
                    if (item != null)
                        c1.AddCriteria(Criteria.Equal("ScopeID", item.Id.ToString()));
                }
                c.AddCriteria(c1);
                //modified = true;
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
                //modified = true;
            }

            //if (modified)
                return c;
           // return null;

            
        }

        #endregion    }
    }
}

