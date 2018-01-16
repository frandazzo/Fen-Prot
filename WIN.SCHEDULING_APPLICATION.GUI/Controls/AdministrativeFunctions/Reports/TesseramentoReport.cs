using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione;
using System.Collections.Generic;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Reports
{
    public partial class TesseramentoReport : DevExpress.XtraReports.UI.XtraReport
    {
        public TesseramentoReport()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (mainLabel.Text.ToLower() == "tesseramento")
                mainLabel.Text = String.Format("{0} {1}", mainLabel.Text, this.Tag);
            if (secondLabel.Text == "")
                secondLabel.Text = String.Format("Situazione al {0} del tesseramento {1}",  GetDate((int)this.Tag), this.Tag);
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
