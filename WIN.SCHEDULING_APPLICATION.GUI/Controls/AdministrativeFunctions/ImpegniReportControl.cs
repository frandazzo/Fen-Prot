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
    public partial class ImpegniReportControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ImpegniReportControl()
        {
            InitializeComponent();
            cboAnno.Text = DateTime.Now.Year.ToString();
        }


        string fileLayout = "";
        string _layoutFileName = "\\LayoutSavings\\reportImpegni.xml";
    


  
    

        
           

       


       

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
                    //gridControl1.ForceInitialize();
                    //// Restore the previously saved layout
                    //gridControl1.MainView.RestoreLayoutFromXml(fileLayout);
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


                ImpegnoHandler h = new ImpegnoHandler();



                IList l  = h.ImpegniTesseramento(Convert.ToInt32(cboAnno.Text));


                gridControl1.DataSource = l;

                if (l.Count == 0)
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
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
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
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {
                    if (app.Regione == null)
                        e.DisplayText = "";
                    else
                        e.DisplayText = app.Regione.Descrizione;
                }
            }
            else if (e.Column.Name == "colImpegnoTotale")
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.ImpegnoTotale.ToString("n2");
                }
            }
            else if (e.Column.Name == "colgen")
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.gen.ToString("n2");
                }
            }
            else if (e.Column.Name == "colfeb")
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.feb.ToString("n2");
                }
            }
            else if (e.Column.Name == "colmar" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.mar.ToString("n2");
                }
            }
            else if (e.Column.Name == "colapr" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.apr.ToString("n2");
                }
            }
            else if (e.Column.Name == "colmag" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.mag.ToString("n2");
                }
            }
            else if (e.Column.Name == "colgiu" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.giu.ToString("n2");
                }
            }
            else if (e.Column.Name == "collug")
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.lug.ToString("n2");
                }
            }
            else if (e.Column.Name == "colago" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.ago.ToString("n2");
                }
            }
            else if (e.Column.Name == "colset" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.set.ToString("n2");
                }
            }
            else if (e.Column.Name == "colott")
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.ott.ToString("n2");
                }
            }
            else if (e.Column.Name == "colnov" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.nov.ToString("n2");
                }
            }
            else if (e.Column.Name == "coldic" )
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.dic.ToString("n2");
                }
            }
            else if (e.Column.Name == "colalt")
            {
                Impegno app = gridView1.GetRow(e.RowHandle) as Impegno;
                if (app != null)
                {

                    e.DisplayText = app.altreDate.ToString("n2");
                }
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
                link.Landscape = true;
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

            brick1 = e.Graph.DrawString("         Tesseramento " + cboAnno.Text, Color.Navy, new RectangleF(200, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);

            brick1.Font = new Font("Tahoma", 16);

            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick1.VertAlignment = DevExpress.Utils.VertAlignment.Top;



            DevExpress.XtraPrinting.TextBrick brick2;

            brick2 = e.Graph.DrawString("Numero tessere ed impegni di pagamento sottoscritti \n dalle sottoindicate strutture territoriali Feneal UIL per l'anno  " + cboAnno.Text, Color.Navy, new RectangleF(200, 30, 600, 40), DevExpress.XtraPrinting.BorderSide.None);

            brick2.Font = new Font("Tahoma", 10, FontStyle.Bold);

            brick2.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);

            brick2.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;



            DevExpress.XtraPrinting.TextBrick brick3;

            brick3 = e.Graph.DrawString("FENEAL U.I.L. \nSEGRETERIA NAZIONALE \nServizio Amministrazione \nServizio Organizzazione", Color.Red, new RectangleF(0, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None);

            brick3.Font = new Font("Tahoma", 7, FontStyle.Bold);

            brick3.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Near);

            brick3.VertAlignment = DevExpress.Utils.VertAlignment.Bottom;


        }

        private void ImpegniReportControl_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void cboAnno_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadData();
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
                Impegno label = view.GetRow(view.FocusedRowHandle) as Impegno;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(Impegno label)
        {
            FormImpegno frm = new FormImpegno( label);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                gridView1.RefreshData();
                gridView1.UpdateSummary();
            }
            frm.Dispose();
        }


    }
}
