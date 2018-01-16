using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public class CustomerSearchDTO
    {
        public string Descrizione { get; set; }
        public bool IsPrivate { get; set; }
        public string Piva { get; set; }
        public Resource Resource { get; set; }
        public Provincia Province { get; set; }
        public Comune Comune { get; set; }
        public string Cellulare { get; set; }
        public string Mail { get; set; }
        public bool CheckPrivate { get; set; }
        public int MaxResult { get; set; }
        public string Responsable { get; set; }

    }
}
