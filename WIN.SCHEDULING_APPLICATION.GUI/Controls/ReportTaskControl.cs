using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using System.Collections;
using DevExpress.XtraEditors;
using System.IO;
using System.Reflection;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using DevExpress.XtraPrinting;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    public partial class ReportTaskControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        string fileLayout = "";

        public ReportTaskControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            CustomGUI_SetCommandBarVisibility(false);
            base.m_ChangeStateEnabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExecuteQuery();
        }

        private void ExecuteQuery()
        {
            try
            {

                WIN.GUI.UTILITY.Helper.ShowWaitBox("Elaborazione in corso...", Properties.Resources.Waiting);


                WIN.SCHEDULING_APPLICATION.HANDLERS.TaskHandler h = new WIN.SCHEDULING_APPLICATION.HANDLERS.TaskHandler();


                IList<IsearchDTO> dtos = new List<IsearchDTO>();

                dtos.Add(appointmentCustomerSearchControl1.CreateDTO());
                dtos.Add(appointmentDateSearchControl1.CreateDTO());
                dtos.Add(taskSimpleSearch1.CreateDTO());


                h.ExecuteQuery(dtos, -1, Properties.Settings.Default.Main_DeadlineDaysBefore);

                gridControl1.DataSource = h.BindableResults;


                if (h.BindableResults.Count == 0)
                    XtraMessageBox.Show("Nessun risultato è stato trovato. Riprovare con altri criteri di selezione!", "Nessun risultato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    try
                    {
                        gridControl1.MainView.SaveLayoutToXml(fileLayout);
                    }
                    catch (Exception)
                    {
                        //non fa nulla
                    }
                }
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }
            finally
            {
                WIN.GUI.UTILITY.Helper.HideWaitBox();
            }
        }

        private void ReportTaskControl_Load(object sender, EventArgs e)
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += "\\LayoutSavings\\reportAttivita.xml";


            //verifico la presenza del file
            f = new FileInfo(fileLayout);


            try
            {
                if (f.Exists)
                {
                    gridControl1.ForceInitialize();
                    // Restore the previously saved layout
                    gridControl1.MainView.RestoreLayoutFromXml(fileLayout);
                }
            }
            catch (Exception)
            {
                //non fa nulla
            }


            if (Properties.Settings.Default.Main_StartInitialSearch)
                ExecuteQuery();

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "OutcomeDate")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.OutcomeDate == DateTime.MinValue)
                        e.DisplayText = "";
                }
            }
            else if (e.Column.FieldName == "PercentageCompleteness")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.PercentageCompleteness == 0)
                        e.DisplayText = "";
                }
            }
            else if (e.Column.Name == "colFiscale")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.CodiceFiscale;
                }
            }
            else if (e.Column.Name == "colContatti")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Residenza.ToString();
                }
            }
            else if (e.Column.Name == "colTelContatti")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.TelefonoUfficio;
                }
            }
            else if (e.Column.Name == "colCell1")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.Cellulare1;
                }
            }
            else if (e.Column.Name == "colCell2")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.Cellulare2;
                }
            }

        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "OutlookDeadLineStateToString")
            {
                e.Info.Caption = string.Empty;
                e.Column.View.Images = imageCollection1;
                e.Column.ImageIndex = 11;
            }
            
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            ////inizializzo la griglia
            //gridView1.Columns["colActivityDeadlineStateToString"].Caption = string.Empty;
            //gridView1.Columns["colActivityDeadlineStateToString"].View.Images = imageCollection1;
            //gridView1.Columns["colActivityDeadlineStateToString"].ImageIndex = 11;
        }

        private void cmdPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                //gridControl1.ShowPrintPreview();

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.Component = gridControl1;
                link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                link.ShowPreview();


            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdPrintAll_Click(object sender, EventArgs e)
        {
            Print();
        }



        public override void Print()
        {
            try
            {
                ArrayList l = GetVisibleRecords();

                if (l.Count > 0)
                {
                    Reports.TaskReport c = new WIN.SCHEDULING_APP.GUI.Reports.TaskReport();
                    c.DataSource = l;
                    c.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private ArrayList GetVisibleRecords()
        {
            ArrayList l = new ArrayList();
            if (gridView1.RowCount > 0)
            {
                gridView1.ExpandAllGroups();
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int handle = gridView1.GetVisibleRowHandle(i);
                if (!gridView1.IsGroupRow(handle))
                {
                    MyTask a = gridView1.GetRow(handle) as MyTask;
                    if (a != null)
                        l.Add(a);

                }
            }
            return l;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MyTask label = view.GetRow(view.FocusedRowHandle) as MyTask;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(MyTask label)
        {
            TaskForm frm = new TaskForm(label);
            frm.CheckSecurityForView();
            frm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                TaskForm frm = new TaskForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.CurrentTask != null)
                    {
                        
                        IBindingList g = gridView1.DataSource as IBindingList;
                        g.Add(frm.CurrentTask);
                    }
                }
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    if (gridView1.IsDataRow(rowIndex))
                    {
                        TryDelete(gridView1.GetRow(rowIndex) as MyTask, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void TryDelete(MyTask myTask, int rowIndex)
        {
            if (myTask == null)
                return;

            if (XtraMessageBox.Show("Rimuovere l'attività selezionata?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TaskHandler h = new TaskHandler();
                h.Delete(myTask);

                IBindingList h1 = gridView1.DataSource as IBindingList;
                h1.Remove(myTask);
            }

        }


    }
}
