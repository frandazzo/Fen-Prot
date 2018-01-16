using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.TECHNICAL.DEPLOYMENT.CORE;

namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public class InstallationInfoFactory : IInstallationInfoFactory
    {

        //private string _hardwareId;

        //public InstallationInfoFactory(string hardwareId)
        //{
        //    _hardwareId = hardwareId;
        //}
        //private IInstallInfo _info;

        //public  void SetBuyer(ISoftwareBuyer buyer)
        //{
        //    IInstallInfo info = InstallationManager.Instance.InstallationInfo;
        //    info.Buyer = buyer;
        //}

        //public  void SetLicence(ILicence licence)
        //{
        //    IInstallInfo info = InstallationManager.Instance.InstallationInfo;
        //    info.Licence = licence;
        //}

        public  IInstallInfo CreateInstallationInfo()
        {
            InstallationInfo i = new InstallationInfo(); ;
            return i;
        }

    }
}
