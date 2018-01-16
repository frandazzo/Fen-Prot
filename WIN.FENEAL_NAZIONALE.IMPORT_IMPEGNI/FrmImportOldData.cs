using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI
{
    public partial class FrmImportOldData : DevExpress.XtraEditors.XtraForm
    {

        string _fileDBname = "";
        string _connectioString; 

        public FrmImportOldData(string conn)
        {
            InitializeComponent();
            _connectioString = conn;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "mdb";
            openFileDialog1.Filter = "File Access (*.mdb)|*.mdb";
            openFileDialog1.ShowDialog();
            _fileDBname = openFileDialog1.FileName;
            lblDB.Text = _fileDBname;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!CheckParams())
                return;

            if (MessageBox.Show(String.Format("Procedere all'aggiornamento della base dati: {0}?", comboBoxEdit1.Text), "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string fileName = String.Format("{0}\\logImport{1}.txt", Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), comboBoxEdit1.Text);

                abstractImporter exp = ImportFactory.GetImporter(comboBoxEdit1.Text, _connectioString, _fileDBname);
                exp.Import(Convert.ToInt32(cboAnno.Text));

                //notifico all'utente
                string logTotal = exp.Log;
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

        private bool CheckParams()
        {
            if (string.IsNullOrEmpty(_fileDBname))
            {
                MessageBox.Show("Selezionare un file database Access corretto!");
                return false;
            }

            if (!File.Exists(_fileDBname))
            {
                MessageBox.Show("Selezionare un file database Access esistente!");
                return false;
            }
            if (string.IsNullOrEmpty(_connectioString))
            {
                MessageBox.Show("Selezionare una stringa di connessione per il database di arrivo!");
                return false;
            }


            return true;
        }
        
    }
}