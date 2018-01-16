using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using System.ComponentModel;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    public class TaskHandler : SimpletHandler
    {

        private IBindingList _bindableResults = new BindingList<MyTask>();


        public IBindingList BindableResults
        {
            get
            {
                return _bindableResults;
            }
        }

        public override string ObjectTypeName
        {
            get { return "MyTask"; }
        }





        public IList ExecuteQuery(IList<IsearchDTO> criterias, int maxQueryresult, int deadlinesDays)
        {
            _bindableResults = new BindingList<MyTask>();

            Query q = _ps.CreateNewQuery("MapperMyTask");

            q.SetTable("App_Tasks");
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


            //calcolo lo stato per ogni appp ritornato
            foreach (MyTask item in l)
            {
                item.CalculateAppointmentInfo(deadlinesDays);
                _bindableResults.Add(item);
            }

            return l;

        }


        public IList GetUserTasks(string customerId, int deadlinesDays)
        {
            _bindableResults = new BindingList<MyTask>();

            if (string.IsNullOrEmpty(customerId))
                throw new Exception("Identificativo cliente non valido!");



            Query q = _ps.CreateNewQuery("MapperMyTask");


            q.AddWhereClause(Criteria.Equal("CustomerID", customerId));


            IList l = q.Execute(_ps);

            //calcolo lo stato per ogni appp ritornato
            foreach (MyTask item in l)
            {
                item.CalculateAppointmentInfo(deadlinesDays);
                _bindableResults.Add(item);
            }

            return l;

        }
    }
}

