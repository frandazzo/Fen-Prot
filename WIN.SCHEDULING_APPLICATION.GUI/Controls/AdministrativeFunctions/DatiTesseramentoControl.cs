using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms;
using DevExpress.XtraPrinting;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions
{
    public partial class DatiTesseramentoControl : DevExpress.XtraEditors.XtraUserControl
    {
        public DatiTesseramentoControl()
        {
            InitializeComponent();
        }


        private void Init()
        {
          


            LoadData();
        }

        private  void LoadData()
        {
            try
            {

                WIN.GUI.UTILITY.Helper.ShowWaitBox("Elaborazione in corso...", Properties.Resources.Waiting);


                TesseramentoHandler h = new TesseramentoHandler();

               IBindingList res = h.GetAllAsBinbingList();

               gridControl1.DataSource = res;

                if (res.Count == 0)
                    XtraMessageBox.Show("Nessun risultato è stato trovato. Riprovare per altri periodi!", "Nessun risultato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
            }
            finally
            {
                WIN.GUI.UTILITY.Helper.HideWaitBox();
            }



        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colCostoTessera")
            {
                Tesseramento app = gridView1.GetRow(e.RowHandle) as Tesseramento;
                if (app != null)
                {
                    e.DisplayText = app.CostoTessera.ToString("c"); 
                }
            }
            else if (e.Column.Name == "colCostoTessere")
            {
                Tesseramento app = gridView1.GetRow(e.RowHandle) as Tesseramento;
                if (app != null)
                {
                    e.DisplayText = app.CostoTessere.ToString("c");
                }
            }
            else if (e.Column.Name == "colQuotaUIL")
            {
                Tesseramento app = gridView1.GetRow(e.RowHandle) as Tesseramento;
                if (app != null)
                {
                    e.DisplayText = app.QuotaUIL.ToString("c");
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Tesseramento label = view.GetRow(view.FocusedRowHandle) as Tesseramento;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(Tesseramento label)
        {
            FormTesseramento frm = new FormTesseramento(label);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void cboNew_Click(object sender, EventArgs e)
        {
            try
            {
                FormTesseramento frm = new FormTesseramento();
                if(frm.ShowDialog()== DialogResult.OK)
                {
                    if (frm.Current != null)
                    {
                        IBindingList g = gridView1.DataSource as IBindingList;
                        g.Add(frm.Current);
                    }
                }
                frm.Dispose();
             
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cboDel_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    if (gridView1.IsDataRow(rowIndex))
                    {
                        TryDelete(gridView1.GetRow(rowIndex) as Tesseramento, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void TryDelete(Tesseramento movimento, int rowIndex)
        {
            if (movimento == null)
                return;

            if (XtraMessageBox.Show("Rimuovere il tesseramento selezionato?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TesseramentoHandler h = new TesseramentoHandler();
                h.Delete(movimento);

                IBindingList h1 = gridView1.DataSource as IBindingList;
                h1.Remove(movimento);
            }

        }

        private void cmdPrintList_Click(object sender, EventArgs e)
        {
            try
            {
                //gridControl1.ShowPrintPreview();

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
                link.CreateMarginalFooterArea += new CreateAreaEventHandler(link_CreateMarginalFooterArea);
                link.Component = gridControl1;
                link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                link.ShowPreview();


            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        void link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {

            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "", Color.DarkBlue,

               new RectangleF(0, 0, 100, 20), BorderSide.None);

            brick.LineAlignment = BrickAlignment.Far;

            brick.Alignment = BrickAlignment.Far;

            brick.AutoWidth = true;
        }

        private void DatiTesseramentoControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {

            //    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.DarkBlue,

            //       new RectangleF(0, 0, 100, 20), BorderSide.None);

            //    brick.LineAlignment = BrickAlignment.Center;

            //    brick.Alignment = BrickAlignment.Center;

            //    brick.AutoWidth = true;
            DevExpress.XtraPrinting.TextBrick brick1;

            brick1 = e.Graph.DrawString("       Dati Tesseramento " , Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);

            brick1.Font = new Font("Tahoma", 16);

            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick1.VertAlignment = DevExpress.Utils.VertAlignment.Top;



            DevExpress.XtraPrinting.TextBrick brick2;

            brick2 = e.Graph.DrawString("Storico dei dati del tesseramento \n effettuati dalla FENEAL NAZIONALE " , Color.Navy, new RectangleF(0, 30, 600, 40), DevExpress.XtraPrinting.BorderSide.None);

            brick2.Font = new Font("Tahoma", 10, FontStyle.Bold);

            brick2.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick2.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;



            DevExpress.XtraPrinting.TextBrick brick3;

            brick3 = e.Graph.DrawString("FENEAL U.I.L. \nSEGRETERIA NAZIONALE \nServizio Amministrazione \nServizio Organizzazione", Color.Red, new RectangleF(0, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None);

            brick3.Font = new Font("Tahoma", 7, FontStyle.Bold);

            brick3.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Near);

            brick3.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;


        }


    
    }
}
