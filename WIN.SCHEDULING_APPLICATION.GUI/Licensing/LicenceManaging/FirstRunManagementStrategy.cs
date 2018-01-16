using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WIN.TECHNICAL.DEPLOYMENT.CORE.LICENCE;

using WIN.TECHNICAL.DEPLOYMENT;
using WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging;
using WIN.SCHEDULING_APP.GUI.Licensing;
using WIN.TECHNICAL.DEPLOYMENT.CORE;
using WIN.TECHNICAL.DEPLOYMENT.EXCEPTIONS;

namespace WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging
{
    public class FirstRunManagementStrategy : ILicenceManagementStrategy
    {
        #region ILicenceFormInitializerStrategy Membri di


       


        public void InitializeInterface(InstallationForm form)
        {
            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = false;
            form.cmdTrial.Enabled = true;
            form.cmdAll.Enabled = true;

            form.txtCode.Enabled = false;
            form.txtCode.Text = "";

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = "";

            form.txtTrial.Enabled = false;
            form.txtTrial.Text = "";

            form.txtRagSoc.Enabled = true;
            form.txtRagSoc.Text = "";

            form.txtMail.Enabled = true;
            form.txtMail.Text = "";
        }

        #endregion



        #region ILicenceManagementStrategy Membri di


        public void CloseDialog(InstallationForm form)
        {
            form.Close();
        }

        public void SaveLicence(InstallationForm form)
        {
            if (form.TypeOfRequestedLicence == LicenceTypes.Unknown)
            {
                MessageBox.Show("Selezionare una modalità di attivazione!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try 
	        {
                if (form.TypeOfRequestedLicence != LicenceTypes.Trial)
                {
                    InstallationManager.Instance.ActivateProduct(new BaseActivatorHandler(), form.txtHardwareId.Text, form.txtCode.Text);
                }
                Save(form);
	        }
	        catch (NotValidActivationCodeException)
	        {
        		SendWarningMessage(form);
	        }
        }

        private void Save(InstallationForm form)
        {
            InstallationManager.Instance.Licence = LicenceFactory.CreateLicence(form.TypeOfRequestedLicence, DateTime.Now, form.txtCode.Text, null, 30, form.txtHardwareId.Text );
            InstallationManager.Instance.Buyer = SoftwareBuyerFactory.CreateSoftwareBuyer(form.txtRagSoc.Text, form.txtMail.Text);
            InstallationManager.Instance.InsertInstallInfo();
            SendConfirmMessage(form.TypeOfRequestedLicence);
            form.DialogResult = DialogResult.OK;
            form.Close();
        }

       

        private void SendConfirmMessage(LicenceTypes licenceTypes)
        {
            if (licenceTypes == LicenceTypes.Trial)
            {
                MessageBox.Show("E' stata ottenuta una licenza di prova della durata di 30 giorni. Per rinnovare la licenza chiamare il produttore per richiedere il codice di attivazione!", "Attivazione prodotto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (licenceTypes == LicenceTypes.All)
            {
                MessageBox.Show("Complimenti! Il codice di attivazione è corretto e il prodotto è stato attivato correttamente", "Attivazione prodotto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void SendWarningMessage(InstallationForm form)
        {
            string codeAlert = "";
            if (form.TypeOfRequestedLicence == LicenceTypes.All)
                codeAlert = " Verificare l'esattezza del codice inserito.";

            MessageBox.Show("Inserire i dati corretti. Verificare l'inserimento corretto del nome azienda e della mail. " + codeAlert, "Attenzione",   MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
        }

        public void InsertActivationCode(InstallationForm form)
        {
            form.TypeOfRequestedLicence = LicenceTypes.All;
            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = true;
            form.cmdTrial.Enabled = true;
            form.cmdAll.Enabled = false;

            form.txtCode.Enabled = true;
            form.txtCode.Text = "";

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = "Permanente";

            form.txtTrial.Enabled = false;
            form.txtTrial.Text = "";

            form.txtRagSoc.Enabled = true;


            form.txtMail.Enabled = true;
        }

        public void RequestTrial(InstallationForm form)
        {
            form.TypeOfRequestedLicence = LicenceTypes.Trial;
            form.cmdCancel.Enabled = true;
            form.cmdInstall.Enabled = true;
            form.cmdTrial.Enabled = false;
            form.cmdAll.Enabled = true;

            form.txtCode.Enabled = false;
            form.txtCode.Text = "LICENZA DI PROVA";

            form.txtLicenceType.Enabled = false;
            form.txtLicenceType.Text = "PROVA";

            form.txtTrial.Enabled = false;
            form.txtTrial.Text = "30";

            form.txtRagSoc.Enabled = true;
            

            form.txtMail.Enabled = true;
            
        }

        #endregion
    }
}
