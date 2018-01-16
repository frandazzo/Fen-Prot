using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    public partial class DocumentSearchControl : DevExpress.XtraEditors.XtraUserControl, ISearchDTOCreator
    {



        public DocumentSearchControl()
        {
            InitializeComponent();
            spYear.EditValue = DateTime.Now.Year;
        }

 

        private void LoadListaCausali()
        {
            lstCau.Items.Clear();

            DocumentTypeHandler h = new DocumentTypeHandler();

            foreach (WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType  item in h.GetAll())
	        {
                lstCau.Items.Add(item);
	        }
            

        }


        private void LoadListaCartelle()
        {
            lstCart.Items.Clear();

            DocumentScopeHandler h = new DocumentScopeHandler();

            foreach (WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope item in h.GetAll())
            {
                lstCart.Items.Add(item);
            }


        }


     
        private void LoadListaOperatori()
        {
            lstOp.Items.Clear();

            OperatorHandler h = new OperatorHandler();

            foreach (Operator item in h.GetAll())
            {
                lstOp.Items.Add(item);
            }


        }





        #region ISearchDTOCreator Membri di

        public WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.IsearchDTO CreateDTO()
        {
            string subject = txtSubject.Text;
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
            return new SimpleDocumentSearch(GetSelectedScopes(), GetSelectedTypes(), GetSelectedOperators(), subject, txtProtocol.Text, Convert.ToInt32(spYear.Value));
        }


        private IList<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope> GetSelectedScopes()
        {
            IList<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope> l = new List<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope>();


            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstCart.CheckedItems)
            {
                l.Add(item.Value as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentScope);
            }


            return l;
        }

        private IList<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType > GetSelectedTypes()
        {
            IList<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType> l = new List<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType>();

        
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstCau.CheckedItems)
            {
                l.Add(item.Value as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.DocumentType);
            }


            return l;
        }

        private IList<Operator> GetSelectedOperators()
        {
            IList<Operator> l = new List<Operator>();

            //foreach (Operator item in lstOp.SelectedItems)
            //{
            //    l.Add(item as Operator);
            //}
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstOp.CheckedItems)
            {
                l.Add(item.Value as Operator);
            }

            return l;
        }

        #endregion

     
     

    

        private void lstCau_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstCau.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }

     

        private void lstOp_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstOp.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }

        private void lstCart_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstCart.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }

        private void DocumentSearchControl_Load(object sender, EventArgs e)
        {
            lstCau.SortOrder = SortOrder.Ascending;
            lstOp.SortOrder = SortOrder.Ascending;
            lstCart.SortOrder = SortOrder.Ascending;
            LoadListaCartelle();
            LoadListaOperatori();
            LoadListaCausali();
        }

        private void txtProtocol_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
