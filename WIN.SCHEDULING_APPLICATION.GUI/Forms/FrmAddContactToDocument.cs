using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmAddContactToDocument : DevExpress.XtraEditors.XtraForm
    {

        CustomerList _list;



        public FrmAddContactToDocument(IList _customers)
        {
            InitializeComponent();
            _list = new CustomerList(_customers);
            AttachList();
            LoadListBox();

        }

        public IList Customers
        {
            get { return _list.Customers; }
        }

        private void LoadListBox()
        {
            lstContacts.Items.Clear();
            foreach (Customer item in _list.Customers)
            {
                lstContacts.Items.Add(item);
            }
            lstContacts.SortOrder = SortOrder.Ascending;
        }

        private void AttachList()
        {
            _list.OnAdd += new CustomerList.AddItemHandler(_list_OnAdd);
            _list.OnRemove += new CustomerList.RemoveItemHandler(_list_OnRemove);
        }


        private void AddContact(Customer c)
        {
           _list.AddCustomers(c);
        }

        private void RemoveContact()
        {
            foreach (Customer item in lstContacts.SelectedItems)
            {
                _list.RemoveCustomer(item);
            }
            LoadListBox();
        }


        void _list_OnRemove(Customer sender, EventArgs e)
        {
            //lstContacts.Items.Remove(sender);
            //lstContacts.SortOrder = SortOrder.Ascending;
        }

        void _list_OnAdd(Customer sender, EventArgs e)
        {
            lstContacts.Items.Add(sender);
            lstContacts.SortOrder = SortOrder.Ascending;
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmComplexCustomerSearch cc = new FrmComplexCustomerSearch();
                if (cc.ShowDialog() == DialogResult.OK)
                {
                    if (cc.Customer != null)
                        AddContact(cc.Customer);
                }
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }





    }


     class CustomerList
    {
        private IList _customers;


        internal delegate void AddItemHandler(Customer c, EventArgs a);
        internal delegate void RemoveItemHandler(Customer c, EventArgs a);

        internal event AddItemHandler OnAdd;
        internal event RemoveItemHandler OnRemove;

        
        /// <summary>
        /// Triggers the OnRemove event.
        /// </summary>
        internal virtual void TriggerOnRemove(Customer c ,EventArgs ea)
        {
            if (OnRemove != null)
                OnRemove(c, ea);
        }
        
        /// <summary>
        /// Triggers the OnAdd event.
        /// </summary>
        internal virtual void TriggerOnAdd(Customer c ,EventArgs ea)
        {
            if (OnAdd != null)
                OnAdd(c, ea);
        }



        internal IList Customers
        {
            get { return _customers; }
        }

        internal CustomerList(IList customers)
        {
            _customers = customers;
        }

        internal void AddCustomers(Customer c)
        {
            if (c == null)
                return;
            foreach (Customer item in _customers )
            {
                if (item.Id.Equals(c.Id))
                    return;
            }
            _customers.Add(c);
            TriggerOnAdd(c,new EventArgs());
        }

        internal void RemoveCustomer(Customer c)
        {
            if (c == null)
                return;
            foreach (Customer item in _customers)
            {
                if (item.Id.Equals(c.Id))
                {
                    _customers.Remove(c);
                    TriggerOnRemove(item,new EventArgs());
                    return;
                }
            }
        }

    }

}