using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using System.Drawing;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.Booking
{
    public class BookingResource : SimpleComboElement
    {

        protected string _imagePath;
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(base.Descrizione))
                ValidationErrors.Add("Impossibile salvare l'elemento selezionato. Descrizione non valida!");
        }

        public Image Image
        {
            get
            {
                try
                {
                    Image myImg = Image.FromFile(_imagePath );
                    return myImg;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        public override string ToString()
        {
            return base.Descrizione;
        }


        #region IComparable Membri di

        //public int CompareTo(object obj)
        //{
        //    BookingResource c = obj as BookingResource;
        //    if (c!=null)
        //        return String.Compare(this.Descrizione,c.Descrizione);
        //    else
        //        return String.Compare(this.Descrizione, "");
        //}

        #endregion
    }
}