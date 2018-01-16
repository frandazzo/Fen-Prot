using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.MovimentoInitializzationStrategies;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.Utility;
using System.Collections;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class MovimentoForm : DevExpress.XtraEditors.XtraForm
    {

        public delegate void MovimentoSavedEventHandler(object sender, MovimentoContabileEventArg e);
        public event MovimentoSavedEventHandler MovimentoSaved;
       

        private TipoMovimernto _type;
        private CausaliAmministrativeForm frm;
        //private int _year = DateTime.Now.Year;
        //private int _month = DateTime.Now.Month;
        AbstractMovimentoContabile _current = null;


        public AbstractMovimentoContabile Current
        {
            get { return _current; }
        }


        //costruttore utilizzato per la creazione di un nuovo oggetto movimento
        public MovimentoForm(TipoMovimernto type)
        {
          
            InitializeComponent();
            
            _type = type;
            _current = MovimentoContabileFactory.GetMovimento(_type);
            //inizializzo l'interfaccia
            IInitializzationStrategy s = InitializzationStrategyFactory.GetInitializator(_type);
            s.InitializeControls(this, true);

            //prepares components
            PrepareLoadDataOfSiglecomponents();
        }

        void frm_Causaleselected(object sender, SelectCausaleEventArg arg)
        {
            bttCausale.EditValue = arg.Causale;
        }

        //costruttore utilizzato per l'aggiornamento di un oggetto movimento
        public MovimentoForm(TipoMovimernto type, AbstractMovimentoContabile movimento)
        {

            InitializeComponent();
            
            _type = type;
            _current = movimento;
            //inizializzo l'interfaccia
            IInitializzationStrategy s = InitializzationStrategyFactory.GetInitializator(_type);
            s.InitializeControls(this, false);

            //prepares components
            PrepareLoadDataOfSiglecomponents();


            //carico i dati dell'oggetto caricato
            LoadData();
        }

        private void LoadData()
        {
            if (_current != null)
            {
                spImporto.Value = (decimal)_current.Importo;
                dtpData.EditValue = _current.Data;    
                cboRegione.EditValue = _current.Regione;
                cboProvincia.EditValue = _current.Provincia;
                bttCausale.EditValue = _current.Causale;
                txtNote.Text = _current.Note;
                spinEditComp.Value = _current.Competenza;
            }
        }

        private void PrepareLoadDataOfSiglecomponents()
        {
            if (layoutRegione.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                //carico le regioni
                LoadComboRegioni();
            else
                LoadComboProvince("");

            //carico il suggeritore
            hyperLinkEdit1.Text = MonthYearSuggest.GetDefaultPeriod();


            //impostazione data
            dtpData.EditValue = DateTime.Now.Date;


            //aggiusto il numero di giorni per il mese selezionato
            AdjustDaysOfMonthChoose();


            //se è visibile il campo competenza lo valorizzo con l'anno corrente
            if (layoutControlItemAnno.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                spinEditComp.Value = DateTime.Now.Year;
            else
                spinEditComp.Value = 0;
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            FormSuggestMonthYear frm = new FormSuggestMonthYear();
            frm.ShowDialog();
            frm.Dispose();

            hyperLinkEdit1.Text = MonthYearSuggest.GetDefaultPeriod();

            //carico nella combo dei giorni i giorni del mese selezionato
            AdjustDaysOfMonthChoose();

        }

        private void AdjustDaysOfMonthChoose()
        {
            int days = DateTime.DaysInMonth(MonthYearSuggest.CurrentYear, MonthYearSuggest.CurrentMonth);

            cboDay.Properties.Items.Clear();



            for (int i = 1; i <= days; i++)
            {
                cboDay.Properties.Items.Add(i.ToString());
            }

            cboDay.SelectedIndex = 0;
        }

        private DateTime RetrieveDateFromForm()
        {
            //prendo la data dal giorno e dal suggerimento
            if (layoutItemDatapicker.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            {
                return new DateTime(MonthYearSuggest.CurrentYear, MonthYearSuggest.CurrentMonth, Convert.ToInt32(cboDay.Text));
            }
            return dtpData.DateTime;
        }


        private void LoadComboRegioni()
        {
            //preparo la combo delle dei comuni
            cboRegione.Properties.Items.Clear();
            ////la riempio con un comune nullo
            cboRegione.Properties.Items.Add(new RegioneNulla());

           
            IList l = GeoLocationFacade.Instance().GetListaOggettiRegioni();
            cboRegione.Properties.Items.AddRange(l);
           
            //seleziono quella iniziale
                cboRegione.SelectedIndex = 0;
        }

        private void LoadComboProvince(string regione)
        {

            //preparo la combo delle zone
            cboProvincia.Properties.Items.Clear();


            //la riempio
            cboProvincia.Properties.Items.Add(new ProvinciaNulla());
            if (string.IsNullOrEmpty(regione))
            {
                IList l = GeoLocationFacade.Instance().GetGeoHandler().ListaProvince;
                cboProvincia.Properties.Items.AddRange(l);
            }
            else
            {
                IList l = GeoLocationFacade.Instance().GetGeoHandler().GetProviciePerRegione(regione);
                cboProvincia.Properties.Items.AddRange(l);

            }

            //seleziono quella iniziale
            cboProvincia.SelectedIndex = 0;
        }

        private void cboRegione_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  if (layoutRegione.Visibility ==  DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                LoadComboProvince(cboRegione.Text);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {

                SaveData();

                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void SaveData()
        {
            //variabile per capire se si fa un'aggiornamento o un nuovo inserimento
            bool added = false;
            if (_current.Key == null)
                added = true;
            
              

            SetObjectProperties();

            SimpletHandler h = MovimentoContabileHandlerFactory.GetMovimentoHandler(_type);
            h.SaveOrUpdate(_current);


            InvokeMovimentoSaved(added);

        }

        private void InvokeMovimentoSaved(bool added)
        {
            //lancio l'evento
            if (MovimentoSaved != null)
            {
                MovimentoContabileEventArg e = new MovimentoContabileEventArg();
                e.Added = added;
                e.Movimento = _current;

                MovimentoSaved.Invoke(this, e);
            }
        }

        private void clearProperties()
        {
            _current = MovimentoContabileFactory.GetMovimento(_type);
            spImporto.Value = 0;
            dtpData.EditValue = DateTime.Now.Date;
            cboDay.Text = "1";
            if (layoutRegione.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                LoadComboRegioni();
            else
                LoadComboProvince("");
            bttCausale.EditValue = null;
            txtNote.Text = "";

            if (layoutItemDatapicker.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                dtpData.Focus();
            else
                cboDay.Focus();

            if (layoutControlItemAnno.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                spinEditComp.Value = DateTime.Now.Year;

        }

        private void SetObjectProperties()
        {
            if (_current == null)
            {
                _current = MovimentoContabileFactory.GetMovimento(_type);
            }

            _current.Importo = (float)spImporto.Value;
            _current.Data = this.RetrieveDateFromForm();
            _current.Provincia = cboProvincia.EditValue as Provincia;
            //se è stata inserita una provincia ne prendo il valore dalla provincia stessa
            //senon è stata inserita vedo se c'è una regione
            if (_current.Provincia.Id != -1)
                _current.Regione = GeoLocationFacade.Instance().GetGeoHandler().GetRegioneById(_current.Provincia.IdRegione.ToString());
            else
                _current.Regione = cboRegione.EditValue as Regione;
            _current.Causale = bttCausale.EditValue  as CausaleAmministrativa;
            _current.Note = txtNote.Text;


            if (layoutControlItemAnno.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                _current.Competenza = (int)spinEditComp.Value;


        }

        private void cmdAddWithNew_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                this.clearProperties();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void bttCausale_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                //eseguo la ricerca della causale
                frm = new CausaliAmministrativeForm(_type);
                frm.Causaleselected += new CausaliAmministrativeForm.SelectCausaleEventHandler(frm_Causaleselected);
                frm.ShowDialog();
                frm.Dispose();

            }
            else
            {
                //elimino la causale dall'editor
                bttCausale.EditValue = null;
            }
        }

        private void hyperLinkEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                FormSuggestMonthYear frm = new FormSuggestMonthYear();
                frm.ShowDialog();
                frm.Dispose();

                hyperLinkEdit1.Text = MonthYearSuggest.GetDefaultPeriod();

                //carico nella combo dei giorni i giorni del mese selezionato
                AdjustDaysOfMonthChoose();
            }
        }

        




    }
}