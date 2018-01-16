using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using System.ComponentModel;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    public class DocumentHandler : SimpletHandler
    {

        private IBindingList _bindableResults = new BindingList<Document>();


        public IBindingList BindableResults
        {
            get
            {
                return _bindableResults;
            }
        }

        public override string ObjectTypeName
        {
            get { return "Document"; }
        }





        public IList ExecuteQuery(IList<IsearchDTO> criterias, int maxQueryresult)
        {
            _bindableResults = new BindingList<Document>();

            Query q = _ps.CreateNewQuery("MapperDocument");

            q.SetTable("App_Documents");
            if (maxQueryresult > 0)
                q.SetMaxNumberOfReturnedRecords(maxQueryresult);

            if (criterias.Count > 0)
            {
                CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
                foreach (IsearchDTO item in criterias)
                {

                    if (item != null)
                    {
                        AbstractBoolCriteria crit = item.GenerateSql();
                        if (crit != null)
                            c.AddCriteria(crit);
                    }
                }
                q.AddWhereClause(c);
            }

            string a = q.CreateQuery(_ps);

            IList l = q.Execute(_ps);


            foreach (Document item in l)
            {
                _bindableResults.Add(item);
            }

            return l;

        }


        //public IList GetAppointmentsByUser(string customerId, int deadlinesDays)
        //{
        //    _bindableResults = new BindingList<MyAppointment>();

        //    if (string.IsNullOrEmpty(customerId))
        //        throw new Exception("Identificativo cliente non valido!");



        //    Query q = _ps.CreateNewQuery("MapperMyAppointment");


        //    q.AddWhereClause(Criteria.Equal("CustomerID", customerId));


        //    IList l = q.Execute(_ps);


        //    foreach (MyAppointment item in l)
        //    {
        //        _bindableResults.Add(item);
        //    }

        //    return l;

        //}

        public IList GetUserDocuments(Customer customer)
        {
            _bindableResults = new BindingList<Document>();

            Query q = _ps.CreateNewQuery("MapperDocument");

            q.SetTable("App_Documents");

            IList<Customer> l1 = new List<Customer>();
            l1.Add(customer);

            IsearchDTO dto = new CustomerAppointmentDTO(false, l1, true);

            q.AddWhereClause(dto.GenerateSql());


            string a = q.CreateQuery(_ps);

            IList l = q.Execute(_ps);


            foreach (Document item in l)
            {
                _bindableResults.Add(item);
            }

            return l;
        }
    }
}
