using System;
using System.Collections.Generic;
using System.Text;
using WIN.SECURITY.Attributes;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SECURITY;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{

    [SecureContext()]
    public class AdministrationCommand: OpenCommand
    {
        public AdministrationCommand(MainForm form)
            : base(form)
        {

        }

         protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
        {
            return new AdministrationControl(_main);
        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
        {
            return new AdministrationControl(_main);
        }

        protected override string ObjectToOpenName()
        {
            return "Amministrazione territoriale Feneal";
        }



        public override void Execute(System.Collections.Hashtable WitParameter1)
        {
            //int id;
            //try 
            //{	        
            //    id = int.Parse (WitParameter1["Id"].ToString ());
            //}
            //catch (Exception)
            //{
            //    throw new Exception ("Impossibile eseguire il comando di apertura: " + ObjectToOpenName() + "; Id inesistente");
            //}
            //Open(id);
            Open();
        }

        [Secure(Area = "Amministrazione", Alias = "Amministrazione", MacroArea = "Applicativo")]
        protected override void SetTargetControlReceviers(BaseGUIControl control)
        {
            SecurityManager.Instance.Check();
            control.AddLinkCommand("AppointmentCalendar", new AdministrationCommand(_main));
            
        }
    }

}
