using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.TECHNICAL.PERSISTENCE;
//using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class AbstractAmministrazioneHandler : SimpletHandler
    {

        public override string ObjectTypeName
        {
            get { return ""; }
        }


        protected IBindingList _bindableResults = new BindingList<AbstractMovimentoContabile>();


        public IList ExecuteQuery(IList<IsearchDTO> criterias)
        {
            _bindableResults = new BindingList<AbstractMovimentoContabile>();

            Query q = _ps.CreateNewQuery("Mapper" + ObjectTypeName);

            //q.SetTable("App_Appointments");


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


            //creo la binding list
            foreach (AbstractMovimentoContabile item in l)
            {
                _bindableResults.Add(item);
            }

            return l;

        }


        public IBindingList BindableResults
        {
            get
            { return _bindableResults; }

        }
    }
}
