using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Collections;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext()]
    public partial class BookingTypeControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        
        WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingType _current;

        public BookingTypeControl(MainForm form):base(form)
        {
            InitializeComponent();
            //avvio le procedure per la ricerca di un nuovo elemento
            StartSearchOperation();

        }

        public BookingTypeControl(int id, MainForm form)
            : base(form)
        {
            InitializeComponent();

            //avvio le procedure per il caricamento

            m_IdShowedObject = id;

            StartLoadOperation();

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


        [Secure(Area = "Causali tipo prenotazione", Alias = "Crea", MacroArea = "Impostazioni")]
        protected override void Nested_CheckSecurityForCreation()
        {
            SecurityManager.Instance.Check();
        }

        protected override void Nested_ClearWindowEditors()
        {
            txtDescrizione.Text = "";
            //cboColor.Color = Color.White;
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
            BookingTypeHandler h = new BookingTypeHandler();
            _current = h.GetElementById(m_IdShowedObject.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingType ;

            if (_current == null)
                throw new Exception("Elemento non trovato");
        }

        protected override void Nested_LoadEditorsProperties()
        {
            if (_current != null)
            {
                txtDescrizione.Text = _current.Descrizione;
                //cboColor.Color = Color.FromArgb(_current.Color);
                commandBar1.Custom_SetIdentifier(_current.Id.ToString());
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
            _current = new WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingType ();
            _current.CreatoDa = SecurityManager.Instance.CurrentUser.Username;
            _current.DataCreazione = DateTime.Now;

            SaveOrUpdate();

            m_IdShowedObject = _current.Id;

        }

        private void SaveOrUpdate()
        {
            _current.Descrizione = txtDescrizione.Text;
            //_current.Color = cboColor.Color.ToArgb();

            BookingTypeHandler h = new BookingTypeHandler();
            h.SaveOrUpdate(_current);
        }

        protected override void Nested_PostSaveActions()
        {
             Hashtable ParameterList  = new Hashtable();
             ParameterList.Add("Id", m_IdShowedObject);
             //base.AddCommandToHistory("Labels", ParameterList);

             //commandBar1.CustomGUI_SetInterfaceState(GUIState.Visualizzazione);
             NavigateTo("BookingTypes", ParameterList, true);
        }


        public override void Nested_UpdateData()
        {
            _current.ModificatoDa = SecurityManager.Instance.CurrentUser.Username;
            _current.DataModifica = DateTime.Now;

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



        [Secure(Area = "Causali tipo prenotazione", Alias = "Aggiorna", MacroArea = "Impostazioni")]
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
            commandBar1.Custom_SetFunctionName(string.Format(base.State.StateName + " tipo prenotazione: {0}", desc));
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

                    BookingTypeHandler h = new BookingTypeHandler();
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

        [Secure(Area = "Causali tipo prenotazione", Alias = "Elimina", MacroArea = "Impostazioni")]
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
                    base.NavigateTo("BookingTypes", true);
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
                WIN.SCHEDULING_APP.GUI.Forms.FrmRicercaTipiPrenotazione frm = new WIN.SCHEDULING_APP.GUI.Forms.FrmRicercaTipiPrenotazione();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    commandBar1.Custom_SetIdentifier(frm.SelectedId.ToString ());
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
                NavigateTo("BookingTypes", ParameterList, true);
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



    



    }
}
