using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.TECHNICAL.DEPLOYMENT.CORE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Licensing
{
    public class LicInfo : AbstractPersistenceObject
    {

        public LicInfo(InstallationInfo info)
        {
            _installationInfo = info;
            if (info.Id > 0)
                base.Key = new Key(info.Id);
        }


        private InstallationInfo _installationInfo;

        public InstallationInfo InstallationInfo
        {
            get
            {
                return _installationInfo;
            }
        }


        protected override void DoValidation()
        {
            if (_installationInfo == null)
            {
                ValidationErrors.Add("Record info licenza non valido!");
                return;
            }


            string errors = _installationInfo.GetValidationMessage();

            if (!string.IsNullOrEmpty(errors))
                ValidationErrors.Add(errors);
        }

    }
}
