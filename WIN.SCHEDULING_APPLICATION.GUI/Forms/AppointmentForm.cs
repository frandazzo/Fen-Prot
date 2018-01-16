using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SECURITY.Attributes;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SECURITY;
using WIN.SECURITY.Exceptions;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    [SecureContext()]
    public partial class AppointmentForm : DevExpress.XtraEditors.XtraForm
    {
         private MyAppointment _current;
        private bool _initializing = false;
        bool _changed = false;
        Customer _customer;
     //   Customer _sugestedCustomer;


        public MyAppointment Appointment
        {
            get
            {
                return _current;
            }
        }

        public AppointmentForm(Customer c)
        {
            _customer = c;
            SimpleConstruction();
           
        }


        public AppointmentForm()
        {
            SimpleConstruction();
        }

        private void SimpleConstruction()
        {
            _initializing = true;
            try
            {
                InitializeComponent();
                PrepareForLoading();
                dataLayoutControl1.Visible = true;
                //proprietà di interfaccia per la gestione del rapporto
                SetCreateRapportoGUIVisibility(false);
                SetCreateRapportoGUIButtonVisibility(false);
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

        [Secure(Area = "Appuntamenti", Alias = "Visualizza appuntamento da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForView()
        {
            SecurityManager.Instance.Check();
        }


        public AppointmentForm(MyAppointment c)
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
                    SetRapportoGUI();
                }
                else
                {
                    dataLayoutControl1.Visible = true;
                    //proprietà di interfaccia per la gestione del rapporto
                    SetCreateRapportoGUIVisibility(false);
                    SetCreateRapportoGUIButtonVisibility(false);
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

        private void LoadEditors()
        {
            if (_current != null)
            {
                //calcolo le proprietà dello stato dell'appuntamento
                _current.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
                SetAppointmentStatusInfoData();


                //inserisco i parametri abituali
                txtSub.EditValue = _current.Subject;
                cboZon.EditValue = _current.Resource;
                txtCust.EditValue = _current.Customer;
                //tengo il cliente sincronizzto con la button edit
                _customer = _current.Customer;

                txtLoc.EditValue = _current.Location;
                cboCaus.EditValue = _current.Label;
                cboOp.EditValue = _current.Operator;

                dtpIni.EditValue = _current.StartDate.Date;
                dtpFin.EditValue = _current.EndDate.Date;
                timini.Time = new DateTime(_current.StartDate.TimeOfDay.Ticks);
                timfin.Time = new DateTime(_current.EndDate.TimeOfDay.Ticks);

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
                chkClosed.Checked = _current.IsClosed;
            }
        }

        private void PrepareForLoading()
        {
            //Carico le combo

            LoadComboZone();
            LoadComboCausali();
            LoadComboOperatori();
            LoadComboEsiti();

            //imposto il cliente, la zona, il luogo di default se il cliente è presente

            txtSub.EditValue = Properties.Settings.Default.Main_CalendarSubject;
            if (_customer != null)
            {
                txtCust.EditValue = _customer;
                txtLoc.EditValue = string.Format("{0} {1} {2}", _customer.Residenza.Via, _customer.Residenza.Cap, _customer.Residenza.Comune.Descrizione);
                cboZon.EditValue = _customer.Resource;
                txtNote.EditValue = _customer.OtherDataSummary;
            }
            else
            {
                txtCust.EditValue = null;
                txtLoc.EditValue = "";
                txtNote.EditValue = "";
            }




            //carico la data e l'ora iniziale
            AppointmentDateValidator v = AppointmentUtils.GetProposedDate();

            dtpIni.EditValue = v.StartDate;
            dtpFin.EditValue = v.EndDate;

            timini.Time = new DateTime(v.StartDate.TimeOfDay.Ticks);
            timfin.Time = new DateTime(v.EndDate.TimeOfDay.Ticks);

            ////imposto le note
            //txtNote.EditValue = "";


            //imposto i valori per il rapporto
            dtpOut.EditValue = null;
            chkClosed.Checked = false;



            txtNoteRapp.EditValue = "";

        }

        private void SaveOrUpdate()
        {
            if (_current == null)
                return;
                //inserisco i parametri abituali
            _current.Subject = txtSub.Text;
            _current.Resource = cboZon.SelectedItem as Resource;
            _current.Customer = txtCust.EditValue as Customer;
            _current.Location = txtLoc.Text;
            _current.Label = cboCaus.SelectedItem as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
            _current.Operator = cboOp.SelectedItem as Operator;
            _current.StartDate = dtpIni.DateTime.Date + timini.Time.TimeOfDay;
            _current.EndDate = dtpFin.DateTime.Date + timfin.Time.TimeOfDay;
            _current.Description = txtNote.Text;


            if (dtpOut.EditValue == null)
            {
                _current.OutcomeDate = DateTime.MinValue;
            }
            else
            {
                _current.OutcomeDate = dtpOut.DateTime;
            }
            _current.Outcome = cboOut.SelectedItem as Outcome;
            _current.OutcomeDescription = txtNoteRapp.Text;
            _current.IsClosed = chkClosed.Checked;


        
            //imposto i parametri di base
            _current.AppointmentType = 0;
            _current.AllDay = false;
            _current.StatusId = 0;
            _current.LabelId = 0;
            _current.ResourceId = 0;
            _current.RecurrenceInfo = "";
            _current.ReminderInfo = "";
        


            AppointmentHandler h = new AppointmentHandler();
            h.SaveOrUpdate(_current);



            _current.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
        }

        private MyAppointment CreateDummyApp()
        {
            MyAppointment controller = new MyAppointment();
            controller.Subject = txtSub.Text;
            controller.Location = txtLoc.Text;
            controller.Description = txtNote.Text;
            controller.ResourceId = (cboZon.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource).Id;
            //controller.SetStatus(edStatus.Status);
            //controller.SetLabel(appointmentLabelEdit1.Label);
            //controller.AllDay = this.checkAllDay.Checked;
            controller.StartDate = this.dtpIni.DateTime.Date + this.timini.Time.TimeOfDay;
            controller.EndDate = this.dtpFin.DateTime.Date + this.timfin.Time.TimeOfDay;
            controller.Resource = cboZon.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
            controller.Label = cboCaus.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
            controller.Customer = txtCust.EditValue as Customer;
            controller.Operator = cboOp.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator;


            if (dtpOut.EditValue == null)
            {
                controller.OutcomeDate = DateTime.MinValue;
            }
            else
            {
                controller.CreateRapporto();
                controller.OutcomeDate = dtpOut.DateTime;
                
            }
            controller.Outcome = cboOut.SelectedItem as Outcome;
            controller.Description = txtNoteRapp.Text;
            controller.IsClosed = chkClosed.Checked;

            controller.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
            controller.Key = new Key(-1);
            return controller;
        }

        private void SaveAll()
        {
            if (_current == null || _current.Key == null)
            {

                _current = new MyAppointment();
                CheckSecurityForInsert();
            }
            else
            {
                //CheckSecurityForUpdate();
            }


            SaveOrUpdate();

            this.Text = _current.Subject ;
            _changed = false;
        }






        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAll();
                SetAppointmentStatusInfoData();
                SetAppointmentStatusInfoVisible(true);
                SetRapportoGUI();
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

        [Secure(Area = "Appuntamenti", Alias = "Inserisci appuntamenti da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForInsert()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }


        [Secure(Area = "Appuntamenti", Alias = "Aggiorna appuntamento da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForUpdate()
        {
            SecurityManager.Instance.Check();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.AppointmentReport c = new WIN.SCHEDULING_APP.GUI.Reports.AppointmentReport();
                ArrayList l = new ArrayList();

                l.Add(CreateDummyApp());

                c.DataSource = l;
                c.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
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



        #region Funzioni per il caricamento iniziale


        private void LoadComboZone()
        {
            //preparo la combo delle zone
            cboZon.Properties.Items.Clear();

            ResourceHandler h = new ResourceHandler();
            //la riempio
            cboZon.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboZon.SelectedIndex = 0;
        }


        private void LoadComboCausali()
        {
            //preparo la combo delle zone
            cboCaus.Properties.Items.Clear();

            LabelHandler h = new LabelHandler();
            //la riempio
            cboCaus.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboCaus.SelectedIndex = 0;
        }


        private void LoadComboOperatori()
        {
            //preparo la combo delle zone
            cboOp.Properties.Items.Clear();

            OperatorHandler h = new OperatorHandler();
            //la riempio
            cboOp.Properties.Items.Add("");
            cboOp.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboOp.SelectedIndex = 0;
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

        #endregion



        #region gestione Comando di creazione rapporto

        private void cmdCreateRapporto_Click(object sender, EventArgs e)
        {
            ManageRapporto();
        }

        private void ManageRapporto()
        {
            try
            {

                if (_current != null)
                {
                    if (_current.OutcomeCreated)
                    {
                        if (XtraMessageBox.Show("L'eliminazione del rapporto causerà la perdita dei dati esistenti. Vuoi proseguire?", "Elimina rapporto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //elimino il rapporto
                            _current.CancelRapporto();
                            AdjustRapportoGUI();
                            return;
                        }
                        //l''utente ha scelto di no
                        return;
                    }

                    //creo il rapporto
                    _current.CreateRapporto();
                    AdjustRapportoGUI();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        #endregion




        #region Gestione inerfaccia Rapporto
        private void AdjustRapportoGUI()
        {
            SetRapportoGUI();
            ClearRapportoGUIEditors();
            StartChangeOperation();
        }

        private void ClearRapportoGUIEditors()
        {
            if (_current.OutcomeCreated)
                dtpOut.EditValue = DateTime.Now;
            else
                dtpOut.EditValue = null;
            txtNoteRapp.EditValue = "";
            chkClosed.Checked = false;
            cboOut.EditValue = null;
        }


        private void SetCreateRapportoButtonAppearence()
        {
            if (_current == null)
            {
                SetCreateRapportoButtonCreationViewInfo(true);
                return;
            }

            if (_current.OutcomeCreated)
            {
                SetCreateRapportoButtonCreationViewInfo(false);
            }
            else
            {
                SetCreateRapportoButtonCreationViewInfo(true);
            }
        }

        private void SetCreateRapportoButtonCreationViewInfo(bool p)
        {
            if (!p)
            {
                cmdCreateRapporto.Text = "Annulla rapporto appuntamento";
                cmdCreateRapporto.ToolTip = "Annulla il rapporto per l'appuntamento.";
                cmdCreateRapporto.ImageIndex = 0;
            }
            else
            {
                cmdCreateRapporto.Text = "Crea rapporto appuntamento";
                cmdCreateRapporto.ToolTip = "Crea un rapporto per l'appuntamento che specifichi l'esito e l'eventuale conclusione dell'impegno.";
                cmdCreateRapporto.ImageIndex = 1;
            }
        }



        private void SetCreateRapportoGUIButtonVisibility(bool visible)
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

        private void SetCreateRapportoGUIVisibility(bool visible)
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

        private void SetRapportoGUI()
        {
            if (_current.OutcomeCreated)
            {
                SetCreateRapportoGUIVisibility(true);
                SetCreateRapportoGUIButtonVisibility(true);
            }
            else
            {
                SetCreateRapportoGUIVisibility(false);
                SetCreateRapportoGUIButtonVisibility(true);
            }
            SetCreateRapportoButtonAppearence();
        }

        #endregion




        #region Gestione validazione date appuntamento

        bool IsIntervalValid()
        {
            DateTime start = dtpIni.DateTime + timini.Time.TimeOfDay;
            DateTime end = dtpFin.DateTime + timfin.Time.TimeOfDay;
            return end >= start;
        }

        #endregion

        #region gestione stato appuntamento


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


        private void SetAppointmentStatusInfoData()
        {
            if (_current != null)
            {
                SetImageState();
                lblStato.Text = string.Format("Appuntamento: {0}", _current.StateToString.ToUpper());
                lblnote.Text = _current.DeadlineNotes;
            }
        }

        private void SetImageState()
        {
            switch (_current.State)
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

        #endregion

        private void cmdCreateRapporto_Click_1(object sender, EventArgs e)
        {
            ManageRapporto();
        }


        private void txtSub_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtCust_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboZon_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtLoc_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboCaus_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void dtpIni_EditValueChanged(object sender, EventArgs e)
        {
            ////codice per la validazione delle date
            //if (!m_IsLoading)
            //    if (_current!= null)
            //        _current.StartDate = dtpIni.DateTime.Date + timini.Time.TimeOfDay;
            //UpdateAppointmentInterval();

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

            ////codice per la validazione delle date
            //if (m_IsLoading) return;
            //if (_current != null)
            //{
            //    if (IsIntervalValid())
            //        _current.EndDate = dtpFin.DateTime.Date + timfin.Time.TimeOfDay;
            //    else
            //        dtpFin.EditValue = _current.EndDate.Date;
            //}

            StartChangeOperation();
        }

        private void timini_EditValueChanged(object sender, EventArgs e)
        {

            StartChangeOperation();
        }


        private void timfin_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtNote_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void dtpOut_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboOut_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void chkClosed_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtNoteRapp_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
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
                    if (Properties.Settings.Default.Main_FillAppointmentLocationWithCustomerAddress)
                    {
                        txtLoc.EditValue = string.Format("{0} {1} {2}", _customer.Residenza.Via, _customer.Residenza.Cap, _customer.Residenza.Comune.Descrizione);
                    }
                    cboZon.EditValue = _customer.Resource;
                    txtNote.EditValue = _customer.OtherDataSummary;
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ApplicationUtility.Instance.ShowObjectInfo(_current);
        }
    
    }
}