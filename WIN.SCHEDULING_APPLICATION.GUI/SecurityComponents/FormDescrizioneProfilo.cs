using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class FormDescrizioneProfilo : DevExpress.XtraEditors.XtraForm
    {
       private string m_Descrizione;

        public FormDescrizioneProfilo(string descrizione, string caption)
        {
            InitializeComponent();
            this.Text = caption;
            textBox1.Text = descrizione;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            m_Descrizione = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string Descrizione
        {
            get
            {
                return m_Descrizione;
            }
        }
    }
}