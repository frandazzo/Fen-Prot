using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    public partial class HomePage : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        public HomePage(MainForm form)
            : base(form)
        {
            InitializeComponent();
            CustomGUI_SetCommandBarVisibility(false);
            //non permetto nessuna operazione dalla toolbar
            base.m_ChangeStateEnabled = false;



            webBrowser1.Url = new Uri(GetHomePagePath());
        }

        private string GetHomePagePath()
        {
            string dirPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(dirPath);

            dirPath = f.DirectoryName;

            return dirPath +  "\\Noesis\\default.htm";



        }


        

    }
}
