using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.SCHEDULING_APP.GUI.Licensing;
using WIN.TECHNICAL.DEPLOYMENT.CORE;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public class LicensingInitializer : IInitialize
    {
        private string _hardwareId;

        public LicensingInitializer(string hardwareId)
        {
            _hardwareId = hardwareId;
        }


        #region IInitialize Membri di

        public void Initialize()
        {
            
            InstallationManager.Instance.SetPersister(new InstallInfoPersister(_hardwareId));
            InstallationManager.Instance.SetDecisionTreeManager(new DecisionTreeManager(_hardwareId));
            InstallationManager.Instance.SetInstallInfoFactory(new InstallationInfoFactory());
            InstallationManager.Instance.Initialize();
        }

        public InitializzationType Type
        {
            get { return InitializzationType.Licensing; }
        }

        #endregion
    }
}