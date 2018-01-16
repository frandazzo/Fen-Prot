using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using WIN.TECHNICAL.MIDDLEWARE.Listeners;
using DevExpress.XtraEditors;
using System.Reflection;
using WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.localhost;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
    public partial class Form1 : XtraForm
    {
        string _connectioString; 
        string _fileDataname = "";
        //string _fileDBname = "";

        List<OrganizativeRecord> list = new List<OrganizativeRecord>();
        List<AdministrativeRecord> list1 = new List<AdministrativeRecord>();

        public Form1()
        {
            InitializeComponent();
           
            Trace.Listeners.Add(new TextBoxTraceListener(txtReadLog));
            LoadComboAnni();
        }

        private void LoadComboAnni()
        {
            comboBox11.Properties.Items.Clear();

            for (int i = 1990  ; i <= 2040; i++)
            {
                comboBox11.Properties.Items.Add(i.ToString());
            }

            comboBox11.Text = DateTime.Now.Year.ToString();
        }

        private void cmdSelExcel_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "xls";
            openFileDialog1.Filter = "File Excel (*.xls)|*.xls|File Excel 2007 (*.xlsx)|*.xlsx";
            openFileDialog1.ShowDialog();
           
            _fileDataname = openFileDialog1.FileName;
            lblFileData1.Text = _fileDataname;
        }

        //private void cmdSelectDB_Click(object sender, EventArgs e)
        //{
        //    openFileDialog1.DefaultExt = "mdb";
        //    openFileDialog1.Filter = "File Access (*.mdb)|*.mdb";
        //    openFileDialog1.ShowDialog();
        //    _fileDBname = openFileDialog1.FileName;
        //    lblDB.Text = _fileDBname;
        //}

        private void cmdReadExcel_Click(object sender, EventArgs e)
        {
            if (!CheckParams())
                return;

            try
            {
                list1 = null;
                //MessageBox.Show("inizio lettura");
                list = new List<OrganizativeRecord>();
                //leggo da file excel
                ExcelReader r = new ExcelReader(_fileDataname, true);
                list = r.ReadOrganizzativeData();

                ////verifico l'esistenza della porvincia
                //Exporter exp = new Exporter(_connectioString);


                //exp.CheckProvinceExistence(list);

                //MessageBox.Show("termine check province");

                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                Exception exinner = ex.InnerException;
                if (exinner != null)
                    MessageBox.Show("Eccezione interna:" + exinner.Message + Environment.NewLine + "Eccezione esterna:" + ex.Message);
                MessageBox.Show( ex.Message);
            }

        }

        private bool CheckParams()
        {
            if (string.IsNullOrEmpty(_fileDataname))
            {
                MessageBox.Show("Selezionare un file!");
                return false;
            }

            if (!File.Exists(_fileDataname))
            {
                MessageBox.Show("Selezionare un file !");
                return false;
            }
           


         

            return true;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            if (!CheckParams())
                return;


            if (MessageBox.Show("Procedere all'aggiornamento della base dati ?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                StringBuilder log = new StringBuilder();
                string fileName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\logImport.txt";

                localhost.Credenziali c = new localhost.Credenziali();
                c.UserName = "randazzo";
                c.Password = "francesco1";

                try
                {

                    if (list1 == null)
                    {
                        if (list.Count == 0)
                        {
                            File.AppendAllText(fileName, "Nessun dato importato");
                            MessageBox.Show("Nessun dato importato");
                            return;
                        }

                      

                        localhost.SharetopIntegration serv = new SharetopIntegration();
                        serv.CredenzialiValue = c;
                        string error =  serv.SaveOrganizativeData(list[0].Year, list.ToArray());
                        if (string.IsNullOrEmpty(error))
                        {
                            MessageBox.Show("Dati importati correttamente");
                            return;
                        }
                            
                        throw new Exception(error);
                    }

                    if (list1.Count == 0)
                    {
                        File.AppendAllText(fileName, "Nessun dato importato");
                        MessageBox.Show("Nessun dato importato");
                        return;
                    }

                    localhost.SharetopIntegration i1 = new SharetopIntegration();
                    i1.CredenzialiValue = c;
                    string error1 = i1.SaveAdministrativeData(list1[0].Year, list1.ToArray());
                    if (string.IsNullOrEmpty(error1))
                    {
                        MessageBox.Show("Dati importati correttamente");
                        return;
                    }
                    throw new Exception(error1);


                }
                catch (Exception ex)
                {
                    log.AppendLine(ex.Message);
                }




                //notifico all'utente

                string logTotal = log.ToString();

                if (string.IsNullOrEmpty(logTotal))
                {
                    MessageBox.Show("Importazione avvenuta con successo");
                    File.AppendAllText(fileName, "Importazione avvenuta con successo");
                    return;
                }

                MessageBox.Show("Importazione avvenuta con errori. Consultare il log");
                File.AppendAllText(fileName, logTotal);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            try
            {
                string asmPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo i = new FileInfo(asmPath);

                string fold = i.DirectoryName;

                string fileName =  fold  + @"\TemplatesTesseramento\DATI ECONOMICI.xlsx";

                Process.Start(fileName);


            }
            catch ( Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore",  MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            try
            {
                string asmPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo i = new FileInfo(asmPath);

                string fold = i.DirectoryName;

                string fileName = fold + @"\TemplatesTesseramento\Comuni_Provincie_regioni_Nazioni.xls";

                Process.Start(fileName);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cmdImportOldData_Click(object sender, EventArgs e)
        {
            FrmImportOldData frm = new FrmImportOldData(_connectioString);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!CheckParams())
                return;

            try
            {
                list = null;
                //MessageBox.Show("inizio lettura");
                list1 = new List<AdministrativeRecord>();
                //leggo da file excel
                ExcelReader r = new ExcelReader(_fileDataname, false);
                list1 = r.ReadAdministrativeData();

                ////verifico l'esistenza della porvincia
                //Exporter exp = new Exporter(_connectioString);


                //exp.CheckProvinceExistence(list);

                //MessageBox.Show("termine check province");

                dataGridView1.DataSource = list1;
            }
            catch (Exception ex)
            {
                Exception exinner = ex.InnerException;
                if (exinner != null)
                    MessageBox.Show("Eccezione interna:" + exinner.Message + Environment.NewLine + "Eccezione esterna:" + ex.Message);
                MessageBox.Show( ex.Message);
            }
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            try
            {
                string asmPath = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
                FileInfo i = new FileInfo(asmPath);

                string fold = i.DirectoryName;

                string fileName = fold + @"\TemplatesTesseramento\DATI ORGANIZZATIVI.xlsx";

                Process.Start(fileName);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
