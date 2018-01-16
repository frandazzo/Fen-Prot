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
    public partial class FormCausale : DevExpress.XtraEditors.XtraForm
    {

        
        private TipoMovimernto _type;
       private CausaleAmministrativa _current;


         //utilizzato per creare un nuovo elemento
        public FormCausale(TipoMovimernto type)
        {
            InitializeComponent();

            _type = type;

             ClearData();
        }

            //utilizzato per aggiornare un elemento
        public FormCausale(CausaleAmministrativa current)
        {
            InitializeComponent();
            _current = current;
            _type = _current.Tipo;
            LoadEditorsProperties();

        }


        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                SetObjectProperties();
                CausaleAmministrativaHandler h = new CausaleAmministrativaHandler();
                h.SaveOrUpdate(_current);


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
   




        public CausaleAmministrativa Current
        {
            get { return _current; }
        }

       
     

        private void ClearData()
        {
            textEdit1.Text = "";

        }

    

        private void LoadEditorsProperties()
        {
            if (_current != null)
            {
                textEdit1.Text = _current.Descrizione;
            }
        }

        private void SetObjectProperties()
        {
            if (_current == null)
                _current = new CausaleAmministrativa();

            _current.Descrizione = textEdit1.Text;
            _current.Tipo = _type;
          
        }



    }
}
