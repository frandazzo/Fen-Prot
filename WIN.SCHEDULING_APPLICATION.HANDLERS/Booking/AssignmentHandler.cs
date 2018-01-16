using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;
using WIN.BASEREUSE;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Booking
{
    public class AssignmentHandler : SimpletHandler
    {

        private IBindingList _bindableResults = new BindingList<Assignment>();


        public IBindingList BindableResults
        {
            get
            {
                return _bindableResults;
            }
        }

        public override string ObjectTypeName
        {
            get { return "Assignment"; }
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

        public IList GetAssignmentsByBookingId(int bookingId)
        {
            Query q = _ps.CreateNewQuery("MapperAssignment");


            q.AddWhereClause(Criteria.Equal("Id_Booking", bookingId.ToString()));


            return q.Execute(_ps);
        }


        public FreeRoomCheck IsRoomFree(DateTime start, DateTime end, BookingResource room, int assignmentID)
        {
            if (end <= start)
                throw new Exception("Intervallo date non corretto per la verifica di assegnazioni già presenti");

            if (room == null)
                throw new Exception("Stanza non specificata per la verifica di assegnazioni già presenti");


            end = end.Date;
            start = start.Date;

            //cerco tutte le assegnazioni per una data camera che intersecano strettamente il periodo considerato
            //cosi facendo ottengo tutte le assegnazioni che si sovrappongono ad una potenziale assegnazione nel periodo
            //considerato.

            //l'input assignmentId serve per il caso in cui sto aggiornando una assegnazione esistente e il check
            //va fatto non considerando la presenza dell'assegnazione in questione
            Query q = _ps.CreateNewQuery("MapperAssignment");

            CompositeCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);
            //criterio per la verifica della sovrapposizioe delle assegnazioni
            c.AddCriteria(Criteria.DateRangeStrictlyIntersects("StartDate", "EndDate", start, end, DataAccessServices.Instance().PersistenceFacade .DBType));
            //criterio sulla camera
            c.AddCriteria(Criteria.Equal("Id_Resource", room.Id.ToString()));

            //in caso di modifica
            if (assignmentID > 0)
            {
                NotExp exp = new NotExp(Criteria.Equal("ID", assignmentID.ToString()));
                c.AddCriteria(exp);
            }

            q.AddWhereClause(c);


            string p = q.CreateQuery(_ps);
            IList results =  q.Execute(_ps);

            FreeRoomCheck cc = new FreeRoomCheck();
            cc.IsFree = results.Count == 0;

            if (cc.IsFree)
                return cc;

            return ConstructObject(results, cc, start,end,room);
        }

        private FreeRoomCheck ConstructObject(IList results, FreeRoomCheck cc,DateTime start, DateTime end, BookingResource room)
        {
            string message1 = string.Format("La camera {0} risulta occupata nel periodo dal {1} al {2}{3}", room.Descrizione, start.ToShortDateString(), end.ToShortDateString(), Environment.NewLine);

            DateTime[] listOfDays = GetIntervalListOfDays(start, end);
            ArrayList listOffreeDays = new ArrayList();


            foreach (DateTime item in listOfDays)
            {
                if (IsFreeDay(results, item))
                    listOffreeDays.Add(item);
            }

            if (listOffreeDays.Count == 0)
                cc.Message = message1;
            else
                cc.Message = ConstructMessage(message1, listOffreeDays, room);

            return cc;
        }

        private string ConstructMessage(string message1, ArrayList listOffreeDays, BookingResource room)
        {
            string message2 = string.Format("La stanza {0} non è disponibile nei giorni seguenti: {1}",room.Descrizione , Environment.NewLine );

            StringBuilder bb = new StringBuilder();

            foreach (DateTime item in listOffreeDays)
            {
                bb.AppendLine(item.ToShortDateString());
            }

            return string.Format("{0}{1}{2}", message1, message2, bb.ToString());

        }

        private bool IsFreeDay(IList results, DateTime date)
        {
            foreach (Assignment item in results)
            {
                if (item.IsDayContained(date))
                    return true;
            }
            return false;
        }

        private  DateTime[] GetIntervalListOfDays(DateTime start, DateTime end)
        {
            TimeSpan sp = end.Subtract(start);

            DateTime[] dates = new DateTime[sp.Days];
            int i = 0;
            while (start < end)
            {
                DateTime temp = start;
                dates[i] = temp;
                i++;
                start = start.AddDays(1);
            }
            return dates;
        }



        public IList ExecuteQuery(IList<IsearchDTO> criterias, int maxQueryresult)
        {
            _bindableResults = new BindingList<Assignment >();

            Query q = _ps.CreateNewQuery("MapperAssignment");

            q.SetTable("Book_Assignment");
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
            foreach (Assignment  item in l)
            {
                
                _bindableResults.Add(item);
            }

            return l;

        }


        public IList GetArrivalsAndDepartures(DateTime date , bool arrivals)
        {
            IList result = null;

            
            Query q = _ps.CreateNewQuery("MapperAssignment");

            AbstractBoolCriteria c = new CompositeCriteria(AbstractBoolCriteria.Operatore.AndOp);

            if (arrivals)
            {
                c.AddCriteria(Criteria.DateEqual ("StartDate", date.Date,_ps.DBType));
            }
            else
            {
                c.AddCriteria(Criteria.DateEqual("EndDate", date.Date, _ps.DBType));
            }


            q.AddWhereClause(c);


            result = q.Execute(_ps);


            IList l = new ArrayList();


            foreach (Assignment item in result)
            {
                l.Add(new Arrival(item));
            }


            return l;


        }


        //public IList GetAssignmentsByUser(string customerId)
        //{
        //    _bindableResults = new BindingList<Assignment >();

        //    if (string.IsNullOrEmpty(customerId))
        //        throw new Exception("Identificativo cliente non valido!");



        //    Query q = _ps.CreateNewQuery("MapperAssignment");


        //    q.AddWhereClause(Criteria.Equal("CustomerID", customerId));


        //    IList l = q.Execute(_ps);

        //    //calcolo lo stato per ogni appp ritornato
        //    foreach (Assignment item in l)
        //    {
        //        _bindableResults.Add(item);
        //    }

        //    return l;

        //}

        public IList GetAssignmentsByCustomerId(int customerId)
        {
            Query q = _ps.CreateNewQuery("MapperAssignment");

            SubQueryCriteria sub = new SubQueryCriteria("Book_Checkin", "Id_Assignment");
  sub.AddCriteria(Criteria.Equal("Id_Contact", customerId.ToString()));
            AbstractBoolCriteria c = Criteria.INClause("ID", sub);
          

            q.AddWhereClause(c);

            string l = q.CreateQuery(_ps);

            return q.Execute(_ps);
        }
    }

    public class FreeRoomCheck
    {
        public bool IsFree { get; set; }
        public string Message { get; set; }
    }
}
