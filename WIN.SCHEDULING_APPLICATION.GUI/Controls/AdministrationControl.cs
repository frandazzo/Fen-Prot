using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions;
using WIN.SCHEDULING_APP.GUI.Utility;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using WIN.TECHNICAL.PERSISTENCE;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using System.Collections;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports;
using WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls
{
    public partial class AdministrationControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        string preTitle = "";
        public AdministrationControl(MainForm form)
            : base(form)
        {
            InitializeComponent();
            CustomGUI_SetCommandBarVisibility(false);
            treeList1.ExpandAll();
            treeList2.ExpandAll();
            treeList3.ExpandAll();
            //avvio la renderizzazione del tessseramento
            XtraUserControl r = new RimesseReportControl();
            RenderSubControl(r);
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            TreeListNode Node = hi.Node;

            SelectFunctionTree1(Node);
        }

        private void SelectFunctionTree1( TreeListNode Node)
        {
            preTitle = "";
           
            if (Node != null)
            {
                XtraUserControl r = null;
                if (Node.Id == 1)
                {

                    r = new RimesseReportControl();
                    preTitle = "Tesseramento: ";
                }
                else if (Node.Id == 12)
                {
                    r = new IncassiTesseramentoReportControl();
                    preTitle = "Tesseramento: ";
                }
                else if (Node.Id == 13)
                {
                    r = new PagamentiUILReportControl();
                    preTitle = "Tesseramento: ";
                }
                else if (Node.Id == 15)
                {
                    r = new DatiTesseramentoControl();
                    preTitle = "Tesseramento: ";
                }
                else if (Node.Id == 16)
                {
                    OpenTesseramentoReport();
                }
                else if (Node.Id == 8)
                {
                    OpenImportImpegniprogram();

                }
                else if (Node.Id == 9)
                {
                    OpenReportImpegni();

                }
                else if (Node.Id == 5)
                {
                    OpenImpegniRimesseConfrontoReport();

                }
                else if (Node.Id == 6)
                {
                    OpenImpegniRimesseConfrontoReportPeriodo();

                }
                else if (Node.Id == 10)
                {
                    r = new ImpegniReportControl();
                    preTitle = "Tesseramento: ";

                }
                else if (Node.Id == 3)
                {
                    OpenReportConfrontoSomme();

                }
                else if (Node.Id == 4)
                {
                    OpenReportAnaliticoRimesse();

                }

                if (r != null)
                {
                    RenderSubControl(r);
                    lblFunction.Text = preTitle + Node.GetDisplayText(0);
                }



            }
        }

        private void OpenImpegniRimesseConfrontoReportPeriodo()
        {
            try
            {
                FormSelezioneAnnoPeriodo frm = new FormSelezioneAnnoPeriodo();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    string periodo = frm.SelectedPeriodo;
                    ViewReportConfrontoImpegniRimesseMensileDaInizioAnno(anno, periodo);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewReportConfrontoImpegniRimesseMensileDaInizioAnno(int anno, string periodo)
        {
            ConfrontoRimesseImpegniHandler h = new ConfrontoRimesseImpegniHandler();

            IList<ConfrontoRimessaImpegno> l = h.GetListaConfrontiDaInizioAnno(anno, GetMeseFromInterface(periodo));



            ImpegniTesseramentoPeriodoReport r = new ImpegniTesseramentoPeriodoReport(anno, periodo);
            r.DataSource = l;
            r.Tag = anno;
            r.ShowPreviewDialog();
        }

        private void OpenTesseramentoReport()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    ViewReportTesseramento(anno);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewReportTesseramento(int anno)
        {
            TesseramentoHandler h = new TesseramentoHandler();
            IList l = new ArrayList();

            Tesseramento t = h.GetCompleteTesseramentoByAnno(anno);

            if (t == null)
            {
                XtraMessageBox.Show("Nessun riepilogo disponibile per l'anno: " + anno.ToString(), "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            l.Add(t);

            TesseramentoReport r = new TesseramentoReport();
            r.DataSource = l;
            r.Tag = anno;
            r.ShowPreviewDialog();
        }

        private void OpenReportAnaliticoRimesse()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    ViewReportRimesse(anno);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewReportRimesse(int anno)
        {
            RimesseTesseramentoHandler h = new RimesseTesseramentoHandler();

            MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(anno, null, null, null, true);

            IList<IsearchDTO > listDto = new List<IsearchDTO >();
            listDto.Add(dto);


            IList l = h.ExecuteQuery(listDto );



            RimesseReport r = new RimesseReport();
            r.DataSource = l;
            r.Tag = anno;
            r.ShowPreviewDialog();
        }

        private void OpenReportImpegni()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    ViewReportImpegni(anno);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        
        }

        private void ViewReportImpegni(int anno)
        {
            ImpegnoHandler h = new ImpegnoHandler();

            IList l = h.ImpegniTesseramento(anno);



            ImpegniReport r = new ImpegniReport();
            r.DataSource = l;


            r.parameter1.Value = h.Tesseramento.TessereNonDistribuite ;
            r.parameter2.Value = h.Tesseramento.TotaleValoreTessereNonDistribuite.ToString("n2");

            r.parameter1.Visible = false;
            r.parameter2.Visible = false;

            r.Tag = anno;
            r.ShowPreviewDialog();
        }

        private void OpenImpegniRimesseConfrontoReport()
        {
            try
            {
                FormSelezioneAnnoPeriodo frm = new FormSelezioneAnnoPeriodo();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    string periodo = frm.SelectedPeriodo;
                    ViewReportConfrontoImpegniRimesseMensile(anno, periodo);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewReportConfrontoImpegniRimesseMensile(int anno, string periodo)
        {
            ConfrontoRimesseImpegniHandler h = new ConfrontoRimesseImpegniHandler();

            IList<ConfrontoRimessaImpegno> l = h.GetListaConfronti(anno, GetMeseFromInterface(periodo));



            ImpegniTesseramentoReport r = new ImpegniTesseramentoReport(anno, periodo);
            r.DataSource = l;
            r.Tag = anno;
            r.ShowPreviewDialog();
        }

        private int GetMeseFromInterface(string periodo)
        {
            if (periodo == "Gennaio")
                return 1;
            else if (periodo == "Febbraio")
                return 2;
            else if (periodo == "Marzo")
                return 3;
            else if (periodo == "Aprile")
                return 4;
            else if (periodo == "Maggio")
                return 5;
            else if (periodo == "Giugno")
                return 6;
            else if (periodo == "Luglio")
                return 7;
            else if (periodo == "Agosto")
                return 8;
            else if (periodo == "Settembre")
                return 9;
            else if (periodo == "Ottobre")
                return 10;
            else if (periodo == "Novembre")
                return 11;
            else if (periodo == "Dicembre")
                return 12;
            else if (periodo == "Gennaio A.S.")
                return 13;
            else if (periodo == "Febbraio A.S.")
                return 14;
            else if (periodo == "Marzo A.S.")
                return 15;
            else if (periodo == "Aprile A.S.")
                return 16;
            else if (periodo == "Maggio A.S.")
                return 17;
            else if (periodo == "Giugno A.S.")
                return 18;

            throw new Exception("Periodo non riconosciuto");
        }

        private void OpenReportConfrontoSomme()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    ViewReportSommeDaVersare(anno);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewReportSommeDaVersare(int anno)
        {
            RiepilogoTesseramentoHandler h = new RiepilogoTesseramentoHandler();

            IList l = h.GetRiepilogoTesseramento(anno);



            RiepilogoquoteDaVersareReport r = new RiepilogoquoteDaVersareReport();
            r.DataSource = l;
            r.Tag = anno;
            r.ShowPreviewDialog();

        }

        private void OpenImportImpegniprogram()
        {
            try
            {
                //WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.exe
                string asmPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo f = new FileInfo(asmPath);

                string fold = f.DirectoryName;

                string progName = fold + @"\WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.exe";


                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(progName, "\"" + DataAccessServices.Instance().ConnectionString + "\"");
                p.StartInfo.UseShellExecute = false;
                p.Start();


            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);

            }
        }


        private void RenderSubControl(XtraUserControl control)
        {
            if (panelContainer.Controls.Count > 0)
            {
                panelContainer.Controls[0].Dispose();
                panelContainer.Controls.Clear();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            panelContainer.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        private void treeList3_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            TreeListNode Node = hi.Node;

            SelectFunctionTree3(Node);
        }

        private void SelectFunctionTree3(TreeListNode Node)
        {
          
            if (Node != null)
            {
                XtraUserControl r = null;
                if (Node.Id == 1)
                {

                    r = new ContributiReportControllo();


                    RenderSubControl(r);
                    lblFunction.Text = Node.GetDisplayText(0);
                }
                else
                {//eseguo le funzioni che non richiedono un rendering
                    XtraMessageBox.Show("clicked element: " + Node.Id.ToString());
                }


            }
        }

        private void treeList2_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            TreeListNode Node = hi.Node;

            SelectFunctionTree2(Node);

        }

        private void SelectFunctionTree2(TreeListNode Node)
        {
            preTitle = "";
           
            if (Node != null)
            {
                XtraUserControl r = null;
                if (Node.Id == 1)
                {

                    r = new QuacReportControllo();
                    preTitle = "QUAC: ";

                    RenderSubControl(r);
                    lblFunction.Text = preTitle + Node.GetDisplayText(0);
                }
                else if (Node.Id == 3)
                {
                    OpenReportAnalitico();

                }
                else if (Node.Id == 4)
                {
                    OpenReportTotProvincia();

                }
                else if (Node.Id == 5)
                {
                    OpenReportTotRegione();

                }
                else if (Node.Id == 6)
                {
                    OpenReportTotProvinciaRegione();

                }
                //else
                //{//eseguo le funzioni che non richiedono un rendering
                //    XtraMessageBox.Show("clicked element: " + hi.Node.Id.ToString());
                //}
            }
        }

        private void OpenReportAnalitico()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm(true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    int causale = frm.SelectedCausale;
                    ViewRiepiloghiAnaliticiQuac(anno, causale);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewRiepiloghiAnaliticiQuac(int anno, int causale)
        {
            QuacHandler h = new QuacHandler();
 
            IList<CausaleAmministrativa > causali = new List<CausaleAmministrativa >();
            FillListaCausali(causale, causali);


            string causaleDescription = GetDescrizioneCausale(causale, causali); 

            MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(anno,null,null,causali, false );

            IList<IsearchDTO > cli= new List<IsearchDTO>();
            cli.Add(dto);

            IList l = h.ExecuteQuery(cli);


            QuacAnaliticaPerProvincia r = new QuacAnaliticaPerProvincia();
            r.DataSource = l;
            r.Tag = anno.ToString() + "#" + causaleDescription;
            r.ShowPreviewDialog();
            
        }

        private string GetDescrizioneCausale(int causale, IList<CausaleAmministrativa> causali)
        {
            foreach (CausaleAmministrativa item in causali)
            {
                if (item.Id.Equals(causale))
                    return item.Descrizione;
            }

            return "";
        }

        private  void FillListaCausali(int causale, IList<CausaleAmministrativa> causali)
        {
            if (causale > 0)
            {
                CausaleAmministrativa caus = null;
                CausaleAmministrativaHandler hh = new CausaleAmministrativaHandler();
                caus = hh.GetElementById(causale.ToString()) as CausaleAmministrativa;
                if (caus != null)
                    causali.Add(caus);
            }
        }

        private void OpenReportTotProvinciaRegione()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm(true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    int causale = frm.SelectedCausale;
                    ViewRiepiloghiQuac(anno, causale, true, true, false);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void OpenReportTotRegione()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm(true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    int causale = frm.SelectedCausale;
                    ViewRiepiloghiQuac(anno, causale, false, false, false);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void OpenReportTotProvincia()
        {
            try
            {
                SelezionaAnnoForm frm = new SelezionaAnnoForm(true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int anno = frm.SelectedAnno;
                    int causale = frm.SelectedCausale;
                    ViewRiepiloghiQuac(anno, causale, true, false, true);
                }
                frm.Dispose();

            }
            catch (Exception ex)
            {

                ErrorHandler.Show(ex);
            }
        }

        private void ViewRiepiloghiQuac(int anno, int causale, bool provinciale, bool raggruppato, bool orderByProvincia)
        {
            QuacHandler h = new QuacHandler();

            IList l = h.GetRiepilogoTesseramentoPrepProvincia(anno, causale, provinciale, orderByProvincia);


            IList<CausaleAmministrativa> causali = new List<CausaleAmministrativa>();
            this.FillListaCausali(causale, causali);
            string causaleDescription = GetDescrizioneCausale(causale, causali);


            


            if (provinciale && raggruppato)
            {

                QuacPerRegioneProvinciaReport r = new QuacPerRegioneProvinciaReport();
                r.DataSource = l;
                r.Tag = anno.ToString() + "#" + causaleDescription;
                r.ShowPreviewDialog();
            }
            else if (provinciale)
            {
                QuacPerProvinciaReport r = new QuacPerProvinciaReport();
                r.DataSource = l;
                r.Tag = anno.ToString() + "#" + causaleDescription;
                r.ShowPreviewDialog();
            }
            else
            {
                QuacPerRegioneReport r = new QuacPerRegioneReport();
                r.DataSource = l;
                r.Tag = anno.ToString() + "#" + causaleDescription;
                r.ShowPreviewDialog();
            }
        }

        private void treeList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TreeList list = sender as TreeList;
                TreeListNode Node = list.FocusedNode;

                SelectFunctionTree1(Node);
            }
        }

        private void treeList2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TreeList list = sender as TreeList;
                TreeListNode Node = list.FocusedNode;
                SelectFunctionTree2(Node);
            }
        }

        private void treeList3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                TreeList list = sender as TreeList;
                TreeListNode Node = list.FocusedNode;
                SelectFunctionTree3(Node);
            }
        }

    }
}