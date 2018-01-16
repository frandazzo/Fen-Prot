using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione
{
    public class CausaleAmministrativa : AbstractPersistenceObject,IComparable
    {
        //public override bool Equals(object obj)
        //{
        //    return this.Id.Equals((obj as CausaleAmministrativa).Id);
        //}

        //public override int GetHashCode()
        //{
        //        return base.GetHashCode();
        //}

        public int CompareTo(object obj)
        {
            CausaleAmministrativa c = obj as CausaleAmministrativa;
            if (c != null)
                return String.Compare(this.Descrizione, c.Descrizione);
            else
                return String.Compare(this.Descrizione, "");
        }



        private TipoMovimernto _tipo =  TipoMovimernto.RimessaTesseramento;

        public TipoMovimernto Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }

        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(base.Descrizione))
                ValidationErrors.Add("Descrizione causale mancante");
        }

        public override string ToString()
        {
            return base.Descrizione;
        }


    }

    public enum TipoMovimernto
    {
        IncassoTesseramento,
        PagamentoTesseramento,
        RimessaTesseramento,
        Contribuzione,
        Quac
    }
}
