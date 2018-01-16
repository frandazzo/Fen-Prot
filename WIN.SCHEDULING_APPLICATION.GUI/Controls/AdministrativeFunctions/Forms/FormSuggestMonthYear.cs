using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.Utility;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class FormSuggestMonthYear : DevExpress.XtraEditors.XtraForm
    {
        public FormSuggestMonthYear()
        {
            InitializeComponent();
            cboMonth.Text =  MonthYearSuggest.CurrentMonth.ToString();
            cboYear.Text = MonthYearSuggest.CurrentYear.ToString();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            MonthYearSuggest.SetCurrentMonth(Convert.ToInt32(cboMonth.Text));
            MonthYearSuggest.SetCurrentYear(Convert.ToInt32(cboYear.Text));

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}