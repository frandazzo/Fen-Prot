using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData
{
    class movimento
    {
        public string Provincia { get; set; }
        public DateTime Data { get; set; }
        public decimal Importo { get; set; }
        public int Causale { get; set; }


        public string DescrizioneCausale
        {
            get
            {
                if (Causale == 1)
                    return "Industria";

                if (Causale == 2)
                    return "Artigianato";

                if (Causale == 3)
                    return "Cooperazione";

                if (Causale == 4)
                    return "Regionali";

                return "";

            }
        }

        public Localita Localita { get; set; }
        public Causale CausaleAmministrativa { get; set; }

    }
}
