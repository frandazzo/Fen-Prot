using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APP.GUI.SecurityComponents;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APP.GUI
{
    [SecureContext]
    class ApplicationUtility
    {

        private static ApplicationUtility _instance;

        internal static ApplicationUtility Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ApplicationUtility();
                return _instance;
            }
        }

        internal void OpenOpzioniForm()
        {
            FormOpzioni o = new FormOpzioni();
            o.ShowDialog();

        }

        internal void ShowObjectInfo(AbstractPersistenceObject obj)
        {
            
             if (obj!= null)
             {
                 StringBuilder b = new StringBuilder ();
                 b.AppendLine("Creato da - " + obj.CreatoDa);
                 b.AppendLine("Creato in data - " + obj.DataCreazione.ToString());
                 b.AppendLine("Modificato da - " + obj.ModificatoDa);
                 b.AppendLine("Modificato in data - " + obj.DataModifica.ToString());
                 XtraMessageBox.Show(b.ToString(), "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
       
     
      
        }


        [Secure(Area = "Ruoli", Alias = "Gestione", MacroArea = "Sicurezza")]
        internal void OpenRoleForm()
        {
            try
            {
                SecurityManager.Instance.Check();
                FormGestioneRuoli frm = new FormGestioneRuoli();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        [Secure(Area = "Admin password", Alias = "Cambio password", MacroArea = "Sicurezza")]
        internal void OpenCambiaPasswordForm()
        {
            try
            {
                SecurityManager.Instance.Check();
                FrmCambiaPassword frm = new FrmCambiaPassword();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        [Secure(Area = "Profili", Alias = "Gestione", MacroArea = "Sicurezza")]
        internal void OpenProfileForm()
        {
            try
            {
                SecurityManager.Instance.Check();
                FormGestioneProfili frm = new FormGestioneProfili();
                frm.ShowDialog();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        internal void OpenApplicationInfoFile()
        {
            try
            {
                string appPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(appPath);
                string dir = f.DirectoryName;

                string result = dir + "\\Assets\\help.chm";

                if (!File.Exists(result))
                {
                    XtraMessageBox.Show("Funzionalità non installata", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Process.Start(result);
            }
            catch (Exception)
            {
                //
            }
        }



        internal void OpenNewApplicationInstance()
        {
            try
            {
                string username = SecurityManager.Instance.CurrentUser.Username;
                string password = SecurityManager.Instance.CurrentUser.Password;

                string appFile = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

                ProcessStartInfo i = new ProcessStartInfo(appFile, username + " " + password);

                Process.Start(i);
            }
            catch (Exception)
            {
                //
            }
        }



        private ApplicationUtility()
        { }

        internal  void OpenPrinterSelectionForm()
        {
            FrmSelectPrinter frm = new FrmSelectPrinter();
            frm.ShowDialog();
        }

        internal void OpenNoesisComunicationTool()
        {
            try
            {
                string appPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(appPath);
                string dir = f.DirectoryName;

                string result = dir + "\\Assets\\Teleassistenza.exe";
                Process.Start(result);
            }
            catch (Exception)
            {
                //
            }
        }

        internal void OpenApplicationInfoForm()
        {
            FormInformazioni i = new FormInformazioni();
            i.ShowDialog();
        }
    }
}
