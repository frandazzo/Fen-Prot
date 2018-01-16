using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SECURITY.Core;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class FormProfili : DevExpress.XtraEditors.XtraForm
    {
       public SecureDataManager SecureDataAccess = new SecureDataManager();
       private IList< IProfile> list   = new List< IProfile>();
       private IProfile m_Profile;


       public IProfile SelectedProfile
       {
           get
           {
               return m_Profile;
           }
       }

        public FormProfili()
        {
            InitializeComponent();
            LoadCombo();
        }

        private void LoadCombo()
        {
            list = SecureDataAccess.GetProfiles();
            foreach (IProfile elem in list)
            {
                comboBox1.Properties.Items.Add(elem.Description);
            }
            comboBox1.Properties.Sorted = true;

            if (list.Count > 0)
                comboBox1.SelectedIndex = 0;

        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            foreach (IProfile elem in list)
            {
                if (elem.Description.Equals(comboBox1.Text))
                    m_Profile = elem; 
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}