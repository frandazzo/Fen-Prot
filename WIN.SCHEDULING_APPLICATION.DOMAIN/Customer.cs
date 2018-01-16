using WIN.BASEREUSE;
using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class Customer: AbstractPersona,IComparable
    {


        public Customer()
        {
            this.DataNascita = DateTime.MinValue;
        }
        //private string _partitaIva = "";

        //public string PartitaIva
        //{
        //    get
        //    {
        //        return _partitaIva;
        //    }
        //    set
        //    {
        //        _partitaIva = value;
        //    }
        //}

 

        private bool _is_Private;

        public bool Is_Private
        {
            get
            {
                return _is_Private;
            }
            set
            {
                _is_Private = value;
            }
        }

        private Resource  _resource = null;

        public Resource Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }
     

        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(base.Cognome))
                ValidationErrors.Add("Inserire un cognome valido per il contatto!");

            
            if (_resource == null)
                ValidationErrors.Add("Inserire un raggruppamento valido per il contatto!");
        }


        //protected  string m_Responsable = "";
        //public  string Responsable
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(m_Responsable))
        //            return m_Responsable.ToUpper();
        //        return m_Responsable;
        //    }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //            m_Responsable = value.ToUpper();
        //        else
        //            m_Responsable = "";
        //    }
        //}


        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Matricola { get; set; }

        private bool _isAbbonato;

        public bool IsAbbonato
        {
            get
            {
                return _isAbbonato;
            }
            set
            {
                _isAbbonato = value;
            }
        }

        public override string ToString()
        {
            return base.CompleteName  ;
        }


        public string OtherDataSummary
        {
            get
            {
                StringBuilder b = new StringBuilder();

                if (!string.IsNullOrEmpty(Marca))
                    b.Append(string.Format("Marca: {0}; ",Marca));

                if (!string.IsNullOrEmpty(Modello))
                    b.Append(string.Format("Modello: {0}; ", Modello));

                if (!string.IsNullOrEmpty(Matricola))
                    b.Append(string.Format("Matricola: {0}; ", Matricola));

                string b1 = "";
                if (IsAbbonato)
                {
                    b1 = "Abbonato: Si";
                    b.Append(b1);
                }


                return b.ToString();
            }

        }



        #region IComparable Membri di

        public int CompareTo(object obj)
        {
            Customer c = obj as Customer;
            if (c != null)
                return String.Compare(this.CompleteName, c.CompleteName);
            else
                return String.Compare(this.CompleteName, "");
        }

        #endregion
    }



}
