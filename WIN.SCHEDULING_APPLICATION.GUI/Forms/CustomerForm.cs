using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.SECURITY;
using WIN.SECURITY.Attributes;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraReports.UI;


namespace WIN.SCHEDULING_APP.GUI.Forms
{
    [SecureContext()]
    public partial class CustomerForm : DevExpress.XtraEditors.XtraForm
    {
        private Customer _current;
        private bool _initializing = false;
        bool _changed = false;



        public Customer Customer
        {
            get
            {
                return _current;
            }
        }

        public CustomerForm()
        {
            _initializing = true;
            try
            {
                InitializeComponent();
                PrepareForLoading();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
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

        [Secure(Area = "Contatti", Alias = "Visualizza contatto da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForView()
        {
            SecurityManager.Instance.Check();
        }


        public CustomerForm(Customer c)
        {
            _initializing = true;
            try
            {
                InitializeComponent();
                PrepareForLoading();
                _current = c;
                if (_current != null)
                {
                    LoadEditors();
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
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

        private void LoadEditors()
        {
            if (_current != null)
            {
                txtDescrizione.Text = _current.Cognome;
                txtResp.EditValue = _current.Nome;
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

                

                cboZone.EditValue = _current.Resource;





                txtInd.EditValue = _current.Residenza.Via;
                txtCap.EditValue = _current.Residenza.Cap;


                chkPrivate.Checked = _current.Is_Private;

                txtIva.EditValue = _current.CodiceFiscale;

                txtFax.EditValue = _current.Comunicazione.Fax;
                txtFisso.EditValue = _current.Comunicazione.TelefonoUfficio;
                txtcell1.EditValue = _current.Comunicazione.Cellulare1;
                txtCell2.EditValue = _current.Comunicazione.Cellulare2;
                txtMail.EditValue = _current.Comunicazione.Mail;

                txtNote.EditValue = _current.Note;

                txtMarca.EditValue = _current.Marca;
                txtMatricola.EditValue = _current.Matricola;
                txtModello.EditValue = _current.Modello;
                chkAbbonato.Checked = _current.IsAbbonato;

                this.Text = _current.Descrizione;
            }

        }

        private void PrepareForLoading()
        {
            this.Text = "Nuovo contatto";
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

            //cboProv.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetProvinciaByName(Properties.Settings.Default.Main_Province);
            //cboCom.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetComuneByName(Properties.Settings.Default.Main_Comune);
            txtInd.EditValue = "";
            txtCap.EditValue = "";


            txtDescrizione.Text = "";
            chkPrivate.Checked = false;
            txtResp.EditValue = "";
            txtIva.EditValue = "";
            LoadComboZone();

            txtFax.EditValue = "";
            txtFisso.EditValue = "";
            txtcell1.EditValue = "";
            txtCell2.EditValue = "";
            txtMail.EditValue = "";


            txtMarca.EditValue = "";
            txtModello.EditValue = "";
            txtMatricola.EditValue = "";
            chkAbbonato.Checked = false;

            txtNote.EditValue = "";
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


        private void SaveOrUpdate()
        {
            _current.Cognome = txtDescrizione.Text;
            _current.Nome = txtResp.Text;

            if (dtpNas.EditValue == null)
                _current.DataNascita = DateTime.MinValue;
            else
                _current.DataNascita = dtpNas.DateTime;

            if (cboSex.Text == "Uomo")
                _current.Sesso = AbstractPersona.Sex.Maschio;
            else
                _current.Sesso = AbstractPersona.Sex.Femmina;

            _current.Resource = cboZone.SelectedItem as Resource;

            _current.Nazionalita = cboNazNas.SelectedItem as Nazione;
            _current.ProvinciaNascita = cboProvNas.SelectedItem as Provincia;
            _current.ComuneNascita = cboComNas.SelectedItem as Comune;

            _current.Residenza.Nazione = cboNazRes.SelectedItem as Nazione;
            _current.Residenza.Provincia = cboProv.SelectedItem as Provincia;
            _current.Residenza.Comune = cboCom.SelectedItem as Comune;

            _current.Residenza.Via = txtInd.Text;
            _current.Residenza.Cap = txtCap.Text;


            _current.Is_Private = chkPrivate.Checked;

            _current.CodiceFiscale = txtIva.Text;

            _current.Comunicazione.Fax = txtFax.Text;
            _current.Comunicazione.TelefonoUfficio = txtFisso.Text;
            _current.Comunicazione.Cellulare1 = txtcell1.Text;
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

        private void cmdOK_Click(object sender, EventArgs e)
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

        [Secure(Area = "Contatti", Alias = "Inserisci contatto da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForInsert()
        {
            Console.Write("Sto per fare il chek");
            SecurityManager.Instance.Check();
            //XtraMessageBox.Show("Chek eseguito");
        }


        [Secure(Area = "Contatti", Alias = "Aggiorna contatto da finestra mobile", MacroArea = "Applicativo")]
        public void CheckSecurityForUpdate()
        {
            SecurityManager.Instance.Check();
        }

        private void SaveAll()
        {
            if (_current == null || _current.Key == null)
            {

                _current = new Customer();
                CheckSecurityForInsert();
            }
            else
            {
                //CheckSecurityForUpdate();
            }


            SaveOrUpdate();

            this.Text = _current.Descrizione;
            _changed = false;
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

        private void simpleButton4_Click(object sender, EventArgs e)
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
                }
                else if (c == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    return;
                }
            }


            this.DialogResult = DialogResult.Cancel;
            this.Close();


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.CustomerReport c = new WIN.SCHEDULING_APP.GUI.Reports.CustomerReport();
                ArrayList l = new ArrayList();

                l.Add(CreatEDummyCustomer());

                c.DataSource = l;
                c.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private Customer CreatEDummyCustomer()
        {
            Customer c = new Customer();
            c.Cognome = txtDescrizione.Text;
            c.Resource = cboZone.SelectedItem as Resource;
            c.Residenza.Provincia = cboProv.SelectedItem as Provincia;
            c.Residenza.Comune = cboCom.SelectedItem as Comune;

            c.Residenza.Via = txtInd.Text;
            c.Residenza.Cap = txtCap.Text;


            c.Is_Private = chkPrivate.Checked;
            c.Nome = txtResp.Text;
            c.CodiceFiscale = txtIva.Text;

            c.Comunicazione.Fax = txtFax.Text;
            c.Comunicazione.TelefonoUfficio = txtFisso.Text;
            c.Comunicazione.Cellulare1 = txtcell1.Text;
            c.Comunicazione.Cellulare2 = txtCell2.Text;
            c.Comunicazione.Mail = txtMail.Text;

            c.Note = txtNote.Text;


            c.Marca = txtMarca.Text;
            c.Matricola = txtMatricola.Text;
            c.Modello = txtModello.Text;
            c.IsAbbonato = chkAbbonato.Checked;

            return c;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
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

        private void txtCap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Comune c = cboCom.SelectedItem as Comune;
            if (c != null)
                txtCap.EditValue = c.CAP;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ApplicationUtility.Instance.ShowObjectInfo(_current);
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

        private void simpleButton5_Click(object sender, EventArgs e)
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