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
    public partial class FrmSelezionaIntervalloDate : DevExpress.XtraEditors.XtraForm
    {
        public FrmSelezionaIntervalloDate(DateTime start, DateTime end)
        {
            InitializeComponent();
            if (start > end)
            {
                dateEdit1.EditValue = end;
                dateEdit2.EditValue = start;
            }
            else
            {
                dateEdit1.EditValue = start;
                dateEdit2.EditValue = end;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!DatesAreValid())
            {
                DateTime f = dateEdit1.DateTime;
                dateEdit1.EditValue = dateEdit2.DateTime;
                dateEdit2.EditValue = f;
            }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private bool DatesAreValid()
        {
            return dateEdit1.DateTime <= dateEdit2.DateTime;
                
        }
    }
}