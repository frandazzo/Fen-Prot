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
    public partial class FrmRicercaTipiDocumento : DevExpress.XtraEditors.XtraForm
    {
         private int _id = -1;


        public int SelectedId
        {
            get
            {
                return _id;
            }
        }

        public FrmRicercaTipiDocumento()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            DocumentTypeHandler h = new DocumentTypeHandler();

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
               
                XtraMessageBox.Show("Selezionare almeno una causale documento!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType label = gridView1.GetRow(gridView1.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType;
            SetSelectedId(label);

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0)
                return;

            GridView View = sender as GridView;
            if (e.Column.FieldName == "Descrizione")
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType label = View.GetRow(e.RowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType;

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
                WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType label = view.GetRow(view.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType;
                SetSelectedId(label);
            }
        }

        private void SetSelectedId(WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType label)
        {
            if (label != null)
            {
                _id = label.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Selezionare una causale documento!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}