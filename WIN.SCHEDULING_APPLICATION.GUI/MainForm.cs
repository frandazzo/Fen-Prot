using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.Collections;
using DevExpress.XtraBars.Helpers;
using Microsoft.VisualBasic;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.GUI.UTILITY;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Commands;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APP.GUI.SecurityComponents;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using DevExpress.XtraBars.Localization;
using WIN.SCHEDULING_APP.GUI.Commands.Specifics;
using WIN.SCHEDULING_APP.GUI.Licensing;
using WIN.SCHEDULING_APP.GUI.Licensing.LicenceManaging;
using WIN.TECHNICAL.DEPLOYMENT;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.HANDLERS.DBHandlers;
using WIN.SECURITY.Exceptions;

using WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess;


namespace WIN.SCHEDULING_APP.GUI
{
  


    [SecureContext()]
    public partial class MainForm : XtraForm
    {
        private NavigationUtils _navUtil;
        string _customerId = "";

        public MainForm()
        {
            InitializeComponent();
           
        }
        public MainForm(string customerId)
        {
            InitializeComponent();
            _customerId = customerId;

        }

        internal NavigationUtils  NavigatorUtility
        {
            get { return _navUtil; }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            sItem1.Caption = "Data: "+  DateTime.Now.ToShortDateString();
            sItem2.Caption = "Ora: " + DateTime.Now.ToLongTimeString();
        }

        private void iSelectPrinter_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.OpenPrinterSelectionForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NetworkCredentials.Instance().NetworkDomain = Properties.Settings.Default.networkdomain;
            NetworkCredentials.Instance().NetworkUsername = Properties.Settings.Default.networkusername;
            NetworkCredentials.Instance().NetworkPassord = Properties.Settings.Default.networkpassword;
            //NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            //p.UncFileExist(@"\\DESKTOP-E9KNOCC\ciccio\ciccio.txt");

            //initialize skinning properties
            barManager.ForceInitialize();
            MyBarLocalizer.Active = new MyBarLocalizer();
            SkinHelper.InitSkinPopupMenu(mPaintStyle);


            //initialize navigator
            _navUtil = new NavigationUtils(splitContainerControl.Panel2, this);

            //renders startup controls
            if (_customerId == "")
                _navUtil.NavigateToStartupControl(Properties.Settings.Default.Main_StartCommand);
            else
            {
                try
                {
                    IOpenCommand cmd = new CustomerCommand(this);
                    Hashtable h = new Hashtable();
                    h.Add("Id", _customerId);
                    cmd.Execute(h);
                    HistoryOfCommands.Instance().AddCommandToHistory(cmd);
                    MemoryHelper.ReduceMemory();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(ex);
                    _navUtil.NavigateToStartupControl(Properties.Settings.Default.Main_StartCommand);
                }

            }

            //sets the caption text
            this.Text = "Gestionale appuntamenti - " + Properties.Settings.Default.Main_AppName;

            //sets the name of the current logged user
            string nome = ((User)(SecurityManager.Instance.CurrentUser)).Username;
            sItem.Caption = string.Format("Benvenuto: {0}!", nome);

            if (DataAccessServices.Instance().PersistenceFacade.DBType == DB.DBType.Access)
            {
                // barRipristina.Visibility = BarItemVisibility.Always;ù
                barButtonbackup.Visibility = BarItemVisibility.Always;
                UpdateLastBackInfo();
                barBack.Visibility = BarItemVisibility.Always;
            }
            else
            {
                //barRipristina.Visibility = BarItemVisibility.Never;
                barButtonbackup.Visibility = BarItemVisibility.Never;
                barBack.Visibility = BarItemVisibility.Never;
            }



            //sets initial view
            splitContainerControl.Collapsed = Properties.Settings.Default.Main_PanelCollapsed;
            administration.Visible = !Properties.Settings.Default.Main_ShowOnlyAgendaFunctions;
        }

        private void UpdateLastBackInfo()
        {
           
            TimeSpan ts = DateTime.Now - Properties.Settings.Default.Main_LastBack;

            if (ts.Days >= 7)
            {
                barButtonbackup.Caption = string.Format("ATTENZIONE!!! Ultimo backup effettuato più di sette giorni fa! ({0}) Eseguire nuovamente il backup! ", Properties.Settings.Default.Main_LastBack.ToLongDateString());
                 barButtonbackup.Appearance.ForeColor = Color.Red;
            }
            else
            {
                 barButtonbackup.Caption = string.Format("Ultimo backup effettuato: {0}", Properties.Settings.Default.Main_LastBack.ToLongDateString());
                 barButtonbackup.Appearance.ForeColor = Color.Black;
            }
            
        }



        // Custom localizer that changes skin captions 
        //public class MyBarLocalizer : BarLocalizer
        //{
        //    public override string GetLocalizedString(BarString id)
        //    {
        //        if (id == BarString.SkinCaptions)
        //        {
        //            //Default value for BarString.SkinCaptions:
        //            //"|DevExpress Style|Caramel|Money Twins|The Asphalt World|iMaginary|Lilian|Black|Blue|Office 2010 Blue|Office 2010 Black|Office 2010 Silver|Office 2007 Blue|Office 2007 Black|Office 2007 Silver|Office 2007 Green|Office 2007 Pink|Seven|Seven Classic|Darkroom|McSkin|Sharp|Sharp Plus|Foggy|Dark Side|Xmas (Blue)|Springtime|Summer|Pumpkin|Valentine|Stardust|Coffee|Glass Oceans|High Contrast|Liquid Sky|London Liquid Sky|"
        //            string defaultSkinCaptions = base.GetLocalizedString(id);
        //            string newSkinCaptions = defaultSkinCaptions.Replace("|DevExpress Style|", "|Noesis|");
        //            return newSkinCaptions;
        //        }
        //        return base.GetLocalizedString(id);
        //    }


        //}


        private void inboxItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ApplicationUtility.Instance.OpenRoleForm();
        }

        

        private void outboxItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ApplicationUtility.Instance.OpenProfileForm();
        }

      
        private void iNewApp_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.OpenNewApplicationInstance();
        }

        private void iBig_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void iSmall_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_navUtil.CheckBeforeExit () == DialogResult.OK)
                this.Close();
        }

        private void iTele_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.OpenNoesisComunicationTool();
        }

        private void iNovita_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.OpenApplicationInfoFile();
        }

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.OpenApplicationInfoForm();
        }

        private void iNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    _navUtil.Current.StartCreateOperation();
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler.Show(ex);
            //}
            CreateContact();
        }

        private void CreateContact()
        {
            try
            {
                CustomerForm frm = new CustomerForm();
                frm.ShowDialog();

                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void iCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (_navUtil.Current.State.StateName == "Creazione")
            //{
            //    _navUtil.NavigateToPrevious();
            //}
            //else
            //{
            //    _navUtil.Current.StartUndoOperation();
            //}
            CreateAppointment();
        }

        private void CreateAppointment()
        {
            try
            {
                AppointmentForm frm = new AppointmentForm();
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void iSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    _navUtil.Current.StartSaveOperation();
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler.Show(ex);
            //}


            CreateTask();
        }

        private void CreateTask()
        {
            try
            {
                TaskForm frm = new TaskForm();
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void idel_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    _navUtil.Current.StartDeleteOperation();
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler.Show(ex);
            //}
            CreateDocument();
        }

        private void iPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _navUtil.Current.Print();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void iInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
             try
            {
                _navUtil.Current.GetInfo();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void labels_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Labels);
        }

        

        private void iHome_ItemClick(object sender, ItemClickEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Home);
        }

        private void iBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            _navUtil.NavigateToPrevious();
        }

        private void iNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            _navUtil.NavigateToNext();
        }

        private void ioptions_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.OpenOpzioniForm();
        }

        private void outcomes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Outcomes);
        }

        private void operators_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Operators);
        }

        private void zone_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Resources);
        }

        private void customersItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                FormRicercaCliente c = new FormRicercaCliente();
                if (c.ShowDialog() == DialogResult.OK)
                {
                    _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Contacts, c.SelectedCustomer.Id);
                }
                c.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            
        }

        private void createApp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //_navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Appointments);
            CreateAppointment();
        }

        private void reportItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.AppointmentReport);
        }

        private void calendarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.AppointmentCalendar);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //_navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Activities);
            CreateTask();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.TaskReport);
        }

        private void doctypes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.DocumentTypes);
        }

        private void DocFolders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.DocumentScopes);
        }

        private void navBarItem3doc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CreateDocument();
        }

        private static void CreateDocument()
        {
            try
            {
                DocumentForm frm = new DocumentForm();
                frm.CheckSecurityForInsert();
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void navBarItem3reportdoc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.DocumentReport);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                InstallationForm frm = InstallationFormFactory.GetFormOnViewLicenceOrUpdateIfIsTrial(InstallationManager.Instance.Licence.HardwareId);
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CreateContact();
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ApplicationUtility.Instance.OpenCambiaPasswordForm();
        }

        private void barBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ExecuteBackup();
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        [Secure(Area = "Protezione", Alias = "Backup database", MacroArea = "Archivi")]
        private  void ExecuteBackup()
        {
            SecurityManager.Instance.Check();
            AccessDBUtils.BackupDB();
            Properties.Settings.Default.Main_LastBack = DateTime.Now;
            Properties.Settings.Default.Save();
            UpdateLastBackInfo();
            XtraMessageBox.Show("Backup eseguito correttamente!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void administration_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Administration);
        }

        private void calendar1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingCalendar);
        }

        private void BookingResources_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingResources);
        }

        private void bookingType_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingTypes);
        }

        private void roomstatistic_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingStats);
        }

        private void bedTypes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingBedTypes);
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            try
            {
                FrmArrivedPersons frm = new FrmArrivedPersons();
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
          
            
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                FrmArrivals frm = new FrmArrivals();
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                FrmDepartures frm = new FrmDepartures();
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
             _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingReport);
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _navUtil.NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType.BookingPaymentReport);
        }

        private void navBarControl_Click(object sender, EventArgs e)
        {

        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            try
            {
                //WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.exe
                string asmPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(asmPath);

                string fold = f.DirectoryName;

                DirectoryInfo dirinfo = new DirectoryInfo(fold);

                fold = dirinfo.Parent.FullName;

                string progName = fold + @"\FenealConnector\WIN.WEBCONNECTOR.exe";


                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(progName);
                p.StartInfo.UseShellExecute = false;
                p.Start();


            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);

            }
        }


   


    
        

    }
}