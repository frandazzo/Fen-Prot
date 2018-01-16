using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.Utility
{
    public partial class CommandBar : DevExpress.XtraEditors.XtraUserControl
    {
        //eventi sui tasti
        public event EventHandler NewCommandPressed;
        public event EventHandler UndoCommandPressed;

        public event EventHandler SaveCommandPressed;
        public event EventHandler DelCommandPressed;

        public event EventHandler PrintCommandPressed;
        public event EventHandler InfoCommandPressed;

        public event EventHandler NewSearchCommandPressed;


        public event EventHandler FindElementIdCommandPressed;
        public event EventHandler ViewElementCommandPressed;

        public CommandBar()
        {
            InitializeComponent();
            CustomGUI_SetInterfaceState(GUIState.Ricerca);

        }

        public string Custom_Identifier
        {
            get
            {
                return buttonEdit1.Text;
            }
        }

        public GUIState Custom_GetCommandBarStateFromGuiState(string guiState)
        {
            switch (guiState)
            {
                case  "Aggiornamento":
                    return GUIState.Aggiornamento ;
                case "Creazione":
                    return GUIState.Creazione;
                case "Visualizzazione":
                    return GUIState.Visualizzazione;
                case "Ricerca":
                    return GUIState.Ricerca ;
                default:
                    return GUIState.Invalid;
            }
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //bottone di ricerca
            if (e.Button.Index == 0)
            {
                StartSearch();
                ViewElement();
            }
            else //bottone per la visualizzazione
            {
                ViewElement();
            }
        }

        public void Custom_SetIdentifier(string id)
        {
            buttonEdit1.EditValue = id;
            buttonEdit1.Focus();
        }

        private void StartSearch()
        {
            if (FindElementIdCommandPressed != null)
                FindElementIdCommandPressed(this, new EventArgs());
        }

        private void ViewElement()
        {
            if (string.IsNullOrEmpty(buttonEdit1.Text))
                return;
            if (IsEditorValueCorrect())
            {
                if (ViewElementCommandPressed != null)
                    ViewElementCommandPressed(this, new EventArgs());
            }
        }

        private bool IsEditorValueCorrect()
        {
            try
            {
                //se il valore nell'editor non è un  intero esco
                int val = int.Parse(buttonEdit1.Text.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
                return false;
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (NewSearchCommandPressed != null)
                NewSearchCommandPressed(this, new EventArgs());
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            if (NewCommandPressed != null)
                NewCommandPressed(this, new EventArgs());
        }

        private void cmdUndo_Click(object sender, EventArgs e)
        {
            if (UndoCommandPressed != null)
                UndoCommandPressed(this, new EventArgs());
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (SaveCommandPressed != null)
                SaveCommandPressed(this, new EventArgs());
        }

        private void cmdDel_Click(object sender, EventArgs e)
        {
            if (DelCommandPressed != null)
                DelCommandPressed(this, new EventArgs());
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (PrintCommandPressed != null)
                PrintCommandPressed(this, new EventArgs());
        }

        private void cmdInfo_Click(object sender, EventArgs e)
        {
            if (InfoCommandPressed != null)
                InfoCommandPressed(this, new EventArgs());
        }

        private void buttonEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(buttonEdit1.Text))
                {
                    StartSearch();
                    ViewElement();
                }
                else
                    ViewElement();
            }
        }


        public void Custom_SetFocusOnEditor()
        {
            buttonEdit1.Focus();
        }

        public void Custom_SetFunctionName(string title)
        {
            commandBarMainGroup.Text = title;
        }

        public void Custom_SetEditorEnabled(bool enabled)
        {
            buttonEdit1.Enabled = enabled;
        }

        public void Custom_SetDeleteButtonEnabled(bool enabled)
        {
            cmdDel.Enabled = enabled;
        }

        public void Custom_SetNewButtonEnabled(bool enabled)
        {
            cmdNew.Enabled = enabled;
        }

        public void Custom_SetSaveButtonEnabled(bool enabled)
        {
            cmdSave.Enabled = enabled;
        }

        public void Custom_SetUndoButtonEnabled(bool enabled)
        {
            cmdUndo.Enabled = enabled;
        }

        public void Custom_SetPrintButtonEnabled(bool enabled)
        {
            cmdPrint.Enabled = enabled;
        }

        public void Custom_SetSearchButtonEnabled(bool enabled)
        {
            cmdSearch.Enabled = enabled;
        }


        public void Custom_SetInfoButtonEnabled(bool enabled)
        {
            cmdInfo.Enabled = enabled;
        }


        public void CustomGUI_SetInterfaceState(GUIState state)
        {
            switch (state)
            {
                case GUIState.Visualizzazione:
                    //questa riga di codice fixa una bug dell'image list che stramnamente
                    //non recupera più l'immagine all'indice selezionato!!!!
                    if (imageList1.Images.Count >0)
                        pictureEdit1.EditValue = imageList1.Images[14];
                    Custom_SetEditorEnabled(false);
                    Custom_SetSearchButtonEnabled(true);
                    Custom_SetNewButtonEnabled(true);
                    Custom_SetUndoButtonEnabled(false);
                    Custom_SetSaveButtonEnabled(false);
                    Custom_SetDeleteButtonEnabled(true);
                    Custom_SetPrintButtonEnabled(true);
                    Custom_SetInfoButtonEnabled(true);
                    break;
                case GUIState.Aggiornamento:
                    pictureEdit1.EditValue = imageList1.Images[13];
                    Custom_SetEditorEnabled(false);
                    Custom_SetSearchButtonEnabled(false);
                    Custom_SetNewButtonEnabled(false);
                    Custom_SetUndoButtonEnabled(true);
                    Custom_SetSaveButtonEnabled(true);
                    Custom_SetDeleteButtonEnabled(false);
                    Custom_SetPrintButtonEnabled(false);
                    Custom_SetInfoButtonEnabled(false);
                    break;
                case GUIState.Creazione:
                    pictureEdit1.EditValue = imageList1.Images[13];
                    Custom_SetEditorEnabled(false);
                    Custom_SetSearchButtonEnabled(true);
                    Custom_SetNewButtonEnabled(false);
                    Custom_SetUndoButtonEnabled(true);
                    Custom_SetSaveButtonEnabled(true);
                    Custom_SetDeleteButtonEnabled(false);
                    Custom_SetPrintButtonEnabled(false);
                    Custom_SetInfoButtonEnabled(false);
                    break;
                case GUIState.Ricerca:
                    pictureEdit1.EditValue = imageList1.Images[15];
                    Custom_SetEditorEnabled(true);
                    Custom_SetSearchButtonEnabled(true);
                    Custom_SetNewButtonEnabled(true);
                    Custom_SetUndoButtonEnabled(false);
                    Custom_SetSaveButtonEnabled(false);
                    Custom_SetDeleteButtonEnabled(false);
                    Custom_SetPrintButtonEnabled(false);
                    Custom_SetInfoButtonEnabled(false);
                    break;
                default:
                    pictureEdit1.EditValue = imageList1.Images[15];
                    Custom_SetEditorEnabled(false);
                    Custom_SetSearchButtonEnabled(true);
                    Custom_SetNewButtonEnabled(true);
                    Custom_SetUndoButtonEnabled(false);
                    Custom_SetSaveButtonEnabled(false);
                    Custom_SetDeleteButtonEnabled(false);
                    Custom_SetPrintButtonEnabled(false);
                    Custom_SetInfoButtonEnabled(false);
                    break;
            }
        }

        private void pictureEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
        }




    }


    public enum GUIState
    {
        Visualizzazione,
        Aggiornamento,
        Creazione,
        Ricerca,
        Invalid
    }
}
