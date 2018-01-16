using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    public partial class AppointmentCustomerSearchControl : DevExpress.XtraEditors.XtraUserControl, ISearchDTOCreator
    {
        private bool _createSubQueryForDocuments = false;

        public bool CreateSubQueryForDocuments
        {
            get { return _createSubQueryForDocuments; }
            set { _createSubQueryForDocuments = value; }
        }

        public AppointmentCustomerSearchControl()
        {
            InitializeComponent();
            lstCustomers.SortOrder = SortOrder.Ascending;
        }

        

        public bool ContactSearchEnabled
        {
            get { return chkNoCust.Enabled; }
            set { chkNoCust.Enabled = value; }
        }


        private IList<Customer> GetSelectedCustomers()
        {
            IList<Customer> l = new List<Customer>();

            foreach (Customer item in lstCustomers.Items)
            {
                l.Add(item as Customer);
            }

            return l;
        }



        private bool ExistCustomer(Customer customer)
        {
            if (customer == null)
                throw new InvalidOperationException("Cliente nullo");

            foreach (Customer item in lstCustomers.Items)
            {
                if (item != null)

                    if (item.Id.Equals(customer.Id))
                        return true;
            }
            return false;
        }


        #region ISearchDTOCreator Membri di

        public WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.IsearchDTO CreateDTO()
        {
            if (!_createSubQueryForDocuments)
                return new CustomerAppointmentDTO(chkNoCust.Checked, GetSelectedCustomers());
            else
                return new CustomerAppointmentDTO(chkNoCust.Checked, GetSelectedCustomers(), true);

        }

        #endregion

        private void chkNoCust_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoCust.Checked)
            {
                chkNoCust.Font = new Font(chkNoCust.Font, FontStyle.Bold);
                lstCustomers.Enabled = false;
                cmdAdd.Enabled = false;
                cmdRemove.Enabled = false;
            }
            else
            {
                chkNoCust.Font = new Font(chkNoCust.Font, FontStyle.Regular);
                lstCustomers.Enabled = true;
                cmdAdd.Enabled = true;
                cmdRemove.Enabled = true;
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedItems.Count == 1)
                lstCustomers.Items.RemoveAt(lstCustomers.SelectedIndex);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.SelectedCustomer != null)
                        if (!ExistCustomer(frm.SelectedCustomer))
                            lstCustomers.Items.Add(frm.SelectedCustomer);
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }
        }

     

     

    
    }
}

