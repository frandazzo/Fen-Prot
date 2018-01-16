using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WIN.TECHNICAL.DEPLOYMENT.CORE.LICENCE;
using WIN.TECHNICAL.DEPLOYMENT;

using WIN.TECHNICAL.DEPLOYMENT.CORE;
using WIN.TECHNICAL.DEPLOYMENT.EXCEPTIONS;

namespace WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging
{
    public class SetNewCodeManagementStrategy : ILicenceManagementStrategy 
    {
        #region ILicenceFormInitializerStrategy Membri di

        public void InitializeInterface(InstallationForm form)
        {
            ILicence l = InstallationManager.Instance.Licence;

            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = false;
            form.cmdTrial.Enabled = false;
            form.cmdAll.Enabled = true;

            form.txtCode.Enabled = false;
            //form.txtCode.Text = l.ActivationCode;

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = l.TypeToString();
            form.lblScadenza.Text = "ATTENZIONE! La licenza di prova scadrà tra " + l.RemainingDays.ToString() + " giorni.";
            form.lblScadenza.Visible = true;
            form.txtTrial.Enabled = false;
            form.txtTrial.Text = l.TrialDays.ToString();

            form.txtRagSoc.Enabled = true;
            form.txtRagSoc.Text = InstallationManager.Instance.Buyer.CustomerName;

            form.txtMail.Enabled = true;
            form.txtMail.Text = InstallationManager.Instance.Buyer.Mail;

            form.txtLicenceType.Text = "PROVA";

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
            if (form.TypeOfRequestedLicence != LicenceTypes.All)
            {
                MessageBox.Show("Impostare correttamente i dati di attivazione!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                InstallationManager.Instance.ActivateProduct(new BaseActivatorHandler(), form.txtHardwareId.Text, form.txtCode.Text);

                UpdateLicence(form);
            }
            catch (NotValidActivationCodeException)
            {
                SendWarningMessage(form);
            }
           
                
               
           
        }

        private void UpdateLicence(InstallationForm form)
        {
            InstallationManager.Instance.Licence = LicenceFactory.CreateFullLicence(DateTime.Now, form.txtCode.Text, form.txtHardwareId.Text );
            InstallationManager.Instance.Buyer = SoftwareBuyerFactory.CreateSoftwareBuyer(form.txtRagSoc.Text, form.txtMail.Text);
            InstallationManager.Instance.UpdateInstallInfo();
            SendConfirmMessage();
            form.DialogResult = DialogResult.OK;
            form.Close();
        }



        private void SendConfirmMessage()
        {
            MessageBox.Show("Complimenti! Il codice di attivazione è corretto e il prodotto è stato attivato correttamente", "Attivazione prodotto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //private bool CheckActivation(string publicKey, string code)
        //{
        //    BaseActivatorHandler h = new BaseActivatorHandler();
        //    h.SetCodeToValidate(code);
        //    h.SetPublicKey(publicKey);
        //    return h.IsActivationCodeValid();
        //}

        private void SendWarningMessage(InstallationForm form)
        {
            MessageBox.Show("Inserire i dati corretti. Verificare l'inserimento corretto del nome azienda e della mail. Verificare l'esattezza del codice inserito.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void InsertActivationCode(InstallationForm form)
        {
            ILicence l = InstallationManager.Instance.Licence;
            form.TypeOfRequestedLicence = LicenceTypes.All;
            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = true;
            form.cmdTrial.Enabled = true;
            form.cmdAll.Enabled = false;

            form.txtCode.Enabled = true;
            form.txtCode.Text = "";

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = "FULL";

            form.txtTrial.Enabled = false;
            form.txtTrial.Text = "";

            form.txtRagSoc.Enabled = true;
            form.txtMail.Enabled = true;
        }

        public void RequestTrial(InstallationForm form)
        {
            ILicence l = InstallationManager.Instance.Licence;
            form.TypeOfRequestedLicence = LicenceTypes.Trial;
            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = false;
            form.cmdTrial.Enabled = false;
            form.cmdAll.Enabled = true;

            form.txtCode.Enabled = false;
            //form.txtCode.Text = l.ActivationCode;

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = l.TypeToString();
            form.lblScadenza.Text = "ATTENZIONE! La licenza di prova scadrà tra " + l.TrialDays.ToString() + " giorni.";
            form.lblScadenza.Visible = true;
            form.txtTrial.Enabled = false;
            form.txtTrial.Text = l.TrialDays.ToString();

            form.txtRagSoc.Enabled = true;
            form.txtRagSoc.Text = InstallationManager.Instance.Buyer.CustomerName;

            form.txtMail.Enabled = true;
            form.txtMail.Text = InstallationManager.Instance.Buyer.Mail;

            form.txtLicenceType.Text = "PROVA";

        }

        #endregion
    }
}
