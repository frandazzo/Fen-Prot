using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT;

using WIN.TECHNICAL.DEPLOYMENT.CORE;
using WIN.TECHNICAL.PERSISTENCE;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing;

namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public class InstallInfoPersister : IInstallInfoPersister
    {

        private string _hardwareId;
      

        public InstallInfoPersister(string hardwareId)
        {
            _hardwareId = hardwareId;
           
        }


        #region IInstallInfoPersister Membri di

        public IInstallInfo GetInstallInfo()
        {
            IPersistenceFacade svc = DataAccessServices.Instance().PersistenceFacade;
            Query q = svc.CreateNewQuery("MapperLicInfo");
            q.AddWhereClause(Criteria.MatchesEqual("HardwareId",_hardwareId ,svc.DBType));
            IList i = q.Execute(svc);
            if (i.Count == 0)
                return null;
            return (IInstallInfo)((LicInfo)i[0]).InstallationInfo;
        }

        public void Insert(IInstallInfo info)
        {
            IPersistenceFacade svc = DataAccessServices.Instance().PersistenceFacade;
            LicInfo i = new LicInfo(info as InstallationInfo);
            svc.InsertObject("LicInfo", i);

        }

        public void Update(IInstallInfo info)
        {
            IPersistenceFacade svc = DataAccessServices.Instance().PersistenceFacade;
            LicInfo i = new LicInfo(info as InstallationInfo);
            svc.UpdateObject("LicInfo", i);
        }

        #endregion
    }
}
