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

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public partial class FormImpegno : DevExpress.XtraEditors.XtraForm
    {
        private Impegno _impegno;

        public FormImpegno(Impegno impegno)
        {
            InitializeComponent();
            _impegno = impegno;

            LoadData();

        }

        private void LoadData()
        {
            if (_impegno == null)
                return;

            spinEdit1.EditValue = _impegno.gen;
            spinEdit2.EditValue = _impegno.feb;
            spinEdit3.EditValue = _impegno.mar;
            spinEdit4.EditValue = _impegno.apr;
            spinEdit5.EditValue = _impegno.mag;
            spinEdit6.EditValue = _impegno.giu;
            spinEdit7.EditValue = _impegno.lug;
            spinEdit8.EditValue = _impegno.ago;
            spinEdit9.EditValue = _impegno.set;
            spinEdit10.EditValue = _impegno.ott;
            spinEdit11.EditValue = _impegno.nov;
            spinEdit12.EditValue = _impegno.dic;
            spinEdit13.EditValue = _impegno.altreDate;

            spinEdit1as.EditValue = _impegno.genas;
            spinEdit2as.EditValue = _impegno.febas;
            spinEdit3as.EditValue = _impegno.maras;
            spinEdit4as.EditValue = _impegno.apras;
            spinEdit5as.EditValue = _impegno.magas;
            spinEdit6as.EditValue = _impegno.giuas;




            textEdit1.EditValue = _impegno.Provincia.Descrizione;
            spinEdit14.EditValue = _impegno.ImpegnoTotale ;
            spinEdit15.EditValue = _impegno.Rate;
            spinEdit16.EditValue = _impegno.TessereRichieste;



        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                _impegno.TessereRichieste = (int)spinEdit16.Value ;

                _impegno.gen = spinEdit1.Value;
                _impegno.feb = spinEdit2.Value;
                _impegno.mar = spinEdit3.Value;
                _impegno.apr = spinEdit4.Value;
                _impegno.mag = spinEdit5.Value;
                _impegno.giu = spinEdit6.Value;
                _impegno.lug = spinEdit7.Value;
                _impegno.ago = spinEdit8.Value;
                _impegno.set = spinEdit9.Value;
                _impegno.ott = spinEdit10.Value;
                _impegno.nov = spinEdit11.Value;
                _impegno.dic = spinEdit12.Value;
                _impegno.altreDate = spinEdit13.Value;
                _impegno.ImpegnoTotale = _impegno.ImpegnoCalcolato;

                _impegno.genas = spinEdit1as.Value;
                _impegno.febas = spinEdit2as.Value;
                _impegno.maras = spinEdit3as.Value;
                _impegno.apras = spinEdit4as.Value;
                _impegno.magas = spinEdit5as.Value;
                _impegno.giuas = spinEdit6as.Value;

                ImpegnoHandler h = new ImpegnoHandler();

                h.SaveOrUpdate(_impegno);
                
            }
            catch (Exception ex)
            {
              WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
                
            }
        }
    }
}