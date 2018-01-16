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
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Forms;

namespace WIN.SCHEDULING_APP.GUI.Controls
{

    //[SecureContext()]
    //public partial class TaskControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    //{
    //    //variabile che serve a gestire l'aggiornamento delle proprietà di base
    //    //dell'appuntamento che vengono gestite dal calendario
    // //   bool notUpdateBaseAppParameters = false;
    //    bool viewDetails = !Properties.Settings.Default.Main_ViewTaskDetails;
    //    MyTask _current;
    //    Customer _customer;

    //    public TaskControl(MainForm form, Customer customer)
    //        : base(form)
    //    {
    //        InitializeComponent();

    //        _customer = customer;
    //        //avvio le operazioni di creazione
    //        StartCreateOperation();

    //    }

    //    public TaskControl(int id, MainForm form)
    //        : base(form)
    //    {
    //        InitializeComponent();

    //        //avvio le procedure per il caricamento

    //        m_IdShowedObject = id;

    //        StartLoadOperation();

    //    }


    //    #region Undo

    //    public override void Nested_ReLoadProperties()
    //    {
    //        StartLoadOperation();
    //    }


    //    #endregion

    //    #region Funzioni per il caricamento iniziale


    //    //private void LoadComboZone()
    //    //{
    //    //    //preparo la combo delle zone
    //    //    cboZon.Properties.Items.Clear();

    //    //    ResourceHandler h = new ResourceHandler();
    //    //    //la riempio
    //    //    cboZon.Properties.Items.AddRange(h.GetAll());

    //    //    //seleziono quella iniziale
    //    //    cboZon.SelectedIndex = 0;
    //    //}


    //    //private void LoadComboCausali()
    //    //{
    //    //    //preparo la combo delle zone
    //    //    cboCaus.Properties.Items.Clear();

    //    //    LabelHandler h = new LabelHandler();
    //    //    //la riempio
    //    //    cboCaus.Properties.Items.AddRange(h.GetAll());

    //    //    //seleziono quella iniziale
    //    //    cboCaus.SelectedIndex = 0;
    //    //}


    //    //private void LoadComboOperatori()
    //    //{
    //    //    //preparo la combo delle zone
    //    //    cboOp.Properties.Items.Clear();

    //    //    OperatorHandler h = new OperatorHandler();
    //    //    //la riempio
    //    //    cboOp.Properties.Items.Add("");
    //    //    cboOp.Properties.Items.AddRange(h.GetAll());

    //    //    //seleziono quella iniziale
    //    //    cboOp.SelectedIndex = 0;
    //    //}

    //    //private void LoadComboEsiti()
    //    //{
    //    //    //preparo la combo delle zone
    //    //    cboOut.Properties.Items.Clear();

    //    //    OutcomeHandler h = new OutcomeHandler();
    //    //    //la riempio
    //    //    cboOut.Properties.Items.Add("");
    //    //    cboOut.Properties.Items.AddRange(h.GetAll());

    //    //    //seleziono quella iniziale
    //    //    cboOut.SelectedIndex = 0;
    //    //}

    //    #endregion

    //    #region Creation


    //    [Secure(Area = "Attività", Alias = "Crea", MacroArea = "Applicativo")]
    //    protected override void Nested_CheckSecurityForCreation()
    //    {
    //        SecurityManager.Instance.Check();
    //    }
    //    private void LoadComboEsiti()
    //    {
    //        //preparo la combo delle zone
    //        cboOut.Properties.Items.Clear();

    //        OutcomeHandler h = new OutcomeHandler();
    //        //la riempio
    //        cboOut.Properties.Items.Add("");
    //        cboOut.Properties.Items.AddRange(h.GetAll());

    //        //seleziono quella iniziale
    //        cboOut.SelectedIndex = 0;
    //    }
    //    protected override void Nested_ClearWindowEditors()
    //    {

    //        //Carico le combo

    //        //LoadComboZone();
    //        //LoadComboCausali();
    //        //LoadComboOperatori();
    //        LoadComboEsiti();

    //        //imposto il cliente, la zona, il luogo di default se il cliente è presente

    //        txtSub.EditValue = Properties.Settings.Default.Main_TaskSubject;
    //        if (_customer != null)
    //        {
    //            txtCust.EditValue = _customer;
    //            //txtLoc.EditValue = string.Format("{0} {1} {2}", _customer.IndirizzoSedeLegale.Via, _customer.IndirizzoSedeLegale.Cap, _customer.IndirizzoSedeLegale.Comune.Descrizione);
    //            //cboZon.EditValue = _customer.Resource;
    //            txtNote.EditValue = _customer.OtherDataSummary;
    //        }
    //        else
    //        {
    //            txtCust.EditValue = null;
    //            //txtLoc.EditValue = "";
    //            txtNote.EditValue = "";
    //        }

    //        cboPriority.SelectedIndex = 1;
    //        cboState.SelectedIndex = 0;
    //        spPerc.EditValue = 0;


           

    //        dtpIni.EditValue = DateTime.Now.Date;
    //        dtpFin.EditValue = DateTime.Now.Date ;

    //        //timini.Time = new DateTime(v.StartDate.TimeOfDay.Ticks);
    //        //timfin.Time = new DateTime(v.EndDate.TimeOfDay.Ticks);

    //        ////imposto le note
    //        //txtNote.EditValue = "";


    //        //imposto i valori per il rapporto
    //        dtpOut.EditValue = null;
    //        //chkClosed.Checked = false;
           


    //        txtNoteRapp.EditValue = "";





    //        commandBar1.Custom_SetIdentifier("");
    //    }

    //    protected override void Nested_PrepareForCreation()
    //    {
    //        _current = null;
    //        dataLayoutControl1.Visible = true;
    //        //proprietà di interfaccia per la gestione del rapporto
    //        SetDetailsGUIVisibility(false);
    //        SetDetailsGUIButtonVisibility(false);
    //        SetAppointmentStatusInfoVisible(false);
    //    }



    //    #endregion

    //    #region Change
    //    [Secure(Area = "Attività", Alias = "Aggiorna", MacroArea = "Applicativo")]
    //    protected override void Nested_CheckSecurityForChanging()
    //    {
    //        SecurityManager.Instance.Check();
    //    }

    //    public override void Nested_NotifyParent()
    //    {
    //        string desc = "";

    //        if (_current != null)
    //        {
    //            desc = _current.Subject;
    //        }

    //        commandBar1.CustomGUI_SetInterfaceState(commandBar1.Custom_GetCommandBarStateFromGuiState(base.State.StateName));
    //        commandBar1.Custom_SetSearchButtonEnabled(false);
    //        commandBar1.Custom_SetFunctionName(string.Format(base.State.StateName + " attività: {0}", desc));
    //    }


    //    public override void StartChangeOperation()
    //    {
    //        if (m_IsLoading)
    //            return;
    //        try
    //        {
    //            base.StartChangeOperation();
    //        }
    //        catch (AccessDeniedException)
    //        {
    //            XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }



    //    protected override void Nested_PostChangeActions()
    //    {
    //        SetAppointmentStatusInfoVisible(false);
    //    }


    //    private void txtSub_EditValueChanged(object sender, EventArgs e)
    //    {
    //        StartChangeOperation();
    //    }

    //    private void txtCust_EditValueChanged(object sender, EventArgs e)
    //    {
    //        StartChangeOperation();
    //    }

    //    //private void cboZon_SelectedIndexChanged(object sender, EventArgs e)
    //    //{
    //    //    StartChangeOperation();
    //    //}

    //    //private void txtLoc_EditValueChanged(object sender, EventArgs e)
    //    //{
    //    //    StartChangeOperation();
    //    //}

    //    //private void cboCaus_SelectedIndexChanged(object sender, EventArgs e)
    //    //{
    //    //    StartChangeOperation();
    //    //}

    //    //private void cboOp_SelectedIndexChanged(object sender, EventArgs e)
    //    //{
    //    //    StartChangeOperation();
    //    //}

    //    private void dtpIni_EditValueChanged(object sender, EventArgs e)
    //    {
    //        if (!m_IsLoading)
    //        {
    //            if (dtpIni.DateTime.Date > dtpFin.DateTime.Date)
    //            {
    //                m_IsLoading = true;
    //                dtpFin.EditValue = dtpIni.DateTime.Date;
    //                m_IsLoading = false;
    //            }
    //        }


    //        StartChangeOperation();
    //    }

    //    private void dtpFin_EditValueChanged(object sender, EventArgs e)
    //    {

    //        if (!m_IsLoading)
    //        {
    //            if (dtpIni.DateTime.Date > dtpFin.DateTime.Date)
    //            {
    //                m_IsLoading = true;
    //                dtpFin.EditValue = dtpIni.DateTime.Date;
    //                m_IsLoading = false;
    //            }
    //        }
    //        StartChangeOperation();
    //    }

    //    //private void timini_EditValueChanged(object sender, EventArgs e)
    //    //{

    //    //    StartChangeOperation();
    //    //}


    //    //private void timfin_EditValueChanged(object sender, EventArgs e)
    //    //{
    //    //    StartChangeOperation();
    //    //}

    //    private void txtNote_EditValueChanged(object sender, EventArgs e)
    //    {
    //        StartChangeOperation();
    //    }

    //    private void dtpOut_EditValueChanged(object sender, EventArgs e)
    //    {

    //        if (!m_IsLoading)
    //        {
                
    //                m_IsLoading = true;

    //                if (dtpOut.EditValue != null)
    //                {
    //                    //rinfresco i dati
    //                    cboState.EditValue = "Completata";
    //                    spPerc.EditValue = 100;
    //                }
    //                else
    //                {
    //                     cboState.EditValue = "In_Corso";
    //                     spPerc.EditValue = 0;
    //                }
                        
    //                m_IsLoading = false;
    //            }
            

    //        StartChangeOperation();
    //    }

    //    private void cboOut_EditValueChanged(object sender, EventArgs e)
    //    {
    //        StartChangeOperation();
    //    }

    //    //private void chkClosed_EditValueChanged(object sender, EventArgs e)
    //    //{
    //    //    StartChangeOperation();
    //    //}

    //    private void txtNoteRapp_EditValueChanged(object sender, EventArgs e)
    //    {
    //        StartChangeOperation();
    //    }

    //    private void cboState_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        if (!m_IsLoading)
    //        {
    //            m_IsLoading = true;
    //            if (cboState.Text == "Completata")
    //            {
    //                //rinfresco i dati
    //                spPerc.EditValue = 100;
    //                dtpOut.EditValue = DateTime.Now;
    //            }
    //            else if (cboState.Text == "Non_Iniziata")
    //            {
    //                //rinfresco i dati
    //                spPerc.EditValue = 0;
    //                dtpOut.EditValue = null;
    //            }
    //            else
    //            {
    //                if (Convert.ToInt32(spPerc.EditValue) == 100)
    //                    spPerc.EditValue = 75;
    //                dtpOut.EditValue = null;
    //            }
    //            m_IsLoading = false;
    //        }

    //        StartChangeOperation();
    //    }

    //    private void cboPriority_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        StartChangeOperation();
    //    }

    //    private void spPerc_EditValueChanged(object sender, EventArgs e)
    //    {
    //        if (!m_IsLoading)
    //        {
    //            m_IsLoading = true;
    //            if (Convert.ToInt32(spPerc.EditValue) == 100)
    //            {
    //                //rinfresco i dati
    //                cboState.EditValue = "Completata";
    //                dtpOut.EditValue = DateTime.Now;
    //            }
    //            else if (Convert.ToInt32(spPerc.EditValue) == 0)
    //            {
    //                //rinfresco i dati
    //                cboState.EditValue = "Non_Iniziata";
    //                dtpOut.EditValue = null;
    //            }
    //            else
    //            {
    //                if (cboState.Text == "Completata" || cboState.Text == "Non_Iniziata")
    //                    cboState.EditValue = "In_Corso";
    //                dtpOut.EditValue = null;
    //            }
    //            m_IsLoading = false;
    //        }

    //        StartChangeOperation();
    //    }
    //    #endregion

    //    #region Salvataggio

    //    public override void Nested_InsertData()
    //    {
    //        _current = new MyTask();

    //        SaveOrUpdate();

    //        m_IdShowedObject = _current.Id;

    //    }

    //    private void SaveOrUpdate()
    //    {
    //        //inserisco i parametri abituali
    //        _current.Subject = txtSub.Text;
    //        //_current.Resource = cboZon.SelectedItem as Resource;
    //        _current.Customer = txtCust.EditValue as Customer;
    //        //_current.Location = txtLoc.Text;
    //        //_current.Label = cboCaus.SelectedItem as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
    //        //_current.Operator = cboOp.SelectedItem as Operator;
    //        DataRange h1 =AppointmentUtils.CreateRangeForQuery(new DataRange(dtpIni.DateTime.Date, dtpFin.DateTime.Date));
    //        _current.StartDate = h1.Start;
    //        //artificio per evitare l'arrotondamento dei comandi ado su sql
    //        _current.EndDate = h1.Finish.AddMinutes (-1);
    //        _current.Description = txtNote.Text;


    //        _current.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), cboPriority.Text) ;
    //        _current.ActivityState = (ActivityState)Enum.Parse(typeof(ActivityState), cboState.Text);
    //        _current.PercentageCompleteness = Convert.ToInt32( spPerc.EditValue);



    //        if (dtpOut.EditValue == null)
    //            _current.OutcomeDate = DateTime.MinValue;
    //        else
    //            _current.OutcomeDate = dtpOut.DateTime;
          
    //        _current.Outcome = cboOut.SelectedItem as Outcome;
    //        _current.OutcomeDescription = txtNoteRapp.Text;
    //        //_current.IsClosed = chkClosed.Checked;


    //        //if (!notUpdateBaseAppParameters)
    //        //{
    //        //    //imposto i parametri di base
    //        //    //_current.AppointmentType = 0;
    //        //    //_current.AllDay = false;
    //        //    //_current.PercentageCompleteness = 0;
    //        //    //_current.LabelId = 0;
    //        //    //_current.ResourceId = 0;
    //        //    //_current.RecurrenceInfo = "";
    //        //    //_current.ReminderInfo = "";
    //        //}


    //        TaskHandler h = new TaskHandler();
    //        h.SaveOrUpdate(_current);
    //    }

    //    protected override void Nested_PostSaveActions()
    //    {
    //        Hashtable ParameterList = new Hashtable();
    //        ParameterList.Add("Id", m_IdShowedObject);
    //        NavigateTo("Tasks", ParameterList, true);
    //    }


    //    public override void Nested_UpdateData()
    //    {
    //        try
    //        {
                
    //            SaveOrUpdate();
    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
          

    //    }

    //    #endregion

    //    #region Visualizzazione

    //    protected override void Nested_PrepareLoading()
    //    {
    //        dataLayoutControl1.Visible = true;


    //        //Carico le combo

    //        //LoadComboZone();
    //        //LoadComboCausali();
    //        //LoadComboOperatori();
    //        LoadComboEsiti();

    //        //visualizzo le proprietà per la gestione dell'interfaccia
    //        //di creazione rappporto
    //        SetDetailsGUIVisibility(true);
    //        SetAppointmentStatusInfoVisible(true);
    //    }

    //    protected override void Nested_LoadDataFromDataSource()
    //    {
    //        TaskHandler h = new TaskHandler();
    //        _current = h.GetElementById(m_IdShowedObject.ToString()) as MyTask;

    //        if (_current == null)
    //            throw new Exception("Attività non trovata");
    //    }

    //    protected override void Nested_LoadEditorsProperties()
    //    {
    //        if (_current != null)
    //        {
    //            //calcolo le proprietà dello stato dell'appuntamento
    //            _current.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
    //            SetAppointmentStatusInfoData();


    //            //inserisco i parametri abituali
    //            txtSub.EditValue = _current.Subject;
    //            //cboZon.EditValue = _current.Resource;
    //            txtCust.EditValue = _current.Customer;
    //            //tengo il cliente sincronizzto con la button edit
    //            _customer = _current.Customer;

    //            //txtLoc.EditValue = _current.Location;
    //            //cboCaus.EditValue = _current.Label;
    //            //cboOp.EditValue = _current.Operator;

    //            dtpIni.EditValue = _current.StartDate.Date;
    //            dtpFin.EditValue = _current.EndDate.Date;
    //            //timini.Time = new DateTime(_current.StartDate.TimeOfDay.Ticks);
    //            //timfin.Time = new DateTime(_current.EndDate.TimeOfDay.Ticks);


    //            cboPriority.EditValue = _current.Priority.ToString();
    //            cboState.EditValue = _current.ActivityState.ToString();
    //            spPerc.EditValue = _current.PercentageCompleteness;



    //            txtNote.EditValue = _current.Description;

    //            if (_current.OutcomeDate == DateTime.MinValue)
    //            {
    //                dtpOut.EditValue = null;
    //            }
    //            else
    //            {
    //                dtpOut.EditValue = _current.OutcomeDate;
    //            }
    //            cboOut.EditValue = _current.Outcome;
    //            txtNoteRapp.EditValue = _current.OutcomeDescription;
    //            //chkClosed.Checked = _current.IsClosed;


    //            commandBar1.Custom_SetIdentifier(_current.Id.ToString());
    //        }
    //    }

    //    protected override void Nested_PostLoadingActions()
    //    {
    //        SetDetailsGUI();
    //    }



    //    #endregion

    //    #region Delete

    //    public override void DoDelete()
    //    {
    //        if (_current == null)
    //            return;


    //        try
    //        {
    //            if (XtraMessageBox.Show("Sicuro di voler procedere? ", "Elimina attività", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //            {
    //                Nested_CheckSecurityForDeletion();

    //                TaskHandler h = new TaskHandler();
    //                h.Delete(_current);

    //                _mainForm.NavigatorUtility.NavigateToPrevious();
    //            }
    //        }
    //        catch (AccessDeniedException)
    //        {
    //            XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }



    //    }

    //    [Secure(Area = "Attività", Alias = "Elimina", MacroArea = "Applicativo")]
    //    protected override void Nested_CheckSecurityForDeletion()
    //    {
    //        SecurityManager.Instance.Check();
    //    }

    //    #endregion

    //    #region GetInfo

    //    public override void GetInfo()
    //    {
    //        ApplicationUtility.Instance.ShowObjectInfo(_current);
    //    }

    //    #endregion

    //    #region Print

    //    public override void Print()
    //    {
    //        try
    //        {
    //            if (_current != null)
    //            {
    //                if (base.State.StateName == "Visualizzazione")
    //                {
    //                    Reports.TaskReport c = new WIN.SCHEDULING_APP.GUI.Reports.TaskReport();
    //                    ArrayList l = new ArrayList();
    //                    l.Add(_current);
    //                    c.DataSource = l;
    //                    c.ShowPreviewDialog();
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }

    //    #endregion



    //    private void commandBar1_SaveCommandPressed(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            StartSaveOperation();
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }

    //    private void commandBar1_UndoCommandPressed(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            if (base.State.StateName == "Creazione")
    //            {
    //                _mainForm.NavigatorUtility.NavigateToPrevious();
    //            }
    //            else
    //            {
    //                StartUndoOperation();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }

    //    private void commandBar1_PrintCommandPressed(object sender, EventArgs e)
    //    {
    //        Print();
    //    }

    //    private void commandBar1_NewCommandPressed(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            StartCreateOperation();
    //        }
    //        catch (AccessDeniedException)
    //        {
    //            XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }

    //    private void commandBar1_InfoCommandPressed(object sender, EventArgs e)
    //    {
    //        GetInfo();
    //    }

    //    private void commandBar1_DelCommandPressed(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            StartDeleteOperation();
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }



    //    #region Funzioni per la gestione del cliente

    //    private void txtCust_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    //    {
    //        if (e.Button.Index == 0)
    //        {
    //            //pulsante di ricerca cliente
    //            SearchCustomer();
    //        }
    //        else if (e.Button.Index == 1)
    //        {
    //            //pulsante di annullamento cliente
    //            _customer = null;
    //            txtCust.EditValue = null;

    //        }
    //        else if (e.Button.Index == 2)
    //        {
    //            //pulsante di navigazione
    //            if (_customer != null)
    //                GotoCustomer();
    //        }
    //        else if (e.Button.Index == 3)
    //        {
    //            //modifico l'elemento


    //            if (_customer == null)
    //                return;
    //            else
    //            {
    //                CustomerForm frm = new CustomerForm(_customer);
    //                try
    //                {
    //                    frm.CheckSecurityForView();
    //                    if (frm.ShowDialog() == DialogResult.OK)
    //                    {
    //                        txtCust.EditValue = frm.Customer;
    //                        _customer = frm.Customer;
    //                    }
    //                }
    //                catch (AccessDeniedException)
    //                {
    //                    XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            //new creo uno nuovo
    //            CustomerForm frm = new CustomerForm();
    //            if (frm.ShowDialog() == DialogResult.OK)
    //            {
    //                txtCust.EditValue = frm.Customer;
    //                _customer = frm.Customer;
    //            }

    //        }
    //    }

    //    private void GotoCustomer()
    //    {
    //        try
    //        {
    //            Hashtable h = new Hashtable();
    //            h.Add("Id", _customer.Id);
    //            NavigateTo("Customers", h);
    //        }
    //        catch (AccessDeniedException)
    //        {
    //            XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }

    //    }

    //    private void SearchCustomer()
    //    {
    //        try
    //        {
    //            WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();
    //            if (frm.ShowDialog() == DialogResult.OK)
    //            {
    //                txtCust.EditValue = frm.SelectedCustomer;
    //                _customer = frm.SelectedCustomer;
    //                //txtLoc.EditValue = string.Format("{0} {1} {2}", _customer.IndirizzoSedeLegale.Via, _customer.IndirizzoSedeLegale.Cap, _customer.IndirizzoSedeLegale.Comune.Descrizione);
    //                //cboZon.EditValue = _customer.Resource;
    //                txtNote.EditValue = _customer.OtherDataSummary;
    //            }
    //            frm.Dispose();
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }
    //    #endregion




    //    #region gestione Comando di creazione rapporto

    //    private void cmdCreateRapporto_Click(object sender, EventArgs e)
    //    {
    //        ManageDetailsVisibility();
    //    }

    //    private void ManageDetailsVisibility()
    //    {
    //        try
    //        {

    //            //if (base.State.StateName == "Visualizzazione" || base.State.StateName == "Aggiornamento")
    //            //{
    //            //    if (_current.OutcomeCreated)
    //            //    {
    //            //        if (XtraMessageBox.Show("L'eliminazione del rapporto causerà la perdita dei dati esistenti. Vuoi proseguire?", "Elimina rapporto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //            //        {
    //            //            //elimino il rapporto
    //            //            _current.CancelRapporto();
    //            //            AdjustRapportoGUI();
    //            //            return;
    //            //        }
    //            //        //l''utente ha scelto di no
    //            //        return;
    //            //    }

    //            //    //creo il rapporto
    //            //    _current.CreateRapporto();
    //            //    AdjustRapportoGUI();
    //            //}
    //            //AdjustGUI();

    //            SetDetailsGUI();
    //        }
    //        catch (Exception ex)
    //        {
    //            ErrorHandler.Show(ex);
    //        }
    //    }


    //    #endregion




    //    #region Gestione interfaccia dettagli
    //    //private void AdjustGUI()
    //    //{
    //    //    SetDetailsGUI();
    //    //    //ClearRapportoGUIEditors();
    //    //    //StartChangeOperation();
    //    //}

    //    //private void ClearRapportoGUIEditors()
    //    //{
    //    //    //if (_current.OutcomeCreated)
    //    //    //    dtpOut.EditValue = DateTime.Now;
    //    //    //else
    //    //    //    dtpOut.EditValue = null;
    //    //    //txtNoteRapp.EditValue = "";
    //    //    //chkClosed.Checked = false;
    //    //    //cboOut.EditValue = null;
    //    //}


    //    private void SetDetailsButtonAppearence()
    //    {
    //        if (_current == null)
    //        {
    //            SetDetailsButtonCreationViewInfo(true);
    //            return;
    //        }

    //        if (viewDetails)
    //        {
    //            SetDetailsButtonCreationViewInfo(false);
    //            //viewDetails = true;
    //        }
    //        else
    //        {
    //            SetDetailsButtonCreationViewInfo(true);
    //            //viewDetails = false;
    //        }
    //    }

    //    private void SetDetailsButtonCreationViewInfo(bool p)
    //    {
    //        if (!p)
    //        {
    //            cmdCreateRapporto.Text = "Nascondi dettagli";
    //            cmdCreateRapporto.ToolTip = "Nasconde i dettagli dell'attività.";
    //            cmdCreateRapporto.ImageIndex = 4;
    //        }
    //        else
    //        {
    //            cmdCreateRapporto.Text = "Visualizza dettagli";
    //            cmdCreateRapporto.ToolTip = "Visualizza i dettagli dell'attività";
    //            cmdCreateRapporto.ImageIndex = 3;
    //        }
    //    }



    //    private void SetDetailsGUIButtonVisibility(bool visible)
    //    {
    //        if (visible)
    //        {
    //            layoutControlItemCreateRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //        }
    //        else
    //        {
    //            layoutControlItemCreateRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //        }
    //    }

    //    private void SetDetailsGUIVisibility(bool visible)
    //    {
    //        if (visible)
    //        {
    //            layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //        }
    //        else
    //        {
    //            layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //        }
    //    }

    //    private void SetDetailsGUI()
    //    {
    //        if (!viewDetails)
    //        {
    //            SetDetailsGUIVisibility(true);
    //            SetDetailsGUIButtonVisibility(true);
    //            viewDetails = true;
    //        }
    //        else
    //        {
    //            SetDetailsGUIVisibility(false);
    //            SetDetailsGUIButtonVisibility(true);
    //            viewDetails = false;
    //        }
    //        SetDetailsButtonAppearence();
    //    }

    //    #endregion




    //    #region Gestione validazione date appuntamento

    //    //bool IsIntervalValid()
    //    //{
    //    //    DateTime start = dtpIni.DateTime + timini.Time.TimeOfDay;
    //    //    DateTime end = dtpFin.DateTime + timfin.Time.TimeOfDay;
    //    //    return end >= start;
    //    //}

    //    #endregion

    //    //private void cboZon_DrawItem(object sender, ListBoxDrawItemEventArgs e)
    //    //{
    //    //    try
    //    //    {
    //    //        Resource r = e.Item as Resource;
    //    //        if (r != null)
    //    //            e.Appearance.BackColor = Color.FromArgb(r.Color);
    //    //    }
    //    //    catch (Exception)
    //    //    {
    //    //        //
    //    //    }
    //    //}

    //    //private void cboCaus_DrawItem(object sender, ListBoxDrawItemEventArgs e)
    //    //{
    //    //    try
    //    //    {
    //    //        WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label r = e.Item as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
    //    //        if (r != null)
    //    //            e.Appearance.BackColor = Color.FromArgb(r.Color);
    //    //    }
    //    //    catch (Exception)
    //    //    {
    //    //        //
    //    //    }
    //    //}




    //    #region gestione stato appuntamento


    //    private void SetAppointmentStatusInfoVisible(bool visible)
    //    {
    //        if (visible)
    //        {
    //            emptySpaceItemheader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //            lblnotelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //            lblstatelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //            imageLayloutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
    //        }
    //        else
    //        {
    //            emptySpaceItemheader.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //            lblnotelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //            lblstatelayoutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //            imageLayloutitem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
    //        }
    //    }


    //    private void SetAppointmentStatusInfoData()
    //    {
    //        if (_current != null)
    //        {
    //            SetImageState();
    //            lblStato.Text = string.Format(lblStato.Text, _current.ActivityDeadlineStateToString.ToUpper());
    //            lblnote.Text = _current.DeadlineNotes;
    //        }
    //    }

    //    private void SetImageState()
    //    {
    //        switch (_current.ActivityDeadlineState)
    //        {
    //            case AppointmentState.Pianificato:
    //                pictureEdit1.Image = imageCollection1.Images[0];
    //                break;
    //            case AppointmentState.In_Scadenza:
    //                pictureEdit1.Image = imageCollection1.Images[1];
    //                break;
    //            case AppointmentState.Scade_Oggi:
    //                pictureEdit1.Image = imageCollection1.Images[2];
    //                break;
    //            case AppointmentState.Scaduto:
    //                pictureEdit1.Image = imageCollection1.Images[3];
    //                break;
    //            case AppointmentState.Eseguito:
    //                pictureEdit1.Image = imageCollection1.Images[4];
    //                break;
    //            case AppointmentState.Concluso:
    //                pictureEdit1.Image = imageCollection1.Images[5];
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    #endregion




    //}
}

