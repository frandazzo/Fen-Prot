using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using WIN.SCHEDULING_APP.GUI.Initializzation;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APP.GUI.SecurityComponents;
using WIN.SECURITY;
using System.Threading;
using System.Diagnostics;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.SCHEDULING_APP.GUI.Licensing;


namespace WIN.SCHEDULING_APP.GUI
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] cmdArgs)
        {

             string parameterUserName  = "";
             string parameterPassword  = "";
             bool _exitApplication = false;    
            

            try
            {
                //avvio il thread per il recupero dell'id dell'hardware
                HardwareIdRetriever _retriever = new HardwareIdRetriever();
                Thread t = new Thread(_retriever.RetrieveHardwareId);
                t.Start();

                //Inizializzo gli stili dell'applicazione
                ManageApplicationStyles();

                //inizializzo l'applicazione
                MaangeInitializzation();
               
                //attendo la fine del recupero dell'id dell'hardware
                t.Join();

                //una volta ottenuto l'id hardware posso verificarlo
                ManageLicensing(_retriever, ref _exitApplication);

                //se non ho una licenza valida esco!!!
                if (_exitApplication)
                    return;

                //avvio l'applicazione
                if (cmdArgs.Length > 0)
                {
                     parameterUserName = cmdArgs[0];
                     parameterPassword = cmdArgs[1];

                     if (!SecurityManager.Instance.Logon(parameterUserName, parameterPassword))
                         return;
                     if (cmdArgs.Length == 3)
                         Application.Run(new MainForm(cmdArgs[2]));
                     else
                        Application.Run(new MainForm());
                }
                else
                {

                    LoginForm frm = new LoginForm();
                    if (frm.ShowDialog() == DialogResult.OK)
                        Application.Run(new MainForm());

                }
            }
            catch (Exception ex)
            {
               
                ErrorHandler.Show(ex);
            }

            
        }

        private static void ManageLicensing(HardwareIdRetriever _retriever, ref bool _exitApplication)
        {

            //a questo punto posso inizializzare il modulo per il licensing
            LicensingInitializer licensing = new LicensingInitializer(_retriever.HardwareId);
            licensing.Initialize();


            //verifico le licenze e vedo se posso continuare o devo chiudere l'applicazione
            bool licenceIsValid = !InstallationManager.Instance.IsLicenceValid();
            FirstRunActivationCodeAction command = new FirstRunActivationCodeAction(InstallationManager.Instance.IsFirstApplicationRun, licenceIsValid,_retriever.HardwareId );
            command.Execute();
            _exitApplication = command.CloseApplication;
        }

        private static void MaangeInitializzation()
        {
            Initializer i = new Initializer();
            i.InitializeApplication();
        }

        private static void ManageApplicationStyles()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevexpressInitializzation();
        }

        private static void DevexpressInitializzation()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.Main_AppStyleName);
            UserLookAndFeel.Default.StyleChanged += new EventHandler(Default_StyleChanged);
        }

        static void Default_StyleChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Main_AppStyleName = UserLookAndFeel.Default.ActiveSkinName;
            Properties.Settings.Default.Save();
        }
    }
}