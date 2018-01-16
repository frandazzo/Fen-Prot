using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using System.Collections;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    [SecureContext()]
    public partial class TaskForm : DevExpress.XtraEditors.XtraForm
    {
           bool viewDetails = !Properties.Settings.Default.Main_ViewTaskDetails;
            private MyTask _current;
            private bool _initializing = false;
            bool _changed = false;
            Customer _customer;


        [Secure(Area = "Attività", Alias = "Visualizza attività da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForView()
        {
            SecurityManager.Instance.Check();
        }
        public MyTask CurrentTask
        {
            get
            {
                return _current;
            }
        }


        public TaskForm(MyTask c)
        {
            _initializing = true;
            try
            {
                InitializeComponent();
                PrepareForLoading();
                _current = c;
                if (_current != null)
                {
                    LoadEditors();
                    SetDetailsGUI();
                }
                else
                {
                    dataLayoutControl1.Visible = true;
                    //proprietà di interfaccia per la gestione del rapporto
                    SetDetailsGUIVisibility(false);
                    SetDetailsGUIButtonVisibility(false);
                    SetAppointmentStatusInfoVisible(false);
                }
               
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            finally
            {
                _initializing = false;
            }
           

        }



        public MyTask Task
        {
            get
            {
                return _current;
            }
        }

        public TaskForm()
        {
            Initialize();
        }


        public TaskForm(Customer c)
        {
            _customer = c;
            Initialize();
        }


        private void Initialize()
        {
            _initializing = true;
            try
            {
                InitializeComponent();
                PrepareForLoading();

                dataLayoutControl1.Visible = true;
                //proprietà di interfaccia per la gestione del rapporto
                SetDetailsGUIVisibility(false);
                SetDetailsGUIButtonVisibility(false);
                SetAppointmentStatusInfoVisible(false);

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            finally
            {
                _initializing = false;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAll();
                SetDetailsGUI();
                SetAppointmentStatusInfoData();
                SetAppointmentStatusInfoVisible(true);
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

        [Secure(Area = "Attività", Alias = "Inserisci attività da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForInsert()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }


        [Secure(Area = "Attività", Alias = "Aggiorna attività da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForUpdate()
        {
            SecurityManager.Instance.Check();
        }

        private void SaveAll()
        {
            if (_current == null || _current.Key == null)
            {

                _current = new MyTask();
                CheckSecurityForInsert();
            }
            else
            {
                //CheckSecurityForUpdate();
            }


            SaveOrUpdate();

            this.Text = _current.Subject;
            _changed = false;
        }

    

        public void StartChangeOperation()
        {
            if (_initializing)
                return;

            if (_current != null)
            {
                if (_changed == false)
                {
                    _changed = true;
                    this.Text += "  (Salvare le modifiche per renderle effettive!)";
                    SetAppointmentStatusInfoVisible(false);
                }
            }
           
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (_changed)
            {
                DialogResult c = XtraMessageBox.Show("Salvare i dati prima di chiudere?", "Domanda", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    try
                    {
                        SaveOrUpdate();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.Show(ex);
                    }
                    return;
                }
                else if (c == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                else
                {
                    return;
                }
            }

            if (_current != null)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
            this.Close();
                 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.TaskReport c = new WIN.SCHEDULING_APP.GUI.Reports.TaskReport();
                ArrayList l = new ArrayList();

                l.Add(CreateDummyTask());

                c.DataSource = l;
                c.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

         private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAll();

                this.DialogResult = DialogResult.OK;
                this.Close();

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

         private void LoadComboEsiti()
         {
             //preparo la combo delle zone
             cboOut.Properties.Items.Clear();

             OutcomeHandler h = new OutcomeHandler();
             //la riempio
             cboOut.Properties.Items.Add("");
             cboOut.Properties.Items.AddRange(h.GetAll());

             //seleziono quella iniziale
             cboOut.SelectedIndex = 0;
         }



         private void LoadEditors()
         {
             if (_current != null)
             {
                 //calcolo le proprietà dello stato dell'appuntamento
                 _current.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
                 SetAppointmentStatusInfoData();


                 //inserisco i parametri abituali
                 txtSub.EditValue = _current.Subject;
                 txtCust.EditValue = _current.Customer;
                 //tengo il cliente sincronizzto con la button edit
                 _customer = _current.Customer;

                 dtpIni.EditValue = _current.StartDate.Date;
                 dtpFin.EditValue = _current.EndDate.Date;


                 cboPriority.EditValue = _current.Priority.ToString();
                 cboState.EditValue = _current.ActivityState.ToString();
                 spPerc.EditValue = _current.PercentageCompleteness;



                 txtNote.EditValue = _current.Description;

                 if (_current.OutcomeDate == DateTime.MinValue)
                 {
                     dtpOut.EditValue = null;
                 }
                 else
                 {
                     dtpOut.EditValue = _current.OutcomeDate;
                 }
                 cboOut.EditValue = _current.Outcome;
                 txtNoteRapp.EditValue = _current.OutcomeDescription;
                 //chkClosed.Checked = _current.IsClosed;
             }
         }

         private void SetAppointmentStatusInfoData()
         {
             if (_current != null)
             {
                 SetImageState();
                 lblStato.Text = string.Format("Attività: {0}", _current.ActivityDeadlineStateToString.ToUpper());
                 lblnote.Text = _current.DeadlineNotes;
             }
         }

         private void SetImageState()
         {
             switch (_current.ActivityDeadlineState)
             {
                 case AppointmentState.Pianificato:
                     pictureEdit1.Image = imageCollection1.Images[0];
                     break;
                 case AppointmentState.In_Scadenza:
                     pictureEdit1.Image = imageCollection1.Images[1];
                     break;
                 case AppointmentState.Scade_Oggi:
                     pictureEdit1.Image = imageCollection1.Images[2];
                     break;
                 case AppointmentState.Scaduto:
                     pictureEdit1.Image = imageCollection1.Images[3];
                     break;
                 case AppointmentState.Eseguito:
                     pictureEdit1.Image = imageCollection1.Images[4];
                     break;
                 case AppointmentState.Concluso:
                     pictureEdit1.Image = imageCollection1.Images[5];
                     break;
                 default:
                     break;
             }
         }


        private void PrepareForLoading()
        {
            LoadComboEsiti();

            //imposto il cliente, la zona, il luogo di default se il cliente è presente

            txtSub.EditValue = Properties.Settings.Default.Main_TaskSubject;
            
            txtCust.EditValue = _customer;
            txtNote.EditValue = "";

            cboPriority.SelectedIndex = 1;
            cboState.SelectedIndex = 0;
            spPerc.EditValue = 0;

            dtpIni.EditValue = DateTime.Now.Date;
            dtpFin.EditValue = DateTime.Now.Date;


            dtpOut.EditValue = null;
            txtNoteRapp.EditValue = "";




        }

        private void SaveOrUpdate()
        {
            //inserisco i parametri abituali
            _current.Subject = txtSub.Text;
            //_current.Resource = cboZon.SelectedItem as Resource;
            _current.Customer = txtCust.EditValue as Customer;
            //_current.Location = txtLoc.Text;
            //_current.Label = cboCaus.SelectedItem as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
            //_current.Operator = cboOp.SelectedItem as Operator;
            DataRange h1 = AppointmentUtils.CreateRangeForQuery(new DataRange(dtpIni.DateTime.Date, dtpFin.DateTime.Date));
            _current.StartDate = h1.Start;
            //artificio per evitare l'arrotondamento dei comandi ado su sql
            _current.EndDate = h1.Finish.AddMinutes(-1);
            _current.Description = txtNote.Text;


            _current.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), cboPriority.Text);
            _current.ActivityState = (ActivityState)Enum.Parse(typeof(ActivityState), cboState.Text);
            _current.PercentageCompleteness = Convert.ToInt32(spPerc.EditValue);



            if (dtpOut.EditValue == null)
                _current.OutcomeDate = DateTime.MinValue;
            else
                _current.OutcomeDate = dtpOut.DateTime;

            _current.Outcome = cboOut.SelectedItem as Outcome;
            _current.OutcomeDescription = txtNoteRapp.Text;


            TaskHandler h = new TaskHandler();
            h.SaveOrUpdate(_current);


            _current.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
        }
        private object CreateDummyTask()
        {
            MyTask c = new MyTask();
            //inserisco i parametri abituali
            c.Subject = txtSub.Text;
            //_current.Resource = cboZon.SelectedItem as Resource;
            c.Customer = txtCust.EditValue as Customer;
            //_current.Location = txtLoc.Text;
            //_current.Label = cboCaus.SelectedItem as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
            //_current.Operator = cboOp.SelectedItem as Operator;
            DataRange h1 = AppointmentUtils.CreateRangeForQuery(new DataRange(dtpIni.DateTime.Date, dtpFin.DateTime.Date));
            c.StartDate = h1.Start;
            //artificio per evitare l'arrotondamento dei comandi ado su sql
            c.EndDate = h1.Finish.AddMinutes(-1);
            c.Description = txtNote.Text;


            c.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), cboPriority.Text);
            c.ActivityState = (ActivityState)Enum.Parse(typeof(ActivityState), cboState.Text);
            c.PercentageCompleteness = Convert.ToInt32(spPerc.EditValue);



            if (dtpOut.EditValue == null)
                c.OutcomeDate = DateTime.MinValue;
            else
                c.OutcomeDate = dtpOut.DateTime;

            c.Outcome = cboOut.SelectedItem as Outcome;
            c.OutcomeDescription = txtNoteRapp.Text;

            c.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);

            return c;
        }

        private void cmdCreateRapporto_Click(object sender, EventArgs e)
        {
            ManageDetailsVisibility();
        }

        private void ManageDetailsVisibility()
        {
            try
            {

                SetDetailsGUI();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


      




        #region Gestione interfaccia dettagli



        private void SetDetailsButtonAppearence()
        {
            if (_current == null)
            {
                SetDetailsButtonCreationViewInfo(true);
                return;
            }

            if (viewDetails)
            {
                SetDetailsButtonCreationViewInfo(false);
                //viewDetails = true;
            }
            else
            {
                SetDetailsButtonCreationViewInfo(true);
                //viewDetails = false;
            }
        }

        private void SetDetailsButtonCreationViewInfo(bool p)
        {
            if (!p)
            {
                cmdCreateRapporto.Text = "Nascondi dettagli";
                cmdCreateRapporto.ToolTip = "Nasconde i dettagli dell'attività.";
                cmdCreateRapporto.ImageIndex = 4;
            }
            else
            {
                cmdCreateRapporto.Text = "Visualizza dettagli";
                cmdCreateRapporto.ToolTip = "Visualizza i dettagli dell'attività";
                cmdCreateRapporto.ImageIndex = 3;
            }
        }



        private void SetDetailsGUIButtonVisibility(bool visible)
        {
            if (visible)
            {
                layoutControlItemCreateRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlItemCreateRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void SetDetailsGUIVisibility(bool visible)
        {
            if (visible)
            {
                layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void SetDetailsGUI()
        {
            if (!viewDetails)
            {
                SetDetailsGUIVisibility(true);
                SetDetailsGUIButtonVisibility(true);
                viewDetails = true;
            }
            else
            {
                SetDetailsGUIVisibility(false);
                SetDetailsGUIButtonVisibility(true);
                viewDetails = false;
            }
            SetDetailsButtonAppearence();
        }

        #endregion




        private void txtSub_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtCust_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        //private void cboZon_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    StartChangeOperation();
        //}

        //private void txtLoc_EditValueChanged(object sender, EventArgs e)
        //{
        //    StartChangeOperation();
        //}

        //private void cboCaus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    StartChangeOperation();
        //}

        //private void cboOp_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    StartChangeOperation();
        //}

        private void dtpIni_EditValueChanged(object sender, EventArgs e)
        {
            if (!_initializing )
            {
                if (dtpIni.DateTime.Date > dtpFin.DateTime.Date)
                {
                    _initializing = true;
                    dtpFin.EditValue = dtpIni.DateTime.Date;
                    _initializing = false;
                }
            }


            StartChangeOperation();
        }

        private void dtpFin_EditValueChanged(object sender, EventArgs e)
        {

            if (!_initializing)
            {
                if (dtpIni.DateTime.Date > dtpFin.DateTime.Date)
                {
                    _initializing = true;
                    dtpFin.EditValue = dtpIni.DateTime.Date;
                    _initializing = false;
                }
            }
            StartChangeOperation();
        }



        private void txtNote_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void dtpOut_EditValueChanged(object sender, EventArgs e)
        {
            if (!_initializing)
            {

                _initializing = true;

                if (dtpOut.EditValue != null)
                {
                    //rinfresco i dati
                    cboState.EditValue = "Completata";
                    spPerc.EditValue = 100;
                }
                else
                {
                    cboState.EditValue = "In_Corso";
                    spPerc.EditValue = 0;
                }

                _initializing = false;
            }
            StartChangeOperation();
        }

        private void cboOut_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }


        private void txtNoteRapp_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_initializing)
            {
                _initializing = true;
                if (cboState.Text == "Completata")
                {
                    //rinfresco i dati
                    spPerc.EditValue = 100;
                    dtpOut.EditValue = DateTime.Now;
                }
                else if (cboState.Text == "Non_Iniziata")
                {
                    //rinfresco i dati
                    spPerc.EditValue = 0;
                    dtpOut.EditValue = null;
                }
                else
                {
                    if (Convert.ToInt32(spPerc.EditValue) == 100)
                        spPerc.EditValue = 75;
                    dtpOut.EditValue = null;
                }
                _initializing = false;
            }

            StartChangeOperation();
        }

        private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void spPerc_EditValueChanged(object sender, EventArgs e)
        {
            if (!_initializing)
            {
                _initializing = true;
                if (Convert.ToInt32(spPerc.EditValue) == 100)
                {
                    //rinfresco i dati
                    cboState.EditValue = "Completata";
                    dtpOut.EditValue = DateTime.Now;
                }
                else if (Convert.ToInt32(spPerc.EditValue) == 0)
                {
                    //rinfresco i dati
                    cboState.EditValue = "Non_Iniziata";
                    dtpOut.EditValue = null;
                }
                else
                {
                    if (cboState.Text == "Completata" || cboState.Text == "Non_Iniziata")
                        cboState.EditValue = "In_Corso";
                    dtpOut.EditValue = null;
                }
                _initializing = false;
            }

            StartChangeOperation();
        }

        private void txtCust_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                //pulsante di ricerca cliente
                SearchCustomer();
            }
            else if (e.Button.Index == 1)
            {
                //pulsante di annullamento cliente
                _customer = null;
                txtCust.EditValue = null;
            }
            else if (e.Button.Index == 2)
            {
                //modifico l'elemento


                if (_customer == null)
                    return;
                else
                {
                    CustomerForm frm = new CustomerForm(_customer);
                    try
                    {
                        frm.CheckSecurityForView();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            txtCust.EditValue = frm.Customer;
                            _customer = frm.Customer;
                        }
                    }
                    catch (AccessDeniedException)
                    {
                        XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                //new creo uno nuovo
                CustomerForm frm = new CustomerForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtCust.EditValue = frm.Customer;
                    _customer = frm.Customer;
                }

            }
        }


        private void SearchCustomer()
        {
            try
            {
                WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtCust.EditValue = frm.SelectedCustomer;
                    _customer = frm.SelectedCustomer;
                    txtNote.EditValue = _customer.OtherDataSummary;
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        private void SetAppointmentStatusInfoVisible(bool visible)
        {
            if (visible)
            {
                emptySpaceItemheader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblnotelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblstatelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                imageLayloutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                emptySpaceItemheader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lblnotelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lblstatelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                imageLayloutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            ApplicationUtility.Instance.ShowObjectInfo(_current);
        }

    }
}