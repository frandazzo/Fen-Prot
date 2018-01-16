using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Collections;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using DevExpress.XtraPivotGrid;

namespace WIN.SCHEDULING_APP.GUI.Controls
{

    public partial class BookingStatsControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {

        
        int ressourceCount;

        public BookingStatsControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            comboBoxEdit1.EditValue = DateTime.Now.Year.ToString();
            CustomGUI_SetCommandBarVisibility(false);


            BookingResourceHandler h = new BookingResourceHandler();
            ressourceCount = h.GetAll().Count;
            if (ressourceCount == 0)
                ressourceCount = 1;

            SetDataPivotSource();


            
        }

        
        private void SetDataPivotSource()
        {
            try
            {
           
                StatisticsHandler hh = new StatisticsHandler();
                IList h = hh.GetBookingStatistics(Convert.ToInt32(comboBoxEdit1.Text));
                pivotGridControl1.DataSource = h;
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show (ex);
                
            }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SetDataPivotSource();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string cc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\StatisticheCamereVenduta.xls";
        
            pivotGridControl1.ExportToXls(cc);

            System.Diagnostics.Process.Start(cc);
        }

        private void pivotGridControl1_CustomSummary(object sender, DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs e)
        {
            if (e.DataField != fieldPercentualeCopertura1)
                return;


            
            
            

          
           if (ReferenceEquals(e.ColumnField, null) || ReferenceEquals(e.RowField, null))
           {
               //this is Grand Total cell
               e.CustomValue = (decimal)e.SummaryValue.Summary /ressourceCount;
               return;
           }
           DevExpress.XtraPivotGrid.PivotGridControl pivot = sender as DevExpress.XtraPivotGrid.PivotGridControl;
           int lastRowFieldIndex = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.RowArea) - 1;
           int lastColumnFieldIndex = pivot.Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.ColumnArea) - 1;
           if (e.RowField.AreaIndex == lastRowFieldIndex && e.ColumnField.AreaIndex == lastColumnFieldIndex)
           {
               //this is Ordinary cell
               e.CustomValue = e.SummaryValue.Summary;
           }
           else
           {
               //this is Total cell
               e.CustomValue = (decimal)e.SummaryValue.Summary / ressourceCount;
           }





            
        }
    }
}
