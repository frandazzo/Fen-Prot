using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class CustomerAssignmentForm : DevExpress.XtraEditors.XtraForm
    {
        public CustomerAssignmentForm(int customerId)
        {
            InitializeComponent();
            LoadDataForCustomer(customerId);

        }

        private void LoadDataForCustomer(int customerId)
        {
            IList customerAssignments = new ArrayList();

            AssignmentHandler h = new AssignmentHandler();

            customerAssignments = h.GetAssignmentsByCustomerId(customerId);

            gridControl1.DataSource = customerAssignments;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
         
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
               
                if (info.Column != null)
                {
                    if (info.Column.Name == "link")
                    {
                        //prendo l'oggetto e lo visualizzo
                        Assignment ass = view.GetRow(info.RowHandle) as Assignment;
                        CustomerBooking frm = new CustomerBooking(ass.Booking.Id);
                        frm.ShowDialog();
                        frm.Dispose();
                    }

                }

                

            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;

            Point pt = view.GridControl.PointToClient(Control.MousePosition);

            DoRowDoubleClick(view, pt);
        }

     

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
                e.Value = "Vai alla prenotazione";
        }
    }
}