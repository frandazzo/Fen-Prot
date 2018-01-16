using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.BASEREUSE;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    public partial class TaskSimpleSearch : DevExpress.XtraEditors.XtraUserControl, ISearchDTOCreator
    {
        public TaskSimpleSearch()
        {
            InitializeComponent();
            dtpAlla.DateTime = DateTime.Now;
        }

        #region ISearchDTOCreator Membri di

        public WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.IsearchDTO CreateDTO()
        {
            DateTime a =  DateTime.MinValue;
            if (dtpAlla.EditValue != null)
                a = dtpAlla.DateTime;

            string subject = txtSub.Text;
            if (!string.IsNullOrEmpty(subject))
            {
                if (Properties.Settings.Default.Main_InsertJolly)
                {
                    //seleziono il carattere jolly in dipendenza dal tipo di DB
                    if (DataAccessServices.Instance().PersistenceFacade.DBType == DB.DBType.Access)
                        subject = "%" + subject;
                    else
                        subject = "%" + subject;
                }
            }
            return new SimpleTaskSearch(subject, cboPriority.Text, CalculateDataRange(), chk0.Checked, chk1.Checked, chk2.Checked, chk3.Checked, chk4.Checked, chkDeadTasks.Checked, a);
        }

        private WIN.BASEREUSE.DataRange CalculateDataRange()
        {
            if (!chk2.Checked)
                return DataRange.Empty();


            if (dtpDa.EditValue == null && dtpA.EditValue == null)
                return DataRange.Empty();
            else if (dtpDa.EditValue != null && dtpA.EditValue == null)
                return DataRange.CreateOpen(dtpDa.DateTime);
            else if (dtpDa.EditValue == null && dtpA.EditValue != null)
                return (DataRange)DataRange.CreateOpenEnded(dtpA.DateTime);
            else
                return new DataRange(dtpDa.DateTime, dtpA.DateTime);





        }

        #endregion

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk2.Checked)
            {
                dtpDa.Enabled = true;
                dtpA.Enabled = true;
            }
            else
            {
                dtpDa.Enabled = false;
                dtpA.Enabled = false;
            }

            if (chk2.Checked)
                chk2.Font = new Font(chk2.Font, FontStyle.Bold);
            else
                chk2.Font = new Font(chk2.Font, FontStyle.Regular);
        }

        private void chk0_CheckedChanged(object sender, EventArgs e)
        {
            if (chk0.Checked)
                chk0.Font = new Font(chk0.Font, FontStyle.Bold);
            else
                chk0.Font = new Font(chk0.Font, FontStyle.Regular);
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked)
                chk1.Font = new Font(chk1.Font, FontStyle.Bold);
            else
                chk1.Font = new Font(chk1.Font, FontStyle.Regular);
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk3.Checked)
                chk3.Font = new Font(chk3.Font, FontStyle.Bold);
            else
                chk3.Font = new Font(chk3.Font, FontStyle.Regular);
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk4.Checked)
                chk4.Font = new Font(chk4.Font, FontStyle.Bold);
            else
                chk4.Font = new Font(chk4.Font, FontStyle.Regular);
        }

        private void chkDeadTasks_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeadTasks.Checked)
            {
                dtpAlla.Enabled = true;
                dtpAlla.EditValue = DateTime.Now;

                //disabilito gli altri controlli
                chk0.Enabled = false;
                chk0.Checked = true;
                chk1.Enabled = false;
                chk1.Checked = true;
                chk2.Enabled = false;
                chk2.Checked = false;
                chk3.Enabled = false;
                chk3.Checked = true;
                chk4.Enabled = false;
                chk4.Checked = true;

                dtpA.Enabled = false;
                dtpDa.Enabled = false;
            }
            else
            {
                dtpAlla.Enabled = false;
                

                //abiliot gli altri controlli
                chk0.Enabled = true;
                chk0.Checked = true;
                chk1.Enabled = true;
                chk1.Checked = true;
                chk2.Enabled = true;
                chk2.Checked = false;
                chk3.Enabled = true;
                chk3.Checked = true;
                chk4.Enabled = true;
                chk4.Checked = true;

                dtpA.Enabled = false;
                dtpDa.Enabled = false;
            }

        }

  
    }
}
