using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using System.Collections;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraEditors;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APP.GUI.Forms;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
 
//    [SecureContext()]
//    public partial class AppuntamentoControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
//    {
//        //variabile che serve a gestire l'aggiornamento delle proprietà di base
//        //dell'appuntamento che vengono gestite dal calendario
//        bool notUpdateBaseAppParameters = false;

//         MyAppointment _current;
//         Customer _customer;

//        public AppuntamentoControl(MainForm form, Customer customer):base(form)
//        {
//            InitializeComponent();

//            _customer = customer;
//            //avvio le operazioni di creazione
//            StartCreateOperation();

//        }

//        public AppuntamentoControl(int id, MainForm form)
//            : base(form)
//        {
//            InitializeComponent();

//            //avvio le procedure per il caricamento

//            m_IdShowedObject = id;

//            StartLoadOperation();

//        }


//        #region Undo

//        public override void Nested_ReLoadProperties()
//        {
//            StartLoadOperation();
//        }


//        #endregion

//        #region Funzioni per il caricamento iniziale


//        private void LoadComboZone()
//        {
//            //preparo la combo delle zone
//            cboZon.Properties.Items.Clear();

//            ResourceHandler h = new ResourceHandler();
//            //la riempio
//            cboZon.Properties.Items.AddRange(h.GetAll());

//            //seleziono quella iniziale
//            cboZon.SelectedIndex = 0;
//        }


//        private void LoadComboCausali()
//        {
//            //preparo la combo delle zone
//            cboCaus.Properties.Items.Clear();

//            LabelHandler h = new LabelHandler();
//            //la riempio
//            cboCaus.Properties.Items.AddRange(h.GetAll());

//            //seleziono quella iniziale
//            cboCaus.SelectedIndex = 0;
//        }


//        private void LoadComboOperatori()
//        {
//            //preparo la combo delle zone
//            cboOp.Properties.Items.Clear();

//            OperatorHandler h = new OperatorHandler();
//            //la riempio
//            cboOp.Properties.Items.Add("");
//            cboOp.Properties.Items.AddRange(h.GetAll());

//            //seleziono quella iniziale
//            cboOp.SelectedIndex = 0;
//        }

//        private void LoadComboEsiti()
//        {
//            //preparo la combo delle zone
//            cboOut.Properties.Items.Clear();

//            OutcomeHandler h = new OutcomeHandler();
//            //la riempio
//            cboOut.Properties.Items.Add("");
//            cboOut.Properties.Items.AddRange(h.GetAll());

//            //seleziono quella iniziale
//            cboOut.SelectedIndex = 0;
//        }

//        #endregion

//        #region Creation


//        [Secure(Area = "Appuntamenti", Alias = "Crea", MacroArea = "Applicativo")]
//        protected override void Nested_CheckSecurityForCreation()
//        {
//            SecurityManager.Instance.Check();
//        }

//        protected override void Nested_ClearWindowEditors()
//        {
           
//            //Carico le combo

//            LoadComboZone();
//            LoadComboCausali();
//            LoadComboOperatori();
//            LoadComboEsiti();

//            //imposto il cliente, la zona, il luogo di default se il cliente è presente

//            txtSub.EditValue =  Properties.Settings.Default.Main_CalendarSubject;
//            if (_customer != null)
//            {
//                txtCust.EditValue = _customer;
//                txtLoc.EditValue = string.Format("{0} {1} {2}", _customer.IndirizzoSedeLegale.Via, _customer.IndirizzoSedeLegale.Cap, _customer.IndirizzoSedeLegale.Comune.Descrizione);
//                cboZon.EditValue = _customer.Resource;
//                txtNote.EditValue = _customer.OtherDataSummary;
//            }
//            else
//            {
//                txtCust.EditValue = null;
//                txtLoc.EditValue = "";
//                txtNote.EditValue = "";
//            }
            



//            //carico la data e l'ora iniziale
//            AppointmentDateValidator v = AppointmentUtils.GetProposedDate();

//            dtpIni.EditValue = v.StartDate;
//            dtpFin.EditValue = v.EndDate;

//            timini.Time = new DateTime(v.StartDate.TimeOfDay.Ticks);
//            timfin.Time = new DateTime(v.EndDate.TimeOfDay.Ticks);

//            ////imposto le note
//            //txtNote.EditValue = "";


//            //imposto i valori per il rapporto
//            dtpOut.EditValue = null;
//            chkClosed.Checked = false;

            

//            txtNoteRapp.EditValue = "";





//            commandBar1.Custom_SetIdentifier("");
//        }

//        protected override void Nested_PrepareForCreation()
//        {
//            _current = null;
//            dataLayoutControl1.Visible = true;
//            //proprietà di interfaccia per la gestione del rapporto
//            SetCreateRapportoGUIVisibility(false);
//            SetCreateRapportoGUIButtonVisibility(false);
//            SetAppointmentStatusInfoVisible(false);
//        }

     

//        #endregion

//        #region Change
//        [Secure(Area = "Appuntamenti", Alias = "Aggiorna", MacroArea = "Applicativo")]
//        protected override void Nested_CheckSecurityForChanging()
//        {
//            SecurityManager.Instance.Check();
//        }

//        public override void Nested_NotifyParent()
//        {
//            string desc = "";

//            if (_current != null)
//            {
//                desc = _current.Subject;
//            }

//            commandBar1.CustomGUI_SetInterfaceState(commandBar1.Custom_GetCommandBarStateFromGuiState(base.State.StateName));
//            commandBar1.Custom_SetSearchButtonEnabled (false);
//            commandBar1.Custom_SetFunctionName(string.Format(base.State.StateName + " appuntamento: {0}", desc));
//        }


//        public override void StartChangeOperation()
//        {
//            if (m_IsLoading)
//                return;
//            try
//            {
//                base.StartChangeOperation();
//            }
//            catch (AccessDeniedException)
//            {
//                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }



//        protected override void Nested_PostChangeActions()
//        {
//            SetAppointmentStatusInfoVisible(false);
//        }


//     private void txtSub_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void txtCust_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void cboZon_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void txtLoc_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void cboCaus_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void cboOp_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void dtpIni_EditValueChanged(object sender, EventArgs e)
//        {
//            ////codice per la validazione delle date
//            //if (!m_IsLoading)
//            //    if (_current!= null)
//            //        _current.StartDate = dtpIni.DateTime.Date + timini.Time.TimeOfDay;
//            //UpdateAppointmentInterval();

//            if (!m_IsLoading)
//            {
//                if (dtpIni.DateTime.Date > dtpFin.DateTime.Date)
//                {
//                    m_IsLoading = true;
//                    dtpFin.EditValue = dtpIni.DateTime.Date;
//                    m_IsLoading = false;
//                }
//            }


//            StartChangeOperation();
//        }

//        private void dtpFin_EditValueChanged(object sender, EventArgs e)
//        {

//            if (!m_IsLoading)
//            {
//                 if (dtpIni.DateTime.Date > dtpFin.DateTime.Date)
//                 {
//                    m_IsLoading = true;
//                    dtpFin.EditValue = dtpIni.DateTime.Date;
//                    m_IsLoading = false;
//                 }
//            }

//            ////codice per la validazione delle date
//            //if (m_IsLoading) return;
//            //if (_current != null)
//            //{
//            //    if (IsIntervalValid())
//            //        _current.EndDate = dtpFin.DateTime.Date + timfin.Time.TimeOfDay;
//            //    else
//            //        dtpFin.EditValue = _current.EndDate.Date;
//            //}

//            StartChangeOperation();
//        }

//        private void timini_EditValueChanged(object sender, EventArgs e)
//        {

//            StartChangeOperation();
//        }


//        private void timfin_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void txtNote_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void dtpOut_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void cboOut_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void chkClosed_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }

//        private void txtNoteRapp_EditValueChanged(object sender, EventArgs e)
//        {
//            StartChangeOperation();
//        }
//        #endregion

//        #region Salvataggio

//        public override void Nested_InsertData()
//        {
//            _current = new MyAppointment();

//            SaveOrUpdate();

//            m_IdShowedObject = _current.Id;

//        }

//        private void SaveOrUpdate()
//        {
//            //inserisco i parametri abituali
//            _current.Subject = txtSub.Text;
//            _current.Resource  = cboZon.SelectedItem as Resource;
//            _current.Customer = txtCust.EditValue as Customer;
//            _current.Location  = txtLoc.Text;
//            _current.Label = cboCaus.SelectedItem as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
//            _current.Operator = cboOp.SelectedItem as Operator;
//            _current.StartDate = dtpIni.DateTime.Date + timini.Time.TimeOfDay;
//            _current.EndDate = dtpFin.DateTime.Date + timfin.Time.TimeOfDay;
//            _current.Description = txtNote.Text;


//            if (dtpOut.EditValue == null)
//            {
//                _current.OutcomeDate = DateTime.MinValue;
//            }
//            else
//            {
//                _current.OutcomeDate = dtpOut.DateTime;
//            }
//            _current.Outcome = cboOut.SelectedItem as Outcome;
//            _current.OutcomeDescription = txtNoteRapp.Text;
//            _current.IsClosed = chkClosed.Checked;


//            if (!notUpdateBaseAppParameters)
//            {
//                //imposto i parametri di base
//                _current.AppointmentType = 0;
//                _current.AllDay = false;
//                _current.StatusId = 0;
//                _current.LabelId = 0;
//                _current.ResourceId = 0;
//                _current.RecurrenceInfo = "";
//                _current.ReminderInfo = "";
//            }


//            AppointmentHandler h = new AppointmentHandler();
//            h.SaveOrUpdate(_current);
//        }

//        protected override void Nested_PostSaveActions()
//        {
//            Hashtable ParameterList = new Hashtable();
//            ParameterList.Add("Id", m_IdShowedObject);
//            NavigateTo("Appointments", ParameterList, true);
//        }


//        public override void Nested_UpdateData()
//        {
//            try
//            {
//                notUpdateBaseAppParameters = true;
//                SaveOrUpdate();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            finally
//            {
//                notUpdateBaseAppParameters = false;
//            }
            
//        }

//        #endregion

//        #region Visualizzazione

//        protected override void Nested_PrepareLoading()
//        {
//            dataLayoutControl1.Visible = true;


//            //Carico le combo

//            LoadComboZone();
//            LoadComboCausali();
//            LoadComboOperatori();
//            LoadComboEsiti();
           
//            //visualizzo le proprietà per la gestione dell'interfaccia
//            //di creazione rappporto
//            SetCreateRapportoGUIVisibility(true);
//            SetAppointmentStatusInfoVisible(true);
//        }

//        protected override void Nested_LoadDataFromDataSource()
//        {
//            AppointmentHandler h = new AppointmentHandler();
//            _current = h.GetElementById(m_IdShowedObject.ToString()) as MyAppointment;

//            if (_current == null)
//                throw new Exception("Appuntamento non trovato");
//        }

//        protected override void Nested_LoadEditorsProperties()
//        {
//            if (_current != null)
//            {
//                //calcolo le proprietà dello stato dell'appuntamento
//                _current.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
//                SetAppointmentStatusInfoData();


//                //inserisco i parametri abituali
//                txtSub.EditValue =_current.Subject;
//                cboZon.EditValue = _current.Resource;
//                txtCust.EditValue=_current.Customer;
//                //tengo il cliente sincronizzto con la button edit
//                _customer = _current.Customer;

//                txtLoc.EditValue = _current.Location;
//                cboCaus.EditValue  = _current.Label ;
//                cboOp.EditValue = _current.Operator;

//                dtpIni.EditValue = _current.StartDate.Date;
//                dtpFin.EditValue = _current.EndDate.Date;
//                timini.Time = new DateTime(_current.StartDate.TimeOfDay.Ticks);
//                timfin.Time = new DateTime(_current.EndDate.TimeOfDay.Ticks);

//                txtNote.EditValue = _current.Description;

//                if (_current.OutcomeDate == DateTime.MinValue)
//                {
//                    dtpOut.EditValue = null;
//                }
//                else
//                {
//                    dtpOut.EditValue = _current.OutcomeDate;
//                }
//                cboOut.EditValue = _current.Outcome;
//                txtNoteRapp.EditValue = _current.OutcomeDescription;
//                chkClosed.Checked = _current.IsClosed ;


//                commandBar1.Custom_SetIdentifier(_current.Id.ToString());
//            }
//        }

//        protected override void Nested_PostLoadingActions()
//        {
//            SetRapportoGUI();
//        }

     

//        #endregion

//        #region Delete

//        public override void DoDelete()
//        {
//            if (_current == null)
//                return;


//            try
//            {
//                if (XtraMessageBox.Show("Sicuro di voler procedere? ", "Elimina appuntamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                {
//                    Nested_CheckSecurityForDeletion();

//                    AppointmentHandler h = new AppointmentHandler();
//                    h.Delete(_current);

//                    _mainForm.NavigatorUtility.NavigateToPrevious();
//                }
//            }
//            catch (AccessDeniedException)
//            {
//                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }



//        }

//        [Secure(Area = "Appuntamenti", Alias = "Elimina", MacroArea = "Applicativo")]
//        protected override void Nested_CheckSecurityForDeletion()
//        {
//            SecurityManager.Instance.Check();
//        }

//        #endregion

//        #region GetInfo

//        public override void GetInfo()
//        {
//            ApplicationUtility.Instance.ShowObjectInfo(_current);
//        }

//        #endregion

//        #region Print

//        public override void Print()
//        {
//            try
//            {
//                if (_current != null)
//                {
//                    if (base.State.StateName == "Visualizzazione")
//                    {
//                        Reports.AppointmentReport c = new WIN.SCHEDULING_APP.GUI.Reports.AppointmentReport();
//                        ArrayList l = new ArrayList();
//                        l.Add(_current);
//                        c.DataSource = l;
//                        c.ShowPreviewDialog();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }

//        #endregion



//        private void commandBar1_SaveCommandPressed(object sender, EventArgs e)
//        {
//            try
//            {
//                StartSaveOperation();
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }

//        private void commandBar1_UndoCommandPressed(object sender, EventArgs e)
//        {
//            try
//            {
//                if (base.State.StateName == "Creazione")
//                {
//                    _mainForm.NavigatorUtility.NavigateToPrevious();
//                }
//                else
//                {
//                    StartUndoOperation();
//                }
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }

//        private void commandBar1_PrintCommandPressed(object sender, EventArgs e)
//        {
//            Print();
//        }

//        private void commandBar1_NewCommandPressed(object sender, EventArgs e)
//        {
//            try
//            {
//                StartCreateOperation();
//            }
//            catch (AccessDeniedException)
//            {
//                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }

//        private void commandBar1_InfoCommandPressed(object sender, EventArgs e)
//        {
//            GetInfo();
//        }

//        private void commandBar1_DelCommandPressed(object sender, EventArgs e)
//        {
//            try
//            {
//                StartDeleteOperation();
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }



//        #region Funzioni per la gestione del cliente

//        private void txtCust_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
//        {
//            if (e.Button.Index == 0)
//            {
//                //pulsante di ricerca cliente
//                SearchCustomer();
//            }
//            else if (e.Button.Index == 1)
//            {
//                //pulsante di annullamento cliente
//                _customer = null;
//                txtCust.EditValue = null;
                
//            }
//            else if (e.Button.Index == 2)
//            {
//                //pulsante di navigazione
//                if (_customer != null)
//                    GotoCustomer();
//            }
//            else if (e.Button.Index == 3)
//            {
//                //modifico l'elemento
                

//                if (_customer == null)
//                    return;
//                else
//                {
//                    CustomerForm frm = new CustomerForm(_customer );
//                    try
//                    {
//                        frm.CheckSecurityForView();
//                        if (frm.ShowDialog() == DialogResult.OK)
//                        {
//                            txtCust.EditValue = frm.Customer;
//                            _customer = frm.Customer;
//                        }
//                    }
//                    catch (AccessDeniedException)
//                    {
//                        XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//            else
//            {
//                //new creo uno nuovo
//                CustomerForm frm = new CustomerForm();
//                if (frm.ShowDialog() == DialogResult.OK)
//                {
//                    txtCust.EditValue = frm.Customer;
//                    _customer = frm.Customer;
//                }

//            }
//        }

//        private void GotoCustomer()
//        {
//            try
//            {
//                Hashtable h = new Hashtable();
//                h.Add("Id", _customer.Id);
//                NavigateTo("Customers", h);
//            }
//            catch (AccessDeniedException)
//            {
//                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
           
//        }

//        private void SearchCustomer()
//        {
//            try
//            {
//                WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();
//                if (frm.ShowDialog() == DialogResult.OK)
//                {
//                    txtCust.EditValue = frm.SelectedCustomer;
//                    _customer = frm.SelectedCustomer;
//                    if (Properties.Settings.Default.Main_FillAppointmentLocationWithCustomerAddress)
//                    {
//                        txtLoc.EditValue = string.Format("{0} {1} {2}", _customer.IndirizzoSedeLegale.Via, _customer.IndirizzoSedeLegale.Cap, _customer.IndirizzoSedeLegale.Comune.Descrizione);
//                    }
//                    cboZon.EditValue = _customer.Resource;
//                    txtNote.EditValue = _customer.OtherDataSummary;
//                }
//                frm.Dispose();
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }
//        #endregion




//        #region gestione Comando di creazione rapporto

//        private void cmdCreateRapporto_Click(object sender, EventArgs e)
//        {
//            ManageRapporto();
//        }

//        private void ManageRapporto()
//        {
//            try
//            {

//                if (base.State.StateName == "Visualizzazione" || base.State.StateName == "Aggiornamento")
//                {
//                    if (_current.OutcomeCreated)
//                    {
//                        if (XtraMessageBox.Show("L'eliminazione del rapporto causerà la perdita dei dati esistenti. Vuoi proseguire?","Elimina rapporto",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
//                        {
//                            //elimino il rapporto
//                            _current.CancelRapporto();
//                            AdjustRapportoGUI();
//                            return;
//                        }
//                        //l''utente ha scelto di no
//                        return;
//                    }

//                    //creo il rapporto
//                    _current.CreateRapporto();
//                    AdjustRapportoGUI();
//                }
//            }
//            catch (Exception ex)
//            {
//                ErrorHandler.Show(ex);
//            }
//        }


//#endregion




//        #region Gestione inerfaccia Rapporto
//        private void AdjustRapportoGUI()
//        {
//            SetRapportoGUI();
//            ClearRapportoGUIEditors();
//            StartChangeOperation();
//        }

//        private void ClearRapportoGUIEditors()
//        {
//            if (_current.OutcomeCreated)
//                dtpOut.EditValue = DateTime.Now;
//            else
//                dtpOut.EditValue = null;
//            txtNoteRapp.EditValue = "";
//            chkClosed.Checked = false;
//            cboOut.EditValue = null;
//        }


//        private void SetCreateRapportoButtonAppearence()
//        {
//            if (_current == null)
//            {
//                SetCreateRapportoButtonCreationViewInfo(true);
//                return;
//            }

//            if (_current.OutcomeCreated)
//            {
//                SetCreateRapportoButtonCreationViewInfo(false);
//            }
//            else
//            {
//                SetCreateRapportoButtonCreationViewInfo(true);
//            }
//        }

//        private void SetCreateRapportoButtonCreationViewInfo(bool p)
//        {
//            if (!p)
//            {
//                cmdCreateRapporto.Text = "Annulla rapporto appuntamento";
//                cmdCreateRapporto.ToolTip = "Annulla il rapporto per l'appuntamento.";
//                cmdCreateRapporto.ImageIndex = 0;
//            }
//            else
//            {
//                cmdCreateRapporto.Text = "Crea rapporto appuntamento";
//                cmdCreateRapporto.ToolTip = "Crea un rapporto per l'appuntamento che specifichi l'esito e l'eventuale conclusione dell'impegno.";
//                cmdCreateRapporto.ImageIndex = 1;
//            }
//        }



//        private void SetCreateRapportoGUIButtonVisibility(bool visible)
//        {
//            if (visible)
//            {
//                layoutControlItemCreateRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
//            }
//            else
//            {
//                layoutControlItemCreateRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
//            }
//        }

//        private void SetCreateRapportoGUIVisibility(bool visible)
//        {
//            if (visible)
//            {
//                layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
//            }
//            else
//            {
//                layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
//            }
//        }

//        private void SetRapportoGUI()
//        {
//            if (_current.OutcomeCreated)
//            {
//                SetCreateRapportoGUIVisibility(true);
//                SetCreateRapportoGUIButtonVisibility(true);
//            }
//            else
//            {
//                SetCreateRapportoGUIVisibility(false);
//                SetCreateRapportoGUIButtonVisibility(true);
//            }
//            SetCreateRapportoButtonAppearence();
//        }

//        #endregion




//        #region Gestione validazione date appuntamento

//        bool IsIntervalValid()
//        {
//            DateTime start = dtpIni.DateTime + timini.Time.TimeOfDay;
//            DateTime end = dtpFin.DateTime + timfin.Time.TimeOfDay;
//            return end >= start;
//        }

//        #endregion

//        private void cboZon_DrawItem(object sender, ListBoxDrawItemEventArgs e)
//        {
//            try
//            {
//                Resource r = e.Item as Resource;
//                if (r != null)
//                    e.Appearance.BackColor = Color.FromArgb(r.Color);
//            }
//            catch (Exception)
//            {
//                //
//            }
//        }

//        private void cboCaus_DrawItem(object sender, ListBoxDrawItemEventArgs e)
//        {
//            try
//            {
//                WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label r = e.Item as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
//                if (r != null)
//                    e.Appearance.BackColor = Color.FromArgb(r.Color);
//            }
//            catch (Exception)
//            {
//                //
//            }
//        }




//        #region gestione stato appuntamento


//        private void SetAppointmentStatusInfoVisible(bool visible)
//        {
//            if (visible)
//            {
//                emptySpaceItemheader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
//                lblnotelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
//                lblstatelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
//                imageLayloutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
//            }
//            else
//            {
//                emptySpaceItemheader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
//                lblnotelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
//                lblstatelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
//                imageLayloutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
//            }
//        }


//        private void SetAppointmentStatusInfoData()
//        {
//            if (_current != null)
//            {
//                SetImageState();
//                lblStato.Text = string.Format(lblStato.Text, _current.StateToString.ToUpper());
//                lblnote.Text = _current.DeadlineNotes;
//            }
//        }

//        private void SetImageState()
//        {
//            switch (_current.State)
//            {
//                case AppointmentState.Pianificato:
//                    pictureEdit1.Image = imageCollection1.Images[0];
//                    break;
//                case AppointmentState.In_Scadenza:
//                    pictureEdit1.Image = imageCollection1.Images[1];
//                    break;
//                case AppointmentState.Scade_Oggi:
//                    pictureEdit1.Image = imageCollection1.Images[2];
//                    break;
//                case AppointmentState.Scaduto:
//                    pictureEdit1.Image = imageCollection1.Images[3];
//                    break;
//                case AppointmentState.Eseguito:
//                    pictureEdit1.Image = imageCollection1.Images[4];
//                    break;
//                case AppointmentState.Concluso:
//                    pictureEdit1.Image = imageCollection1.Images[5];
//                    break;
//                default:
//                    break;
//            }
//        }

//        #endregion
//    }
}
