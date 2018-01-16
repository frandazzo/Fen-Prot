using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmSelectPrinter : DevExpress.XtraEditors.XtraForm
    {

       string strOldPrinter  = "";
       object WshNetwork ;
       System.Drawing.Printing.PrintDocument pd =  new System.Drawing.Printing.PrintDocument();
        string m_printernName  = "";

        public string  PrinterName
        {
            get
            {
                return m_printernName;
            } 
        }


        public FrmSelectPrinter()
        {
            InitializeComponent();
            PopulateInstalledPrintersListBox();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
             this.DialogResult =  DialogResult.Cancel;
             this.Close();
        }


      private  bool ChangeDefaultPrinter(string strPrinterName) 
       {
          Type t = null; 
          try
          {
             strOldPrinter = pd.PrinterSettings.PrinterName;
             t = Type.GetTypeFromProgID("WScript.Network");
             WshNetwork = Activator.CreateInstance(t);

             t.InvokeMember("SetDefaultPrinter", System.Reflection.BindingFlags.InvokeMethod, null, WshNetwork, new object[] { strPrinterName });
                 //Microsoft.VisualBasic.CreateObject("WScript.Network");
             //WshNetwork.SetDefaultPrinter(strPrinterName);
             pd.PrinterSettings.PrinterName = strPrinterName;

             if (pd.PrinterSettings.IsValid)
                 return true;
             else
             {
                 //WshNetwork.SetDefaultPrinter(strOldPrinter);
                 t.InvokeMember("SetDefaultPrinter", System.Reflection.BindingFlags.InvokeMethod, null, WshNetwork, new object[] { strOldPrinter });
                 return false;
             }
          }
          catch (Exception)
          {
              //
              t.InvokeMember("SetDefaultPrinter", System.Reflection.BindingFlags.InvokeMethod, null, WshNetwork, new object[] { strOldPrinter });
             
             return false;
          }
          finally
          {
              WshNetwork = null;
              pd = null;

          }
        }


        private void PopulateInstalledPrintersListBox()
        {
              //' Add list of installed printers found to the combo box.
              //' The pkInstalledPrinters string will be used to provide the display string.
            int i;
            string pkInstalledPrinters;

            cboPrint.Properties.Items.Clear();
            cboPrint.Properties.ReadOnly = false;
            for (i = 0; i < PrinterSettings.InstalledPrinters.Count;i++ )
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];

                cboPrint.Properties.Items.Add(pkInstalledPrinters);
            }
            try 
            {	        
	             cboPrint.SelectedIndex = 0;
            }
            catch (Exception)
            {
        		
	            //
            }
        


      }



      private void cmdOk_Click(object sender, EventArgs e)
      {
          m_printernName = pd.PrinterSettings.PrinterName;
          ChangeDefaultPrinter(m_printernName);
          this.DialogResult = DialogResult.OK;
          this.Close();
      }

      private void comboBoxEdit1_Properties_SelectedIndexChanged(object sender, EventArgs e)
      {
          if (cboPrint.SelectedIndex != -1)
              pd.PrinterSettings.PrinterName = cboPrint.SelectedItem as string;
      }
    }
}