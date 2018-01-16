using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports
{
    public partial class QuacAnaliticaPerProvincia : DevExpress.XtraReports.UI.XtraReport
    {
        public QuacAnaliticaPerProvincia()
        {
            InitializeComponent();
        }

        private void QuacAnaliticaPerProvincia_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
                secondLabel.Text = String.Format("{0} {1}", secondLabel.Text, AbstractMovimentoContabile.GetLastMovivimentoDate(this.DataSource as IList).ToShortDateString()); //GetDate((int)this.Tag));
        }


      


        private string GetDate(int anno)
        {
            if (anno == DateTime.Now.Year)
                return DateTime.Now.Date.ToShortDateString();

            return new DateTime(Convert.ToInt32(this.Tag), 12, 31).ToShortDateString();

        }

    }
}
