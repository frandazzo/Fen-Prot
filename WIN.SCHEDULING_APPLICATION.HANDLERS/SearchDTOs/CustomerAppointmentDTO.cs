using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class CustomerAppointmentDTO : IsearchDTO
    {
        private bool _senzaCliente;
        private bool _createSubquery = false;
        private IList<Customer> _customers = new List<Customer>();

        public CustomerAppointmentDTO(bool senzaCliente, IList<Customer> customers, bool createSubQuery)
        {
            _createSubquery = createSubQuery;
            _senzaCliente = senzaCliente;
            _customers = customers;
        }

        public CustomerAppointmentDTO(bool senzaCliente, IList<Customer> customers)
        {
            _senzaCliente = senzaCliente;
            _customers = customers;
        }

        #region IsearchDTO Membri di


        public WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql()
        {


            if (!_createSubquery)
            {
                CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);

                if (_senzaCliente)
                {
                    c.AddCriteria(Criteria.IsNull("CustomerID"));
                }
                else
                {
                    if (_customers.Count > 0)
                    {
                        CreateCustomerCriteria(c);

                    }
                    else
                        c = null;
                }

                return c;
            }
            else // creo la subquery per i contatti sui documenti
            {
                if (_customers.Count == 0)
                    return null;
                CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
                //creo la clausola where per la sotto query
                AbstractBoolCriteria CompositeListaSoggetti = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
                if (_customers.Count > 0)
                    foreach (Customer elem in _customers)
                        CompositeListaSoggetti.AddCriteria(Criteria.Equal("ContactID", elem.Id.ToString()));
                //creo il corpo della sottoquery
                AbstractBoolCriteria  subCriteria  = CompositeListaSoggetti;
                //aggiungo anche la clausola distinct   … Select Distinct DocumentID from App_Destinations….
                SubQueryCriteria  subqry = new SubQueryCriteria("App_Destinations ", "DocumentID", true);
                //a ggiungo la clausola where … where ContactId = @par1 or ContactId = @par2 ….
                if (_customers.Count > 0)
                      subqry.AddCriteria(subCriteria);
                // aggiungo la sottoquery al criterio principale  ….select * from [Tabella]  where (ID in (select distinct DocumentId……))
                c.AddCriteria(Criteria.INClause("ID ", subqry));

                return c;
            }

        }

        private void CreateCustomerCriteria(CompositeCriteria c)
        {
            CompositeCriteria c1 = new CompositeCriteria(AbstractBoolCriteria.Operatore.OrOp);
            foreach (Customer item in _customers)
            {
                if (item != null)
                    c1.AddCriteria(Criteria.Equal("CustomerID", item.Id.ToString()));
            }
            c.AddCriteria(c1);
        }

        #endregion

    }
}
