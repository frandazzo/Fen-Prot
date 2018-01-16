using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging;



namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public class FirstRunActivationCodeAction : ICommand
    {
        private bool _isFirstRun;
        private bool _isLicenceNotValid;
        private bool  _closeApplication;

        public bool CloseApplication
        { get { return _closeApplication; } }

        public FirstRunActivationCodeAction(bool isFirstRun, bool isLicenceNotValid, string hardwareId)
        {
            _isFirstRun = isFirstRun;
            _isLicenceNotValid = isLicenceNotValid;
            _hardwareId = hardwareId;
        }

        public FirstRunActivationCodeAction(string hardwareId)
        {
            _hardwareId = hardwareId;
        }

        private string _hardwareId;

        #region ICommand Membri di

        public void Execute()
        {
            //Qui apro il form di attivazione 
            if (_isFirstRun )
                InstallationManager.Instance.InstallationInfo.FirstRunDate = DateTime.Now;

            InstallationForm frm = InstallationFormFactory.GetFormOnFirstApplicationRunOrInvalidLicence(_isFirstRun, _isLicenceNotValid, _hardwareId );

            if (frm != null)
            {
                ShowForm(frm);
            }
        }

        private void ShowForm(InstallationForm frm)
        {
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frm.Dispose();
                return;
            }
            //Chiudo l'applicazione se non compilo correttamente il form
            //del codice
            _closeApplication = true;
            frm.Dispose();
        }

        #endregion
    }
}
