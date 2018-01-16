using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmEliminaAllegato : DevExpress.XtraEditors.XtraForm
    {
        public FrmEliminaAllegato()
        {
            InitializeComponent();
        }


        public bool EliminaFile
        {
            get
            {
                return checkEdit1.Checked;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

     
    }
}