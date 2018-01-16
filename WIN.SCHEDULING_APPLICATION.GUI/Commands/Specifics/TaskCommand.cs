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
    //public class TaskCommand: OpenCommand
    //{
    //    Customer _current = null;
    //    public TaskCommand(MainForm form)
    //        : base(form)
    //    {

    //    }

    //     protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl()
    //    {
    //        return new TaskControl(_main,_current  );
    //    }



    //    protected override WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl DoCreateTargetControl(int id)
    //    {
    //        return new TaskControl(id, _main);
    //    }

    //    protected override string ObjectToOpenName()
    //    {
    //        return "Task";
    //    }



    //    public override void Execute(System.Collections.Hashtable WitParameter1)
    //    {
    //        int id;
    //        try
    //        {
    //            id = int.Parse(WitParameter1["Id"].ToString());



    //            _current = WitParameter1["Customer"] as Customer;
    //            MyTask app = WitParameter1["Task"] as MyTask;

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

    

    //    [Secure(Area = "Attività", Alias = "Visualizza", MacroArea = "Applicativo")]
    //    protected override void SetTargetControlReceviers(BaseGUIControl control)
    //    {
    //        SecurityManager.Instance.Check();
    //        control.AddLinkCommand("Customers", new CustomerCommand(_main));
    //        control.AddLinkCommand("Resources", new ResourcesCommand(_main));
    //        control.AddLinkCommand("Labels", new LabelsCommand(_main));
    //        control.AddLinkCommand("Operators", new OperatorCommand(_main));
    //        control.AddLinkCommand("Tasks", new TaskCommand(_main));
            
    //    }
    //}

}
