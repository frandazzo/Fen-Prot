using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.BASEREUSE;
using System.Collections;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls.CustomAppointmentFormAssets
{
    public partial class CustomAppForm : DevExpress.XtraEditors.XtraForm
    {

        SchedulerControl control;
        DevExpress.XtraScheduler.Appointment apt;
        bool openRecurrenceForm = false;
        int suspendUpdateCount;


        // The MyAppointmentFormController class is inherited from
        // the AppointmentFormController to add custom properties.
        // See its declaration below.
        ControllerForm controller;

        protected AppointmentStorage Appointments
        {
            get { return control.Storage.Appointments; }
        }

        protected bool IsUpdateSuspended { get { return suspendUpdateCount > 0; } }






        public CustomAppForm(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool openRecurrenceForm)
        {
            InitializeComponent();
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new ControllerForm(control, apt);
            this.apt = apt;
            this.control = control;

            
            LoadComboZone();
            LoadComboCausali();
            LoadComboOperatori();
            LoadComboEsiti();


            if (controller.IsNewAppointment)
            {
                SetCreateRapportoGUIVisibility(false);
                SetAppointmentStatusInfoVisible(false);
                //SetCreateRapportoGUIButtonVisibility(false);
            }
            else
            {
                //visualizzo le proprietà per la gestione dell'interfaccia
                //di creazione rappporto
                SetCreateRapportoGUIVisibility(true);
                SetAppointmentStatusInfoVisible(true);
                SetCreateRapportoGUIButtonVisibility(true);
            }




            // Required for Windows Form Designer support
            //
            SuspendUpdate();
            ResumeUpdate();
            UpdateForm();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //

           
        }

        private void dtpin_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                controller.DisplayStart = dtpin.DateTime.Date + timin.Time.TimeOfDay;
            UpdateIntervalControls();
        }

        private void timin_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsUpdateSuspended)
                controller.DisplayStart = dtpin.DateTime.Date + timin.Time.TimeOfDay;
            UpdateIntervalControls();
        }

        private void dtpfin_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.DisplayEnd = dtpfin.DateTime.Date + timfin.Time.TimeOfDay;
            else
                dtpfin.EditValue = controller.DisplayEnd.Date;
        }

        private void timfin_EditValueChanged(object sender, EventArgs e)
        {
            if (IsUpdateSuspended) return;
            if (IsIntervalValid())
                controller.DisplayEnd = dtpfin.DateTime.Date + timfin.Time.TimeOfDay;
            else
                timfin.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);
        }


        bool IsIntervalValid()
        {
            DateTime start = dtpin.DateTime + timin.Time.TimeOfDay;
            DateTime end = dtpfin.DateTime + timfin.Time.TimeOfDay;
            return end >= start;
        }



        protected void SuspendUpdate()
        {
            suspendUpdateCount++;
        }
        protected void ResumeUpdate()
        {
            if (suspendUpdateCount > 0)
                suspendUpdateCount--;
        }

        protected virtual void UpdateIntervalControls()
        {
            if (IsUpdateSuspended)
                return;

            SuspendUpdate();
            try
            {
                dtpin.EditValue = controller.DisplayStart.Date;
                dtpfin.EditValue = controller.DisplayEnd.Date;
                timin.EditValue = new DateTime(controller.DisplayStart.TimeOfDay.Ticks);
                timfin.EditValue = new DateTime(controller.DisplayEnd.TimeOfDay.Ticks);


                //timeStart.Visible = !controller.AllDay;
                //timeEnd.Visible = !controller.AllDay;
                //timeStart.Enabled = !controller.AllDay;
                //timeEnd.Enabled = !controller.AllDay;

            }
            finally
            {
                ResumeUpdate();
            }
        }


        void UpdateForm()
        {
            SuspendUpdate();
            try
            {
                txtSub.EditValue = controller.Subject;
                txtLoc.EditValue = controller.Location;

               

                txtNote.EditValue = controller.Description;

                if (controller.IsNewAppointment)
                {
                    // per le risorse prendo l'elemento suggerito dall'appuntamento
                   
                    InitializeComboResourcesValue();




                    cboCaus.SelectedIndex = 0;
                    cboOp.SelectedIndex = 0;
                    txtCust.EditValue = null;

                    chkClosed.Checked = false;
                    txtNoteRapp.EditValue = "";
                    cboOut.SelectedIndex = 0;
                    dtpOut.EditValue = null;


                    //////carico la data e l'ora iniziale
                    //AppointmentDateValidator v = AppointmentUtils.GetProposedDate();

                    //dtpin.EditValue = v.StartDate;
                    //dtpfin.EditValue = v.EndDate;

                    //timin.Time = new DateTime(v.StartDate.TimeOfDay.Ticks);
                    //timfin.Time = new DateTime(v.EndDate.TimeOfDay.Ticks);

                    //////aggiorno il controller
                    ////controller.Start = v.StartDate;
                    ////controller.End = v.EndDate;
                }
                else
                {
                    cboCaus.EditValue = controller.CustomLabel;
                    cboZon.EditValue = controller.CustomResource;
                    cboOp.EditValue = controller.CustomOperator;
                    txtCust.EditValue = controller.CustomCustomer;

                    dtpin.EditValue = controller.Start.Date;
                    dtpfin.EditValue = controller.End.Date;
                    timin.Time = new DateTime(controller.Start.TimeOfDay.Ticks);
                    timfin.Time = new DateTime(controller.End.TimeOfDay.Ticks);

                    if (controller.CustomOutcomeCreated)
                    {
                        chkClosed.Checked = controller.CustomIsClosed;
                        txtNoteRapp.EditValue = controller.CustomOutcomeDescription;
                        cboOut.EditValue = controller.CustomOutcome;
                        dtpOut.EditValue = controller.CustomOutcomeDate;
                    }
                    else
                    {
                        chkClosed.Checked = false;
                        txtNoteRapp.EditValue = "";
                        cboOut.SelectedIndex = 0;
                        dtpOut.EditValue = null;
                    }

                }

                SetRapportoGUI();
                
                ////calcolo le proprietà dello stato dell'appuntamento
                if (!controller.IsNewAppointment)
                    SetAppointmentStatusInfoData();

            }
            finally
            {
                ResumeUpdate();
            }
            UpdateIntervalControls();
        }

        private void InitializeComboResourcesValue()
        {
            int idRed = -1;
            bool converted = false;

            try
            {

                idRed = Convert.ToInt32(apt.ResourceId);
                converted = true;
            }
            catch (Exception)
            {

                converted = false;
            }


            if (converted)
            {

                int i = 0;
                foreach (WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource item in cboZon.Properties.Items)
                {
                    //AbstractPersistenceObject o = item.Value as AbstractPersistenceObject;
                    if (item.Id.Equals(idRed))
                    {
                        cboZon.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
                cboZon.SelectedIndex = 0;
        }

        //private WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource GetSelectedResource()
        //{
        //    int idRed = Convert.ToInt32(apt.ResourceId);
        //    ResourceHandler h11 = new ResourceHandler();
        //    WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource rr = h11.GetElementById(idRed.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
        //    return rr;
        //}


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
            
            //creo un appuntamento fittizio
            MyAppointment app = new MyAppointment();
            app.IsClosed = controller.CustomIsClosed;
            app.OutcomeCreated = controller.CustomOutcomeCreated;
            app.StartDate = controller.DisplayStart;
            app.EndDate = controller.DisplayEnd;


            //calcolo lo stato
            app.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);

            SetImageState(app.State);
            lblStato.Text = string.Format(lblStato.Text, app.StateToString.ToUpper());
            lblnote.Text = app.DeadlineNotes;
            
        }

        private void SetImageState(AppointmentState state)
        {
            switch (state)
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



        #region Gestione inerfaccia Rapporto
        private void AdjustRapportoGUI()
        {
            SetRapportoGUI();
            ClearRapportoGUIEditors();
        }

        private void ClearRapportoGUIEditors()
        {
            if (controller.CustomOutcomeCreated)
                dtpOut.EditValue = DateTime.Now;
            else
                dtpOut.EditValue = null;
            txtNoteRapp.EditValue = "";
            chkClosed.Checked = false;
            cboOut.EditValue = null;
        }


        private void SetCreateRapportoButtonAppearence()
        {
            //if (controller.IsNewAppointment)
            //{
            //    SetCreateRapportoButtonCreationViewInfo(true);
            //    return;
            //}

            if (controller.CustomOutcomeCreated)
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
                this.Size = new Size(this.Size.Width, 530);
            }
            else
            {
                layoutControlGroupRapporto.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                this.Size = new Size(this.Size.Width, 390);
            }
        }

        private void SetRapportoGUI()
        {
            if (controller.CustomOutcomeCreated)
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
               
                txtCust.EditValue = null;
            }
            else if (e.Button.Index == 2)
            {
                //modifico l'elemento
                Customer c = controller.CustomCustomer;

                if (c == null)
                    return;
                else
                {
                    CustomerForm frm = new CustomerForm(controller.CustomCustomer);
                    try
                    {
                        frm.CheckSecurityForView();
                        if (frm.ShowDialog() == DialogResult.OK)
                            txtCust.EditValue = frm.Customer;
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
                    txtCust.EditValue = frm.Customer;

            }

           
        }

        private void SearchCustomer()
        {
            try
            {
                WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Customer c = null;
                     c = frm.SelectedCustomer;
                     txtCust.EditValue = c;
                     controller.CustomCustomer = c;

                     if (Properties.Settings.Default.Main_FillAppointmentLocationWithCustomerAddress)
                     {
                         txtLoc.EditValue = string.Format("{0} {1} {2}", c.Residenza.Via, c.Residenza.Cap, c.Residenza.Comune.Descrizione);
                     }
                    cboZon.EditValue = c.Resource;
                    txtNote.EditValue = c.OtherDataSummary;
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdCreateRapporto_Click(object sender, EventArgs e)
        {
            ManageRapporto();
        }

        private void ManageRapporto()
        {
            try
            {
                //if (controller.IsNewAppointment)
                //    return;

                if (controller.CustomOutcomeCreated)
                {
                    if (XtraMessageBox.Show("L'eliminazione del rapporto causerà la perdita dei dati esistenti. Vuoi proseguire?", "Elimina rapporto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //elimino il rapporto
                        //_current.CancelRapporto();
                        //********************************
                        controller.CustomOutcomeCreated = false;
                        controller.CustomOutcomeDate = DateTime.MinValue;
                        controller.CustomOutcomeDescription = "";
                        controller.CustomOutcome = null;
                        controller.CustomIsClosed = false;
                        //*************************************
                        AdjustRapportoGUI();
                        return;
                    }
                    //l''utente ha scelto di no
                    return;
                }

                ////creo il rapporto
                //_current.CreateRapporto();
                //********************************
                controller.CustomOutcomeCreated = true;
                controller.CustomOutcomeDate = DateTime.Now;
                controller.CustomOutcomeDescription = "";
                controller.CustomOutcome = null;
                controller.CustomIsClosed = false;
                //*************************************
                AdjustRapportoGUI();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {

                // Required to check the appointment for conflicts.
                if (!controller.IsConflictResolved())
                    return;

                controller.Subject = txtSub.Text;
                controller.Location = txtLoc.Text;
                controller.Description = txtNote.Text;
                controller.ResourceId = (cboZon.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource).Id;
                //controller.SetStatus(edStatus.Status);
                //controller.SetLabel(appointmentLabelEdit1.Label);
                //controller.AllDay = this.checkAllDay.Checked;
                controller.DisplayStart = this.dtpin.DateTime.Date + this.timin.Time.TimeOfDay;
                controller.DisplayEnd = this.dtpfin.DateTime.Date + this.timfin.Time.TimeOfDay;
                controller.CustomResource = cboZon.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
                controller.CustomLabel = cboCaus.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
                controller.CustomCustomer = txtCust.EditValue as Customer;
                controller.CustomOperator = cboOp.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator;


                if (dtpOut.EditValue == null)
                {
                    controller.CustomOutcomeDate = DateTime.MinValue;
                }
                else
                {
                    controller.CustomOutcomeDate = dtpOut.DateTime;
                }
                controller.CustomOutcome = cboOut.SelectedItem as Outcome;
                controller.CustomOutcomeDescription = txtNoteRapp.Text;
                controller.CustomIsClosed = chkClosed.Checked;



                // Save all changes of the editing appointment.
                controller.ApplyChanges();
                this.DialogResult = DialogResult.OK;
            }

            //foreach (Appointment item in control.Storage.Appointments.Items)
            //{
            //    MyAppointment app = item.GetSourceObject(control.Storage) as MyAppointment;

            //    if (app.Id == 276)
            //        item.Delete();
            //}
        }

        private bool IsInputValid()
        {
            //costruisco un oggetto fittizio per verificare il set minimo di inpout
            MyAppointment a = new MyAppointment();
            a.Subject = txtSub.Text;
            a.Resource = cboZon.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
            a.Label  = cboCaus.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;

            a.StartDate = this.dtpin.DateTime.Date + this.timin.Time.TimeOfDay;
            a.EndDate = this.dtpfin.DateTime.Date + this.timfin.Time.TimeOfDay;

            a.OutcomeCreated = controller.CustomOutcomeCreated;
            a.OutcomeDate = dtpOut.DateTime;

            if (a.IsValid())
                return true;


            string error = BuildErrorstring(a.ValidationErrors);

            XtraMessageBox.Show(error, "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private string BuildErrorstring(System.Collections.ArrayList arrayList)
        {
            StringBuilder b = new StringBuilder();
            foreach (string item in arrayList)
            {
                b.AppendLine(item);
            }
            return b.ToString();
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

                Reports.AppointmentReport c = new WIN.SCHEDULING_APP.GUI.Reports.AppointmentReport();
                ArrayList l = new ArrayList();
                l.Add(CreateApp());
                c.DataSource = l;
                c.ShowPreviewDialog();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private MyAppointment CreateApp()
        {
            if (control.Storage.Appointments.IsNewAppointment(apt))
            {

                MyAppointment controller = new MyAppointment();
                controller.Subject = txtSub.Text;
                controller.Location = txtLoc.Text;
                controller.Description = txtNote.Text;
                controller.ResourceId = (cboZon.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource).Id;
                //controller.SetStatus(edStatus.Status);
                //controller.SetLabel(appointmentLabelEdit1.Label);
                //controller.AllDay = this.checkAllDay.Checked;
                controller.StartDate = this.dtpin.DateTime.Date + this.timin.Time.TimeOfDay;
                controller.EndDate = this.dtpfin.DateTime.Date + this.timfin.Time.TimeOfDay;
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
                    controller.OutcomeDate = dtpOut.DateTime;
                }
                controller.Outcome = cboOut.SelectedItem as Outcome;
                controller.Description = txtNoteRapp.Text;
                controller.IsClosed = chkClosed.Checked;

                controller.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);
                controller.Key = new Key(-1);
                return controller;
            }
            else
            {
                return apt.GetSourceObject(control.Storage) as MyAppointment;
            }
        }

    }
}