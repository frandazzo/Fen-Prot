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
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.Utility;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions
{
    public partial class QuacReportControllo : DevExpress.XtraEditors.XtraUserControl
    {
        string orderBy = "";
        string fileLayout = "";
        TipoMovimernto _type = TipoMovimernto.Quac;
        string _layoutFileName = "\\LayoutSavings\\reportQuac.xml";
        MovimentoForm frm;
        GridGroupSummaryItem titleItem = null;
        
        public QuacReportControllo()
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



            LoadData(true);
        }

        private void LoadData(bool renewSuggestedDate)
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
                    //imposto la data suggerita
                    if (renewSuggestedDate)
                    {
                        SetSuggestedDateTolastOf(h.BindableResults);
                    }

                    //aggiorno il layout della grid
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

        private void SetSuggestedDateTolastOf(IBindingList iBindingList)
        {
            try
            {
                DateTime d = DateTime.MinValue;
                foreach (AbstractMovimentoContabile item in iBindingList)
                {
                    if (item.Data > d)
                        d = item.Data;
                }

                MonthYearSuggest.SetCurrentMonth(d.Month);
                MonthYearSuggest.SetCurrentYear(d.Year);
            }
            catch (Exception)
            {
                MonthYearSuggest.SetCurrentMonth(DateTime.Now.Month);
                MonthYearSuggest.SetCurrentYear(DateTime.Now.Year);
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
                if (gridView1.SortInfo.Count > 0)
                {
                    GridColumnSortInfo i = gridView1.SortInfo[0];
                    string sortType = "crescente";
                    if (i.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                        sortType = "decrescente";
                    orderBy = string.Format("ordinato per {0} {1}", i.Column.FieldName.ToLower(), sortType);
                }
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

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {

            //    PageInfoBrick brick = e.Graph.DrawPageInfo(PageInfo.DateTime, "", Color.DarkBlue,

            //       new RectangleF(0, 0, 100, 20), BorderSide.None);

            //    brick.LineAlignment = BrickAlignment.Center;

            //    brick.Alignment = BrickAlignment.Center;

            //    brick.AutoWidth = true;
            DevExpress.XtraPrinting.TextBrick brick1;

            brick1 = e.Graph.DrawString("Quote di adesione contrattuale " + cboAnno.Text, Color.Navy, new RectangleF(0, 0, 620, 20), DevExpress.XtraPrinting.BorderSide.None);

            brick1.Font = new Font("Tahoma", 14);

            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick1.VertAlignment = DevExpress.Utils.VertAlignment.Top;



            DevExpress.XtraPrinting.TextBrick brick2;


            ColumnFilterInfo f = gridView1.Columns["Causale"].FilterInfo;
          //  MessageBox.Show(f.FilterString);

            string ind = "Industria";
            string art = "Artigianato";
            string coo = "Cooperazione";
            string reg = "Regionali";

            string label = "Industria - Artigianato - Cooperative - Regionali";

            if (!string.IsNullOrEmpty(f.FilterString))
            {
                if (f.FilterString.Contains(ind.ToUpper()))
                    label = ind;
                else if (f.FilterString.Contains(art.ToUpper()))
                    label = art;
                else if (f.FilterString.Contains(coo.ToUpper()))
                    label = coo;
                else
                    label = reg;
            }

            IList data = GetVisibileData();


            brick2 = e.Graph.DrawString("Riepilogo generale da \n" + label + " \n alla data: " + AbstractMovimentoContabile.GetLastMovivimentoDate(GetVisibileData()).ToShortDateString() + " " + orderBy, Color.Navy, new RectangleF(0, 20, 650, 50), DevExpress.XtraPrinting.BorderSide.None);

            brick2.Font = new Font("Tahoma", 10, FontStyle.Bold);

            brick2.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick2.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;






            DevExpress.XtraPrinting.TextBrick brick3;

            brick3 = e.Graph.DrawString("FENEAL U.I.L. \nSEGRETERIA NAZIONALE \nServizio Amministrazione \nServizio Organizzazione", Color.Red, new RectangleF(0, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None);

            brick3.Font = new Font("Tahoma", 7, FontStyle.Bold);

            brick3.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Near);

            brick3.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;


        }

        private IList GetVisibileData()
        {
            IList l = new ArrayList();

            for (int i = 0; i < gridView1 .RowCount; i++)
			{
			    int handle = gridView1.GetVisibleRowHandle(i);
                if (!gridView1.IsGroupRow(handle))
                {
                    Quac c = gridView1.GetRow(handle) as Quac;
                    if (c != null)
                        l.Add(c);
                }
			}
          

            return l;
        }
        private string GetDate(int anno)
        {
            if (anno == DateTime.Now.Year)
                return DateTime.Now.Date.ToShortDateString();

            return new DateTime(Convert.ToInt32(this.Tag), 12, 31).ToShortDateString();

        }

        private void cboAnno_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(false);
        }

        private void QuacReportControllo_Load(object sender, EventArgs e)
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
    }
}
