using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Collections;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    public partial class BookingPaymentStats : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        public BookingPaymentStats(MainForm form)
            : base(form)
        {
            InitializeComponent();
            comboBoxEdit1.EditValue = DateTime.Now.Year.ToString();
            CustomGUI_SetCommandBarVisibility(false);

            SetDataPivotSource();

        }

        
        private void SetDataPivotSource()
        {
            try
            {
           
                StatisticsHandler hh = new StatisticsHandler();
                IList h = hh.GetPaymentStatistics(Convert.ToInt32(comboBoxEdit1.Text));
                pivotGridControl1.DataSource = h;
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show (ex);
                
            }
           
        }

     

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string cc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\StatisticheIncassi.xls";

            pivotGridControl1.ExportToXls(cc);

            System.Diagnostics.Process.Start(cc);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SetDataPivotSource();
        }
    }
}
