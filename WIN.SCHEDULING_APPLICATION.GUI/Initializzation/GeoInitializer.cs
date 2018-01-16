using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public class GeoInitializer : IInitialize
    {
        #region IInitialize Membri di

        public void Initialize()
        {
            GeoLocationFacade.InitializeInstance(new GeoHandler(DataAccessServices.Instance().PersistenceFacade));
        }

        public InitializzationType Type
        {
            get { return InitializzationType.Geo; }
        }

        #endregion
    }
}
