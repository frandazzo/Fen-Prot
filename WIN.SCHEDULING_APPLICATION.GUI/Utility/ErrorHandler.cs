using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.Utility
{
    public class ErrorHandler
    {
        public static void  Show(Exception ex)
        {
           // string error = ex.Message;

            //if (ex.InnerException != null)
            //    message = message + Environment.NewLine + ex.InnerException.Message;

            string error = ex.Message + Environment.NewLine;

            if (ex.InnerException != null)
                error = error + ex.InnerException.Message + Environment.NewLine;

            if (!Properties.Settings.Default.Main_ProductionEnvironment)
            {
                if (ex.InnerException != null)
                    if (ex.InnerException.InnerException != null)
                        error = error + ex.InnerException.InnerException.Message + Environment.NewLine;


                error = error + ex.StackTrace;
            }

            XtraMessageBox.Show(error, Properties.Settings.Default.Main_AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public static void Show(string ex)
        {
            string message = ex;

            

            XtraMessageBox.Show(message, Properties.Settings.Default.Main_AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        
    }
}
