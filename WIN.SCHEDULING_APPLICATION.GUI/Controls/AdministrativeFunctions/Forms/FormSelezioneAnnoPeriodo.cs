using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class FormSelezioneAnnoPeriodo : XtraForm
    {
        public FormSelezioneAnnoPeriodo()
        {
            InitializeComponent();
            LoadAnni();
        }

        private String _selectedPeriodo;

        public String SelectedPeriodo
        {
            get { return _selectedPeriodo; }
            set { _selectedPeriodo = value; }
        }
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



       

       

        private void LoadAnni()
        {
            cboAnno.Properties.Items.Clear();
            for (int i = 1990; i < 2031; i++)
            {
                cboAnno.Properties.Items.Add(i.ToString());    
            }

            cboAnno.Text = DateTime.Now.Year.ToString();
        }

     

     

       

       

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            _selectedPeriodo = cboPeriodo.Text;
            _SelectedAnno = Convert.ToInt32( cboAnno.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
