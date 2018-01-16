using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class FormTesseramento : DevExpress.XtraEditors.XtraForm
    {
        private Tesseramento _current;


        public Tesseramento Current
        {
            get { return _current; }
        }

        //utilizzato per creare un nuovo elemento
        public FormTesseramento()
        {
            InitializeComponent();

            ClearData();

        }

        private void ClearData()
        {
            spAnno.Value = DateTime.Now.Year;
            spCosto.Value = 0;
            spQuota.Value = 0;
            spRichieste.Value = 0;
        }

        //utilizzato per aggiornare un elemento
        public FormTesseramento(Tesseramento current)
        {
            InitializeComponent();
            _current = current;
            LoadEditorsProperties();

        }


        private void LoadEditorsProperties()
        {
            if (_current != null)
            {
                spAnno.Value = _current.Anno;
                spCosto.Value = (decimal)_current.CostoTessera;
                spQuota.Value = (decimal)_current.QuotaUIL;
                spRichieste.Value = _current.TesseraAcquistate;
            }
        }

        private void SetObjectProperties()
        {
            if (_current == null)
                _current = new Tesseramento();

            _current.Anno = Convert.ToInt32(spAnno.Value) ;
            _current.CostoTessera = (float)spCosto.Value;
            _current.QuotaUIL = (float)spQuota.Value;
            _current.TesseraAcquistate = Convert.ToInt32(spRichieste.Value);
        }


        private void cmdOk_Click(object sender, EventArgs e)
        {

            try
            {
                SetObjectProperties();
                TesseramentoHandler h = new TesseramentoHandler();
                h.SaveOrUpdate(_current);


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }
    }
}