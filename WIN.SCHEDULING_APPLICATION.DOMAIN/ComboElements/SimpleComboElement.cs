using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements
{
    public class SimpleComboElement : AbstractPersistenceObject,IComparable
    {

        protected int _color;
        public int Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(base.Descrizione))
                ValidationErrors.Add("Impossibile salvare l'elemento selezionato. Descrizione non valida!");
        }


        public override string ToString()
        {
            return base.Descrizione;
        }


        #region IComparable Membri di

        public int CompareTo(object obj)
        {
            SimpleComboElement c = obj as SimpleComboElement;
            if (c!=null)
                return String.Compare(this.Descrizione,c.Descrizione);
            else
                return String.Compare(this.Descrizione, "");
        }

        #endregion
    }
}
