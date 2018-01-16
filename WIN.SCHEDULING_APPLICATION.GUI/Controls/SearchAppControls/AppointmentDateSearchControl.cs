using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    public partial class AppointmentDateSearchControl : DevExpress.XtraEditors.XtraUserControl, ISearchDTOCreator
    {

        public enum ReportParameterType
        {
            Appointments,
            Activities
        }

        private ReportParameterType _reportType = ReportParameterType.Appointments;
        private bool m_isLoading;
        private WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Oggi;

        private bool _startWithNoCriteria;

        public AppointmentDateSearchControl()
        {
            InitializeComponent();
        }

        public ReportParameterType ReportType
        {
            get { return _reportType; }
            set { _reportType = value; }
        }


        private void AppointmentDateSearchControl_Load(object sender, EventArgs e)
        {
            m_isLoading = true;

            if (_reportType == ReportParameterType.Appointments)
                InitializeAppointmentsParameters();
            else
                InitializeActivitiessParameters();

            m_isLoading = false;


        }

        private void InitializeAppointmentsParameters()
        {
            if (DateSearchParametersRuntimePersister.Initialized)
            {
                DateSearchParametersRuntimePersister.SetPersistedParameters(this);
            }
            else
            {
                checkEdit0.Checked = true;
                dateTimePicker1.EditValue = dateTimePicker2.EditValue = DateTime.Now;

                if (StartWithNoCriteria)
                {
                    chkAll.Checked = true;
                    CheckNoCriteria();
                }
            }
            DateSearchParametersRuntimePersister.Initialized = true;
        }
        private void InitializeActivitiessParameters()
        {
            if (ActivityDateSearchParametersRuntimePersister.Initialized)
            {
                ActivityDateSearchParametersRuntimePersister.SetPersistedParameters(this);
            }
            else
            {
                checkEdit0.Checked = true;
                dateTimePicker1.EditValue = dateTimePicker2.EditValue = DateTime.Now;

                if (StartWithNoCriteria)
                {
                    chkAll.Checked = true;
                    CheckNoCriteria();
                }
            }
            ActivityDateSearchParametersRuntimePersister.Initialized = true;
        }



        #region ISearchDTOCreator Membri di

        public WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.IsearchDTO CreateDTO()
        {
            return new PeriodAppointmentDTO(_state, new WIN.BASEREUSE.DataRange(dateTimePicker1.DateTime.Date,dateTimePicker2.DateTime.Date), chkOverlaped.Checked,  chkAll.Checked);
        }

        #endregion

        private void dateTimePicker1_EditValueChanged(object sender, EventArgs e)
        {
            if (!m_isLoading)
            {
                if (dateTimePicker1.DateTime.Date > dateTimePicker2.DateTime.Date)
                {
                    m_isLoading = true;
                    dateTimePicker2.EditValue = dateTimePicker1.DateTime.Date;

                    if (_reportType == ReportParameterType.Appointments)
                        DateSearchParametersRuntimePersister.End = dateTimePicker2.DateTime;
                    else
                        ActivityDateSearchParametersRuntimePersister.End = dateTimePicker2.DateTime;
                    m_isLoading = false;
                }
                if (_reportType == ReportParameterType.Appointments)
                    DateSearchParametersRuntimePersister.Start = dateTimePicker1.DateTime;
                else
                    ActivityDateSearchParametersRuntimePersister.Start = dateTimePicker1.DateTime;
            }
        }

        private void dateTimePicker2_EditValueChanged(object sender, EventArgs e)
        {
            if (!m_isLoading)
            {
                if (dateTimePicker1.DateTime.Date > dateTimePicker2.DateTime.Date)
                {
                    m_isLoading = true;
                    dateTimePicker2.EditValue = dateTimePicker1.DateTime.Date;
                    m_isLoading = false;
                }
                if (_reportType == ReportParameterType.Appointments)
                    DateSearchParametersRuntimePersister.End = dateTimePicker2.DateTime;
                else
                    ActivityDateSearchParametersRuntimePersister.End = dateTimePicker2.DateTime;
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckControlStatus(sender);



        }

        private void CheckControlStatus(object sender)
        {
            CheckEdit rb = sender as CheckEdit;
            rb.Font = new Font(rb.Font, rb.Checked ? FontStyle.Bold : FontStyle.Regular);
            bool isSpecifyDates = rb == checkEdit12 && rb.Checked;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = isSpecifyDates;

            if (rb == checkEdit0 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Oggi;
            else if (rb == checkEdit1 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Domani;
            else if (rb == checkEdit2 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossima_Settimana;
            else if (rb == checkEdit3 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossime_Due_Settimane;
            else if (rb == checkEdit4 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossimo_Mese;
            else if (rb == checkEdit5 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossimi_Tre_Mesi;
            else if (rb == checkEdit6 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossimi_Sei_Mesi;
            else if (rb == checkEdit7 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultima_Settimana;
            else if (rb == checkEdit8 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultime_Due_Settimane;
            else if (rb == checkEdit9 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultimo_Mese;
            else if (rb == checkEdit10 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultimi_Tre_Mesi;
            else if (rb == checkEdit11 && rb.Checked)
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultimi_Sei_Mesi;
            else
                _state = WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Periodo;

            if (_reportType == ReportParameterType.Appointments)
                DateSearchParametersRuntimePersister.Status = _state;
            else
                ActivityDateSearchParametersRuntimePersister.Status = _state;
        }


        internal WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum AssignedState
        {
            get { return _state; }
        }

        internal void AssignDate(DateTime start, DateTime end)
        {
            dateTimePicker1.EditValue = start;
            dateTimePicker2.EditValue = end;
        }

        internal DateTime AssignedDateEnd
        {
            get { return dateTimePicker2.DateTime; }
        }

        internal DateTime AssignedDateStart
        {
            get { return dateTimePicker1.DateTime; }
        }

        internal bool AssignNoSelectedPeriod
        {
            get
            {
                return chkAll.Checked;
            }
            set
            {
                chkAll.Checked = value;
            }
        }

        internal bool AssignOverlappedSelected
        {
            get
            {
                return chkOverlaped.Checked;
            }
            set
            {
                chkOverlaped.Checked = value;
            }
        }

        internal void AssignCheckFromStatus(WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.PeriodAppointmentDTO.PeriodAppointmentDTOEnum state)
        {

            switch (state)
            {
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossimi_Sei_Mesi:
                    checkEdit6.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossimi_Tre_Mesi:
                    checkEdit5.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossimo_Mese:
                    checkEdit4.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossime_Due_Settimane:
                    checkEdit3.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Prossima_Settimana:
                    checkEdit2.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Domani:
                    checkEdit1.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Oggi:
                    checkEdit0.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultima_Settimana:
                    checkEdit7.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultime_Due_Settimane:
                    checkEdit8.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultimo_Mese:
                    checkEdit9.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultimi_Tre_Mesi:
                    checkEdit10.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Ultimi_Sei_Mesi:
                    checkEdit11.Checked = true;
                    break;
                case PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Periodo:
                    checkEdit12.Checked = true;
                    break;
                default:
                    checkEdit0.Checked = true;
                    break;
            }
        }



        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
           CheckNoCriteria();
           if (_reportType == ReportParameterType.Appointments)
                DateSearchParametersRuntimePersister.NoSelectedPeriod = chkAll.Checked;
           else
               ActivityDateSearchParametersRuntimePersister.NoSelectedPeriod = chkAll.Checked;
        }

        private void CheckNoCriteria()
        {
            if (chkAll.Checked)
            {
                chkOverlaped.Enabled = false;
                checkEdit0.Enabled = false;
                checkEdit1.Enabled = false;
                checkEdit2.Enabled = false;
                checkEdit3.Enabled = false;
                checkEdit4.Enabled = false;
                checkEdit5.Enabled = false;
                checkEdit6.Enabled = false;
                checkEdit7.Enabled = false;
                checkEdit8.Enabled = false;
                checkEdit9.Enabled = false;
                checkEdit10.Enabled = false;
                checkEdit11.Enabled = false;
                checkEdit11.Enabled = false;
                checkEdit12.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                chkOverlaped.Enabled = true;
                checkEdit0.Enabled = true;
                checkEdit1.Enabled = true;
                checkEdit2.Enabled = true;
                checkEdit3.Enabled = true;
                checkEdit4.Enabled = true;
                checkEdit5.Enabled = true;
                checkEdit6.Enabled = true;
                checkEdit7.Enabled = true;
                checkEdit8.Enabled = true;
                checkEdit9.Enabled = true;
                checkEdit10.Enabled = true;
                checkEdit11.Enabled = true;
                checkEdit11.Enabled = true;
                checkEdit12.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;


                if (!checkEdit12.Checked)
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                }
            }
        }
        public bool StartWithNoCriteria
        {
            get
            {
                return _startWithNoCriteria;
            }
            set
            {
                _startWithNoCriteria = value;
            }
        }

        private void chkOverlaped_CheckedChanged(object sender, EventArgs e)
        {
            if (_reportType == ReportParameterType.Appointments)
                DateSearchParametersRuntimePersister.OverlappedSelected = chkOverlaped.Checked;
            else
                ActivityDateSearchParametersRuntimePersister.OverlappedSelected = chkOverlaped.Checked;
        }
    }
}
