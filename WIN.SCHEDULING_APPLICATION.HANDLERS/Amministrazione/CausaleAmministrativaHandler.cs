using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;
using System.Collections;
using System.ComponentModel;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class CausaleAmministrativaHandler : SimpletHandler 
    {
        public override string ObjectTypeName
        {
            get { return "CausaleAmministrativa"; }
        }

        public System.ComponentModel.IBindingList GetAllAsBinbingList(DOMAIN.Amministrazione.TipoMovimernto type)
        {
            int inputType = System.Convert.ToInt32(type);



            IList l = SetAndExecuteQuery(inputType);

            return TransformToBindingList(l);

        }

        private IList SetAndExecuteQuery(int type)
        {
            Query q = _ps.CreateNewQuery("Mapper" + ObjectTypeName);

            q.AddWhereClause(Criteria.Equal("TipoCausale", type.ToString()));


            OrderByCriteria c = new OrderByCriteria();
            c.AddCriteria(Criteria.SortCriteria("Descrizione", true));

            q.AddOrderByClause(c);


            IList l = q.Execute(_ps);
            return l;
        }

        private  IBindingList TransformToBindingList(IList l)
        {
            IBindingList res = new BindingList<CausaleAmministrativa>();

            foreach (CausaleAmministrativa item in l)
            {
                res.Add(item);
            }

            return res;
        }
    }
}
