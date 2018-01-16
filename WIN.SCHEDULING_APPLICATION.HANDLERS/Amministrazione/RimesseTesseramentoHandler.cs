using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione;
using System.ComponentModel;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.Amministrazione
{
    public class RimesseTesseramentoHandler : AbstractAmministrazioneHandler
    {

       // protected IBindingList _bindableResults = new BindingList<AbstractMovimentoContabile>();


        public override string ObjectTypeName
        {
            get { return "TesseramentoRimessa"; }
        }

        
    }
}