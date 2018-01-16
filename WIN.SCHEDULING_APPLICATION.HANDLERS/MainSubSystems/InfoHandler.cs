using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems
{
    public class InfoHandler
    {
        private static InfoHandler _instance;

        private InfoHandler()
        {

        }

        public static InfoHandler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InfoHandler();
                return _instance;
            }
        }

        public SoftwareInfo GetInfo()
        {
            IPersistenceFacade ps = DataAccessServices.Instance().PersistenceFacade;

            return ps.GetObject("SoftwareInfo", 1) as SoftwareInfo;

        }



    }
}
