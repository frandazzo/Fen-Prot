using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public class PersistenceInitializer : IInitialize
    {
        #region IInitialize Membri di

        public void Initialize()
        {
            try
            {
            IPersistenceFacade ps = DataAccessServices.Instance().PersistenceFacade;

            if (ps == null)
                throw new Exception("Servizio di persistenza non impostato");
            }
            catch (Exception ex)
            {
                //Tracer.Instance.TraceIf(Tracer.Instance.TraceSwitch.TraceWarning, "Impossibile inizializzare i servizi di persistenza dell'applicazione", false);
                //Tracer.Instance.TraceIf(Tracer.Instance.TraceSwitch.TraceError, ex.Message, true);
                throw new Exception( "Impossibile inizializzare i servizi di persistenza dell'applicazione", ex);
            }
        }

        public InitializzationType Type
        {
            get { return InitializzationType.Persistence; }
        }

        #endregion
    }
}
