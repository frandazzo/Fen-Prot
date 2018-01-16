using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.TECHNICAL.DEPLOYMENT.CORE;

namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public class SoftwareBuyerFactory
    {
        public static ISoftwareBuyer CreateSoftwareBuyer(string name, string mail)
        {
            ISoftwareBuyer buy = new SoftwareBuyer();
            buy.CustomerName = name;
            buy.Mail = mail;
            return buy;
        }
    }
}
