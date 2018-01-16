using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports
{
    public partial class ImpegniReport : DevExpress.XtraReports.UI.XtraReport
    {
        public ImpegniReport()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //object gg = sender;
            if (mainLabel.Text.ToLower() == "tesseramento")
                mainLabel.Text = String.Format("{0} {1}", mainLabel.Text, this.Tag);
            if (secondLabel.Text.EndsWith(":"))
                secondLabel.Text = String.Format("{0} {1}", secondLabel.Text, GetDate((int)this.Tag));
        }


        private string GetDate(int anno)
        {
            if (anno == DateTime.Now.Year)
                return DateTime.Now.Date.ToShortDateString();

            return new DateTime(Convert.ToInt32(this.Tag), 12, 31).ToShortDateString();

        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //DevExpress.XtraReports.UI.ReportFooterBand rpt = sender as DevExpress.XtraReports.UI.ReportFooterBand;
            //if (rpt != null)
            //{
                
            //}
        }

       
        
    }
}
