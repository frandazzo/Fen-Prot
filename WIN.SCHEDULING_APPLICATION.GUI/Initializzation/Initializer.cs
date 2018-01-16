using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public class Initializer
    {
        private IList<IInitialize> _initializers = new List<IInitialize>();
        public IList<IInitialize> Initializers
        {
            get { return _initializers = new List<IInitialize>(); }
        }


        public Initializer()
        {
         
            _initializers.Add(new PersistenceInitializer());
            _initializers.Add(new SecurityInitializer());
            _initializers.Add(new GeoInitializer());
            _initializers.Add(new PrimaryDocumentScopeInitializzation());

        }

        public void InitializeApplication()
        {
            foreach (IInitialize elem in _initializers)
                elem.Initialize();
        }

    }
}
