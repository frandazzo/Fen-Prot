using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using System.Xml;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using DevExpress.XtraPrinting;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FormRicercaCliente : DevExpress.XtraEditors.XtraForm
    {
        private int _id = -1;
        private Customer _customer = null;


        public Customer SelectedCustomer
        {
            get
            {
                return _customer;
            }
        }

        public int SelectedId
        {
            get
            {
                return _id;
            }
        }

        public FormRicercaCliente()
        {
            InitializeComponent();
            //LoadGrid();
            LoadComboZone();
            LoadComboProvince();
            //imposto la provincia come da impostazioni applicazione
            cboProv.EditValue = GeoLocationFacade.Instance().GetGeoHandler().GetProvinciaByName(Properties.Settings.Default.Main_Province);
            //string c = Properties.Settings.Default.Main_Comune;
            //Comune cc = GeoLocationFacade.Instance().GetGeoHandler().GetComuneByName(Properties.Settings.Default.Main_Comune);
            //LoadComboComuni(c);
            cboCom.EditValue  = GeoLocationFacade.Instance().GetGeoHandler().GetComuneByName(Properties.Settings.Default.Main_Comune);


            //tolgo dalla visualizzazione qualsiasi riferimento a campi non congruenti con Fenealgest
            if (Properties.Settings.Default.Main_OtherApp)
            {
                layoutControlItemPrivateCheck.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItemResource.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }



        private void LoadComboComuni(string province)
        {
            //preparo la combo delle dei comuni
            cboCom.Properties.Items.Clear();
            //la riempio con un comune nullo
            cboCom.Properties.Items.Add(new ComuneNullo());

            if (!string.IsNullOrEmpty(province))
            {
                IList l = GeoLocationFacade.Instance().GetListaOggettiComuniPerProvincia(province);
                cboCom.Properties.Items.AddRange(l);
            }
            //seleziono quella iniziale
            cboCom.SelectedIndex = 0;
        }

        private void LoadComboProvince()
        {
            //preparo la combo delle zone
            cboProv.Properties.Items.Clear();


            //la riempio
            cboProv.Properties.Items.Add(new ProvinciaNulla());
            IList l = GeoLocationFacade.Instance().GetListaOggettiProvincie();
            cboProv.Properties.Items.AddRange(l);

            //seleziono quella iniziale
            cboProv.SelectedIndex = 0;
        }

        private void LoadComboZone()
        {
            //preparo la combo delle zone
            cboZone.Properties.Items.Clear();

            ResourceHandler h = new ResourceHandler();
            //la riempio
            cboZone.Properties.Items.Add("");
            cboZone.Properties.Items.AddRange(h.GetAll());

            //seleziono quella iniziale
            cboZone.SelectedIndex = 0;
        }


        private void LoadGrid()
        {
            CustomerHandler h = new CustomerHandler();

            IList l = h.GetAll();

            gridControl1.DataSource = l;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {

            //gridControl1.ShowPrintPreview ();
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = gridControl1;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.ShowPreview();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            _id = -1;

            if (gridView1.SelectedRowsCount != 1)
            {
               
                XtraMessageBox.Show("Selezionare almeno un cliente!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer label = gridView1.GetRow(gridView1.FocusedRowHandle) as Customer;
            SetSelectedId(label);

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.RowHandle < 0)
            //    return;

            //GridView View = sender as GridView;
            //if (e.Column.FieldName == "Descrizione")
            //{
            //    WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label label = View.GetRow(e.RowHandle) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Label;

            //    int color = label.Color;

            //    e.Appearance.BackColor = Color.FromArgb(color);

            //}

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _id = -1;
                GridView view  = sender as GridView;
                Point pt  = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                Customer label = view.GetRow(view.FocusedRowHandle) as Customer;
                SetSelectedId(label);
            }
        }

        private void SetSelectedId(Customer label)
        {
            if (label != null)
            {
                _id = label.Id;
                _customer = label;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Selezionare un  cliente!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboComuni((cboProv.SelectedItem as Provincia).Descrizione);
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.CustomerSearchDTO dto = new WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs.CustomerSearchDTO();
                dto.MaxResult = Properties.Settings.Default.Main_MaxResult;
                dto.Cellulare = txtcell1.Text;
                dto.Mail = txtMail.Text;
                dto.Piva = txtPiva.Text;
                dto.Descrizione = txtDesc.Text;
                dto.Responsable = txtNome.Text;
                dto.Comune = cboCom.SelectedItem as Comune;
                dto.Province = cboProv.SelectedItem as Provincia;
                dto.Resource = cboZone.SelectedItem as Resource;
                if (chkPrivate.CheckState == CheckState.Indeterminate)
                    dto.CheckPrivate = false;
                else
                {
                    dto.CheckPrivate = true;
                    dto.IsPrivate = chkPrivate.Checked;
                }


                CustomerHandler h = new CustomerHandler();

                IList l = h.SearchCustomers(dto);

                gridControl1.DataSource = l;

                if (l.Count == 0)
                {
                    XtraMessageBox.Show("Nessun risultato trovato!", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    gridControl1.Focus();
                }
                

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }
    }
}