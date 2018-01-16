using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Collections;
using WIN.BASEREUSE;
using DevExpress.XtraPrinting;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using DevExpress.XtraEditors;
using System.IO;
using System.Reflection;

namespace WIN.SCHEDULING_APP.GUI.Controls
{

    public partial class BookingPaymentStatsControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {

        string fileLayout;

        public BookingPaymentStatsControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            
            
            CustomGUI_SetCommandBarVisibility(false);

            dateEdit1.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateEdit2.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));


            SetGridDataSource();

        }

   
        private void SetGridDataSource()
        {
            try
            {
           
                BookingHandler hh = new BookingHandler();
                DataRange r = null;
                if (dateEdit1.DateTime > dateEdit2.DateTime)
                    r = new DataRange(dateEdit2.DateTime, dateEdit1.DateTime);
                else
                    r=new DataRange(dateEdit1.DateTime, dateEdit2.DateTime);
                IList h = hh.GetBookings(r);
                if (h.Count == 0)
                    XtraMessageBox.Show("Nessuna prenotazione trovata", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    try
                    {
                        gridControl1.MainView.SaveLayoutToXml(fileLayout);

                    }
                    catch (Exception)
                    {
                        //non fa nulla
                    }


                }
                gridControl1.DataSource = h;
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show (ex);
                
            }
           
        }

    

    

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            SetGridDataSource();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = gridControl1;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.ShowPreview();
        }

        private void BookingPaymentStatsControl_Load(object sender, EventArgs e)
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += "\\LayoutSavings\\reportPrenotazioni.xml";


            //verifico la presenza del file
            f = new FileInfo(fileLayout);

            try
            {
                if (f.Exists)
                {
                    gridControl1.ForceInitialize();
                    // Restore the previously saved layout
                    gridControl1.MainView.RestoreLayoutFromXml(fileLayout);
                }
            }
            catch (Exception)
            {
                //non fa nulla
            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

        }
    }
}
