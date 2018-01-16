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
    public partial class OrganizzativeControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {

        public OrganizzativeControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            CustomGUI_SetCommandBarVisibility(false);
            
            ////avvio la renderizzazione del tessseramento
            //XtraUserControl r = new RimesseReportControl();
            //RenderSubControl(r);
        }

        private void RenderSubControl(XtraUserControl control)
        {
            if (panelContainer.Controls.Count > 0)
            {
                panelContainer.Controls[0].Dispose();
                panelContainer.Controls.Clear();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            panelContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
      

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraMessageBox.Show("Dati struttura");
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraMessageBox.Show("Organismi regionali");
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraMessageBox.Show("Organismi territoriali");
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            XtraMessageBox.Show("Rappresentanza e rappresentatività");
        }
    }
}
