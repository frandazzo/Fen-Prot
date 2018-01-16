using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using DevExpress.XtraGrid.Views.Grid;
using WIN.SECURITY.Exceptions;
using WIN.SCHEDULING_APP.GUI.Utility;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class CausaliAmministrativeForm : DevExpress.XtraEditors.XtraForm
    {

        public delegate void SelectCausaleEventHandler(object sender, SelectCausaleEventArg arg);
        public event SelectCausaleEventHandler Causaleselected;



        private TipoMovimernto _type;
     //   private bool _setFocusOnNew = false;


        public CausaliAmministrativeForm(TipoMovimernto type)
        {
            InitializeComponent();
            _type = type;
            LoadData();
        }

        
    

        private  void LoadData()
        {
            try
            {

                WIN.GUI.UTILITY.Helper.ShowWaitBox("Elaborazione in corso...", Properties.Resources.Waiting);


                CausaleAmministrativaHandler h = new CausaleAmministrativaHandler();

               IBindingList res = h.GetAllAsBinbingList(_type);

               gridControl1.DataSource = res;
               //if (res.Count == 0)
               //    _setFocusOnNew = true;
               //else
               //    _setFocusOnNew = false;

                //if (res.Count == 0)
                //    XtraMessageBox.Show("Nessun risultato è stato trovato. Riprovare per altri periodi!", "Nessun risultato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
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
            if (e.Column.Name == "colDescrizione")
            {
                CausaleAmministrativa app = gridView1.GetRow(e.RowHandle) as CausaleAmministrativa;
                if (app != null)
                {
                    e.DisplayText = app.Descrizione; 
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
                CausaleAmministrativa label = view.GetRow(view.FocusedRowHandle) as CausaleAmministrativa;
                if (label != null)
                    //ShowDialogForm(label);
                    if (Causaleselected != null)
                    {
                        Causaleselected.Invoke(this, new SelectCausaleEventArg(label));
                        this.Close();
                    }
            }
        }

        private void ShowDialogForm(CausaleAmministrativa label)
        {
            FormCausale frm = new FormCausale(label);
            frm.ShowDialog();
            frm.Dispose();
        }

 

  

        private void TryDelete(CausaleAmministrativa movimento, int rowIndex)
        {
            if (movimento == null)
                return;

            if (XtraMessageBox.Show("Rimuovere la causale selezionata?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CausaleAmministrativaHandler h = new CausaleAmministrativaHandler();
                h.Delete(movimento);

                IBindingList h1 = gridView1.DataSource as IBindingList;
                h1.Remove(movimento);
            }

        }

   

        private void cmdNew_Click(object sender, EventArgs e)
        {
            try
            {
                FormCausale frm = new FormCausale(_type);
                if (frm.ShowDialog() == DialogResult.OK)
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

        private void cmdDel_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    if (gridView1.IsDataRow(rowIndex))
                    {
                        TryDelete(gridView1.GetRow(rowIndex) as CausaleAmministrativa, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //gridControl1.ShowPrintPreview();

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.Component = gridControl1;
                link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                link.ShowPreview();


            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int[] res = gridView1.GetSelectedRows();

                if (res.Length != 1)
                {
                    XtraMessageBox.Show("Selezionare una causale!", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                

               
                if (gridView1.IsDataRow(res[0]))
                {
                    CausaleAmministrativa caus = gridView1.GetRow(res[0]) as CausaleAmministrativa;
                    if (caus != null)
                        ShowDialogForm(caus);
                }
                
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

            //cmdNew.Focus();
            //return;

            GridView view = sender as GridView;

            if (view == null)
                return;

            


            if (e.KeyCode == Keys.Return)
            {
                CausaleAmministrativa c = view.GetFocusedRow() as CausaleAmministrativa;
                if (c != null)
                    if (Causaleselected != null)
                    {
                        Causaleselected.Invoke(this, new SelectCausaleEventArg(c));
                        this.Close();
                    }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                cmdNew.Focus();
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void CausaliAmministrativeForm_Load(object sender, EventArgs e)
        {
            //if (_setFocusOnNew)
            //    cmdNew.Focus();
            //else
            //    gridView1.Focus();
        }

    
    }
}
