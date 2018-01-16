using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using System.Reflection;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Collections;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions
{
    public partial class PagamentiUILReportControl : DevExpress.XtraEditors.XtraUserControl
    {
            string fileLayout = "";
            TipoMovimernto _type = TipoMovimernto.PagamentoTesseramento;
            string _layoutFileName = "\\LayoutSavings\\reportPagamentiTesseramento.xml";
            MovimentoForm frm;
            GridGroupSummaryItem titleItem = null;

        public PagamentiUILReportControl()
        {
            InitializeComponent();
            cboAnno.Text = DateTime.Now.Year.ToString();

            titleItem = new GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Data", gridView1.Columns["Data"], "{0}");
            gridView1.GroupSummary.Add(titleItem);
            gridView1.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(gridView1_CustomSummaryCalculate);
          
        }

        
        
     

   





    

        private void RimesseReportControl_Load(object sender, EventArgs e)
        {
            Init();

        }


        void frm_MovimentoSaved(object sender, MovimentoContabileEventArg e)
        {
            if (e.Added)
                if (e.Movimento != null)
                {
                    IBindingList g = gridView1.DataSource as IBindingList;
                    g.Add(e.Movimento);
                }
        }

        private void Init()
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += _layoutFileName;


            //verifico la presenza del file
            f = new FileInfo(fileLayout);


            try
            {
                if (f.Exists)
                {
                    gridControl1.ForceInitialize();
                    // Restore the previously saved layout
                    gridControl1.MainView.RestoreLayoutFromXml(fileLayout);
                }
            }
            catch (Exception)
            {
                //non fa nulla
            }



            LoadData();
        }

        private  void LoadData()
        {
            try
            {

                WIN.GUI.UTILITY.Helper.ShowWaitBox("Elaborazione in corso...", Properties.Resources.Waiting);


                AbstractAmministrazioneHandler h = MovimentoContabileHandlerFactory.GetMovimentoHandler(_type);

                IList<IsearchDTO> dtos = new List<IsearchDTO>();
                MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(Convert.ToInt32(cboAnno.Text), null, null, null, false);
                dtos.Add(dto);

                h.ExecuteQuery(dtos);

                gridControl1.DataSource = h.BindableResults;

                if (h.BindableResults.Count == 0)
                    XtraMessageBox.Show("Nessun risultato è stato trovato. Riprovare per altri periodi!", "Nessun risultato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    try
                    {
                        gridControl1.MainView.SaveLayoutToXml(fileLayout);
                    }
                    catch (Exception)
                    {
                        //non fa nulla
                    }
                }
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
            if (e.Column.Name == "colProvincia")
            {
                AbstractMovimentoContabile app = gridView1.GetRow(e.RowHandle) as AbstractMovimentoContabile;
                if (app != null)
                {
                    if (app.Provincia == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = app.Provincia.Descrizione;
                }
            }
            else if (e.Column.Name == "colRegione")
            {
                AbstractMovimentoContabile app = gridView1.GetRow(e.RowHandle) as AbstractMovimentoContabile;
                if (app != null)
                {
                    if (app.Regione == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = app.Regione.Descrizione;
                }
            }
            else if (e.Column.Name == "colCausale")
            {
                AbstractMovimentoContabile app = gridView1.GetRow(e.RowHandle) as AbstractMovimentoContabile;
                if (app != null)
                {
                    if (app.Causale == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = app.Causale.Descrizione;
                }
            }
            else if (e.Column.Name == "colImporto")
            {
                AbstractMovimentoContabile app = gridView1.GetRow(e.RowHandle) as AbstractMovimentoContabile;
                if (app != null)
                {

                    e.DisplayText = app.Importo.ToString("n");
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
                AbstractMovimentoContabile label = view.GetRow(view.FocusedRowHandle) as AbstractMovimentoContabile;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(AbstractMovimentoContabile label)
        {
            frm = new MovimentoForm( _type, label);
            frm.MovimentoSaved += new MovimentoForm.MovimentoSavedEventHandler(frm_MovimentoSaved);
            frm.ShowDialog();
            gridView1.RefreshData();
            gridView1.UpdateSummary();
            frm.Dispose();
        }

        private void cboNew_Click(object sender, EventArgs e)
        {
            try
            {
                frm = new MovimentoForm(_type);
                frm.MovimentoSaved += new MovimentoForm.MovimentoSavedEventHandler(frm_MovimentoSaved);
                frm.ShowDialog();
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
                        TryDelete(gridView1.GetRow(rowIndex) as AbstractMovimentoContabile, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void TryDelete(AbstractMovimentoContabile movimento, int rowIndex)
        {
            if (movimento == null)
                return;

            if (XtraMessageBox.Show("Rimuovere il movimento selezionato?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AbstractAmministrazioneHandler h = MovimentoContabileHandlerFactory.GetMovimentoHandler(_type);
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
                link.CreateReportFooterArea += new CreateAreaEventHandler(link_CreateReportFooterArea);
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

        void link_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {
            e.Graph.DefaultFont = new Font(e.Graph.DefaultFont, FontStyle.Bold);
        }

        void link_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {

            PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.NumberOfTotal, "", Color.DarkBlue,

               new RectangleF(0, 0, 100, 20), BorderSide.None);

            brick.LineAlignment = BrickAlignment.Far;

            brick.Alignment = BrickAlignment.Far;

            brick.AutoWidth = true;
        }

        private void cboAnno_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void PagamentiUILReportControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Item != titleItem) return;
            if (e.SummaryProcess != DevExpress.Data.CustomSummaryProcess.Finalize) return;
            GridColumn col = view.GroupedColumns[e.GroupLevel];
            object value = view.GetGroupRowValue(e.GroupRowHandle);
            e.TotalValue = string.Format("Totale {0} {1}", col.GetCaption(), value);
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;

            if (view == null)
                return;




            if (e.KeyCode == Keys.Return)
            {
                AbstractMovimentoContabile c = view.GetFocusedRow() as AbstractMovimentoContabile;
                if (c != null)
                {
                    ShowDialogForm(c);
                }

            }
        }


        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {

            //    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.DarkBlue,

            //       new RectangleF(0, 0, 100, 20), BorderSide.None);

            //    brick.LineAlignment = BrickAlignment.Center;

            //    brick.Alignment = BrickAlignment.Center;

            //    brick.AutoWidth = true;
            DevExpress.XtraPrinting.TextBrick brick1;

            brick1 = e.Graph.DrawString("               Tesseramento " + cboAnno.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);

            brick1.Font = new Font("Tahoma", 16);

            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick1.VertAlignment = DevExpress.Utils.VertAlignment.Top;



            DevExpress.XtraPrinting.TextBrick brick2;

            brick2 = e.Graph.DrawString("Pagamenti effettuati alla UIL \nrelativi al tesseramento  " + cboAnno.Text + " alla data " + AbstractMovimentoContabile.GetLastMovivimentoDate(gridControl1.DataSource as IList).ToShortDateString(), Color.Navy, new RectangleF(0, 30, 600, 40), DevExpress.XtraPrinting.BorderSide.None);

            brick2.Font = new Font("Tahoma", 10, FontStyle.Bold);

            brick2.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick2.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;



            DevExpress.XtraPrinting.TextBrick brick3;

            brick3 = e.Graph.DrawString("FENEAL U.I.L. \nSEGRETERIA NAZIONALE \nServizio Amministrazione \nServizio Organizzazione", Color.Red, new RectangleF(0, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None);

            brick3.Font = new Font("Tahoma", 7, FontStyle.Bold);

            brick3.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Near);

            brick3.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;


        }

        private void gridView1_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        }


    }
}
