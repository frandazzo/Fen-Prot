using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using System.ComponentModel;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    public class AppointmentHandler : SimpletHandler 
    {

        private IBindingList _bindableResults = new BindingList<MyAppointment>();


        public IBindingList BindableResults
        {
            get
            {
                return _bindableResults;
            }
        }

        public override string ObjectTypeName
        {
            get { return "MyAppointment"; }
        }

        public override void SaveOrUpdate(AbstractPersistenceObject element)
        {
            if (element == null)
                return;

            if (element.Key == null)
                _ps.InsertObject(ObjectTypeName, element);
            else
                _ps.UpdateObject(ObjectTypeName, element);


            _ps.GetObjectReloadingCache(ObjectTypeName, element.Id);

        }



        public IList ExecuteQuery(IList<IsearchDTO> criterias, int maxQueryresult, int deadlinesDays)
        {
            _bindableResults = new BindingList<MyAppointment>();

            Query q = _ps.CreateNewQuery("MapperMyAppointment");

            q.SetTable("App_Appointments");
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
            foreach (MyAppointment item in l)
            {
                item.CalculateAppointmentInfo(deadlinesDays);
                _bindableResults.Add(item);
            }

            return l;

        }


        public IList GetAppointmentsByUser(string customerId, int deadlinesDays)
        {
            _bindableResults = new BindingList<MyAppointment>();

            if (string.IsNullOrEmpty(customerId))
                throw new Exception("Identificativo cliente non valido!");



            Query q = _ps.CreateNewQuery("MapperMyAppointment");


            q.AddWhereClause(Criteria.Equal("CustomerID",customerId ));


           IList l = q.Execute(_ps);

            //calcolo lo stato per ogni appp ritornato
           foreach (MyAppointment item in l)
           {
               item.CalculateAppointmentInfo(deadlinesDays);
               _bindableResults.Add(item);
           }

           return l;

        }
    }
}
