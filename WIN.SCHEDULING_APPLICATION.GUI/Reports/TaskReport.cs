using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APP.GUI.Reports
{
    public partial class TaskReport : DevExpress.XtraReports.UI.XtraReport
    {
        public TaskReport()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MyTask m = this.GetCurrentRow() as MyTask;


            if (m != null)
                if (m.OutcomeDate == DateTime.MinValue)
                    xrTableCell10.Text = "";
                else
                    xrTableCell10.Text = m.OutcomeDate.ToShortDateString();

            SetImageState(m);
            SetPriorityImage(m);

        }

        private void SetPriorityImage(MyTask m)
        {
            switch (m.Priority)
            {
                case PriorityType.Normale:
                    xrPictureBox2.Image = imageCollection1.Images[15];
                    break;
                case PriorityType.Alta:
                    xrPictureBox2.Image = imageCollection1.Images[12];
                    break;
                case PriorityType.Bassa:
                    xrPictureBox2.Image = imageCollection1.Images[13];
                    break;
                default:
                    break;
            }

        }

        private void SetImageState(MyTask m)
        {
            switch (m.OutlookDeadLineState)
            {
                case OutlookDeadLineState.CompleteFlag:
                    xrPictureBox1.Image = imageCollection1.Images[6];
                    break;
                case OutlookDeadLineState.SuperRedFlag:
                    xrPictureBox1.Image = imageCollection1.Images[7];
                    break;
                case OutlookDeadLineState.RedFlag:
                    xrPictureBox1.Image = imageCollection1.Images[8];
                    break;
                case OutlookDeadLineState.MinorRedFlag:
                    xrPictureBox1.Image = imageCollection1.Images[10];
                    break;
                case OutlookDeadLineState.EmptyFlag:
                    xrPictureBox1.Image = imageCollection1.Images[11];
                    break;
                default:
                    break;

            }
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            //MyTask m = this.GetCurrentRow() as MyTask;


           
        }

    }
}
