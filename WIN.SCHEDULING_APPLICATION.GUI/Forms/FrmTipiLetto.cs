using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Collections;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmTipiLetto : DevExpress.XtraEditors.XtraForm
    {
         private int _id = -1;


        public int SelectedId
        {
            get
            {
                return _id;
            }
        }

        public FrmTipiLetto()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            BedTypeHandler h = new BedTypeHandler();

            IList l = h.GetAll();

            gridControl1.DataSource = l;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            //gridControl1.ShowPrintPreview ();
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = gridControl1;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.ShowPreview();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            _id = -1;

            if (gridView1.SelectedRowsCount != 1)
            {

                XtraMessageBox.Show("Selezionare almeno una causale!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType label = gridView1.GetRow(gridView1.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType;
            SetSelectedId(label);

        }



    

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType label = view.GetRow(view.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType;
                SetSelectedId(label);
            }
        }

        private void SetSelectedId(WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BedType label)
        {
            if (label != null)
            {
                _id = label.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Selezionare un tipo letto!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                _id = -1;
                GridView view = sender as GridView;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }
    }
}