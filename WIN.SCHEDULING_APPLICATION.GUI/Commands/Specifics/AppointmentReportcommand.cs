using System;
using System.Collections.Generic;
using System.Text;
using WIN.SECURITY.Attributes;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SECURITY;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{
    [SecureContext()]
    public class AppointmentReportcommand: OpenCommand
    {
        public AppointmentReportcommand(MainForm form)
            : base(form)
        {

        }

         protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
        {
            return new ReportAppuntamentiControl(_main );
        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
        {
            return new ReportAppuntamentiControl( _main);
        }

        protected override string ObjectToOpenName()
        {
            return "Report appuntamenti";
        }



        public override void Execute(System.Collections.Hashtable WitParameter1)
        {
            int id;
            try 
	        {	        
        		id = int.Parse (WitParameter1["Id"].ToString ());
	        }
	        catch (Exception)
	        {
		        throw new Exception ("Impossibile eseguire il comando di apertura: " + ObjectToOpenName() + "; Id inesistente");
	        }
            Open(id);
        }

        [Secure(Area = "Appuntamenti", Alias = "Report", MacroArea = "Applicativo")]
        protected override void SetTargetControlReceviers(BaseGUIControl control)
        {
            SecurityManager.Instance.Check();
            control.AddLinkCommand("AppointmentReports", new AppointmentReportcommand(_main));
            
        }
    }

}
