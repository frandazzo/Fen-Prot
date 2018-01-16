using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmRicercaCartelleDocumenti : DevExpress.XtraEditors.XtraForm
    {
         private int _id = -1;


        public int SelectedId
        {
            get
            {
                return _id;
            }
        }

        public FrmRicercaCartelleDocumenti()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            DocumentScopeHandler h = new DocumentScopeHandler();

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
               
                XtraMessageBox.Show("Selezionare almeno una cartella documento!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope label = gridView1.GetRow(gridView1.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope;
            SetSelectedId(label);

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            GridView View = sender as GridView;
            if (e.Column.FieldName == "Descrizione")
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope label = View.GetRow(e.RowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope;

                int color = label.Color;

                e.Appearance.BackColor = Color.FromArgb(color);

            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _id = -1;
                GridView view  = sender as GridView;
                Point pt  = view.GridControl.PointToClient(Control.MousePosition);
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
                WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope label = view.GetRow(view.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope;
                SetSelectedId(label);
            }
        }

        private void SetSelectedId(WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope label)
        {
            if (label != null)
            {
                _id = label.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Selezionare una cartella documento!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}