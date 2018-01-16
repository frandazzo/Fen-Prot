using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using System.Collections;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using System.Xml;
using DevExpress.XtraRichEdit.Export;
using System.IO;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APP.GUI.Reports;
using System.Threading;
using WIN.SCHEDULING_APP.GUI.Forms.UnhadledCode;
using System.Runtime.InteropServices;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess;
using System.Linq;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    [SecureContext()]
    public partial class DocumentForm : DevExpress.XtraEditors.XtraForm
    {
            private Document _current;
            private bool _initializing = false;
            bool _changed = false;

            


        
        //    IList _customers = new ArrayList();
            Customer _customer;


        [Secure(Area = "Documenti", Alias = "Visualizza documenti da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForView()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }
        public Document CurrentDocument
        {
            get
            {
                return _current;
            }
        }


        public DocumentForm(Document c)
        {
            _initializing = true;
            try
            {
                WIN.GUI.UTILITY.Helper.ShowWaitBox("Attendere costruzione editor documento...", Properties.Resources.Waiting);
                InitializeComponent();

                PrepareForLoading();
                _current = c;
                if (_current != null)
                {
                    LoadEditors();
                }
               
            }
            catch(ThreadAbortException)
            {

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            finally
            {
                _initializing = false;
                WIN.GUI.UTILITY.Helper.HideWaitBox();
            }
           

        }

        //private void InitializeRchBody()
        //{
        //    // 
        //    // rchbody
        //    // 
        //    this.rchbody = new DevExpress.XtraRichEdit.RichEditControl();
        //    this.rchbody.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
        //    this.rchbody.Location = new System.Drawing.Point(12, 205);
        //    this.rchbody.MenuManager = this.ribbonControl1;
        //    this.rchbody.Name = "rchbody";
        //    this.rchbody.Size = new System.Drawing.Size(810, 296);
        //    this.rchbody.TabIndex = 16;
        //    this.rchbody.Text = "richEditControl1";
        //    this.rchbody.TextChanged += new System.EventHandler(this.rchbody_TextChanged);
        //    this.rchbody.BeforeExport += new DevExpress.XtraRichEdit.BeforeExportEventHandler(this.rchbody_BeforeExport);
        //}





        public DocumentForm()
        {
            Initialize();
        }

        private void Initialize()
        {
            _initializing = true;
            try
            {
                WIN.GUI.UTILITY.Helper.ShowWaitBox("Attendere costruzione editor documento...", Properties.Resources.Waiting);
                InitializeComponent();
                PrepareForLoading();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            finally
            {
                WIN.GUI.UTILITY.Helper.HideWaitBox();
                _initializing = false;
            }
        }


        public DocumentForm(Customer customer)
        {
            _customer = customer;
            Initialize();
        }

 

        [Secure(Area = "Documenti", Alias = "Crea documento da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForInsert()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }


        [Secure(Area = "Documenti", Alias = "Aggiorna documento da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForUpdate()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }

        private void SaveAll()
        {
            CreateNewDocumentIfNull();

            SaveOrUpdate();

            this.Text = _current.Subject;
            txtprot.Enabled = false;
            _changed = false;
        }

        private void CreateNewDocumentIfNull()
        {
            if (_current == null || _current.Key == null)
            {
               

                _current = new Document();

                CheckSecurityForInsert();
            }
        }

    

        public void StartChangeOperation()
        {
            if (_initializing)
                return;

            if (_current != null)
            {
                if (_changed == false)
                {
                    _changed = true;
                    this.Text += "  (Salvare le modifiche per renderle effettive!)";
                }
            }
           
        }






         private void LoadComboOperatori()
         {
             //preparo la combo delle zone
             cboop.Properties.Items.Clear();

             OperatorHandler h = new OperatorHandler();
             //la riempio
             cboop.Properties.Items.Add("");
             cboop.Properties.Items.AddRange(h.GetAll());

             //seleziono quella iniziale
             cboop.SelectedIndex = 0;
         }

         private void LoadComboCausali()
         {
             //preparo la combo delle zone
             cbocau.Properties.Items.Clear();

             DocumentTypeHandler h = new DocumentTypeHandler();
             //la riempio
             cbocau.Properties.Items.AddRange(h.GetAll());

             //seleziono quella iniziale
             cbocau.SelectedIndex = 0;
         }

         private void LoadComboCartelle()
         {
             //preparo la combo delle zone
             cbocar.Properties.Items.Clear();

             DocumentScopeHandler h = new DocumentScopeHandler();
             //la riempio
             IList l = h.GetAll();

             IList l1 = new ArrayList();
             foreach (DocumentScope item in l)
             {
                 if (!item.Descrizione.StartsWith("OLD"))
                     l1.Add(item);
             }

             cbocar.Properties.Items.AddRange(l1);
             
             
             

             //seleziono quella iniziale
             cbocar.SelectedIndex = 0;
         }


         private void PrepareForLoading()
         {

             LoadComboCartelle();
             LoadComboCausali();
             LoadComboOperatori();

             cbopri.SelectedIndex = 1;
             cbotip.SelectedIndex = 0;
             ////imposto il cliente, la zona, il luogo di default se il cliente è presente

             txtsub.EditValue = Properties.Settings.Default.Main_DocumentDefaultSubject;
             txtprot.EditValue = "";
             txtresp.EditValue = "";
             dtpdata.DateTime = DateTime.Now;
             lstatt.Items.Clear();
             lstcont.Items.Clear();
             if (_customer != null)
                 lstcont.Items.Add(_customer);
            // _customers = new ArrayList();
             rchbody.RtfText = "";
       
         }


         private void LoadEditors()
         {
             if (_current != null)
             {
                 ////inserisco i parametri abituali
                 txtsub.EditValue = _current.Subject;
                 txtprot.EditValue = _current.Protocol;
                 txtresp.EditValue = _current.Responsable;
                 dtpdata.EditValue = _current.Date;

                 foreach (Customer item in _current.Contacts)
                 {
                     lstcont.Items.Add(item);
                 }

                 foreach (AttachmentForDocument item in _current.Attachments)
                 {
                     lstatt.Items.Add(item, GetFileImageIndex( item));
                 }


                 cbopri.EditValue = _current.Priority.ToString();
                 cbotip.EditValue = _current.Nature.ToString();
                 cbocau.EditValue = _current.Type;
                 cboop.EditValue = _current.Operator;


                 //ricalcolo la lista delle cartelle documenti se si tratta di aggiornamento
                 DocumentScopeHandler h = new DocumentScopeHandler();
                 IList l = h.GetAll();
                 cbocar.Properties.Items.Clear();
                 cbocar.Properties.Items.AddRange(l);

              


                 cbocar.EditValue = _current.Scope;

                 //carico il corpo nell'editor
                 using( MemoryStream ms = new MemoryStream(_current.Body.Document))
                 {
                    rchbody.LoadDocument(ms, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
                    string a = rchbody.RtfText;
                 }

             }
         }

     

       


        private void SaveOrUpdate()
        {

            if (_current != null  && _current.Key != null)
                CheckSecurityForUpdate();
            ////inserisco i parametri abituali
            _current.Subject = txtsub.Text;
            _current.Protocol = txtprot.Text;
            _current.Responsable = txtresp.Text;
            _current.Date = dtpdata.DateTime;

            _current.Contacts = new ArrayList();
            foreach (Customer item in lstcont.Items)
            {
                _current.Contacts.Add(item);
            }

            _current.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), cbopri.Text);
            _current.Nature = (WIN.SCHEDULING_APPLICATION.DOMAIN.Document.DocumentNature)Enum.Parse(typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.Document.DocumentNature), cbotip.Text);

            _current.Operator = cboop.SelectedItem as Operator;
            _current.Type = cbocau.SelectedItem as DocumentType;
            _current.Scope = cbocar.SelectedItem as DocumentScope;


            using (MemoryStream ms = new MemoryStream())
            {
                rchbody.SaveDocument(ms, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
                byte[] array = ms.ToArray();
                _current.Body.Document = array;
            }

            _current.Attachments = new ArrayList();

            foreach (DevExpress.XtraEditors.Controls.ImageListBoxItem  item in lstatt.Items)
            {
                _current.Attachments.Add(item.Value);
            }



          //  string a = rchbody.RtfText;

            DocumentHandler h = new DocumentHandler();
            h.SaveOrUpdate(_current);


           
        }
        private Document CreateDummyDocument()
        {
            Document c = new Document();
            ////inserisco i parametri abituali
            c.Subject = txtsub.Text;
            c.Protocol = txtprot.Text;
            c.Responsable = txtresp.Text;
            c.Date = dtpdata.DateTime;

            c.Contacts = new ArrayList();
            foreach (Customer item in lstcont.Items)
            {
                _current.Contacts.Add(item);
            }

            c.Priority = (PriorityType)Enum.Parse(typeof(PriorityType), cbopri.Text);
            c.Nature = (WIN.SCHEDULING_APPLICATION.DOMAIN.Document.DocumentNature)Enum.Parse(typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.Document.DocumentNature), cbotip.Text);

            c.Operator = cboop.SelectedItem as Operator;
            c.Type = cbocau.SelectedItem as DocumentType;
            c.Scope = cbocar.SelectedItem as DocumentScope;


            using (MemoryStream ms = new MemoryStream())
            {
                rchbody.SaveDocument(ms, DevExpress.XtraRichEdit.DocumentFormat.Rtf);
                byte[] array = ms.ToArray();
                c.Body.Document = array;
            }
            return c;
        }

        private void rchbody_BeforeExport(object sender, DevExpress.XtraRichEdit.BeforeExportEventArgs e)
        {
            RtfDocumentExporterOptions options = e.Options as RtfDocumentExporterOptions;
            if (options != null) options.Compatibility.DuplicateObjectAsMetafile = false;
        }

        private void barButtonItem1Salva_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveAll();
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

        private void barButtonItem2SaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveAll();

                this.DialogResult = DialogResult.OK;
                this.Close();

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

        private void barButtonItem3PrintAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_current == null)
                    return;
                //if (_changed)
                //{
                //    XtraMessageBox.Show("Salvare il documento prima di effettuare la stampa!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                DocumentReport c = new DocumentReport();
                ArrayList l = new ArrayList();

                l.Add(CreateDummyDocument());

                c.DataSource = l;
                c.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void barButtonItem1close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_changed)
            {
                DialogResult c = XtraMessageBox.Show("Salvare i dati prima di chiudere?", "Domanda", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    try
                    {
                        SaveOrUpdate();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.Show(ex);
                    }
                    return;
                }
                else if (c == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }
                else
                {
                    return;
                }
            }

            if (_current != null)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
            this.Close();
                 
        }

        private void barButtonItem4Info_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ApplicationUtility.Instance.ShowObjectInfo(_current);
        }

        private void cmdContacts_Click(object sender, EventArgs e)
        {
            try
            {
                //FrmAddContactToDocument frm = new FrmAddContactToDocument(ExtractCustomerList());
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    ReloadCustomerList(frm.Customers);
                //    StartChangeOperation();
                //}
                FrmComplexCustomerSearch cc = new FrmComplexCustomerSearch();
                if (cc.ShowDialog() == DialogResult.OK)
                {
                    if (cc.Customer != null)
                    {
                        lstcont.Items.Add(cc.Customer);
                        lstcont.SelectedIndex = lstcont.Items.Count - 1;
                        StartChangeOperation();
                    }
                }
                cc.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void ReloadCustomerList(IList customers)
        {
            lstcont.Items.Clear();
            foreach (Customer item in customers)
            {
                lstcont.Items.Add(item);
            }
            lstcont.SortOrder = SortOrder.Ascending;
        }

        private IList ExtractCustomerList()
        {
            IList customers = new ArrayList();

            foreach (Customer item in lstcont.Items)
            {
                Customer c = item;
                if (c != null)
                    customers.Add(c);

            }
            return customers;
        }

        private void txtsub_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtprot_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void dtpdata_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cbotip_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cbopri_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cbocar_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cbocau_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboop_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtresp_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

 

        private void rchbody_TextChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cbocar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentScope p = cbocar.EditValue as DocumentScope;
            if (p != null)
                txtresp.Text = p.Responsable;

            StartChangeOperation();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (_current == null)
            {
                XtraMessageBox.Show("Salvare il documento prima di asegnargli un protocollo", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                if (!string.IsNullOrEmpty(_current.Protocol))
                {
                    if (XtraMessageBox.Show("Attenzione! Il protocollo è già stato inserito. Il calcolo di un nuovo protocollo comporta la perdità del protocollo attuale. Procedere al ricalcolo del nuovo protocollo?", "Messaggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _current.CalculateProtocol(ProtocolRetrieverFactory.GetProtocolRetriever(DataAccessServices.Instance().PersistenceFacade, Properties.Settings.Default.Main_ProtocolStrategy));
                        txtprot.Text = _current.Protocol;
                        StartChangeOperation();
                    }

                }
                else
                {
                    _current.CalculateProtocol(ProtocolRetrieverFactory.GetProtocolRetriever(DataAccessServices.Instance().PersistenceFacade, Properties.Settings.Default.Main_ProtocolStrategy));
                    txtprot.Text = _current.Protocol;
                    StartChangeOperation();
                }
              
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (_current == null)
                return;

            if (!string.IsNullOrEmpty(_current.Protocol))
            {
                if (XtraMessageBox.Show("Attenzione! Il protocollo è già stato inserito. La sovrascittura del protocollo esistente comporta la perdità del protocollo nel caso sia stato precedentemente calcolato automaticamente. Procedere alla sovrascrittura del protocollo?", "Messaggio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtprot.Enabled = true;
                    StartChangeOperation();
                }
            }
            else
            {
                txtprot.Enabled = true;
                StartChangeOperation();
            }
           
        }

        private void lstcont_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lstcont.SelectedItem != null)
                {
                    lstcont.Items.RemoveAt(lstcont.SelectedIndex);
                    StartChangeOperation();
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                CreateNewDocumentIfNull();

                //scrivo la cartella corrente nel caso non sia avvenuto un salvataggio
                _current.Scope = cbocar.SelectedItem as DocumentScope;

                FrmViewAttachment cc = new FrmViewAttachment(_current);
                if (cc.ShowDialog() == DialogResult.OK)
                {
                    lstatt.Items.Add(cc.Attachment, GetFileImageIndex(cc.Attachment));
                    lstatt.SelectedIndex = lstatt.Items.Count - 1;
                    StartChangeOperation();
                }
                cc.Dispose();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
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

            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            string temp = p.CopyUncFileToLocalTempFolder(attachmentForDocument.AttachmentCompletePath);

            SHFILEINFO shinfo = new SHFILEINFO();
            //SHFILEINFO shinfo1 = new SHFILEINFO();
            IntPtr hImgSmall; //the handle to the system image list
            //IntPtr hImgLarge; //the handle to the system image list

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

     

        private void lstatt_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lstatt.SelectedItem != null)
                {
                    if (_current != null && _current.Key != null)
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

                        if (!_current.Scope.IsVisibleFromProfile(SecurityManager.Instance.CurrentUser.Role.Profiles.Select(z => z.Description).ToList(), SecurityManager.Instance.CurrentUser.Username))
                        {
                            ErrorHandler.Show("Funzionalità non abilitata. Accesso negato");
                            return;
                        }


                    }

                   


                    FrmViewAttachment cc = new FrmViewAttachment((lstatt.SelectedItem as DevExpress.XtraEditors.Controls.ImageListBoxItem).Value as AttachmentForDocument);
                    if (cc.ShowDialog() == DialogResult.OK)
                    {
                        lstatt.Items.RemoveAt(lstatt.SelectedIndex);
                        lstatt.Items.Add(cc.Attachment, GetFileImageIndex(cc.Attachment));
                        lstatt.SelectedIndex = lstatt.Items.Count - 1;
                        StartChangeOperation();
                    }
                    cc.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        [Secure(Area = "Documenti", Alias = "Elimina allegato (Aggiorna documento)", MacroArea = "Applicativo")]
        public void CheckSecurityForAttachmentDeletion()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }

        [Secure(Area = "Documenti", Alias = "Visualizza allegato (Aggiorna documento)", MacroArea = "Applicativo")]
        public void CheckSecurityForAttachmentView()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
        }

        private void lstatt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lstatt.SelectedItem != null)
                {

                    if (_current != null && _current.Key != null)
                    {
                        try
                        {
                            CheckSecurityForAttachmentDeletion();
                        }
                        catch (AccessDeniedException)
                        {

                            ErrorHandler.Show("Funzionalità non abilitata. Accesso negato");
                            return;
                        }
                    }

                    FrmEliminaAllegato frm = new FrmEliminaAllegato();
                    if (frm.ShowDialog() == DialogResult.Yes)
                    {
                        if (frm.EliminaFile)
                        {
                            AttachmentForDocument g = (lstatt.SelectedItem as DevExpress.XtraEditors.Controls.ImageListBoxItem).Value as AttachmentForDocument;
                            if (g!=null)
                                if (g.AttachmentExist)
                                {
                                    NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
                                    p.DeleteUncFile(g.AttachmentCompletePath);
                                }
                        }
                        lstatt.Items.RemoveAt(lstatt.SelectedIndex);
                        StartChangeOperation();
                    }
                }
            }
        }

        private void lstatt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   

    }
}