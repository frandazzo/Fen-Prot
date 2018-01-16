using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.BASEREUSE;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    [SecureContext()]
    public  abstract class SimpletHandler : ISimpleHandler 
    {
        protected IPersistenceFacade _ps;

        public SimpletHandler()
        {
            _ps = DataAccessServices.Instance().PersistenceFacade;
        }



      

        #region IComboElementHandler Membri di

        public virtual System.Collections.IList GetAll()
        {
            return _ps.GetAllObjects(ObjectTypeName);
        }

        public virtual AbstractPersistenceObject GetElementById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            int id1 = -1;
            id1 = Convert(id);

            if (id1 == -1)
                return null;

            return _ps.GetObjectReloadingCache(ObjectTypeName, id1) as AbstractPersistenceObject;
        }

        protected int Convert(string id)
        {
            try
            {
                 return int.Parse(id);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual void SaveOrUpdate(AbstractPersistenceObject element)
        {
            if (element == null)
                return;

            if (element.Key == null)
                _ps.InsertObject(ObjectTypeName, element);
            else
                _ps.UpdateObject(ObjectTypeName, element);


       
        }

        public virtual void Delete(AbstractPersistenceObject element)
        {
            if (element == null)
                return;

            if (element.Key == null)
                return;

            _ps.DeleteObject(ObjectTypeName, element);
        }



        public abstract string ObjectTypeName{get;}


        #endregion
    }
}
