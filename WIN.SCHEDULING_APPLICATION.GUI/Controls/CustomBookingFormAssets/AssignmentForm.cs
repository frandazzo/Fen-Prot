using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Xml;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;
using System.Threading;
using System.Collections;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls.CustomBookingFormAssets
{
    public partial class AssignmentForm : DevExpress.XtraEditors.XtraForm
    {

        Assignment _currentAssignment;
        SchedulerControl _control;
        DevExpress.XtraScheduler.Appointment _apt;
        IBooking _parentBooking;
        bool _isCreationOp = false;

        private   DevExpress.XtraGrid.GridControl _gridControl1;


        private void InitializeComboResourcesValue()
        {
            int idRed = -1;
            bool converted = false;

            try
            {

                idRed = Convert.ToInt32(_apt.ResourceId);
                converted = true;
            }
            catch (Exception)
            {

                converted = false;
            }


            if (converted)
            {

                int i = 0;
                foreach (WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource item in chkResources.Properties.Items)
                {
                    //AbstractPersistenceObject o = item.Value as AbstractPersistenceObject;
                    if (item.Id.Equals(idRed))
                    {
                        chkResources.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
                chkResources.SelectedIndex = 0;
        }

        public AssignmentForm(Assignment apt)
        {
            InitializeComponent();

            _currentAssignment = apt;

            LoadResourcesCombo();
            LoadBedTypesCombo();

            LoadAssignmentData();

            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void LoadAssignmentData()
        {
           
            InitializeComboResourcesValue();

            dtpIn.DateTime = _currentAssignment.StartDate;
            dtpOut.DateTime = _currentAssignment.EndDate;
            txtNote.Text = _currentAssignment.Notes ;
           
                cboLetti.EditValue = _currentAssignment.BedType;



            LoadPicture(_currentAssignment);

            LoadOspiti(_currentAssignment);
        }
       

        public AssignmentForm(SchedulerControl control,Appointment apt,IBooking parent,DevExpress.XtraGrid.GridControl gridControl1)
        {
            InitializeComponent();

            _control = control;
            _apt = apt;
            //se c'è un oggetto assignment sottostante è un aggiornamento altrimenti una creazione
            Assignment a = _apt.GetSourceObject(_control.Storage) as Assignment;
            if (a == null)
                _isCreationOp = true;
            else
                _isCreationOp = false;

            lstcont.Items.Clear();
            _parentBooking = parent;
            _gridControl1 = gridControl1;

            LoadResourcesCombo();
            LoadBedTypesCombo();

            LoadAppointmentData();

        }

        private void LoadBedTypesCombo()
        {
            //preparo la combo delle zone
            cboLetti.Properties.Items.Clear();

            BedTypeHandler h = new BedTypeHandler();
            //la riempio
            cboLetti.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboLetti.SelectedIndex = 0;
        }

        private void CreateNewAppointment()
        {
            _apt = _control.Storage.CreateAppointment(AppointmentType.Normal);
            _apt.AllDay = true;
        }

        private void LoadAppointmentData()
        {
            Assignment ass = _apt.GetSourceObject(_control.Storage) as Assignment;
            InitializeComboResourcesValue();

            dtpIn.DateTime = _apt.Start;
            dtpOut.DateTime = _apt.End;
            txtNote.Text = _apt.Location;
            if (!_isCreationOp)
                cboLetti.EditValue = ass.BedType;



            LoadPicture(ass);

            LoadOspiti(ass);
        }

        private void LoadOspiti(Assignment ass)
        {
            if (ass == null)
                return;
            lstcont.Items.Clear();

            if (ass.CheckedIn)
            {
                foreach (Checkin item in ass.Checkins)
                {
                    
                    lstcont.Items.Add(item);
                }
            }
        }

        private void LoadPicture(Assignment ass)
        {
            if (ass == null)
                return;
            if (ass.CheckedIn)
            {
                pictureEdit1.Image = Properties.Resources.Lock_Lock_icon;
                //carico la lista
                labelControl1.Text = "Check In effettuato";

            }
            else
            {
                pictureEdit1.Image = Properties.Resources.Lock_Unlock_icon;
                labelControl1.Text = "Check In non effettuato";
            }
        }

        private void LoadResourcesCombo()
        {
            //preparo la combo delle zone
            chkResources.Properties.Items.Clear();

            BookingResourceHandler h = new BookingResourceHandler();
            //la riempio
            chkResources.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            chkResources.SelectedIndex = 0;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAssignment();

                RefreshGridDataSource();

                this.Close();
            }
            catch (Exception ex)
            {
                 WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }     
        }

        private void RefreshGridDataSource()
        {
            _gridControl1.DataSource = null;
            AssignmentHandler hh = new AssignmentHandler();
            _gridControl1.DataSource = hh.GetAssignmentsByBookingId(_parentBooking.Id);
        }


        private void SaveAssignment()
        {
            CheckInputIsValid();

            _apt.BeginUpdate();
            _apt.Location = txtNote.Text;
            _apt.ResourceId = (chkResources.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource).Id;

            _apt.Start = this.dtpIn.DateTime.Date;
            _apt.End = this.dtpOut.DateTime.Date;


            BookingResource res = chkResources.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource;
            BedType bed = cboLetti.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType;
            _apt.CustomFields["Resource"] = res;
            _apt.CustomFields["Booking"] = _parentBooking;
            _apt.CustomFields["BedType"] = bed;

            if (_isCreationOp)
            {
                _control.Storage.Appointments.Add(_apt);
            }
            _apt.EndUpdate();
            
        }



        private void CheckInputIsValid()
        {
            //qui verifico l'inoput preventivamente.
            //non lascio la validazione finale all'oggetto di dominio per come è costruita la gui 
            //di devexpress

            //verifica delle date
            if (this.dtpOut.DateTime.Date <= this.dtpIn.DateTime.Date)
                throw new Exception("L'intervallo date inserito non è valido");
            //verifico la possibilità di aggiungere una nuova assegnazione oppure
            //se la modifica di una assegnazione può essere fatta
            AssignmentHandler h = new AssignmentHandler();

            int assignmentID = -1;
            if (!_isCreationOp)
            {
                Assignment a = _apt.GetSourceObject(_control.Storage) as Assignment;
                if (a == null)
                    throw new Exception("Impossibile otttenere il source object dall'appuntamento!! Contattare la noesis per la risoluzione del bug");
                assignmentID = a.Id;
            }
            

            FreeRoomCheck cc = h.IsRoomFree(this.dtpIn.DateTime.Date, this.dtpOut.DateTime.Date, chkResources.EditValue as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource, assignmentID);
            if (!cc.IsFree)
                throw new Exception(cc.Message);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
  
            try
            {
                //FrmAddContactToDocument frm = new FrmAddContactToDocument(ExtractCustomerList());
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    ReloadCustomerList(frm.Customers);
                //    StartChangeOperation();
                //}
                FormCheckin cc = new FormCheckin();
                if (cc.ShowDialog() == DialogResult.OK)
                {
                    if (cc.Checkin!= null)
                    {
                        Assignment ass = _apt.GetSourceObject(_control.Storage) as Assignment;
                        ass.AddCheckins(cc.Checkin );

                        lstcont.Items.Add(cc.Checkin );
                        lstcont.SelectedIndex = lstcont.Items.Count - 1;

                        LoadPicture(ass);
                    }
                }
                cc.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (lstcont.SelectedItem != null)
            {
                Assignment ass = _apt.GetSourceObject(_control.Storage) as Assignment;
                ass.Removecheckin((lstcont.SelectedItem as Checkin).Customer);
                lstcont.Items.RemoveAt(lstcont.SelectedIndex);
                LoadPicture(ass);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Assignment ass ;

            if (_currentAssignment == null)
            {
                ass = _apt.GetSourceObject(_control.Storage) as Assignment;
            }
            else
            {
                ass = _currentAssignment;
            }

            if (ass == null)
                return;
            

            IList l = new ArrayList();
            l.Add(ass);



            Reports.AssignmentReport rpt = new Reports.AssignmentReport();
            rpt.DataSource = l;
            rpt.ShowPreviewDialog();

        }

        private void lstcont_DoubleClick(object sender, EventArgs e)
        {
            Checkin ccc = lstcont.SelectedItem as Checkin;
            if (ccc == null)
                return;
            try
            {
                //FrmAddContactToDocument frm = new FrmAddContactToDocument(ExtractCustomerList());
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    ReloadCustomerList(frm.Customers);
                //    StartChangeOperation();
                //}
                FormCheckin cc = new FormCheckin(ccc);
                if (cc.ShowDialog() == DialogResult.OK)
                {
                    //if (cc.Checkin != null)
                    //{
                    //    Assignment ass = _apt.GetSourceObject(_control.Storage) as Assignment;
                    //    ass.AddCheckins(cc.Checkin);

                    //    lstcont.Items.Add(cc.Checkin);
                    //    lstcont.SelectedIndex = lstcont.Items.Count - 1;

                    //    LoadPicture(ass);
                    //}
                }
                cc.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }

        }
    }
}