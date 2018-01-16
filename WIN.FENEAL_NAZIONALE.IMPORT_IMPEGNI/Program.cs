using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] cmdArgs)
        {

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += currentDomain_UnhandledException;



          
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
           
           
        }

        static void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Errore");
            MessageBox.Show(e.ExceptionObject.ToString());
        }


    }
}
