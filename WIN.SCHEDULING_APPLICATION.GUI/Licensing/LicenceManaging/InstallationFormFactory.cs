using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT;


namespace WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging
{
    public class InstallationFormFactory
    {

        public static InstallationForm GetFormOnViewLicenceOrUpdateIfIsTrial( string hardwareId)
        {

            if (InstallationManager.Instance.IsLicenceTrial())
                return new InstallationForm(new SetNewCodeManagementStrategy(), hardwareId);
            return new InstallationForm(new ViewPermanentLicenceStrategy(), hardwareId );


        }


        internal static InstallationForm GetFormOnFirstApplicationRunOrInvalidLicence(bool isFirstRun, bool isLicenceNotValid, string hardwareId)
        {
            if (isFirstRun == true)
            {
                return new InstallationForm(new FirstRunManagementStrategy(), hardwareId);
            }
            if (isLicenceNotValid)
            {
                return new InstallationForm(new LicenceNotValidManagementStrategy(), hardwareId);
            }
            return null;
        }
    }
}
