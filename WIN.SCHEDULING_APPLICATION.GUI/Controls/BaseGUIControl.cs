using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    public partial class BaseGUIControl : WIN.GUI.UTILITY.AbstractBrowserControl
    {
        protected MainForm _mainForm;
        public BaseGUIControl()
        {
            InitializeComponent();
        }


        public BaseGUIControl(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
        }

        protected bool CheckBeforeNavigate()
        {
            if (base.State.StateName == "Aggiornamento" || base.State.StateName == "Creazione")
            {
                DialogResult i = XtraMessageBox.Show("Si desidera salvare i dati?", Properties.Settings.Default.Main_AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (i == DialogResult.Yes)
                {
                    StartSaveOperation();
                }
                else if (i == DialogResult.Cancel )
                {
                    return false;
                }
            }
            return true;
        }


        public void CustomGUI_SetCommandBarVisibility(bool visible)
        {
            commandBar1.Visible = visible;
        }

        public virtual void SetFocusForSearch()
        {
            commandBar1.Custom_SetFocusOnEditor();
        }


        public virtual void Print()
        {
            //
        }

        public virtual void GetElementInfo()
        {
            //
        }

    }
}
