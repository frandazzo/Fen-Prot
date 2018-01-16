using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FormOpzioni : DevExpress.XtraEditors.XtraForm
    {
        public FormOpzioni()
        {
            InitializeComponent();
            LoadSettings();
            
        }

        private void LoadSettings()
        {
            LoadCommandTypes();
            txtProv.EditValue = Properties.Settings.Default.Main_Province;
            txtCom.EditValue = Properties.Settings.Default.Main_Comune;
            txtNaz.Text = Properties.Settings.Default.Main_Nazione;
            comboBoxEdit1.EditValue = Properties.Settings.Default.Main_Calendar_ViewType;
            txtSubject.EditValue = Properties.Settings.Default.Main_CalendarSubject ;
            chkTaskDetails.Checked = Properties.Settings.Default.Main_ViewTaskDetails;

            chkAskMarkComplete.Checked = Properties.Settings.Default.Main_AskIfActivityMustbeMarkedAsCompleted;
            chkMarkComplete.Checked = Properties.Settings.Default.Main_MarkActivityCompletedafterDragDrop;
            chkFillLocation.Checked = Properties.Settings.Default.Main_FillAppointmentLocationWithCustomerAddress ;
            chkAskRenew.Checked = Properties.Settings.Default.Main_AskIfRenewActivityAfterDragDrop;
            chkRenewTask.Checked = Properties.Settings.Default.Main_RenewActivityAfterDragDrop;

            txtSubTask.EditValue = Properties.Settings.Default.Main_TaskSubject;
            spinEdit2.EditValue = Properties.Settings.Default.Main_DaysOfRenewTask;
            


            chkAnt.Checked = Properties.Settings.Default.Main_PreviewDocument;
            txtDocSub.Text = Properties.Settings.Default.Main_DocumentDefaultSubject;
            chkStartSearch.Checked = Properties.Settings.Default.Main_StartInitialSearch;
            chkJolly.Checked = Properties.Settings.Default.Main_InsertJolly;

            chkPanelColapsed.Checked = Properties.Settings.Default.Main_PanelCollapsed;
            chkTaskPanel.Checked = Properties.Settings.Default.Main_ActivateTaskPanelOnCalendar;
            try
            {
                //proteggo dall'errore di un valore fuori dal range
                spMax.EditValue = Properties.Settings.Default.Main_MaxResult;
                spinEdit1.EditValue = Properties.Settings.Default.Main_DeadlineDaysBefore;
            }
            catch (Exception)
            {
                spMax.EditValue = 100;
            }
            cboPage.EditValue = Properties.Settings.Default.Main_StartCommand ;
            
        }

        private void LoadCommandTypes()
        {
            //recupero la lista
            string[] list = Enum.GetNames(typeof(WIN.SCHEDULING_APP.GUI.Commands.CommandType));
           
            // azzero la combo
            cboPage.Properties.Items.Clear();
            //ordino
            cboPage.Properties.Sorted = true;


            //rimuovo alcuni comandi che non voglio siano optabili
            ArrayList l = new ArrayList();
            foreach (string item in list)
            {
                if (item != "Labels" && item != "Outcomes" && item != "Resources" && item != "Operators" && item != "Contacts" && item != "DocumentTypes" && item != "DocumentScopes")
                    l.Add(item);
            }

            //aggiungo tutti gli elementi
            cboPage.Properties.Items.AddRange(l);

            //Seleziono il primo elemento
            cboPage.SelectedIndex = 0;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSettings();
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
          
        }

        private void UpdateSettings()
        {
            Properties.Settings.Default.Main_Province=txtProv.Text;
            Properties.Settings.Default.Main_Comune = txtCom.Text;
            Properties.Settings.Default.Main_MaxResult = (int)spMax.Value;
            Properties.Settings.Default.Main_StartCommand = cboPage.Text;
            Properties.Settings.Default.Main_DeadlineDaysBefore = Convert.ToInt32( spinEdit1.Value);
            Properties.Settings.Default.Main_Calendar_ViewType = comboBoxEdit1.EditValue.ToString ();
            Properties.Settings.Default.Main_CalendarSubject = txtSubject.EditValue.ToString();
            Properties.Settings.Default.Main_ViewTaskDetails = chkTaskDetails.Checked;

            Properties.Settings.Default.Main_Nazione = txtNaz.Text;

            Properties.Settings.Default.Main_AskIfActivityMustbeMarkedAsCompleted = chkAskMarkComplete.Checked;
            Properties.Settings.Default.Main_MarkActivityCompletedafterDragDrop= chkMarkComplete.Checked;

            Properties.Settings.Default.Main_AskIfRenewActivityAfterDragDrop = chkAskRenew.Checked;
            Properties.Settings.Default.Main_RenewActivityAfterDragDrop = chkRenewTask.Checked;

            Properties.Settings.Default.Main_TaskSubject = txtSubTask.Text;
            Properties.Settings.Default.Main_DaysOfRenewTask = Convert.ToInt32(spinEdit2.Value);

            Properties.Settings.Default.Main_FillAppointmentLocationWithCustomerAddress = chkFillLocation.Checked;
            Properties.Settings.Default.Main_ActivateTaskPanelOnCalendar = chkTaskPanel.Checked;

            Properties.Settings.Default.Main_PreviewDocument = chkAnt.Checked;
            Properties.Settings.Default.Main_DocumentDefaultSubject = txtDocSub.Text;
            Properties.Settings.Default.Main_StartInitialSearch = chkStartSearch.Checked;
            Properties.Settings.Default.Main_InsertJolly = chkJolly.Checked;

            Properties.Settings.Default.Main_PanelCollapsed = chkPanelColapsed.Checked;
        }

        private void chkMarkComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMarkComplete.Checked)
            {
                chkAskMarkComplete.Enabled = true;
            }
            else
            {
                chkAskMarkComplete.Enabled = false;
                chkAskMarkComplete.Checked = false;
            }
        }

        private void chkRenewTask_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRenewTask.Checked)
            {
                chkAskRenew.Enabled = true;
            }
            else
            {
                chkAskRenew.Enabled = false;
                chkAskRenew.Checked = false;
            }
        }
    }
}