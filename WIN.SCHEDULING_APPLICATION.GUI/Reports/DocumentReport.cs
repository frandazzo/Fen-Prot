using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.IO;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;

namespace WIN.SCHEDULING_APP.GUI.Reports
{
    public partial class DocumentReport : DevExpress.XtraReports.UI.XtraReport
    {
        public DocumentReport()
        {
            InitializeComponent();
        }

        private void xrRichText1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IDocumentBody body = this.GetCurrentColumnValue("Body") as IDocumentBody;


            if (body != null)
            {
                if (body.Document != null)
                {
                    using (MemoryStream m = new MemoryStream(body.Document))
                    {

                        XRRichText t = sender as XRRichText;
                        t.LoadFile(m, XRRichTextStreamType.RtfText);

                        //t.Rtf = Encoding.UTF8.GetString(body.Document);
                    }
                }
            }
        }

    }
}
