using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SECURITY;
using WIN.SECURITY.Attributes;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{
    [SecureContext()]
    public class CustomerTaskCommand: OpenCommand
    {
        private Customer _current;

        public CustomerTaskCommand(MainForm form)
            : base(form)
        {

        }

         protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
        {
            return new TaskClienteControl(_main );
        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
        {
            return new TaskClienteControl(_current, _main);
        }

        protected override string ObjectToOpenName()
        {
            return "CustomerTaskList";
        }



        public override void Execute(System.Collections.Hashtable WitParameter1)
        {
            
            try 
	        {	        
        		_current = WitParameter1["Customer"] as Customer;
              
	        }
	        catch (Exception)
	        {
		        throw new Exception ("Impossibile eseguire il comando di apertura: " + ObjectToOpenName() + "; Id inesistente");
	        }
            Open(1);
        }

        [Secure(Area = "Contatti", Alias = "Visualizza lista attività contatto", MacroArea = "Applicativo")]
        protected override void SetTargetControlReceviers(BaseGUIControl control)
        {
            SecurityManager.Instance.Check();
            control.AddLinkCommand("Customers", new CustomerCommand(_main));
            //control.AddLinkCommand("Tasks", new TaskCommand(_main));
           
            
        }
    }

}
