using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    public class MovimentoContabileEventArg : EventArgs
    {
        public AbstractMovimentoContabile Movimento 
        { 
            get; set; 
        }

        public bool Added { get; set; }

       
    }

    
}
