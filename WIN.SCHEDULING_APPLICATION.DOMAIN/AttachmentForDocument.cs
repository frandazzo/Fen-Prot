using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using System.IO;
using WIN.SCHEDULING_APPLICATION.DOMAIN.AttachmentAccess;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class AttachmentForDocument : AbstractPersistenceObject
    {
        private Document _parent = null;
        private string _path = "";
        private string _fileName = "";
        private string _note = "";


        public AttachmentForDocument(Document parent)
        {
            _parent = parent;
        }
        public override string ToString()
        {
            return _fileName;
        }

        protected override void DoValidation()
        {
            string all = _fileName;
            if (string.IsNullOrEmpty(all))
                all = "Allegato senza nome";

            if (_parent == null)
                ValidationErrors.Add(string.Format("Nessun documento associato per l'allegato {0}", all));

            if (string.IsNullOrEmpty(_path ))
                ValidationErrors.Add(string.Format("Percorso file nullo per l'allegato {0}", all));


            if (string.IsNullOrEmpty(_fileName))
            {
                ValidationErrors.Add(string.Format("Nome file nullo per l'allegato {0}", all));
                
            }

            //eseguo la verifica solo se trattasi di un nuovo eleemento
            //per assicurarmi che nella base dati non è entrato nulla di corrotto
            //e che le modifiche al file sstem hanno prodotto tale errore
            //if (this.Key == null)
            //    if (!AttachmentExist)
            //        ValidationErrors.Add(string.Format("File inesistente per l'allegato {0}", all));



        }

        public AttachmentForDocument(){}


        public string AttachmentCompletePath
        {
            get
            {
                if (_fileName == null)
                    _fileName = "";
                if (!string.IsNullOrEmpty(_path))
                {
                    if (_path.EndsWith("\\"))
                        return _path + _fileName;
                    else
                        return String.Format("{0}\\{1}", _path, _fileName);
                }
                else
                    return "";
            }
        }


        public void SetAttachment(string filename)
        {

            NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();

            FileInfo f = p.CretateUncFileFinfo(filename);
            if (f == null)
            { 
                throw new ArgumentException("file non esistente"); 
            }
                    
            _fileName = f.Name;
            _path = f.DirectoryName;

        }

        public bool AttachmentExist
        {
            get
            {
                if (string.IsNullOrEmpty(AttachmentCompletePath))
                    return false;
                NetworkFileSystemUtilsProxy p = new NetworkFileSystemUtilsProxy();
                FileInfo f = p.CretateUncFileFinfo(AttachmentCompletePath);
                
                return f != null;
            }
        }


        public string AttachmentName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }
        public Document Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        

    }
}
