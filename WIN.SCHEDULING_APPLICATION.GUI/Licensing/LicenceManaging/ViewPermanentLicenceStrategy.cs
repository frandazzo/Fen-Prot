using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.TECHNICAL.DEPLOYMENT.CORE.LICENCE;


namespace WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging
{
    public class ViewPermanentLicenceStrategy : ILicenceManagementStrategy
    {
        #region ILicenceFormInitializerStrategy Membri di

        public void InitializeInterface(InstallationForm form)
        {
            ILicence l = InstallationManager.Instance.Licence;

            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = false;
            form.cmdTrial.Enabled = false;
            form.cmdAll.Enabled = false;

            form.txtCode.Enabled = false;
            form.txtCode.Text = l.ActivationCode;

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = l.TypeToString();
            //form.lblScadenza.Text = "ATTENZIONE! Licenza scaduta. Inserire un codice di attivazione.";
            form.lblScadenza.Visible = false;
            form.txtTrial.Enabled = false;
            form.txtTrial.Text = "0";

            form.txtRagSoc.Enabled = false;
            form.txtRagSoc.Text = InstallationManager.Instance.Buyer.CustomerName;

            form.txtMail.Enabled = false;
            form.txtMail.Text = InstallationManager.Instance.Buyer.Mail;

            form.TypeOfRequestedLicence = LicenceTypes.All;
            form.txtLicenceType.Text = "FULL";


            form.txtHardwareId.Text = InstallationManager.Instance.Licence.HardwareId;

        }

        #endregion

        #region ILicenceManagementStrategy Membri di


        public void CloseDialog(InstallationForm form)
        {
            form.Close();
        }

        public void SaveLicence(InstallationForm form)
        {
            //
        }


        public void InsertActivationCode(InstallationForm form)
        {
            //
        }

        public void RequestTrial(InstallationForm form)
        {
            //
        }

        #endregion
    }
}
