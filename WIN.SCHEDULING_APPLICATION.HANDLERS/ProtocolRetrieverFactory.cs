using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    public class ProtocolRetrieverFactory
    {
        public static ILastProtocolNumberRetriever GetProtocolRetriever(IPersistenceFacade service, string typeOfRetriever)
        {
            if (typeOfRetriever == "Progressive")
                return new ProtocolRetrieverProgressive(service);
            else
                return new ProtocolRetriever(service);
        
        }
    }
}
