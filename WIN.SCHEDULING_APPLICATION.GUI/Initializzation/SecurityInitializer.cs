using System;
using System.Collections.Generic;
using System.Text;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public class SecurityInitializer : IInitialize
    {
        #region IInitialize Membri di

        public void Initialize()
        {
            StringBuilder b = new StringBuilder();
            try
            {
                b.AppendLine("Avvio inizializzazione sicurezza");
                SecurityManager m;
                try
                {
                    
                     m = SecurityManager.Instance;
                    b.AppendLine("Recupero istanza securityManager");
                }
                catch (Exception ex1)
                {
                    throw new Exception("Errore nel recupero dell'istanza del security mamager", ex1);
                    
                }

                try
                {
                    m.AddAssembly(typeof(Program).Assembly);
                    b.AppendLine("Assembly Programm_- aggiunto al servizio di siurezza");
                }
                catch (Exception ex2)
                {
                    
                     throw new Exception("Errore nel nell'aggiunta DELL'ASSEMBLY CORRENTE al security mamager", ex2);
                    
                }

               
                SecurityManager.Instance.SecureDataAccess = new SecureDataManager();
                //Tracer.Instance.TraceIf(Tracer.Instance.TraceSwitch.TraceVerbose, "Inizializzazione servizi di sicurezza", false);
            }
            catch (Exception ex)
            {
                //Tracer.Instance.TraceIf(Tracer.Instance.TraceSwitch.TraceWarning, "Impossibile inizializzare i servizi di sicurezza dell'applicazione", false);
                //Tracer.Instance.TraceIf(Tracer.Instance.TraceSwitch.TraceError, ex.Message, true);

                
                throw new Exception("Impossibile inizializzare i servizi di sicurezza dell'applicazione: ", ex);
            }
        }

        public InitializzationType Type
        {
            get { return InitializzationType.Security; }
        }

        #endregion
    }
}