using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports
{
    public partial class ImpegniTesseramentoPeriodoReport : DevExpress.XtraReports.UI.XtraReport
    {
         private int _anno;
        private string _periodo;


        public ImpegniTesseramentoPeriodoReport(int anno, string periodo)
        {
            InitializeComponent();
            _anno = anno;
            _periodo = periodo;
        }

        private void ImpegniTesseramentoReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
                mainLabel.Text = String.Format("Confronto FINO AL mese {0} dell'anno {1}", _periodo,_anno);
        }

    }
}
