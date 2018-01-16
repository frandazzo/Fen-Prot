using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;

namespace WIN.SCHEDULING_APP.GUI.Controls.CustomAppointmentFormAssets
{
    public class ControllerForm : AppointmentFormController
    {
        public DateTime CustomOutcomeDate
        {
            get
            {
                return (DateTime)EditedAppointmentCopy.CustomFields["OutcomeDate"];
            }
            set
            {
                EditedAppointmentCopy.CustomFields["OutcomeDate"] = value;
            }
        }


        public string CustomOutcomeDescription
        {
            get
            {
                return EditedAppointmentCopy.CustomFields["OutcomeDescription"] as string;
            }
            set
            {
                EditedAppointmentCopy.CustomFields["OutcomeDescription"] = value;
            }
        }

        public bool CustomOutcomeCreated
        {
            get
            {
                return Convert.ToBoolean(EditedAppointmentCopy.CustomFields["OutcomeCreated"]);
            }
            set
            {
                EditedAppointmentCopy.CustomFields["OutcomeCreated"] = value;
            }
        }

        public bool CustomIsClosed
        {
            get
            {
                return Convert.ToBoolean(EditedAppointmentCopy.CustomFields["IsClosed"]);
            }
            set
            {
                EditedAppointmentCopy.CustomFields["IsClosed"] = value;
            }
        }



        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Outcome CustomOutcome
        {
            get
            {
                return EditedAppointmentCopy.CustomFields["Outcome"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Outcome;
            }
            set
            {
                EditedAppointmentCopy.CustomFields["Outcome"] = value;
            }
        }

        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource CustomResource
        {
            get
            {
                return EditedAppointmentCopy.CustomFields["Resource"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource ;
            }
            set
            {
                EditedAppointmentCopy.CustomFields["Resource"] = value;
            }
        }


        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator CustomOperator
        {
            get
            {
                return EditedAppointmentCopy.CustomFields["Operator"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator;
            }
            set
            {
                EditedAppointmentCopy.CustomFields["Operator"] = value;
            }
        }



        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label CustomLabel
        {
            get
            {
                return EditedAppointmentCopy.CustomFields["Label"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements .Label ;
               
            }
            set
            {
                EditedAppointmentCopy.CustomFields["Label"] = value;
            }
        }


        public WIN.SCHEDULING_APPLICATION.DOMAIN.Customer CustomCustomer
        {
            get
            {
                return EditedAppointmentCopy.CustomFields["Customer"] as WIN.SCHEDULING_APPLICATION.DOMAIN.Customer;

            }
            set
            {
                EditedAppointmentCopy.CustomFields["Customer"] = value;
            }
        }

        //***********************************************************************

        public string SourceCustomOutcomeDescription
        {
            get
            {
                return SourceAppointment.CustomFields["OutcomeDescription"] as string;
            }
            set
            {
                SourceAppointment.CustomFields["OutcomeDescription"] = value;
            }
        }



        public DateTime SourceCustomOutcomeDate
        {
            get
            {
                return (DateTime)SourceAppointment.CustomFields["OutcomeDate"];
            }
            set
            {
                SourceAppointment.CustomFields["OutcomeDate"] = value;
            }
        }


        public bool SourceCustomIsClosed
        {
            get
            {
                return Convert.ToBoolean(SourceAppointment.CustomFields["IsClosed"]);
            }
            set
            {
                SourceAppointment.CustomFields["IsClosed"] = value;
            }
        }



        public bool SourceCustomOutcomeCreated
        {
            get
            {
                return Convert.ToBoolean(SourceAppointment.CustomFields["OutcomeCreated"]);
            }
            set
            {
                SourceAppointment.CustomFields["OutcomeCreated"] = value;
            }
        }



        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Outcome SourceCustomOutcome
        {
            get
            {
                return SourceAppointment.CustomFields["Outcome"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Outcome;
            }
            set
            {
                SourceAppointment.CustomFields["Outcome"] = value;
            }
        }





        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource SourceCustomResource
        {
            get
            {
                return SourceAppointment.CustomFields["Resource"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
            }
            set
            {
                SourceAppointment.CustomFields["Resource"] = value;
            }
        }

        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator SourceCustomOperator
        {
            get
            {
                return SourceAppointment.CustomFields["Operator"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Operator;
            }
            set
            {
                SourceAppointment.CustomFields["Operator"] = value;
            }
        }

        public WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label SourceCustomLabel
        {
            get
            {
                return SourceAppointment.CustomFields["Label"] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;
            }
            set
            {
                SourceAppointment.CustomFields["Label"] = value;
            }
        }

        public WIN.SCHEDULING_APPLICATION.DOMAIN.Customer SourceCustomCustomer
        {
            get
            {
                return SourceAppointment.CustomFields["Customer"] as WIN.SCHEDULING_APPLICATION.DOMAIN.Customer;
            }
            set
            {
                SourceAppointment.CustomFields["Customer"] = value;
            }
        }

        //************************************************************************************

        public ControllerForm(SchedulerControl control, DevExpress.XtraScheduler.Appointment apt)
            : base(control, apt)
        {
        }

        public override bool IsAppointmentChanged()
        {
            if (base.IsAppointmentChanged())
                return true;
            //return SourceCustomName != CustomName ||
            //    SourceCustomNameId != CustomNameId || SourceCustomDate != CustomDate;
            return true;
        }

        protected override void ApplyCustomFieldsValues()
        {
            SourceCustomResource = CustomResource;
            SourceCustomLabel = CustomLabel;
            SourceCustomOperator = CustomOperator;
            SourceCustomCustomer = CustomCustomer;

            SourceCustomIsClosed = CustomIsClosed;
            SourceCustomOutcome = CustomOutcome ;
            SourceCustomOutcomeCreated = CustomOutcomeCreated;
            SourceCustomOutcomeDate = CustomOutcomeDate;
            SourceCustomOutcomeDescription = CustomOutcomeDescription;
        }
    }

}


