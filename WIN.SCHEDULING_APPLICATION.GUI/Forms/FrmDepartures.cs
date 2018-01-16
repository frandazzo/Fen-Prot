using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using System.Collections;
using DevExpress.XtraPrinting;
using System.Reflection;
using System.IO;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmDepartures : DevExpress.XtraEditors.XtraForm
    {
           string fileLayout = "";

           public FrmDepartures()
        {
            InitializeComponent();
            dateEdit1.EditValue = DateTime.Now;
            Search();
        }

        private void Search()
        {
            try
            {
                AssignmentHandler h = new AssignmentHandler();
                IList l = h.GetArrivalsAndDepartures(dateEdit1.DateTime,false);

                gridControl1.DataSource = l;

                if (l.Count == 0)
                    XtraMessageBox.Show("Nessuna partenza attesa", "Mesaggio",  MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = gridControl1;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.ShowPreview();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void FrmArrivedPersons_Load(object sender, EventArgs e)
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += "\\LayoutSavings\\reportPartenze.xml";


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
    }
}