using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmAttachments : DevExpress.XtraEditors.XtraForm
    {

        private bool _fileMovedOrCopied = false;
        private string _createdFileName = "";

        public FrmAttachments()
        {
            InitializeComponent();
        }


        public void SetAttachment(string path)
        {
            hyperLinkEdit2.EditValue = path;
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            if (p.UncFileExist(path))
            {
                hyperLinkEdit2.Properties.Image = Properties.Resources.tick_16;
            }
            else
            {
                hyperLinkEdit2.Properties.Image = Properties.Resources.warning_16;
            }
        }

        public void SetDestination(string path)
        {
            hyperLinkEdit1.EditValue = path;
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            if (p.UncFolderExist(path))
            {
                hyperLinkEdit1.Properties.Image = Properties.Resources.tick_16;
            }
            else
            {
                hyperLinkEdit1.Properties.Image = Properties.Resources.warning_16;
            }
        }

        public string CreatedAttachement
        {
            get
            {
                return _createdFileName;
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            try
            {
                if (hyperLinkEdit1.EditValue != null)
                {
                    NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
                    string temp = p.CopyUncFileToLocalTempFolder(hyperLinkEdit1.EditValue.ToString());
                    System.Diagnostics.Process.Start(temp);
                }
                    
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void hyperLinkEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (hyperLinkEdit1.EditValue != null)
                {
                    if (!string.IsNullOrEmpty(hyperLinkEdit1.EditValue.ToString()))
                    {
                        XtraMessageBox.Show(hyperLinkEdit1.EditValue.ToString(), "Percorso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void hyperLinkEdit1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (hyperLinkEdit1.EditValue != null)
            {
                if (!string.IsNullOrEmpty(hyperLinkEdit1.EditValue.ToString()))
                {

                    NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();



                    DirectoryInfo i = p.CreateUncFolderFinfo(hyperLinkEdit1.EditValue.ToString());

                    if (i != null)
                        e.DisplayText = i.Name;
                      
                    
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                hyperLinkEdit1.EditValue = folderBrowserDialog1.SelectedPath;
                if (Directory.Exists(folderBrowserDialog1.SelectedPath))
                    hyperLinkEdit1.Properties.Image = Properties.Resources.tick_16;
                else
                    hyperLinkEdit1.Properties.Image = Properties.Resources.warning_16;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                hyperLinkEdit2.EditValue = openFileDialog1.FileName;
                if (File.Exists(openFileDialog1.FileName))
                    hyperLinkEdit2.Properties.Image = Properties.Resources.tick_16;
                else
                    hyperLinkEdit2.Properties.Image = Properties.Resources.warning_16;
            }
        }

        private void hyperLinkEdit2_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (hyperLinkEdit2.EditValue != null)
            {
                if (!string.IsNullOrEmpty(hyperLinkEdit2.EditValue.ToString()))
                {
                    NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();

                    FileInfo i = p.CretateUncFileFinfo(hyperLinkEdit2.EditValue.ToString());

                    if (i != null)
                        e.DisplayText = i.Name;
                      
                   
                }
            }
        }

        private void hyperLinkEdit2_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            //try
            //{
            //    if (hyperLinkEdit2.EditValue != null)
            //        System.Diagnostics.Process.Start(hyperLinkEdit2.EditValue.ToString());
            //}
            //catch (Exception ex)
            //{
            //    ErrorHandler.Show(ex);
            //}
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {   
                //se non esiste un file da allegare
                if (hyperLinkEdit2.EditValue != null)
                {
                    if (string.IsNullOrEmpty(hyperLinkEdit2.EditValue.ToString()))
                    {
                        XtraMessageBox.Show("Inserire un nome file corretto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
                        FileInfo f = p.CretateUncFileFinfo(hyperLinkEdit2.EditValue.ToString());
                        if (f == null)
                        {
                            XtraMessageBox.Show("File inesistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }


               

                //se non eseguo alcuna azione sul file
                if (((int)(radioGroup1.EditValue)) == 3)
                {
                    _createdFileName = hyperLinkEdit2.EditValue.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                //se non esiste il percorso di destinazione
                if (hyperLinkEdit1.EditValue != null)
                {
                    if (string.IsNullOrEmpty(hyperLinkEdit1.EditValue.ToString()))
                    {
                        XtraMessageBox.Show("Impostare un percorso di destinazione corretto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
                        DirectoryInfo f = p.CreateUncFolderFinfo(hyperLinkEdit1.EditValue.ToString());
                        if (f == null)
                        {
                            XtraMessageBox.Show("Directory inesistente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }


                if (IsFileMovedOrCopied())
                    this.DialogResult = DialogResult.OK;
                else
                    this.DialogResult = DialogResult.Cancel;

                this.Close();

            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        private bool IsFileMovedOrCopied()
        {


            if (((int)(radioGroup1.EditValue)) == 1)
            {
                //copio
                MoveFile(false, chkOver.Checked);
            }
            else if (((int)(radioGroup1.EditValue)) == 2)
            {
                //sposto
                MoveFile(true, chkOver.Checked);
            }
            else
            {
                //non  faccio nulla 
            }


            return _fileMovedOrCopied;
        }


        private void MoveFile(bool move, bool overwrite)
        {
           //prendo il nome del file completo per la destinazione
            //cartella destinazione + nome file da allegare
            _createdFileName = GetAttachmentDestinationName();

            string _uncFolder = GetAttachmentDestinationFolder();
            string _uncFilename = GetAttachmentDestinationFilename();

            //se il file di destinazione non esiste lo copio o lo sposto
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            if (p.CretateUncFileFinfo(_createdFileName )== null)
            {
                DoMove(_uncFolder, _uncFilename, move, false);
                 _fileMovedOrCopied= true;
                 return;
            }
            //se il file di destinazione esiste ed ho impostato il flag di sovrascrittura
            //chiedo nnotifica all'utente
            if (overwrite)
            {
                if (XtraMessageBox.Show("Si sta per sovrascrivere un file esistente. Continuare?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DoMove(_uncFolder, _uncFilename, move, true);
                    _fileMovedOrCopied = true;
                    return;
                }
                else
                {
                    _fileMovedOrCopied = false;
                    return;
                }
            }

            //se il file di destinazione esiste e non ho impostato il flag di sovrascrittura
            //chiedo nnotifica all'utente di rinominare il file di destinazione
            if (XtraMessageBox.Show("Il file selezionato è gia esistente nella cartella di destinazione. Il sistema rinominerà il file selezionato per copiarlo o spostarlo nella cartella prescelta. Continuare?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //costruisco il nuovo nome del file
                string newName = CostruisciNuovoNomeFile();
                _createdFileName = Path.Combine(hyperLinkEdit1.EditValue.ToString(), newName);
                DoMove(_uncFolder, newName, move, false);
                _fileMovedOrCopied = true;
                return;
            }


            _fileMovedOrCopied = false;
        }
        



        private string CostruisciNuovoNomeFile()
        {
            int i = 1;
            //destinazione
            string m_destination = hyperLinkEdit1.EditValue.ToString();
            //nome del file
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            string m_FileRegistry = p.CretateUncFileFinfo(hyperLinkEdit2.Text).Name ;

            string temp = System.IO.Path.Combine(m_destination, m_FileRegistry);
            while (p.UncFileExist(temp))
            {
                temp = "";
                temp = String.Format("{0}-{1}", i, m_FileRegistry);
                temp = Path.Combine(m_destination, temp);
                i++;
            }
            return String.Format("{0}-{1}", i-1, m_FileRegistry); 
        }


       
        private string GetAttachmentDestinationName()
        {
            //destinazione
            string m_destination = hyperLinkEdit1.EditValue.ToString();
            //nome del file
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            FileInfo a = p.CretateUncFileFinfo(hyperLinkEdit2.Text);
            string m_FileRegistry = a.Name;

            return System.IO.Path.Combine(m_destination, m_FileRegistry);
        }


        private string GetAttachmentDestinationFolder()
        {
            //destinazione
            return hyperLinkEdit1.EditValue.ToString();

        }

        private string GetAttachmentDestinationFilename()
        {

            //nome del file
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            FileInfo a = p.CretateUncFileFinfo(hyperLinkEdit2.Text);
            return a.Name;


        }


        private void DoMove(string foldername, string filename, bool move, bool overwrite)
        {
            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
            p.CopyLocalFileToUncFolder(hyperLinkEdit2.EditValue.ToString(), foldername ,filename, overwrite);
            //if (move)
            ////File.Move(hyperLinkEdit2.EditValue.ToString(), fileName);
            //else
            //    File.Copy(hyperLinkEdit2.EditValue.ToString(), fileName, overwrite);

        }

        private void hyperLinkEdit2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (hyperLinkEdit2.EditValue != null)
                {
                    if (!string.IsNullOrEmpty(hyperLinkEdit2.EditValue.ToString()))
                    {
                        XtraMessageBox.Show(hyperLinkEdit2.EditValue.ToString(), "Percorso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        




    }
}