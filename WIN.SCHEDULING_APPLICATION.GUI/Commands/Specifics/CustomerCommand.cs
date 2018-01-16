using System;
using System.Collections.Generic;
using System.Text;
using WIN.SECURITY.Attributes;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SECURITY;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{
    [SecureContext()]
    public class CustomerCommand: OpenCommand
    {
        public CustomerCommand(MainForm form)
            : base(form)
        {

        }

         protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
        {
            return new Customerscontrol(_main );
        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
        {
            return new Customerscontrol(id, _main);
        }

        protected override string ObjectToOpenName()
        {
            return "Customer";
        }



        public override void Execute(System.Collections.Hashtable WitParameter1)
        {
            int id;
            try 
	        {	        
        		id = int.Parse (WitParameter1["Id"].ToString ());
                base.m_IdObjectToOpen = id;
	        }
	        catch (Exception)
	        {
		        throw new Exception ("Impossibile eseguire il comando di apertura: " + ObjectToOpenName() + "; Id inesistente");
	        }
            Open(id);
        }

        [Secure(Area = "Contatti", Alias = "Visualizza", MacroArea = "Applicativo")]
        protected override void SetTargetControlReceviers(BaseGUIControl control)
        {
            SecurityManager.Instance.Check();
            control.AddLinkCommand("Customers", new CustomerCommand(_main));
            control.AddLinkCommand("Resources", new ResourcesCommand(_main));
            control.AddLinkCommand("CustomerTasks", new CustomerTaskCommand(_main));
            control.AddLinkCommand("CustomerAppointments", new CustomerAppointmentsCommand(_main));
            control.AddLinkCommand("CustomerDocuments", new CustomerDocumentCommand(_main));
            
        }
    }
    
}