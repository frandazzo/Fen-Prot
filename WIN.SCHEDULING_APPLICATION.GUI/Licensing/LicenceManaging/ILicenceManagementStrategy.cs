using System;
using System.Collections.Generic;
using System.Text;


namespace WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging
{
    public interface ILicenceManagementStrategy
    {
        void InitializeInterface(InstallationForm form);
        void CloseDialog(InstallationForm form);
        void SaveLicence(InstallationForm form);
        void InsertActivationCode(InstallationForm form);
        void RequestTrial(InstallationForm form);

    }
}
