using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public class PrimaryDocumentScopeInitializzation : IInitialize
    {
        #region IInitialize Membri di

        public void Initialize()
        {
            DocumentScopeHandler h = new DocumentScopeHandler();
            DocumentScope s = h.GetElementById("1") as DocumentScope;
            if (!s.IsDefaultpathValid)
            {
                //prendo una locazione di default nel file sistem.
                string sp = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                s.DefaultPath = sp;
                h.SaveOrUpdate(s);
            }
        }

        public InitializzationType Type
        {
            get { return InitializzationType.DocScopeInitializzation; }
        }

        #endregion
    }
}
