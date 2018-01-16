using System;
using System.Collections.Generic;
using System.Text;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APP.GUI.Controls;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{

   [SecureContext()]
    public class BookingReportCommand: OpenCommand
    {
       public BookingReportCommand(MainForm form)
            : base(form)
        {

        }

         protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
        {
            return new BookingPaymentStatsControl(_main);
        }

        protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
        {
            return new BookingPaymentStatsControl(_main);
        }

        protected override string ObjectToOpenName()
        {
            return "Report Prenotazioni";
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

        [Secure(Area = "Statistiche", Alias = "Prenotazioni", MacroArea = "Applicativo")]
        protected override void SetTargetControlReceviers(BaseGUIControl control)
        {
            SecurityManager.Instance.Check();
            //control.AddLinkCommand("AppointmentCalendar", new CalendarCommand(_main));
            
        }
    }

}
