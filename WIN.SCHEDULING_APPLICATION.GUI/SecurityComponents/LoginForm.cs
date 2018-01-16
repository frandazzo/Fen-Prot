using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            uxErrorLabel.Text = "";
            lblApp.Text = Properties.Settings.Default.Main_AppName;

            lblVers.Text = String.Format("Versione software: {0}", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            lblDB.Text = String.Format("Versione database: {0}" ,InfoHandler.Instance.GetInfo().DBVersion.ToString());


        }

        private void uxLogonButton1_Click(object sender, EventArgs e)
        {
             if (SecurityManager.Instance.Logon(uxUserTextBox.Text, uxPassTextBox.Text))
             {
                 this.DialogResult = DialogResult.OK;
                 this.Close();
             }
             else
             {
                this.DialogResult = DialogResult.None;
                uxErrorLabel.Text = SecurityManager.Instance.LastError;
                uxErrorLabel.Text = "Username o password errati";
             }
        }

        private void uxCancelButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void uxUserTextBox_Enter(object sender, EventArgs e)
        {
            uxErrorLabel.Text = "";
            uxUserTextBox.SelectAll();
        }

        private void uxPassTextBox_Enter(object sender, EventArgs e)
        {
            uxErrorLabel.Text = "";
            uxPassTextBox.SelectAll();
        }

    
    }
}