using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements
{
    public class DocumentScope : SimpleComboElement
    {
        public string ProtocolCode { get; set; }
        public string ResponsableProtocolCode { get; set; }
        public string Responsable { get; set; }
        public string DefaultPath { get; set; }
        //contiene una lista separata da # di id dei profili che possono vedere la cartella
        public string Visibility { get; set; }


        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(Descrizione))
                ValidationErrors.Add("Descrizione mancante");

            if (string.IsNullOrEmpty(DefaultPath))
                ValidationErrors.Add("Directory di default mancante");
            else
            {
                DirectoryInfo i = new DirectoryInfo(DefaultPath);
                if (!i.Exists)
                    ValidationErrors.Add("Directory di default inesistente");
            }
        }



        public bool IsDefaultpathValid
        {
            get
            {
                if (string.IsNullOrEmpty(DefaultPath))
                    return false;
                else
                {
                    DirectoryInfo i = new DirectoryInfo(DefaultPath);
                    if (!i.Exists)
                        return false;
                }
                return true;
            }
        }

        public string DefaultDirectoryName
        {
            get
            {
                if (IsDefaultpathValid)
                {

                    DirectoryInfo i = new DirectoryInfo(DefaultPath);

                    return i.Name;
                }
                else
                    return "";
            }
        }

       

        public bool IsVisibleFromProfile(List<string> userProfiles, string username)
        {
            if (username.ToLower().Equals("admin"))
                return true;


            //adesso devo verificare che almeno uno dei profili dell'utente loggato sia presente nella visibility 
            String[] visibilityProfiles = DeserializeVisibility();

            foreach (string item in visibilityProfiles)
	        {
                if (userProfiles.FirstOrDefault(z => z.Equals(item)) != null)
                    return true;
	        }

            return false;

        }

        private string[] DeserializeVisibility()
        {
            if (string.IsNullOrEmpty(Visibility))
                return new string[] { };

            return Visibility.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);

        }
    }
}
