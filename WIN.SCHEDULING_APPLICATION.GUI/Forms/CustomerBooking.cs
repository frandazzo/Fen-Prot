using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APP.GUI.Controls.CustomBookingFormAssets;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class CustomerBooking : DevExpress.XtraEditors.XtraForm
    {
        Booking _currentBooking;

        public CustomerBooking(int bookingId)
        {
            InitializeComponent();

             BookingHandler h = new BookingHandler();
             _currentBooking = h.GetElementById(bookingId.ToString()) as Booking ;
             PaymentSectionInitializzation();
             LoadComboTipoPrenotazione();
             LoadComboOperatori();
             LoadCurrentBookingData();
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
            AssignmentForm frm = new AssignmentForm(label);
            
            frm.ShowDialog();
            frm.Dispose ();
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

   

    }
}