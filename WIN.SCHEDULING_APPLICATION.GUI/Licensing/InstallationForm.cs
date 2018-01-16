using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.TECHNICAL.DEPLOYMENT.CORE.LICENCE;
//using WIN.TECHNICAL.UTILS.DomainTypes;
//using WIN.VIGILANTES.PRESENTATION.Forms.LicenceManaging;
//using WIN.VIGILANTES.PRESENTATION.Utils;
using WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    public partial class InstallationForm : XtraForm
    {
        private ILicenceManagementStrategy _initializerStrategy;
        private LicenceTypes _typeRequested =  LicenceTypes.Unknown;
        private string _hardwareId;

        private const string FirstMessage = @"Grazie per aver scelto {0} e benvenuto nel processo di attivazione del prodotto. Lei potrà utilizzare il prodotto in versione di prova per un periodo di 30 giorni oppure inserire un codice di attivazione che potra richiedere alla Noesis s.n.c.  al numero di telefono 0835/387202.";


        private const string SecondMessage = @"Ogni licenza sia essa provvisoria o definitiva è da considerarsi come licenza per macchina, nel senso che il processo di attivazione verrà richiesto su ogni macchina su cui il prodotto verrà installato. Se un codice di attivazione è stato già inserito su una specifica macchina,  esso sarà mostrato all'avvio dell'applicazione insieme con tutte le altre informazioni relative la licenza acquistata. ";
                                        

        public InstallationForm(ILicenceManagementStrategy strategy,string hardwareId)
        {
            InitializeComponent();
            _initializerStrategy = strategy;
            _hardwareId = hardwareId;
            label3.Text = string.Format(FirstMessage, Properties.Settings.Default.Main_AppName);
            label4.Text = SecondMessage;
            txtHardwareId.Text = hardwareId;

        }

     


        public LicenceTypes TypeOfRequestedLicence
        {
            get { return _typeRequested; }
            set { _typeRequested = value; }
        }

        private void InstallationForm_Load(object sender, EventArgs e)
        {
            _initializerStrategy.InitializeInterface(this);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _initializerStrategy.CloseDialog(this);
        }

        private void cmdInstall_Click(object sender, EventArgs e)
        {
            try
            {
                _initializerStrategy.SaveLicence(this);
            }
            //catch (ValidationException ex1)
            //{
            //    Helper.ThrowValidationErrorMessage(ex1);
            //}
            catch (Exception ex)
            {
                //Helper.ThrowGenericErrorMessage(ex);
                ErrorHandler.Show(ex);
            }
            
        }

        private void cmdTrial_Click(object sender, EventArgs e)
        {
            _initializerStrategy.RequestTrial(this);
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            _initializerStrategy.InsertActivationCode(this);
        }



       
    }
}