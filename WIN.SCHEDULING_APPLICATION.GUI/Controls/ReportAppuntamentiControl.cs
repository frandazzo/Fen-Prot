using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APP.GUI.Utility;
using System.Reflection;
using System.IO;
using DevExpress.XtraPrinting;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    public partial class ReportAppuntamentiControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        string fileLayout = "";

        public ReportAppuntamentiControl(MainForm form)
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


                WIN.SCHEDULING_APPLICATION.HANDLERS.AppointmentHandler h = new WIN.SCHEDULING_APPLICATION.HANDLERS.AppointmentHandler();


                IList<IsearchDTO> dtos = new List<IsearchDTO>();

                dtos.Add(appointmentCustomerSearchControl1.CreateDTO());
                dtos.Add(appointmentDateSearchControl1.CreateDTO());
                dtos.Add(appointmentSimplesearchControl1.CreateDTO());
                dtos.Add(appointmentStateSeachControl1.CreateDTO());

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




        #region Print

        public override void Print()
        {
            try
            {
                ArrayList l = GetVisibleRecords();

                if (l.Count > 0)
                {
                    Reports.AppointmentReport c = new WIN.SCHEDULING_APP.GUI.Reports.AppointmentReport();
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
                    MyAppointment a = gridView1.GetRow(handle) as MyAppointment;
                    if (a != null)
                        l.Add(a);

                }
            }
            return l;
        }

        #endregion

        private void ReportAppuntamentiControl_Load(object sender, EventArgs e)
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += "\\LayoutSavings\\reportAppuntamenti.xml";


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
                MyAppointment app = gridView1.GetRow(e.RowHandle) as MyAppointment;
                if (app != null)
                {
                    if (app.OutcomeDate == DateTime.MinValue)
                        e.DisplayText = "";
                }
            }
            else if (e.Column.Name == "colFiscale")
            {
                MyAppointment app = gridView1.GetRow(e.RowHandle) as MyAppointment;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.CodiceFiscale;
                }
            }
            else if (e.Column.Name == "colContatti")
            {
                MyAppointment app = gridView1.GetRow(e.RowHandle) as MyAppointment;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Residenza.ToString();
                }
            }
            else if (e.Column.Name == "colTelContatti")
            {
                MyAppointment app = gridView1.GetRow(e.RowHandle) as MyAppointment;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.TelefonoUfficio;
                }
            }
            else if (e.Column.Name == "colCell1")
            {
                MyAppointment app = gridView1.GetRow(e.RowHandle) as MyAppointment;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.Cellulare1;
                }
            }
            else if (e.Column.Name == "colCell2")
            {
                MyAppointment app = gridView1.GetRow(e.RowHandle) as MyAppointment;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.Cellulare2;
                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentForm frm = new AppointmentForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.Appointment != null)
                    {

                        IBindingList g = gridView1.DataSource as IBindingList;
                        g.Add(frm.Appointment);
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
                MyAppointment label = view.GetRow(view.FocusedRowHandle) as MyAppointment;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(MyAppointment label)
        {
            AppointmentForm frm = new AppointmentForm(label);
            frm.CheckSecurityForView();
            frm.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    if (gridView1.IsDataRow(rowIndex))
                    {
                        TryDelete(gridView1.GetRow(rowIndex) as MyAppointment, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void TryDelete(MyAppointment myTask, int rowIndex)
        {
            if (myTask == null)
                return;

            if (XtraMessageBox.Show("Rimuovere l'appuntamento selezionato?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AppointmentHandler h = new AppointmentHandler();
                h.Delete(myTask);

                IBindingList h1 = gridView1.DataSource as IBindingList;
                h1.Remove(myTask);
            }

        }
    


    }
}
