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
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FormCheckin : DevExpress.XtraEditors.XtraForm
    {
        //private Customer _customer;
        //private DateTime _date;

        private Checkin _checkin;

        public Checkin Checkin
        {
            get { return _checkin ; }
        }

        public FormCheckin(Checkin checkin)
        {
            InitializeComponent();
            _checkin = checkin;


            LoadData();
        }

        private void LoadData()
        {
            dateEdit1.EditValue = _checkin.Data;
            txtCust.EditValue = _checkin.Customer;
        }

        public FormCheckin()
        {
            InitializeComponent();

            dateEdit1.EditValue = DateTime.Now;
            txtCust.EditValue = null;
        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (_checkin == null)
                _checkin = new SCHEDULING_APPLICATION.DOMAIN.Booking.Checkin();
            if (dateEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Inserire una data corretta","Errore",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCust.EditValue as Customer == null)
            {
                XtraMessageBox.Show("Inserire un contatto corretto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _checkin.Customer = txtCust.EditValue as Customer;
            _checkin.Data = dateEdit1.DateTime;
            
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
              
                txtCust.EditValue = null;
            }
            else if (e.Button.Index == 2)
            {
                //modifico l'elemento


                if (txtCust.EditValue == null)
                    return;
                else
                {
                    CustomerForm frm = new CustomerForm(txtCust.EditValue as Customer);
                    try
                    {
                        frm.CheckSecurityForView();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            txtCust.EditValue = frm.Customer;
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