using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class SelezionaAnnoForm : DevExpress.XtraEditors.XtraForm
    {
        CausaliAmministrativeForm frm;
        private int _selectedCausale;
        private int _SelectedAnno;
        public int SelectedAnno
        {
            get
            {
                return _SelectedAnno;
            }
            private set
            {
                _SelectedAnno = value;
            }
        }



        public SelezionaAnnoForm()
        {
            InitializeComponent();
            LoadAnni();
            
        }

        public SelezionaAnnoForm(bool openCausaliEditor)
        {
            InitializeComponent();
            LoadAnni();
            if (openCausaliEditor)
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        private void LoadAnni()
        {
            comboBoxEdit1.Properties.Items.Clear();
            for (int i = 1990; i < 2031; i++)
            {
                comboBoxEdit1.Properties.Items.Add(i.ToString());    
            }

            comboBoxEdit1.Text = DateTime.Now.Year.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _SelectedAnno = Convert.ToInt32(comboBoxEdit1.Text);
            if (buttonEdit1.EditValue != null)
                _selectedCausale = (buttonEdit1.EditValue as CausaleAmministrativa).Id;
            else
                _selectedCausale = 0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public int SelectedCausale
        {
            get
            {
                return _selectedCausale;
            }
            set
            {
                _selectedCausale = value;
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                //eseguo la ricerca della causale
                frm = new CausaliAmministrativeForm(SCHEDULING_APPLICATION.DOMAIN.Amministrazione.TipoMovimernto.Quac);
                frm.Causaleselected +=new CausaliAmministrativeForm.SelectCausaleEventHandler(frm_Causaleselected);   
                frm.ShowDialog();
                frm.Dispose();

            }
            else
            {
                //elimino la causale dall'editor
                buttonEdit1.EditValue = null;
            }
        }

        void frm_Causaleselected(object sender, SelectCausaleEventArg arg)
        {
            buttonEdit1.EditValue = arg.Causale;
        }

    }
}