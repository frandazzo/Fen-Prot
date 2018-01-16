using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using System.Collections;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;
using WIN.BASEREUSE;
using System.Xml;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APP.GUI.Forms;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext()]
    public partial class Customerscontrol : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
         Customer _current;
         private bool _initializing = false;

        public Customerscontrol(MainForm form):base(form)
        {
            _initializing = true;
            try
            {
                InitializeComponent();
                //avvio le procedure per la ricerca di un nuovo elemento
                StartSearchOperation();
            }
            finally
            {
                _initializing = false;                
            }

            //tolgo dalla visualizzazione qualsiasi riferimento a campi non congruenti con Fenealgest
            if (Properties.Settings.Default.Main_OtherApp)
            {
                layoutControlItemPrivateCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItemResource.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlOtherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            

        }

        public Customerscontrol(int id, MainForm form)
            : base(form)
        {
            _initializing = true;
            try
            {
                InitializeComponent();

                //avvio le procedure per il caricamento

                m_IdShowedObject = id;

                StartLoadOperation();
            }
            finally
            {
                _initializing = false;
            }


            //tolgo dalla visualizzazione qualsiasi riferimento a campi non congruenti con Fenealgest
            if (Properties.Settings.Default.Main_OtherApp)
            {
                layoutControlItemPrivateCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItemResource.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlOtherData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            
        }
        


        #region Print

        public override void Print()
        {
            try
            {
                if (_current != null)
                {
                    if (base.State.StateName == "Visualizzazione")
                    {
                        Reports.CustomerReport c = new WIN.SCHEDULING_APP.GUI.Reports.CustomerReport();
                        ArrayList l = new ArrayList();
                        l.Add(_current);
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

        #endregion


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


        [Secure(Area = "Contatti", Alias = "Crea", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForCreation()
        {
            SecurityManager.Instance.Check();
        }

        protected override void Nested_ClearWindowEditors()
        {
            
            
            //LoadComboProvince();
            ////imposto la provincia come da impostazioni applicazione
            //cboProv.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetProvinciaByName(Properties.Settings.Default.Main_Province);
            //cboCom.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetComuneByName(Properties.Settings.Default.Main_Comune);

            LoadComboNazioni(cboNazRes);
            LoadComboNazioni(cboNazNas);
            //LoadComboProvince(cboProv );
            //LoadComboProvince(cboProvNas);
            dtpNas.EditValue = null;
            cboSex.SelectedIndex = 0;
            //imposto la provincia come da impostazioni applicazione
            cboNazRes.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetNazioneByName(Properties.Settings.Default.Main_Nazione);
            cboNazNas.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetNazioneByName(Properties.Settings.Default.Main_Nazione);
            cboComNas.Enabled = false;
            cboCom.Enabled = false;
            cboProv.Enabled = false;
            cboProvNas.Enabled = false;

            txtInd.EditValue = "";
            txtCap.EditValue = "";
            
            
            txtDescrizione.Text = "";
            chkPrivate.Checked = false;
            txtResp.EditValue = "";
            txtIva.EditValue = "";
            LoadComboZone();

            txtFax.EditValue = "";
            txtFisso .EditValue = "";
            txtcell1.EditValue = "";
            txtCell2.EditValue = "";
            txtMail.EditValue = "";


            txtMarca.EditValue = "";
            txtModello.EditValue = "";
            txtMatricola.EditValue = "";
            chkAbbonato.Checked = false;

            txtNote.EditValue = "";
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


            LoadComboZone();
            //LoadComboProvince();
            LoadComboNazioni(cboNazRes);
            LoadComboNazioni(cboNazNas);
            cboComNas.Enabled = false;
            cboCom.Enabled = false;
            cboProv.Enabled = false;
            cboProvNas.Enabled = false;
        }

        private void LoadComboComuni(string province, ComboBoxEdit cboCom)
        {
            cboCom.Enabled = true;
            //preparo la combo delle dei comuni
            cboCom.Properties.Items.Clear();
            //la riempio con un comune nullo
            cboCom.Properties.Items.Add(new ComuneNullo());

            if (!string.IsNullOrEmpty(province))
            {
                IList l = GeoLocationFacade.Instance().GetListaOggettiComuniPerProvincia(province);
                cboCom.Properties.Items.AddRange(l);
            }
            //seleziono quella iniziale
            cboCom.SelectedIndex = 0;
        }

        private void LoadComboProvince(ComboBoxEdit cboProv)
        {
            cboProv.Enabled = true;
            //preparo la combo delle zone
            cboProv.Properties.Items.Clear();


            //la riempio
            cboProv.Properties.Items.Add(new ProvinciaNulla());
            IList l = GeoLocationFacade.Instance().GetListaOggettiProvincie();
            cboProv.Properties.Items.AddRange(l);

            //seleziono quella iniziale
            cboProv.SelectedIndex = 0;
        }

        private void LoadComboNazioni(ComboBoxEdit cboNaz)
        {
            //preparo la combo delle zone
            cboNaz.Properties.Items.Clear();


            //la riempio
            cboNaz.Properties.Items.Add(new NazioneNulla());
            IList l = GeoLocationFacade.Instance().GetListaOggettiNazioni();
            cboNaz.Properties.Items.AddRange(l);

            //seleziono quella iniziale
            cboNaz.SelectedIndex = 0;

            
        }


        private void LoadComboZone()
        {
            //preparo la combo delle zone
            cboZone.Properties.Items.Clear();

            ResourceHandler h = new ResourceHandler();
            //la riempio
            cboZone.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboZone.SelectedIndex = 0;
        }

        protected override void Nested_LoadDataFromDataSource()
        {
            CustomerHandler h = new CustomerHandler();
            _current = h.GetElementById(m_IdShowedObject.ToString()) as Customer; 

            if (_current == null)
                throw new Exception("Contatto non trovato");
        }

        protected override void Nested_LoadEditorsProperties()
        {
            if (_current != null)
            {
                txtDescrizione.Text = _current.Cognome;
                txtResp.EditValue = _current.Nome;
                txtIva.EditValue = _current.CodiceFiscale;
                cboZone.EditValue = _current.Resource;

                if (_current.DataNascita == DateTime.MinValue)
                    dtpNas.EditValue = null;
                else
                    dtpNas.EditValue = _current.DataNascita;
                if (_current.Sesso == AbstractPersona.Sex.Maschio)
                    cboSex.Text = "Uomo";
                else
                    cboSex.Text = "Donna";
                cboNazNas.EditValue = _current.Nazionalita;
                cboProvNas.EditValue = _current.ProvinciaNascita;
                cboComNas.EditValue = _current.ComuneNascita;

                cboNazRes.EditValue = _current.Residenza.Nazione;
                cboProv.EditValue = _current.Residenza.Provincia;
                cboCom.EditValue = _current.Residenza.Comune;



                txtInd.EditValue = _current.Residenza.Via;
                txtCap.EditValue = _current.Residenza.Cap;


                chkPrivate.Checked = _current.Is_Private;
           

                txtFax.EditValue = _current.Comunicazione.Fax ;
                txtFisso.EditValue = _current.Comunicazione.TelefonoUfficio ;
                txtcell1.EditValue = _current.Comunicazione.Cellulare1 ;
                txtCell2.EditValue = _current.Comunicazione.Cellulare2 ;
                txtMail.EditValue = _current.Comunicazione.Mail ;

                txtNote.EditValue = _current.Note ;

                txtMarca.EditValue = _current.Marca;
                txtMatricola.EditValue = _current.Matricola;
                txtModello.EditValue = _current.Modello;
                chkAbbonato.Checked = _current.IsAbbonato;


              
                commandBar1.Custom_SetIdentifier(_current.Id.ToString());
            }
        }


        #endregion

        #region Salvataggio

        public override void Nested_InsertData()
        {
            _current = new Customer();
          
            SaveOrUpdate();

            m_IdShowedObject = _current.Id;

        }

        private void SaveOrUpdate()
        {
            _current.Cognome = txtDescrizione.Text;
            _current.Nome = txtResp.Text;
            _current.CodiceFiscale = txtIva.Text;


            _current.Resource =  cboZone.SelectedItem  as Resource;


            if (dtpNas.EditValue == null)
                _current.DataNascita = DateTime.MinValue;
            else
                _current.DataNascita = dtpNas.DateTime;

            if (cboSex.Text == "Uomo")
                _current.Sesso = AbstractPersona.Sex.Maschio;
            else
                _current.Sesso = AbstractPersona.Sex.Femmina;

         

            _current.Nazionalita = cboNazNas.SelectedItem as Nazione;
            _current.ProvinciaNascita = cboProvNas.SelectedItem as Provincia;
            _current.ComuneNascita = cboComNas.SelectedItem as Comune;

            _current.Residenza.Nazione = cboNazRes.SelectedItem as Nazione;
          



            _current.Residenza.Provincia = cboProv.SelectedItem as Provincia;
            _current.Residenza.Comune = cboCom.SelectedItem as Comune;

            _current.Residenza.Via = txtInd.Text;
            _current.Residenza.Cap = txtCap.Text;


            _current.Is_Private = chkPrivate.Checked;
           

            _current.Comunicazione.Fax = txtFax.Text;
            _current.Comunicazione.TelefonoUfficio = txtFisso.Text;
            _current.Comunicazione.Cellulare1= txtcell1.Text;
            _current.Comunicazione.Cellulare2 = txtCell2.Text;
            _current.Comunicazione.Mail = txtMail.Text;

            _current.Note = txtNote.Text;


            _current.Marca = txtMarca.Text;
            _current.Matricola = txtMatricola.Text;
            _current.Modello = txtModello.Text;
            _current.IsAbbonato = chkAbbonato.Checked;




            CustomerHandler h = new CustomerHandler();
            h.SaveOrUpdate(_current);
        }

        protected override void Nested_PostSaveActions()
        {
             Hashtable ParameterList  = new Hashtable();
             ParameterList.Add("Id", m_IdShowedObject);
             NavigateTo("Customers", ParameterList, true);
        }


        public override void Nested_UpdateData()
        {
            SaveOrUpdate();
        }

        #endregion

        #region Change


        public override void StartChangeOperation()
        {
            if (_initializing)
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

        private void chkPrivate_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtIva_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtResp_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
            LoadComboComuni((cboProv.SelectedItem as Provincia).Descrizione, cboCom);
        }

        private void cboCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtInd_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtCap_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtcell1_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtFisso_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }


        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }


        private void txtCell2_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtFax_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtMail_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void txtNote_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        [Secure(Area = "Contatti", Alias = "Aggiorna", MacroArea = "Applicativo")]
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
           // commandBar1.Custom_SetPrintButtonEnabled(false);
            commandBar1.Custom_SetFunctionName(string.Format(base.State.StateName + " contatto: {0}", desc));
        }
        #endregion

        #region Delete

        public override void DoDelete()
        {
            if (_current == null)
                return;


            try
            {
                if (XtraMessageBox.Show("Il contatto sarà eliminato solamente se nel sistema non ci sono altri riferimenti al contatto. Sicuro di voler procedere? ", "Elimina contatto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Nested_CheckSecurityForDeletion();

                    CustomerHandler h = new CustomerHandler();
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

        [Secure(Area = "Contatti", Alias = "Elimina", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForDeletion()
        {
            SecurityManager.Instance.Check();
        }

#endregion



        //Pulsante nuova ricerca
        private void commandBar1_NewSearchCommandPressed(object sender, EventArgs e)
        {
            //try
            //{
            //    if (base.CheckBeforeNavigate())
            //        base.NavigateTo("Customers", true);
            //    //else
            //    //    _mainForm.NavigatorUtility.NavigateToPrevious();
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler.Show(ex);
            //}
            FormRicercaCliente c = new FormRicercaCliente();
            if (c.ShowDialog() == DialogResult.OK)
            {
                Hashtable ParameterList = new Hashtable();
                ParameterList.Add("Id", c.SelectedCustomer.Id);
                NavigateTo("Customers", ParameterList, true);
            }
            c.Dispose();

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
                WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();
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
                NavigateTo("Customers", ParameterList, true);
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

  
        private void commandBar1_PrintCommandPressed(object sender, EventArgs e)
        {
            Print();
        }



        #region Eventi aggiuntivi form

      private void txtCap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Comune c = cboCom.SelectedItem as Comune;
            if (c != null)
                txtCap.EditValue = c.CAP;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.State.StateName == "Visualizzazione")
                {
                    Hashtable h = new Hashtable();
                    h.Add("Id", _current.Id);
                    h.Add("Customer", _current);
                    base.NavigateTo("CustomerAppointments", h);
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



        #endregion

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.State.StateName == "Visualizzazione")
                {
                    Hashtable h = new Hashtable();
                    h.Add("Id", _current.Id);
                    h.Add("Customer", _current);
                    base.NavigateTo("CustomerTasks", h);
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
                if (base.State.StateName == "Visualizzazione")
                {
                    Hashtable h = new Hashtable();
                    h.Add("Id", _current.Id);
                    h.Add("Customer", _current);
                    base.NavigateTo("CustomerDocuments", h);
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

        private void cboProvNas_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
            LoadComboComuni((cboProvNas.SelectedItem as Provincia).Descrizione, cboComNas);
        }

        private void cboNazNas_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
            if ((cboNazNas.SelectedItem as Nazione).Descrizione == "ITALIA")
                LoadComboProvince(cboProvNas);
            else
            {
                cboProvNas.EditValue = new ProvinciaNulla();
                cboProvNas.Enabled = false;
                cboComNas.EditValue = new ComuneNullo();
                cboComNas.Enabled = false;
            }
        }

        private void cboNazRes_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
            if ((cboNazRes.SelectedItem as Nazione).Descrizione == "ITALIA")
                LoadComboProvince(cboProv);
            else
            {
                cboProv.EditValue = new ProvinciaNulla();
                cboProv.Enabled = false;
                cboCom.EditValue = new ComuneNullo();
                cboCom.Enabled = false;
            }
        }

        private void dtpNas_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void cboComNas_EditValueChanged(object sender, EventArgs e)
        {
            StartChangeOperation();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (_current == null)
                return;
            if (_current.Key == null)
                return;
            CustomerAssignmentForm frm = new CustomerAssignmentForm(_current.Id);
            frm.ShowDialog(); frm.Dispose();
        }

    



    }
}
