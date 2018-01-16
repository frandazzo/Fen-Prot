using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext()]
    public partial class DocumentiClienteControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
         Customer _current;
        IList _documents = new ArrayList();

        public DocumentiClienteControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            //avvio le procedure per la ricerca di un nuovo elemento
            StartSearchOperation();
            //non permetto nessuna operazione dalla toolbar
            base.m_ChangeStateEnabled = false;
        }

        public DocumentiClienteControl(Customer customer, MainForm form)
            : base(form)
        {
            InitializeComponent();

            //avvio le procedure per il caricamento
            if (customer != null)
            {//imposto fittiziamente l'id a 1 per evitare il ripristino dello stato di ricerca
                m_IdShowedObject = 1;
                _current = customer;
            }
            StartLoadOperation();
            //non permetto nessuna operazione dalla toolbar
            base.m_ChangeStateEnabled = false;
        }


        #region Print

        public override void Print()
        {
            try
            {
                ArrayList l = GetVisibleRecords();

                if (l.Count > 0)
                {
                    Reports.DocumentReport c = new WIN.SCHEDULING_APP.GUI.Reports.DocumentReport();
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

        #endregion



        #region Ricerca

        public override void DoSearch()
        {
            //metto la barra nello stato di ricerca
            //commandBar1.CustomGUI_SetInterfaceState(WIN.SCHEDULING_APP.GUI.Utility.GUIState.Ricerca);
            //commandBar1.Custom_SetFunctionName("Ricerca causale");
            commandBar1.Custom_SetIdentifier("");
            layoutControl1.Visible = false;
        }

        #endregion

        #region Visualizzazione


        protected override void Nested_PrepareLoading()
        {
            layoutControl1.Visible = true;
        }

        protected override void Nested_LoadDataFromDataSource()
        {
            DocumentHandler h = new DocumentHandler();
            h.GetUserDocuments(_current); ;
            _documents = h.BindableResults;
                

        }

        protected override void Nested_LoadEditorsProperties()
        {
            if (_current != null)
            {
                layoutControlGroup2.Text = "Lista documenti contatto - " + _current.Descrizione;
                gridControl1.DataSource = _documents;
                commandBar1.Custom_SetIdentifier(_current.Id.ToString());
            }
        }

        public override void Nested_NotifyParent()
        {
            string desc = "";

            if (_current != null)
            {
                desc = _current.Descrizione;
            }

            commandBar1.CustomGUI_SetInterfaceState(commandBar1.Custom_GetCommandBarStateFromGuiState(base.State.StateName));
            commandBar1.Custom_SetSearchButtonEnabled(false);
            commandBar1.Custom_SetDeleteButtonEnabled(true);
            commandBar1.Custom_SetPrintButtonEnabled(false);
            commandBar1.Custom_SetInfoButtonEnabled(false);
            commandBar1.Custom_SetFunctionName(string.Format(base.State.StateName + " documenti contatto: {0}", desc));
        }


        #endregion

        private void commandBar1_NewCommandPressed(object sender, EventArgs e)
        {
            try
            {
                //Hashtable h = new Hashtable();
                //h.Add("Id", _current.Id);
                //h.Add("Customer", _current);
                //base.NavigateTo("Tasks", h);
                try
                {
                    Nested_CheckSecurityForCreation();
                    DocumentForm frm = new DocumentForm(_current);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.CurrentDocument != null)
                        {

                            IBindingList g = gridView1.DataSource as IBindingList;
                            g.Add(frm.CurrentDocument);
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
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                //gridControl1.ShowPrintPreview ();
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
            if (view.FocusedRowHandle >= 0)
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.Document label = view.GetRow(view.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                if (label != null)
                    Goto(label);
            }
        }

        private void Goto(WIN.SCHEDULING_APPLICATION.DOMAIN.Document label)
        {
            //Hashtable h = new Hashtable();
            //h.Add("Id", label.Id);
            //h.Add("Task", label);
            //NavigateTo("Tasks", h);
            DocumentForm frm = new DocumentForm(label);
            frm.CheckSecurityForView();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "OutcomeDate")
                {
                    if (Convert.ToDateTime(e.Value) == DateTime.MinValue) e.DisplayText = "";
                    return;
                }

                if (e.Column.FieldName == "DaysBeforeDeadline")
                {
                    if (Convert.ToInt32(e.Value) == 0) e.DisplayText = "";
                    return;
                }


                if (e.Column.FieldName == "DaysAfterDeadline")
                {
                    if (Convert.ToInt32(e.Value) == 0) e.DisplayText = "";
                    return;
                }

            }
            catch (Exception)
            {
                //
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {

        }

        private void commandBar1_DelCommandPressed(object sender, EventArgs e)
        {
            WIN.SCHEDULING_APPLICATION.DOMAIN.Document label = null;
            if (gridView1.FocusedRowHandle >= 0)
            {
                label = gridView1.GetRow(gridView1.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                if (label == null)
                    return;
            }


            try
            {
                if (XtraMessageBox.Show("Sicuro di voler procedere? ", "Elimina documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Nested_CheckSecurityForDeletion();

                    DocumentHandler h = new DocumentHandler();
                    h.Delete(_current);

                    IBindingList g = gridView1.DataSource as IBindingList;
                    g.Remove(label);
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

        [Secure(Area = "Documenti", Alias = "Elimina documento da contatto", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForDeletion()
        {
            SecurityManager.Instance.Check();
        }

        [Secure(Area = "Documenti", Alias = "Crea documento da contatto", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForCreation()
        {
            SecurityManager.Instance.Check();
        }




        private void gridView1_CustomColumnDisplayText_1(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Date")
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.Document app = gridView1.GetRow(e.RowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                if (app != null)
                {
                    e.DisplayText = app.Date.ToLongDateString();
                }
            }
        }


    }
}


