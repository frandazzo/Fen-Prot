using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Reports
{
    public partial class CustomerReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        private void xrTableRow1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
