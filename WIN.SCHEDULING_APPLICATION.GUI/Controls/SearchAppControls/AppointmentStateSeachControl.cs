using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    public partial class AppointmentStateSeachControl : DevExpress.XtraEditors.XtraUserControl, ISearchDTOCreator
    {

        private WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.StateAppointmentDTO.StateAppointmentDTOEnum _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.StateAppointmentDTO.StateAppointmentDTOEnum.Tutti;


        public AppointmentStateSeachControl()
        {
            InitializeComponent();
        }

 

        private void LoadListaEsiti()
        {
            lstApp.Items.Clear();

            OutcomeHandler h = new OutcomeHandler();

            foreach (Outcome item in h.GetAll())
	        {
                lstApp.Items.Add(item);
	        }
            

        }




        #region ISearchDTOCreator Membri di

        public WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.IsearchDTO CreateDTO()
        {
            //return new StateAppointmentDTO(_state, new WIN.BASEREUSE.DataRange(dateTimePicker1.DateTime,dateTimePicker2.DateTime));
            return new StateAppointmentDTO(_state, chkClosed.Checked, GetSelectedOutcomes());
        }

        private IList<Outcome> GetSelectedOutcomes()
        {
            IList<Outcome> l = new List<Outcome>();

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem  item in lstApp.CheckedItems)
            {
                l.Add(item.Value as Outcome );
            }

            return l;
        }

        #endregion

     
        private void checkEdit0_CheckedChanged(object sender, EventArgs e)
        {
            CheckControlStatus(sender);
        }

        private void CheckControlStatus(object sender)
        {
            CheckEdit rb = sender as CheckEdit;
            rb.Font = new Font(rb.Font, rb.Checked ? FontStyle.Bold : FontStyle.Regular);
            bool isEnabled = rb == checkEdit2 && rb.Checked;
            chkClosed.Enabled = lstApp.Enabled = isEnabled;

            if (rb == checkEdit0 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.StateAppointmentDTO.StateAppointmentDTOEnum.Tutti;
            else if (rb == checkEdit1 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.StateAppointmentDTO.StateAppointmentDTOEnum.Non_Eseguiti;
            else
                _state = StateAppointmentDTO.StateAppointmentDTOEnum.Eseguiti;


           
        }

        private void AppointmentStateSeachControl_Load(object sender, EventArgs e)
        {
            checkEdit0.Checked = true;
            lstApp.SortOrder = SortOrder.Ascending;
            LoadListaEsiti();
        }

        private void lstApp_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstApp.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }

        private void chkClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClosed.Checked)
                chkClosed.Font = new Font(chkClosed.Font, FontStyle.Bold);
            else
                chkClosed.Font = new Font(chkClosed.Font, FontStyle.Regular);
        }
    }
}
