using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using System.IO;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess;

namespace WIN.SCHEDULING_APP.GUI.Forms
{
    public partial class FrmViewAttachment : DevExpress.XtraEditors.XtraForm
    {

        private Document _document;
        private AttachmentForDocument _current;
        private bool _changed;



        public AttachmentForDocument Attachment
        {
            get
            {
                return _current;
            }
        }

        
        public event EventHandler OnChange;
        private bool _new = false;

        private void Change(object subject)
        {
            if (OnChange != null)
                OnChange.Invoke(subject, EventArgs.Empty);
        }


        public FrmViewAttachment(Document document)
        {
            //se uso questo costruttore sto creando un nuovo attachment
            InitializeComponent();
            _document = document;
            _current = new AttachmentForDocument(document);
            _changed = true;
            _new = true;
            LoadEditors();
        }

        public FrmViewAttachment(AttachmentForDocument attachment)
        {
            //se uso questo costruttore sto aggiornamndo un attachment esistente
            InitializeComponent();
            _document = attachment.Parent;
            _current = attachment;
            _new = false;
            LoadEditors();
        }

        private void LoadEditors()
        {
            if (_new)
            {
                txtNote.Text = "";
                hyperLinkEdit1.Text = "-Nessun allegato-";
                hyperLinkEdit1.Properties.Image = Properties.Resources.warning_16;
            }
            else
            {
                txtNote.Text = _current.Note;
                hyperLinkEdit1.EditValue = _current.AttachmentCompletePath;
                if (_current.AttachmentExist)
                {
                    hyperLinkEdit1.Properties.Image = Properties.Resources.tick_16;
                }
                else
                {
                    hyperLinkEdit1.Properties.Image = Properties.Resources.warning_16;
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
                    
                    FileInfo i = p.CretateUncFileFinfo(hyperLinkEdit1.EditValue.ToString());

                    if (i != null)
                        e.DisplayText = i.Name;
                      
                   
                }
            }
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAttachments frm = new FrmAttachments();
                if (_new)
                {
                    frm.SetDestination(_document.Scope.DefaultPath);
                    frm.SetAttachment("-Nessun allegato-");
                }
                else
                {
                    frm.SetDestination(_current.Path);
                    frm.SetAttachment(_current.AttachmentCompletePath);
                }

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    hyperLinkEdit1.EditValue = frm.CreatedAttachement;
                    NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();


                    if (p.UncFileExist(frm.CreatedAttachement))
                    {
                        hyperLinkEdit1.Properties.Image = Properties.Resources.tick_16;
                    }
                    else
                    {
                        hyperLinkEdit1.Properties.Image = Properties.Resources.warning_16;
                    }
                    _current.SetAttachment(frm.CreatedAttachement);
                }
                frm.Dispose();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            _changed = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void txtNote_EditValueChanged(object sender, EventArgs e)
        {
            _changed = true;
        }

        private void hyperLinkEdit1_EditValueChanged(object sender, EventArgs e)
        {
            _changed = true;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            //il form non deve chiudersi se l'oggetto non è corretto
            try
            {
                if (_changed)
                {
                    _current.Note = txtNote.Text;
                    if (!_current.IsValid())
                    {
                        XtraMessageBox.Show("Selezionare un file corretto", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Change(_current);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }
    }
}