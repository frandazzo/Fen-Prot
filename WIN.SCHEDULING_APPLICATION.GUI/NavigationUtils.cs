using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APP.GUI.Controls;
using System.Windows.Forms;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Commands;
using WIN.GUI.UTILITY;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraEditors;
using WIN.SECURITY.Exceptions;
using System.Collections;

namespace WIN.SCHEDULING_APP.GUI
{
    internal class NavigationUtils
    {
        private BaseGUIControl _current;
        private DevExpress.XtraEditors.SplitGroupPanel _container;
        private MainForm _main;


        internal BaseGUIControl Current
        {
            get
            {
                return _current;
            }
        }

        internal NavigationUtils(DevExpress.XtraEditors.SplitGroupPanel container, MainForm main)
        {
            _main= main;
            _container = container;
        }

        /// <summary>
        /// Renders the control on the current container
        /// </summary>
        /// <param name="control"></param>
        internal void RenderControl(BaseGUIControl control)
        {
            if (_container.Controls.Count > 0)
            {
                _container.Controls[0].Dispose();
                _container.Controls.Clear();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            _container.Controls.Add(control);
            _current = control;
        }

        /// <summary>
        /// Check if is possible to cheange the UI state
        /// </summary>
        /// <returns></returns>
        internal bool CheckBeforeNavigate()
        {
            if (_current.State.StateName == "Aggiornamento" || _current.State.StateName == "Creazione")
            {
                DialogResult i = XtraMessageBox.Show("Si desidera salvare i dati?", Properties.Settings.Default.Main_AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (i == DialogResult.Yes)
                {
                    _current.StartSaveOperation();
                }
                else if (i == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if it is possible to exit the application
        /// </summary>
        /// <returns></returns>
        internal DialogResult CheckBeforeExit()
        {
            DialogResult i = DialogResult.Cancel;
            if (_current.State.StateName == "Aggiornamento" || _current.State.StateName == "Creazione")
            {
                i = MessageBox.Show("Si desidera salvare i dati prima di uscire dall'applicazione?", Properties.Settings.Default.Main_AppName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (i == DialogResult.Yes)
                {
                    _current.StartSaveOperation();
                }
            }
            return i;
        }

        ///// <summary>
        ///// Sets the current control docking style
        ///// </summary>
        ///// <param name="control"></param>
        //internal void SetRenderedControlSize(BaseGUIControl control)
        //{
        //   control.Dock = DockStyle.Fill;
        //}

        internal void NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType type)
        {
            try
            {
                if (CheckBeforeNavigate())
                {
                    IOpenCommand cmd = OpenCommandFactory.GetCommand(type, _main);
                    cmd.Execute();
                    HistoryOfCommands.Instance().AddCommandToHistory(cmd);
                }
                MemoryHelper.ReduceMemory();
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
                

            }
            
        }


        internal void NavigateToControl(WIN.SCHEDULING_APP.GUI.Commands.CommandType type , int id)
        {
            try
            {
                if (CheckBeforeNavigate())
                {
                    IOpenCommand cmd = OpenCommandFactory.GetCommand(type, _main);
                    Hashtable g = new Hashtable();
                    g.Add("Id", id);
                    cmd.Execute(g);
                    HistoryOfCommands.Instance().AddCommandToHistory(cmd);
                }
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);


            }

        }

        /// <summary>
        /// Executes the previous Open command
        /// </summary>
        internal void NavigateToPrevious()
        {
            try
            {
                if (CheckBeforeNavigate())
                {
                    HistoryOfCommands.Instance().GoBack();
                    IOpenCommand command = HistoryOfCommands.Instance().GetCurrentCommand();
                    command.Execute();
                }
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        internal void NavigateToNext()
        {
            try
            {
                if (CheckBeforeNavigate())
                {
                    if (!HistoryOfCommands.Instance().MaxReached)
                    {
                        HistoryOfCommands.Instance().GoNext();
                        IOpenCommand command = HistoryOfCommands.Instance().GetCurrentCommand();
                        command.Execute();
                    }
                }
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        internal void NavigateToStartupControl(string command)
        {
            try
            {
                IOpenCommand cmd = OpenCommandFactory.GetCommand(command, _main );
                if (cmd == null)
                {
                    cmd = OpenCommandFactory.GetCommand(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Home, _main );
                }
                cmd.Execute();
                HistoryOfCommands.Instance().AddCommandToHistory(cmd);
               
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                IOpenCommand cmd = OpenCommandFactory.GetCommand(WIN.SCHEDULING_APP.GUI.Commands.CommandType.Home, _main);
                cmd.Execute();
                HistoryOfCommands.Instance().AddCommandToHistory(cmd);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }



    }
}
