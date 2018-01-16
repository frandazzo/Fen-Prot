using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FormInformazioni : DevExpress.XtraEditors.XtraForm
    {
        public FormInformazioni()
        {
            InitializeComponent();
            lblSwTitle.Text = Properties.Settings.Default.Main_AppName;
            lblVers.Text = String.Format("Versione software: {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            lblDB.Text = String.Format("Versione database: {0}", InfoHandler.Instance.GetInfo().DBVersion.ToString());

            DBTypeLabel.Text = "Tipo database: " + DataAccessServices.Instance().ServiceName;
            MaxCacheSizeLabel.Text = "Massima dimensione della cache: " + DataAccessServices.Instance().MaxCacheSize;
            CustomPersistenceAssemblyNameLabel.Text = "Assembly servizio di persistenza: " + DataAccessServices.Instance().CustomPersistentServiceAssembly;


            string[] arr = DataAccessServices.Instance().ConnectionString.Split(new char[] { ';' });
            txtConnextionStringparameters.Text += Environment.NewLine;

            if (arr.Length > 0)
            {
                for (int i=0; i<arr.Length - 1; i++)
                {
                    string elem  = arr[i];
                    elem = elem.Trim();
                    if (!elem.StartsWith("Password"))
                        txtConnextionStringparameters.Text += Environment.NewLine + elem;
                   
                }
            }


        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.tecnoesis.it");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LabelDBVersion_Click(object sender, EventArgs e)
        {

        }
    }
}