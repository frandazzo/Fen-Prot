using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APP.GUI.Reports
{
    public partial class AppointmentReport : DevExpress.XtraReports.UI.XtraReport
    {
        public AppointmentReport()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MyAppointment m = this.GetCurrentRow() as MyAppointment;

            SetImageState(m);

        }

        private void SetImageState(MyAppointment m)
        {
            switch (m.State)
            {
                case AppointmentState.Pianificato:
                    xrPictureBox1.Image = imageCollection1.Images[0];
                    break;
                case AppointmentState.In_Scadenza:
                    xrPictureBox1.Image = imageCollection1.Images[1];
                    break;
                case AppointmentState.Scade_Oggi:
                    xrPictureBox1.Image = imageCollection1.Images[2];
                    break;
                case AppointmentState.Scaduto:
                    xrPictureBox1.Image = imageCollection1.Images[3];
                    break;
                case AppointmentState.Eseguito:
                    xrPictureBox1.Image = imageCollection1.Images[4];
                    break;
                case AppointmentState.Concluso:
                    xrPictureBox1.Image = imageCollection1.Images[5];
                    break;
                default:
                    break;
            }
        }

    }
}
