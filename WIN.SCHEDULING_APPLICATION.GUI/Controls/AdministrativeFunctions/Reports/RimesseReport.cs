using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using System.Collections.Generic;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports
{
    public partial class RimesseReport : DevExpress.XtraReports.UI.XtraReport
    {
        public RimesseReport()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //object gg = sender;
            if (mainLabel.Text.ToLower() == "tesseramento")
                mainLabel.Text = String.Format("{0} {1}", mainLabel.Text, this.Tag);
            if (secondLabel.Text.EndsWith(":"))
                secondLabel.Text = String.Format("{0} {1}", secondLabel.Text, AbstractMovimentoContabile.GetLastMovivimentoDate(this.DataSource as IList).ToShortDateString());//GetDate((int)this.Tag));
        }


        private string GetDate(int anno)
        {
            IList movimenti = GetListOfRimesse(anno);
            return AbstractMovimentoContabile.GetLastMovivimentoDate(movimenti).ToShortDateString();


        }

        private IList GetListOfRimesse(int anno)
        {
            AbstractAmministrazioneHandler h = MovimentoContabileHandlerFactory.GetMovimentoHandler(TipoMovimernto.RimessaTesseramento);

            IList<IsearchDTO> dtos = new List<IsearchDTO>();
            MovimentoContabileSearchDTO dto = new MovimentoContabileSearchDTO(anno, null, null, null, true);
            dtos.Add(dto);

            h.ExecuteQuery(dtos);

            return h.BindableResults;
        }

    }
}
