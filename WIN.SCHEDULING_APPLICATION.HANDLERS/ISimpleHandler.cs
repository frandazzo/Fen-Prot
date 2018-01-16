using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    public interface ISimpleHandler
    {
        IList GetAll();
        AbstractPersistenceObject GetElementById(string id);
        void SaveOrUpdate(AbstractPersistenceObject element);
        void Delete(AbstractPersistenceObject element);
        string ObjectTypeName{get;}
    }
}
