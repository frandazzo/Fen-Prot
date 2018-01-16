using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using System.Collections.Generic;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports
{
    public partial class QuacPerRegioneReport : DevExpress.XtraReports.UI.XtraReport
    {
        public QuacPerRegioneReport()
        {
            InitializeComponent();
        }

        private void QuacPerRegioneReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string anno = "";
            string causale = "";

            string[] a = this.Tag.ToString().Split('#');
            anno = a[0];

            if (a.Length == 2)
                causale = a[1];
            if (string.IsNullOrEmpty(causale))
                causale = "Industria - Artigianato - Cooperative - Regionali";

            conlabel.Text = causale;
            if (mainLabel.Text.EndsWith("contrattuale"))
                mainLabel.Text = String.Format("{0} {1}", mainLabel.Text, anno);
            if (secondLabel.Text.EndsWith(":"))
                secondLabel.Text = String.Format("{0} {1}", secondLabel.Text, GetDate(Convert.ToInt32(this.Tag.ToString().Replace("#",""))));
        }


        private string GetDate(int anno)
        {

            IList movimenti = GetListOfQuac(anno);
            return AbstractMovimentoContabile.GetLastMovivimentoDate(movimenti).ToShortDateString();


        }

        private IList GetListOfQuac(int anno)
        {
            QuacHandler h = new QuacHandler();

            IList<CausaleAmministrativa> causali = new List<CausaleAmministrativa>();
            
            MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(anno, null, null, null, false);

            IList<IsearchDTO> cli = new List<IsearchDTO>();
            cli.Add(dto);

           return h.ExecuteQuery(cli);
        }
    }
}
