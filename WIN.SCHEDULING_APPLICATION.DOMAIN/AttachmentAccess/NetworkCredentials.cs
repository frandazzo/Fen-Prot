using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess
{
    public class NetworkCredentials
    {
        private static NetworkCredentials _instance;

        public static NetworkCredentials Instance()
        {
            if (_instance == null)
                _instance = new NetworkCredentials();

            return _instance;
        }

        private NetworkCredentials() { }


        public string NetworkUsername { get; set; }
        public string NetworkPassord { get; set; }
        public string NetworkDomain { get; set; }


    }
}
