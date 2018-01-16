using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using System.Collections;
using DevExpress.XtraPrinting;

namespace WIN.SCHEDULING_APP.GUI.Controls.CustomBookingFormAssets
{
    public partial class BookingForm : DevExpress.XtraEditors.XtraForm
    {

        SchedulerControl _control;
        DevExpress.XtraScheduler.Appointment _apt;
        bool _isNewAppointment = false;
        IBooking _currentBooking = null;
        bool _initializing;
        bool _bookingChanged;


        public BookingForm(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt, bool isNewAppointment)
        {
            InitializeComponent();

            _initializing = true;

            _control = control;
            _apt = apt;
            _isNewAppointment = isNewAppointment ;

            PaymentSectionInitializzation();

            _currentBooking = GetCurrentBooking();

            LoadComboTipoPrenotazione();
            LoadComboOperatori();
            LoadCurrentBookingData();


            _initializing = false;
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

        private void LoadComboTipoPrenotazione()
        {
            //preparo la combo delle zone
            cboTipo.Properties.Items.Clear();

            BookingTypeHandler h = new BookingTypeHandler();
            //la riempio
            cboTipo.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboTipo.SelectedIndex = 0;
        }
      

        private void LoadCurrentBookingData()
        {
            dtpDate.DateTime = _currentBooking.Date;
            memoEdit1.Text = _currentBooking.Notes;
            cboTipo.EditValue = _currentBooking.BookingType;
            cboOp.EditValue = _currentBooking.Operator;
            colorEdit1.Color = Color.FromArgb(_currentBooking.Color);
            chkColorBookings.Checked = _currentBooking.ColorBookings;
            memoEdit2.Text = _currentBooking.Notes1;
            chkConfirm.Checked = _currentBooking.Confirmed;
            if (_currentBooking.Confirmed)
            {
                //Visualizzo il pannello del pagamento
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //se è confermata avrà sicuramente un pagamento;
                lblRiepilogoSaldo.Text = String.Format("{0:c2}({1:c2})", _currentBooking.Payment.RestOfPayment, _currentBooking.Payment.ToPay ); 
                lblRiepilogoAcconto.Text = _currentBooking.Payment.Accont.ToString("c2");
                spTassa.EditValue = _currentBooking.Payment.StayTax;
                spTotale.EditValue = _currentBooking.Payment.Total;

                if (_currentBooking.Payment.Accont != 0)
                {
                    spAcconto.EditValue = _currentBooking.Payment.Accont;
                    cboModAcconto.EditValue = _currentBooking.Payment.AccountPaymentType ;
                    dtpAcconto.EditValue = _currentBooking.Payment.AccontData;
                }
                if (_currentBooking.Payment.RestOfPayment != 0)
                {
                    spSaldo.EditValue = _currentBooking.Payment.RestOfPayment;
                    cboModSaldo.EditValue = _currentBooking.Payment.RestOfPaymentPaymentType;
                    dtpSaldo.EditValue = _currentBooking.Payment.RestOfPaymentData;
                }
            }
            else
            {
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }




            AssignmentHandler hh = new AssignmentHandler();
            //prendo tutto dal db per la questione della cache
            IList k = hh.GetAssignmentsByBookingId(_currentBooking.Id);
            gridControl1.DataSource = k;

            //rinfresco
            SetImageAndDescriptionState();
        }

        private void PaymentSectionInitializzation()
        {
            decimal zeroValue = 0;
            spAcconto.EditValue = null;
            spSaldo.EditValue = null;
            dtpAcconto.EditValue = null;
            dtpSaldo.EditValue = null;
            LoadComboModalitaPagamento();
            spTotale.EditValue = zeroValue;
            spTassa.EditValue = zeroValue;
            lblRiepilogoSaldo.Text = String.Format("{0:c2}({1:c2})", zeroValue, spTotale.Value);
            lblRiepilogoAcconto.Text = zeroValue.ToString("c2");
        }

        private void LoadComboModalitaPagamento()
        {
            //preparo la combo delle zone
            cboModAcconto.Properties.Items.Clear();
            cboModSaldo.Properties.Items.Clear();

            PaymentTypeHandler h = new PaymentTypeHandler();
            IList l = h.GetAll();
            //la riempio
            cboModAcconto.Properties.Items.Add("");
            cboModAcconto.Properties.Items.AddRange(l);

            cboModSaldo.Properties.Items.Add("");
            cboModSaldo.Properties.Items.AddRange(l);

            //seleziono quella iniziale
            cboModAcconto.SelectedIndex = 0;
            cboModSaldo.SelectedIndex = 0;
        }

        private IBooking GetCurrentBooking()
        {
            if (_isNewAppointment)
                return CreateNewBooking();
            else
                return ExtractBookingFromAppointment();
        }

        private IBooking ExtractBookingFromAppointment()
        {

            //proteggere questo metodo
            Assignment ass = _apt.GetSourceObject(_control.Storage ) as Assignment ;
            //non è possibile se l'appuntamento non è nuovo che non ci sia un assignment associato!!!!
            if (ass == null)
                throw new Exception("Impossibile trovare una assegnazione associata all'appuntamento. Contattare la Noesis per la risoluzione del bug");

            IBooking b = ass.Booking;//_apt.GetValue(_control.Storage, "Booking") as Booking;

            //non è possibile che una assegnazione non sia collegata ad una prenotazione !!! anche questo se si verifica è un bug

            if (b == null)
                throw new Exception("Impossiblile trovare la prenotazione associata all'assegnazione della camera. Contattare la Noesis per la risoluzione del bug");

            return b;
        }

        private IBooking CreateNewBooking()
        {
            BookingHandler h = new BookingHandler();

            IBooking b = new Booking();
            b.Date = DateTime.Now;
            b.BookingType = new BookingTypeHandler().GetAll()[0] as BookingType;
            b.Notes = "";
            b.Operator = null;
            b.Color = Color.WhiteSmoke.ToArgb();
            b.ColorBookings = false;
            b.Notes1 = "";
            b.UnConfirmBooking();

            h.SaveOrUpdate(b as Booking);

            return b;
           
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            try
            {
              //  CheckIfDeleteBooking();

                this.Close();
                
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }
            
        }

        private void DeleteBooking()
        {
           

                BookingHandler h = new BookingHandler();
                h.Delete(_currentBooking as Booking);
           
        }

        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            if (_initializing)
                return;
            _bookingChanged = true;
        }

        private void memoEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {

            try
            {
                //// verifico il numero delle assegnazioni
                //if (_currentBooking.Assignments.Count == 0)
                //{
                //    if (XtraMessageBox.Show("Non ci sono assegnazioni di camere per la prenotazione corrente. La prenotazione sarà cancellata! Procedere?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        BookingHandler h = new BookingHandler();
                //        h.Delete(_currentBooking as Booking);

                //        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                //        this.Close();
                //        return;
                //    }
                //    //non fa nulla se rispondo di no!!!!
                //    return;
                //}


                if (_bookingChanged)
                {
                    //salvo le modifiche della prenotazione       
                    UpdateBooking();
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }
        }

        private void UpdateRiepiloghi()
        {
            decimal zeroValue = 0;
            if (spAcconto.Value != 0)
                lblRiepilogoAcconto.Text = spAcconto.Value.ToString("c2");
            else
            {
                lblRiepilogoAcconto.Text = zeroValue.ToString("c2");
                spAcconto.EditValue = null;
                cboModAcconto.EditValue = null;
                dtpAcconto.EditValue = null;
            }

            if (spSaldo.Value != 0)
                lblRiepilogoSaldo.Text = String.Format("{0:c2}({1:c2})", spSaldo.Value, spTotale.Value - spAcconto.Value - spSaldo.Value );
            else
            {
                lblRiepilogoSaldo.Text = String.Format("{0:c2}({1:c2})", zeroValue, spTotale.Value - spAcconto.Value);
                spSaldo.EditValue = null;
                cboModSaldo.EditValue = null;
                dtpSaldo.EditValue = null;
            }
            
            
        }
        private void UpdateBooking()
        {
            _currentBooking.Date = dtpDate.DateTime;
            _currentBooking.BookingType = cboTipo.EditValue as BookingType;
            _currentBooking.Notes = memoEdit1.Text;
            _currentBooking.Operator = cboOp.EditValue as Operator;
            _currentBooking.Color = colorEdit1.Color.ToArgb();
            _currentBooking.ColorBookings = chkColorBookings.Checked;
            _currentBooking.Notes1 = memoEdit2.Text;
            if (chkConfirm.Checked)
            {
                _currentBooking.ConfirmBooking();
                //aggiungo tutti gli altri dati di conferma
              

                    _currentBooking.SetTotal((float)spTotale.Value);
                    _currentBooking.SetStayTax((float)spTassa .Value);

                    if (spAcconto.Value != 0)
                    {
                        _currentBooking.SetAccount(dtpAcconto.DateTime, (float)spAcconto.Value, cboModAcconto.EditValue as PaymentType);

                    }
                    else
                        _currentBooking.SetAccount(DateTime.MinValue, 0, null);

                    if (spSaldo.Value != 0)
                    {
                        _currentBooking.SetRestOfTypePayment(dtpSaldo.DateTime, (float)spSaldo.Value, cboModSaldo.EditValue as PaymentType);
                    }
                    else
                        _currentBooking.SetRestOfTypePayment(DateTime.MinValue, 0, null);
                







            }
            else
                _currentBooking.UnConfirmBooking();

            BookingHandler h = new BookingHandler();
            h.SaveOrUpdate(_currentBooking.BaseObject);

            //rinfresco
            SetImageAndDescriptionState();
            UpdateRiepiloghi();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

                if (_bookingChanged)
                {
                    //salvo le modifiche della prenotazione       
                    UpdateBooking();
                }
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }   
          

        }

        private void add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                AssignmentForm frm = new AssignmentForm(_control, CreateNewAppointment(_apt), _currentBooking, gridControl1);
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }   
          
        }


        private Appointment CreateNewAppointment(Appointment template)
        {
            Appointment a  = _control.Storage.CreateAppointment(AppointmentType.Normal);
            a.AllDay = true;
            a.Start = template.Start;
            a.End = template.End;
            a.ResourceId = template.ResourceId;

            return a;
        }

        private void rem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               Assignment a = gridView1.GetRow(gridView1.FocusedRowHandle) as Assignment;
               IBooking b = a.Booking;
               if (a != null)
               {
                   //if (XtraMessageBox.Show("Rimuovere l'assegnazione selezionata?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                   //{
                       Appointment app = GetAppointment(a);
                       if (app != null)
                       {
                           _control.Storage.Appointments.Remove(app);
                       }

                        //dopo che viene eseguito l'evento posso procedere a verificare lo stato della prenotazione
                        //se non ci sono altre assegnazioni posso chiudere il form (la prenotazione è stata cancellata dal
                        //bookingControl
                       //if (b.Assignments.Count == 0)
                       //    this.Close();
                       //else //ripristibno il data source della griglia
                       //{
                           gridControl1.DataSource = null;
                           AssignmentHandler hh = new AssignmentHandler();
                           //prendo tutto dal db per la questione della cache
                           gridControl1.DataSource = hh.GetAssignmentsByBookingId(_currentBooking.Id);
                       //}

                   //}
               }
               else
               {
                   XtraMessageBox.Show("Selezionare una assegnazione!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private Appointment GetAppointment(Assignment a)
        {
            foreach (Appointment item in _control.Storage.Appointments.Items)
            {
                Assignment ass = item.GetSourceObject(_control.Storage) as Assignment;
                if (ass.Id == a.Id)
                    return item;
            }
            return null;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                Assignment label = view.GetRow(view.FocusedRowHandle) as Assignment;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(Assignment label)
        {
            AssignmentForm frm = new AssignmentForm(_control, GetAppointment(label), _currentBooking, gridControl1);
            
            frm.ShowDialog();
            frm.Dispose ();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControlItem4.Visibility =  DevExpress.XtraLayout.Utils.LayoutVisibility.Never ;     
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlGroup6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;


           
            PrintableComponentLink link = new PrintableComponentLink( new PrintingSystem());
            link.Component = layoutControl1;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.Landscape = true;
            link.ShowPreview();
            //layoutControl1.ShowPrintPreview();

            layoutControlGroup5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlGroup6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            emptySpaceItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void SetImageAndDescriptionState()
        {
            BookingState state = _currentBooking.State;
            switch (state)
            {
                case BookingState.NotConfirmed:
                    pictureEdit1.Image = imageCollection1.Images[1];
                    lblstateDescription.Text = "Prenotazione non confermata";
                    break;
                case BookingState.ConfirmedWithAccont:
                    pictureEdit1.Image = imageCollection1.Images[5];
                    lblstateDescription.Text = "Prenotazione confermata";
                    break;
                case BookingState.ConfimedWithoutAccount:
                    pictureEdit1.Image = imageCollection1.Images[4];
                    lblstateDescription.Text = "Prenotazione confermata senza acconto";
                    break;
                case BookingState.Closed:
                    pictureEdit1.Image = imageCollection1.Images[0];
                    lblstateDescription.Text = "Prenotazione conclusa";
                    break;
                default:
                    break;
            }


            
        }

        private void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConfirm.Checked)
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            else
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            Change();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("La prenotazione corrente sarà eliminata. Continuare?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    //elimino dal calendario tutte le assegnazioni
                    foreach (Assignment item in _currentBooking.Assignments)
                    {
                        Appointment app = GetAppointment(item);
                        if (app != null)
                        {
                            _control.Storage.Appointments.Remove(app);
                        }    
                    }
                    

                    BookingHandler h = new BookingHandler();
                    h.Delete(_currentBooking.BaseObject);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cboTipo_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void cboOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void colorEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void chkColorBookings_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void spTotale_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void spTassa_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void dtpAcconto_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void spAcconto_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void cboModAcconto_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void dtpSaldo_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void spSaldo_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void cboModSaldo_EditValueChanged(object sender, EventArgs e)
        {
            Change();
        }

        private void memoEdit2_EditValueChanged(object sender, EventArgs e)
        {
             Change();
        }

        private void BookingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_currentBooking.Assignments.Count == 0)
            {
                if (XtraMessageBox.Show("Se non ci sono assegnazioni la prenotazione verrà eliminata! Continuare?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteBooking();
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }

           
            
        }

      


    }
}