using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using DevExpress.XtraEditors;
using System.IO;
using System.Reflection;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using DevExpress.XtraPrinting;
using WIN.SCHEDULING_APP.GUI.Utility;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.Utils.Drawing;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.SCHEDULING_APP.GUI.Reports;
using System.Threading;
using WIN.SCHEDULING_APP.GUI.Forms.UnhadledCode;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess;
using WIN.SECURITY.Core;
using System.Linq;


namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext()]
    public partial class DocumentControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {

        string fileLayout = "";
        WIN.SCHEDULING_APPLICATION.DOMAIN.Document _previewDoc;
    //    DocumentForm frm;

        public DocumentControl()
        {
            InitializeComponent();
            CustomGUI_SetCommandBarVisibility(false);
            base.m_ChangeStateEnabled = false;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            ExecuteQuery();
        }

        private void ExecuteQuery()
        {
           // LoadNotAvailablePreviewOnRichtext();
            
            try
            {

                WIN.GUI.UTILITY.Helper.ShowWaitBox("Elaborazione in corso...", Properties.Resources.Waiting);


                WIN.SCHEDULING_APPLICATION.HANDLERS.DocumentHandler h = new WIN.SCHEDULING_APPLICATION.HANDLERS.DocumentHandler();


                IList<IsearchDTO> dtos = new List<IsearchDTO>();

                dtos.Add(appointmentCustomerSearchControl1.CreateDTO());
                dtos.Add(documentSearchControl1.CreateDTO());
                


                h.ExecuteQuery(dtos, -1);


                gridView2.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);      

                gridControl2.DataSource = h.BindableResults;

                gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);


                if (h.BindableResults.Count == 0)
                    XtraMessageBox.Show("Nessun risultato è stato trovato. Riprovare con altri criteri di selezione!", "Nessun risultato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    try
                    {
                        gridControl2.MainView.SaveLayoutToXml(fileLayout);
                    }
                    catch (Exception)
                    {
                        //non fa nulla
                    }
                }


                //Seleziono la prima
                if (h.BindableResults.Count > 0)
                    ShowDocumentPreviewAt(0);
                else
                    LoadNotAvailablePreviewOnRichtext();

                gridView2.ExpandAllGroups();
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

        private void ShowDocumentPreviewAt(int index)
        {
            gridView2.FocusedRowHandle = index;
            WIN.SCHEDULING_APPLICATION.DOMAIN.Document doc = gridView2.GetRow(index) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
            _previewDoc = doc;

            if (index >=0)
            {
                using (MemoryStream m = new MemoryStream(doc.Body.Document))
                {
                    lblSub.Text = doc.Subject;
                    lblCreated.Text = string.Format("Creato: {0}", doc.Date.ToLongDateString() );
                    lblPriority.Text = string.Format("Priorità: {0}", doc.PriorityToString);
                    lblContatti.Text = string.Format("Contatti: {0}", doc.ContactList );
                    lblType.Text = string.Format("Documento: {0} - {1}", doc .Protocol, doc.NatureToString);
                    lblCausale.Text = string.Format("Causale: {0}", doc.Type!=null? doc.Type.Descrizione:"");


                    //svuoto la imagelist
                    imageList1.Images.Clear();
                    imageListBoxControl1.Items.Clear();
                    foreach (AttachmentForDocument item in doc.Attachments)
                    {
                        imageListBoxControl1.Items.Add(item, GetFileImageIndex(item));
                    }


                    rchbody.LoadDocument(m, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
                }
            }
            else
                LoadNotAvailablePreviewOnRichtext();
        }




        private int GetFileImageIndex(AttachmentForDocument attachmentForDocument)
        {
            if (attachmentForDocument == null)
                throw new ArgumentException("Allegato");

            if (!attachmentForDocument.AttachmentExist)
            {
                //aggiungo l'icona di warning all'imagecollection
                imageList1.Images.Add(Properties.Resources.warning_16);
                return imageList1.Images.Count - 1;
            }

            SHFILEINFO shinfo = new SHFILEINFO();
            //SHFILEINFO shinfo1 = new SHFILEINFO();
            IntPtr hImgSmall; //the handle to the system image list
            //IntPtr hImgLarge; //the handle to the system image list

            //copio il file localmente per fare in modo che possa trarne le informazioni per l'icona

            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            string temp = p.CopyUncFileToLocalTempFolder(attachmentForDocument.AttachmentCompletePath);
            //Use this to get the small Icon
            hImgSmall = Win32.SHGetFileInfo(temp, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            //The icon is returned in the hIcon member of the shinfo struct
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

            ////Use this to get the large Icon
            //hImgLarge = Win32.SHGetFileInfo(fName, 0, ref shinfo1, (uint)Marshal.SizeOf(shinfo1), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            ////The icon is returned in the hIcon member of the shinfo struct
            //System.Drawing.Icon myIcon1 = System.Drawing.Icon.FromHandle(shinfo1.hIcon);

            imageList1.Images.Add(myIcon);


            return imageList1.Images.Count - 1;
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    DocumentForm frm = new DocumentForm();
                    frm.CheckSecurityForInsert();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frm.CurrentDocument != null)
                        {

                            IBindingList g = gridView2.DataSource as IBindingList;
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

        [Secure(Area = "Documenti", Alias = "Elimina documento da report", MacroArea = "Applicativo")]
        public void CheckSecurityForDeletion()
        {
            try
            {
                SecurityManager.Instance.Check();
            }
            catch (Exception)
            {
                
                throw;
            }
            
               
         
            
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {

            try
            {
                CheckSecurityForDeletion();
                foreach (int rowIndex in gridView2.GetSelectedRows())
                {
                    if (gridView2.IsDataRow(rowIndex))
                    {
                        TryDelete(gridView2.GetRow(rowIndex) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document, rowIndex);
                    }
                }
            }
            catch (AccessDeniedException)
            {
                ErrorHandler.Show("Funzionalità non abilitata. Accesso negato");
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
                //gridControl1.ShowPrintPreview();

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.Component = gridControl2;
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









        public DocumentControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            CustomGUI_SetCommandBarVisibility(false);
            base.m_ChangeStateEnabled = false;
        }


        private void RestoreLayout()
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += "\\LayoutSavings\\reportDocumenti.xml";


            //verifico la presenza del file
            f = new FileInfo(fileLayout);


            try
            {
                if (f.Exists)
                {
                    gridControl2.ForceInitialize();
                    // Restore the previously saved layout
                    gridControl2.MainView.RestoreLayoutFromXml(fileLayout);
                }
                else
                {
                    LoadGridStyle();
                }
            }
            catch (Exception)
            {
                //non fa nulla
            }
        }

    
     

        

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
            if (gridView2.RowCount > 0)
            {
                gridView2.ExpandAllGroups();
            }
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                int handle = gridView2.GetVisibleRowHandle(i);
                if (!gridView2.IsGroupRow(handle))
                {
                    WIN.SCHEDULING_APPLICATION.DOMAIN.Document a = gridView2.GetRow(handle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                    if (a != null)
                        l.Add(a);

                }
            }
            return l;
        }

   

        
        private void TryDelete(WIN.SCHEDULING_APPLICATION.DOMAIN.Document myTask, int rowIndex)
        {
            if (myTask == null)
                return;

            if (XtraMessageBox.Show("Rimuovere il documento selezionato?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DocumentHandler h = new DocumentHandler();
                h.Delete(myTask);

                IBindingList h1 = gridView2.DataSource as IBindingList;
                h1.Remove(myTask);
            }

        }

        private void DocumentControl_Load(object sender, EventArgs e)
        {
            RestoreLayout();


            //if (!Properties.Settings.Default.Main_PreviewDocument)
            //{
            //    splitContainerControl3.Collapsed = true;
            //}
            //else
            //{
            //    splitContainerControl3.Collapsed = false;
            //    LoadNotAvailablePreviewOnRichtext();
            //}


            //if (Properties.Settings.Default.Main_StartInitialSearch)
            //    ExecuteQuery();


        }

        private void LoadGridStyle()
        {
            gridView2.OptionsView.GroupDrawMode = GroupDrawMode.Office2003;
            gridView2.Columns["Date"].GroupIndex = 0;
            gridView2.Columns["Date"].GroupInterval = ColumnGroupInterval.DateRange;
            gridView2.Columns["Date"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            //gridView1.Columns["date"].VisibleIndex = 0;
            gridView2.OptionsView.ShowGroupedColumns = true;
            gridView2.OptionsView.ShowGroupPanel = false;
            //gridView2.SetRowExpanded(-1, true);
            //gridView2.SetRowExpanded(-2, true);
            gridView2.ExpandAllGroups();
        }

        private void LoadNotAvailablePreviewOnRichtext()
        {
            _previewDoc = null;
            if (!splitContainerControl3.Collapsed)
            {
                lblSub.Text = "";
                lblCreated.Text = "";
                lblPriority.Text = "";
                lblContatti.Text = "";
                lblType.Text = "";
                rchbody.RtfText = PreviewNotavailableBody.Body;
                lblCausale.Text = "";
                //svuoto la imagelist
                imageList1.Images.Clear();
                imageListBoxControl1.Items.Clear();
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowClick(view, pt);
        }

        private void DoRowClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                ShowDocumentPreviewAt(view.FocusedRowHandle);
                return;
            }

        }

        private void gridView2_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "ContainsAttachments")
            {
                e.Info.Caption = string.Empty;
                e.Column.View.Images = imageCollection1;
                e.Column.ImageIndex = 2;
                RemoveSortGlyphIfNeccessary(e);
            }

            if (e.Column != null && e.Column.FieldName == "PriorityToString")
            {
                e.Info.Caption = string.Empty;
                e.Column.View.Images = imageCollection1;
                e.Column.ImageIndex = 3;
                RemoveSortGlyphIfNeccessary(e);
            }

            if (e.Column != null && e.Column.FieldName == "NatureToString")
            {

                RemoveSortGlyphIfNeccessary(e);
            }

            


        }

        private void RemoveSortGlyphIfNeccessary(ColumnHeaderCustomDrawEventArgs args)
        {
            DrawElementInfo elementInfo = FindSortGlyphElement(args.Info);
            if (elementInfo == null)
                return;
            args.Info.InnerElements.Remove(elementInfo);
            args.Painter.CalcObjectBounds(args.Info);
        }
        private  DrawElementInfo FindSortGlyphElement(DevExpress.XtraGrid.Drawing.GridColumnInfoArgs info)
        {
            foreach (DrawElementInfo innerElement in info.InnerElements)
                if (innerElement.ElementInfo is SortedShapeObjectInfoArgs)
                    return innerElement;
            return null;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //if (e.FocusedRowHandle > 0 )
                if (!splitContainerControl3.Collapsed)
                {
                    ShowDocumentPreviewAt(e.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
           
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Date")
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.Document app = gridView2.GetRow(e.RowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                if (app != null)
                {
                    e.DisplayText = app.Date.ToLongDateString();
                }
            }
        }

        private void gridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == GridHitTest.Column)
            {
                //your code here
                if (hitInfo.Column.Name == "colDate")
                {
                    gridView2.Columns["Date"].GroupIndex = 0;
                    gridView2.Columns["Date"].GroupInterval = ColumnGroupInterval.DateRange;
                }
                else if (hitInfo.Column.Name == "colSubject")
                {
                    gridView2.Columns["Subject"].GroupIndex = 0;
                    gridView2.Columns["Subject"].GroupInterval = ColumnGroupInterval.Alphabetical;
                }
                else if (hitInfo.Column.Name == "colScope")
                {
                    gridView2.Columns["Scope"].GroupIndex = 0;
                    gridView2.Columns["Scope"].GroupInterval = ColumnGroupInterval.DisplayText;
                }
                else if (hitInfo.Column.Name == "colType")
                {
                    gridView2.Columns["Type"].GroupIndex = 0;
                    gridView2.Columns["Type"].GroupInterval = ColumnGroupInterval.DisplayText;
                }
                else if (hitInfo.Column.Name == "colOperator")
                {
                    gridView2.Columns["Operator"].GroupIndex = 0;
                    gridView2.Columns["Operator"].GroupInterval = ColumnGroupInterval.DisplayText;
                }
                else if (hitInfo.Column.Name == "colProtocol")
                {
                    gridView2.Columns["Protocol"].GroupIndex = 0;
                    gridView2.Columns["Protocol"].GroupInterval = ColumnGroupInterval.Default;
                }
                else if (hitInfo.Column.Name == "colResponsable")
                {
                    gridView2.Columns["Responsable"].GroupIndex = 0;
                    gridView2.Columns["Responsable"].GroupInterval = ColumnGroupInterval.DisplayText;
                }
                else if (hitInfo.Column.Name == "colPriorityToString")
                {
                    gridView2.Columns["PriorityToString"].GroupIndex = 0;
                    gridView2.Columns["PriorityToString"].GroupInterval = ColumnGroupInterval.Value;
                }
                else if (hitInfo.Column.Name == "colNatureToString")
                {
                    gridView2.Columns["NatureToString"].GroupIndex = 0;
                    gridView2.Columns["NatureToString"].GroupInterval = ColumnGroupInterval.Value;
                }
                else if (hitInfo.Column.Name == "colContainsAttachments")
                {
                    gridView2.Columns["ContainsAttachments"].GroupIndex = 0;
                    gridView2.Columns["ContainsAttachments"].GroupInterval = ColumnGroupInterval.Value;
                }
                else if (hitInfo.Column.Name == "colContactList")
                {
                    gridView2.Columns["ContactList"].GroupIndex = 0;
                    gridView2.Columns["ContactList"].GroupInterval = ColumnGroupInterval.Alphabetical;
                }
                else
                {
                    gridView2.Columns["Date"].GroupIndex = 0;
                    gridView2.Columns["Date"].GroupInterval = ColumnGroupInterval.DateRange;
                }
                gridView2.ExpandAllGroups();




            }
           
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SelectDoc(sender);
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

        private void SelectDoc(object sender)
        {
            try
            {
               
                GridView view = sender as GridView;
                //Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
           

        }

        private void DoRowDoubleClick(GridView view)
        {
            //GridHitInfo info = view.CalcHitInfo(pt);
            if (view.FocusedRowHandle >= 0)
            {
                WIN.SCHEDULING_APPLICATION.DOMAIN.Document label = view.GetRow(view.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                if (label != null)
                {
                    ShowDialogForm(label);
                    ShowDocumentPreviewAt(view.FocusedRowHandle);
                }
            }
        }

        private void ShowDialogForm(WIN.SCHEDULING_APPLICATION.DOMAIN.Document label)
        {
            try
            {

                //frm = null;

                //Thread t = new Thread(() => Sleep(label));
                //t.Start();
                  
               


                //if (!t.Join(3000))
                //{
                //    t.Abort();
                //    XtraMessageBox.Show("Si è verifica un problema nell'apertura del documento riprovare!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}

               DocumentForm frm = new DocumentForm(label);
                frm.CheckSecurityForView();
              
                frm.ShowDialog();
                frm.Dispose();
                MemoryHelper.ReduceMemory();
                //GC.Collect();
                //GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }


            
        }




        //private void Sleep(WIN.SCHEDULING_APPLICATION.DOMAIN.Document label)
        //{

        //     frm = new DocumentForm(label);
            
           
        //}

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                SelectDoc(sender);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
               
                DocumentReport c = new DocumentReport();
                ArrayList l = new ArrayList();

                if (gridView2.FocusedRowHandle >= 0)
                {
                    WIN.SCHEDULING_APPLICATION.DOMAIN.Document label = gridView2.GetRow(gridView2.FocusedRowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.Document;
                    if (label != null)
                    {

                        l.Add(label);

                        c.DataSource = l;
                        c.ShowPreviewDialog();
                    
                    }
                }



            
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        [Secure(Area = "Documenti", Alias = "Visualizza allegato (Anteprima)", MacroArea = "Applicativo")]
        public void CheckSecurityForAttachmentView()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }

        private void imageListBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            if (_previewDoc == null)
                return;
            try
            {
                if (imageListBoxControl1.SelectedItem != null)
                {


                    try
                    {
                        CheckSecurityForAttachmentView();
                    }
                    catch (AccessDeniedException)
                    {

                        ErrorHandler.Show("Funzionalità non abilitata. Accesso negato");
                        return;
                    }

                    //una volta verificata la sicurezza devo verificare se l'utente loggato ha il profilo per vedere l'allegato
                    if (!_previewDoc.Scope.IsVisibleFromProfile(SecurityManager.Instance.CurrentUser.Role.Profiles.Select(z => z.Description).ToList(), SecurityManager.Instance.CurrentUser.Username))
                    {
                        ErrorHandler.Show("Funzionalità non abilitata. Accesso negato");
                        return;
                    }

                    AttachmentForDocument c = (imageListBoxControl1.SelectedItem as DevExpress.XtraEditors.Controls.ImageListBoxItem).Value as AttachmentForDocument;
                    if (c.AttachmentExist)
                    {

                        NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
                        string temp = p.CopyUncFileToLocalTempFolder(c.AttachmentCompletePath);

                        Process.Start(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void imageListBoxControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (imageListBoxControl1.SelectedItem != null)
                {
                    AttachmentForDocument c = (imageListBoxControl1.SelectedItem as DevExpress.XtraEditors.Controls.ImageListBoxItem).Value as AttachmentForDocument;
                    XtraMessageBox.Show(c.AttachmentCompletePath, "Percorso file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }
}
