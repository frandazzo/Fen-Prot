using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using System.Collections;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SECURITY.Exceptions;
using System.IO;
using WIN.BASEREUSE;
using WIN.SECURITY.Core;
using System.Linq;
using DevExpress.XtraEditors.Controls;


namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext()]
    public partial class DocScopeControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope _current;

        public DocScopeControl(MainForm form):base(form)
        {
            InitializeComponent();
            LoadChekcedListBoxWithProfiles();
            //avvio le procedure per la ricerca di un nuovo elemento
            StartSearchOperation();

        }

        public DocScopeControl(int id, MainForm form)
            : base(form)
        {
            InitializeComponent();

            LoadChekcedListBoxWithProfiles();

            //avvio le procedure per il caricamento

            m_IdShowedObject = id;

            StartLoadOperation();

        }

        private void LoadChekcedListBoxWithProfiles(string visibility)
        {
            checkedListBoxControl1.Items.Clear();
            IList<WIN.BASEREUSE.Profile> profs = SecurityManager.Instance.SecureDataAccess.GetProfiles().Cast<WIN.BASEREUSE.Profile>().ToList();

            List<CheckedListBoxItem> s = new List<CheckedListBoxItem>();

            string[] a = string.IsNullOrEmpty(visibility) ? null : visibility.Split(new char[]{'#'}, StringSplitOptions.RemoveEmptyEntries);

            if (a == null || a.Length == 0)
            {
                foreach (var item in profs)
                {
                    s.Add(new CheckedListBoxItem(item.Descrizione, false));
                }
            }
            else
            {
                foreach (var item in profs)
                {
                    bool checkedElemnt = a.FirstOrDefault(b => item.Descrizione.Equals(b)) != null;
                    s.Add(new CheckedListBoxItem(item.Descrizione, checkedElemnt));
                    
                }
            }

            checkedListBoxControl1.Items.AddRange(s.ToArray());             
        }


        private void LoadChekcedListBoxWithProfiles()
        {
            IList<WIN.BASEREUSE.Profile> profs = SecurityManager.Instance.SecureDataAccess.GetProfiles().Cast<WIN.BASEREUSE.Profile>().ToList();

            List<CheckedListBoxItem> s = new List<CheckedListBoxItem>();

            checkedListBoxControl1.Items.Clear();

            foreach (var item in profs)
	        {
		        s.Add(new CheckedListBoxItem(item.Descrizione, false));
	        }

            checkedListBoxControl1.Items.AddRange(s.ToArray());
            
           
        }

        #region GetInfo

        public override void GetInfo()
        {
            ApplicationUtility.Instance.ShowObjectInfo(_current);
        }

        #endregion

        #region Undo

        public override void Nested_ReLoadProperties()
        {
            StartLoadOperation();
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

        #region Creation


        [Secure(Area = "Cartella documento", Alias = "Crea", MacroArea = "Impostazioni")]
        protected override void Nested_CheckSecurityForCreation()
        {
            SecurityManager.Instance.Check();
            
                       
        }

        protected override void Nested_ClearWindowEditors()
        {
            txtDescrizione.Text = "";
            txtProtocol.EditValue = "";
            txtResp.EditValue = "";
            txtRespProtocol.EditValue = "";
            cboColor.Color = Color.White;
            hyperLinkEdit1.EditValue = null;
            hyperLinkEdit1.Text = "";
            hyperLinkEdit1.ToolTip = hyperLinkEdit1.EditValue != null ? hyperLinkEdit1.EditValue.ToString()  :"";
            LoadChekcedListBoxWithProfiles();
        }

        protected override void Nested_PrepareForCreation()
        {
            _current = null;
            layoutControl1.Visible = true;
            //commandBar1.CustomGUI_SetInterfaceState(WIN.SCHEDULING_APP.GUI.Utility.GUIState.Creazione);
            //commandBar1.Custom_SetFunctionName("Creazione nuova causale");
            commandBar1.Custom_SetIdentifier("");
        }

        #endregion

        #region Visualizzazione

        protected override void Nested_PrepareLoading()
        {
            layoutControl1.Visible = true;
        }

        protected override void Nested_LoadDataFromDataSource()
        {
            DocumentScopeHandler h = new DocumentScopeHandler();
            _current = h.GetElementById(m_IdShowedObject.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope ;

            if (_current == null)
                throw new Exception("Elemento non trovato");
        }

        protected override void Nested_LoadEditorsProperties()
        {
            if (_current != null)
            {
                txtDescrizione.Text = _current.Descrizione;
                cboColor.Color = Color.FromArgb(_current.Color);
                txtProtocol.EditValue = _current.ProtocolCode;
                txtResp.EditValue = _current.Responsable;
                txtRespProtocol.EditValue = _current.ResponsableProtocolCode ;
                commandBar1.Custom_SetIdentifier(_current.Id.ToString());
                hyperLinkEdit1.EditValue = _current.DefaultPath;
                LoadChekcedListBoxWithProfiles(_current.Visibility);
                
            }
        }

        
        //protected override void Nested_PostLoadingActions()
        //{
        //    commandBar1.Custom_SetFunctionName(string.Format("Visualizzazione causale: {0}", _current.Descrizione));
        //    commandBar1.CustomGUI_SetInterfaceState(GUIState.Visualizzazione);

        //}
        #endregion

        #region Salvataggio

        public override void Nested_InsertData()
        {
            _current = new WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope();
            _current.CreatoDa = SecurityManager.Instance.CurrentUser.Username;
            _current.ProtocolCode = txtProtocol.Text;
            _current.DataCreazione = DateTime.Now;
            _current.Responsable = txtResp.Text;
            _current.ResponsableProtocolCode = txtRespProtocol.Text;
            _current.Visibility = SerializeVisibility();

            if (hyperLinkEdit1.EditValue != null)
                _current.DefaultPath = hyperLinkEdit1.EditValue.ToString();

            SaveOrUpdate();

            m_IdShowedObject = _current.Id;

        }

        private string SerializeVisibility()
        {
            string visibility = "";
            foreach (var item in checkedListBoxControl1.CheckedItems)
            {
                visibility = visibility +  "#" + item;
            }

            return visibility;
        }

        private void SaveOrUpdate()
        {
            _current.Descrizione = txtDescrizione.Text;
            _current.Color = cboColor.Color.ToArgb();

            DocumentScopeHandler h = new DocumentScopeHandler();
            h.SaveOrUpdate(_current);
        }

        protected override void Nested_PostSaveActions()
        {
            Hashtable ParameterList = new Hashtable();
            ParameterList.Add("Id", m_IdShowedObject);
            //base.AddCommandToHistory("Labels", ParameterList);

            //commandBar1.CustomGUI_SetInterfaceState(GUIState.Visualizzazione);
            NavigateTo("DocumentScopes", ParameterList, true);
        }


        public override void Nested_UpdateData()
        {
            _current.ModificatoDa = SecurityManager.Instance.CurrentUser.Username;
            _current.ProtocolCode = txtProtocol.Text;
            _current.DataModifica = DateTime.Now;
            _current.Responsable = txtResp.Text;
            _current.ResponsableProtocolCode = txtRespProtocol.Text;
            _current.Visibility = SerializeVisibility();

            if (hyperLinkEdit1.EditValue != null)
                _current.DefaultPath = hyperLinkEdit1.EditValue.ToString();
            SaveOrUpdate();
        }

        #endregion

        #region Change
        public override void StartChangeOperation()
        {
            if (m_IsLoading)
                return;
            try
            {
                base.StartChangeOperation();
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtDescrizione_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

         private void cboColor_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        [Secure(Area = "Cartella documento", Alias = "Aggiorna", MacroArea = "Impostazioni")]
        protected override void Nested_CheckSecurityForChanging()
        {
            SecurityManager.Instance.Check();
        }

        public override void Nested_NotifyParent()
        {
            string desc = "";

            if (_current != null)
            {
                desc = _current.Descrizione;
            }

            commandBar1.CustomGUI_SetInterfaceState(commandBar1.Custom_GetCommandBarStateFromGuiState(base.State.StateName));
            commandBar1.Custom_SetPrintButtonEnabled(false);
            commandBar1.Custom_SetFunctionName(string.Format(base.State.StateName + " cartella documento: {0}", desc));
        }
        #endregion

        #region Delete

        public override void DoDelete()
        {
            if (_current == null)
                return;


            try
            {
                if (XtraMessageBox.Show("L'elemento sarà eliminato solamente se nel sistema non ci sono altri riferimenti all'elemento oppure se non è un elemento predefinito. Sicuro di voler procedere? ", "Elimina elemento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Nested_CheckSecurityForDeletion();

                    DocumentScopeHandler h = new DocumentScopeHandler();
                    h.Delete(_current);

                    _mainForm.NavigatorUtility.NavigateToPrevious();
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

        [Secure(Area = "Cartella documento", Alias = "Elimina", MacroArea = "Impostazioni")]
        protected override void Nested_CheckSecurityForDeletion()
        {
            SecurityManager.Instance.Check();
        }

        #endregion



        //Pulsante nuova ricerca
        private void commandBar1_NewSearchCommandPressed(object sender, EventArgs e)
        {
            try
            {
                if (base.CheckBeforeNavigate())
                    base.NavigateTo("DocumentScopes", true);
                //else
                //    _mainForm.NavigatorUtility.NavigateToPrevious();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }

        }


        //pulsante nuovo
        private void commandBar1_NewCommandPressed(object sender, EventArgs e)
        {
            try
            {
                StartCreateOperation();
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


        //pulsante per ricercare un id
        private void commandBar1_FindElementIdCommandPressed(object sender, EventArgs e)
        {
            try
            {
                WIN.SCHEDULING_APP.GUI.Forms.FrmRicercaCartelleDocumenti frm = new WIN.SCHEDULING_APP.GUI.Forms.FrmRicercaCartelleDocumenti();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    commandBar1.Custom_SetIdentifier(frm.SelectedId.ToString());
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        //pulsante per visualizzare elemento
        private void commandBar1_ViewElementCommandPressed(object sender, EventArgs e)
        {
            try
            {
                System.Collections.Hashtable ParameterList = new System.Collections.Hashtable();
                ParameterList.Add("Id", commandBar1.Custom_Identifier);
                NavigateTo("DocumentScopes", ParameterList, true);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        //pulsante per salvare i dati
        private void commandBar1_SaveCommandPressed(object sender, EventArgs e)
        {
            try
            {
                StartSaveOperation();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        //pulsante per annullare le modifiche
        private void commandBar1_UndoCommandPressed(object sender, EventArgs e)
        {
            try
            {
                if (base.State.StateName == "Creazione")
                {
                    _mainForm.NavigatorUtility.NavigateToPrevious();
                }
                else
                {
                    StartUndoOperation();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        //pulsante per eliminare il dato
        private void commandBar1_DelCommandPressed(object sender, EventArgs e)
        {
            try
            {
                StartDeleteOperation();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        //pulsante per le informazioni
        private void commandBar1_InfoCommandPressed(object sender, EventArgs e)
        {
            GetInfo();
        }

        private void txtProtocol_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtResp_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtRespProtocol_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                hyperLinkEdit1.EditValue = folderBrowserDialog1.SelectedPath;

               
            }
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            try
            {
                if (hyperLinkEdit1.EditValue != null)
                    System.Diagnostics.Process.Start(hyperLinkEdit1.EditValue.ToString());
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void hyperLinkEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (hyperLinkEdit1.EditValue != null)
            {
                if (!string.IsNullOrEmpty(hyperLinkEdit1.EditValue.ToString()))
                {
                    DirectoryInfo i = new DirectoryInfo(hyperLinkEdit1.EditValue.ToString());

                    if (i.Exists)
                        e.DisplayText = i.Name;
                    else
                        hyperLinkEdit1.EditValue = null;
                }
            }
        }

        private void hyperLinkEdit1_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void hyperLinkEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (hyperLinkEdit1.EditValue != null)
                {
                    if (!string.IsNullOrEmpty(hyperLinkEdit1.EditValue.ToString()))
                    {
                        XtraMessageBox.Show(hyperLinkEdit1.EditValue.ToString(), "Percorso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            StartChangeOperation();

        }

    }
}
