using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class ConfrontoRimessaImpegno
    {
        public double ImportoRimessa { get; set; }
        public double ImportoImpegno { get; set; }


        private double Differenza
        {
            get
            {
                return ImportoImpegno - ImportoRimessa;
            }
            set
            {
                //
            }
            
        }

        public string Provincia { get; set; }
        public string Regione { get; set; }
        public int RegioneId { get; set; }

    }
}
