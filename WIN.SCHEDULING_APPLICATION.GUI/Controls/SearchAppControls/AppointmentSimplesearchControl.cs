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
    public partial class AppointmentSimplesearchControl : DevExpress.XtraEditors.XtraUserControl, ISearchDTOCreator
    {



        public AppointmentSimplesearchControl()
        {
            InitializeComponent();
        }

 

        private void LoadListaCausali()
        {
            lstCau.Items.Clear();

            LabelHandler h = new LabelHandler();

            foreach (WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label item in h.GetAll())
	        {
                lstCau.Items.Add(item);
	        }
            

        }

        private void LoadListaRisorse()
        {
            lstRes.Items.Clear();

            ResourceHandler h = new ResourceHandler();

            foreach (Resource item in h.GetAll())
            {
                lstRes.Items.Add(item);
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
            string subject = txtsubject.Text;
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
            return new SimpleAppointmentSearch(GetSelectedResources(), GetSelectedLabels(), GetSelectedOperators(), subject, txtLoc.Text);
        }

        private IList<Resource> GetSelectedResources()
        {
            IList<Resource> l = new List<Resource>();

            //foreach (Resource item in lstRes.SelectedItems)
            //{
            //    l.Add(item as Resource);
            //}

            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstRes.CheckedItems)
            {
                l.Add(item.Value as Resource);
            }

            return l;
        }

        private IList<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label> GetSelectedLabels()
        {
            IList<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label> l = new List<WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label>();

            //foreach (WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label item in lstCau.SelectedItems)
            //{
            //    l.Add(item as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label);
            //}


            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstCau.CheckedItems)
            {
                l.Add(item.Value as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label);
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

     
     

        private void AppointmentSimplesearchControl_Load(object sender, EventArgs e)
        {
           
            lstCau.SortOrder = SortOrder.Ascending;
            lstRes.SortOrder = SortOrder.Ascending;
            lstOp.SortOrder = SortOrder.Ascending;
            LoadListaRisorse();
            LoadListaOperatori();
            LoadListaCausali();
        }

        private void lstCau_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstCau.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }

        private void lstRes_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstRes.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }

        private void lstOp_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (lstOp.GetItemChecked(e.Index)) return;
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
        }
    }
}
