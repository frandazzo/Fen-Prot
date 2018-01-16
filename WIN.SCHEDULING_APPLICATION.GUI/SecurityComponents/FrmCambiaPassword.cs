using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SECURITY;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class FrmCambiaPassword : DevExpress.XtraEditors.XtraForm
    {
        public FrmCambiaPassword()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            
                if (SecurityManager.Instance.CurrentUser.Password.ToLower() != textEdit1.Text.ToLower())
                {
                    MessageBox.Show("La password di admin non è corretta!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (String.IsNullOrEmpty(textEdit2.Text) || String.IsNullOrEmpty(textEdit3.Text))
                {
                    MessageBox.Show("I campi della nuova password non possono essere nulli", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textEdit2.Text.Length < 5 || textEdit3.Text.Length < 5) 
                { 
                    MessageBox.Show("I campi della nuova password non possono contenere meno di cinque caratteri!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (textEdit2.Text != textEdit3.Text)
                {
                    MessageBox.Show("Ridigitare correttamente la nuova password", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    //se si tratta di applicazione Feneal
                    if (Properties.Settings.Default.Main_OtherApp)
                        DataAccessServices.Instance().PersistenceFacade.ExecuteNonQuery(String.Format("Update Users set Password='{0}' where id=1", textEdit2.Text.ToLower()));
                    else
                        DataAccessServices.Instance().PersistenceFacade.ExecuteNonQuery(String.Format("Update Users set Passwordd='{0}' where id=1", textEdit2.Text.ToLower()));


                    MessageBox.Show("Password modificata con successo. Riavviare l'applicazione per rendere effettive le modifiche", "Messaggio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
          
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(ex);
                }

        }
    }
}