using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Controls;
using WIN.SCHEDULING_APP.GUI.Commands.Specifics;

namespace WIN.SCHEDULING_APP.GUI.Commands
{
    public abstract class OpenCommand : AbstractOpenCommand
    {
        protected MainForm _main;


        public OpenCommand(MainForm renderControl)
        {
            
            _main = renderControl;
            if (_main == null)
                throw new Exception();
        }

        public override void Execute()
        {
            if (base.m_IdObjectToOpen == -1)
            {
                Open();
            }
            else
            {
                Open(base.m_IdObjectToOpen);
            }
        }

        public override void Execute(System.Collections.Hashtable WitParameter1)
        {
            int id = -1;
            try
            {
                id = (int)WitParameter1["Id"];
            }
            catch (Exception)
            {
                throw new Exception("Impossibile eseguire il comando di apertura " + ObjectToOpenName() + " poichè non esiste un identificativo.");
            }
            Open(id);
        }

        protected override void ExecuteInOtherWindow(object Window)
        {
            throw new NotImplementedException();
        }

        protected override void ExecuteInOtherWindow(object Window, System.Collections.Hashtable WithParameter1)
        {
            throw new NotImplementedException();
        }

        public override void SetCommandParameters(System.Collections.Hashtable WitParameter1)
        {
            base.m_IdObjectToOpen = int.Parse (WitParameter1["Id"].ToString ());
        }

        protected virtual string ObjectToOpenName()
        {
            return "NullObjectToOpen";
        }

        protected virtual void Open(int id)
        {
          BaseGUIControl control = CreateTargetControl(id);
          Forward(control);
        }

        protected virtual void Open()
        {
          BaseGUIControl control = CreateTargetControl();
          Forward(control);
        }

        protected BaseGUIControl CreateTargetControl()
        {
            BaseGUIControl control = DoCreateTargetControl();
            SetTargetControlReceviers(control);
            return control;
        }

        protected virtual void SetTargetControlReceviers(BaseGUIControl control)
        {
            
        }

        protected BaseGUIControl CreateTargetControl(int id)
        {
            BaseGUIControl control = DoCreateTargetControl(id);
            SetTargetControlReceviers(control);
            return control;
        }

        protected  void Forward(BaseGUIControl control)
        {
            _main.NavigatorUtility.RenderControl(control);
            //_main.NavigatorUtility.SetRenderedControlSize(control);
            control.Dock = System.Windows.Forms.DockStyle.Fill;
            control.SetFocusForSearch();
        }
  

       
        protected abstract BaseGUIControl  DoCreateTargetControl() ;
        protected abstract  BaseGUIControl DoCreateTargetControl(int id);

    }
}
