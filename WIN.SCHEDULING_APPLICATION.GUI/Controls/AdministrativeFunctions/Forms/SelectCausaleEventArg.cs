using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public class SelectCausaleEventArg : EventArgs
    {
        private  CausaleAmministrativa _causale;
        public SelectCausaleEventArg(CausaleAmministrativa causale)
        {
            _causale = causale;
        }

        public CausaleAmministrativa Causale
        {
            get
            {
                return _causale;
            }
        }
    }
}
