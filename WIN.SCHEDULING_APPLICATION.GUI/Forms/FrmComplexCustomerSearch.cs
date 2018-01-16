using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmComplexCustomerSearch : DevExpress.XtraEditors.XtraForm
    {

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
        }


        public FrmComplexCustomerSearch()
        {
            InitializeComponent();
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            _customer = txtCust.EditValue as Customer;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtCust_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                //pulsante di ricerca cliente
                SearchCustomer();
            }
            else if (e.Button.Index == 1)
            {
                //pulsante di annullamento cliente
                _customer = null;
                txtCust.EditValue = null;
            }
            else if (e.Button.Index == 2)
            {
                //modifico l'elemento


                if (_customer == null)
                    return;
                else
                {
                    CustomerForm frm = new CustomerForm(_customer);
                    try
                    {
                        frm.CheckSecurityForView();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            txtCust.EditValue = frm.Customer;
                            _customer = frm.Customer;
                        }
                    }
                    catch (AccessDeniedException)
                    {
                        XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                //new creo uno nuovo
                CustomerForm frm = new CustomerForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtCust.EditValue = frm.Customer;
                    _customer = frm.Customer;
                }

            }
        }

        private void SearchCustomer()
        {
            try
            {
                WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente frm = new WIN.SCHEDULING_APP.GUI.Forms.FormRicercaCliente();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtCust.EditValue = frm.SelectedCustomer;
                    _customer = frm.SelectedCustomer;
                   
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }





    }
}