using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APP.GUI.Controls;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{
    public class HomeCommand: OpenCommand
    {

        public HomeCommand(MainForm form)
            : base(form)
        {

        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
        {
            return new HomePage(_main );
        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
        {
            return new HomePage(_main );
        }

        protected override string ObjectToOpenName()
        {
            return "Home page";
        }
    }
}
