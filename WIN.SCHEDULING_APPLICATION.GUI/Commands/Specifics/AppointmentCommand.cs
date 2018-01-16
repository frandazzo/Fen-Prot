using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SECURITY.Exceptions;

namespace WIN.SCHEDULING_APP.GUI.Commands.Specifics
{
    //[SecureContext()]
    //public class AppointmentCommand : OpenCommand
    //{
    //    Customer _current = null;
    //    public AppointmentCommand(MainForm form)
    //        : base(form)
    //    {

    //    }

    //     protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
    //    {
    //        return new AppuntamentoControl(_main,_current  );
    //    }



    //    protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
    //    {
    //        return new AppuntamentoControl(id, _main);
    //    }

    //    protected override string ObjectToOpenName()
    //    {
    //        return "Appointment";
    //    }



    //    public override void Execute(System.Collections.Hashtable WitParameter1)
    //    {
    //        int id;
    //        try
    //        {
    //            id = int.Parse(WitParameter1["Id"].ToString());



    //            _current = WitParameter1["Customer"] as Customer;
    //            MyAppointment app = WitParameter1["Appointment"] as MyAppointment;

    //            if (_current != null)
    //            {
    //                Open();
    //                return;
    //            }
    //            if (app != null)
    //            {
    //                Open(id);
    //                return;
    //            }

    //            Open(id);
    //        }
    //        catch (AccessDeniedException)
    //        {
    //            throw;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("Impossibile eseguire il comando di apertura: " + ObjectToOpenName() + ";" + ex.Message);
    //        }
           
    //    }

    

    //    [Secure(Area = "Appuntamenti", Alias = "Visualizza", MacroArea = "Applicativo")]
    //    protected override void SetTargetControlReceviers(BaseGUIControl control)
    //    {
    //        SecurityManager.Instance.Check();
    //        control.AddLinkCommand("Customers", new CustomerCommand(_main));
    //        control.AddLinkCommand("Resources", new ResourcesCommand(_main));
    //        control.AddLinkCommand("Labels", new LabelsCommand(_main));
    //        control.AddLinkCommand("Operators", new OperatorCommand(_main));
    //        control.AddLinkCommand("Appointments", new AppointmentCommand(_main));
            
    //    }
    //}

}
