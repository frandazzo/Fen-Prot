using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements;
using System.Collections;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class Document : AbstractPersistenceObject
    {
        private DateTime _date = DateTime.Now;
        private string _subject;
        private DocumentScope _scope;
        private string _responsable;
        private Operator _operator;
        private IList _contacts = new ArrayList();
        private DocumentType _type;
        private PriorityType _priority = PriorityType.Normale;
        private string _contactList;
        private string _attachmentList;
        private IList _attachments = new ArrayList();
        private IDocumentBody _body = new DocumentBody();
        private DocumentNature _nature = DocumentNature.Interno;
        private string _protocol;

        public bool ContainsAttachments
        {
            get { return !string.IsNullOrEmpty(_attachmentList); }
        }
        public string PriorityToString
        {
            get { return _priority.ToString(); }
        }

        private void CalculateContactListString()
        {
            _contactList = "";
            foreach (Customer item in _contacts)
            {
                _contactList += item.ToString() + "; ";
            }
        }

        private void CalculateAttachmentListString()
        {
            _attachmentList = "";
            foreach (AttachmentForDocument item in _attachments)
            {
                _attachmentList += item.ToString() + "; ";
            }
        }

        public string NatureToString
        {
            get { return _nature.ToString(); }
        }


        protected override void DoValidation()
        {
            if (string.IsNullOrEmpty(_subject))
                ValidationErrors.Add("Inserire un oggetto valido per il documento");

            if (_scope == null)
                ValidationErrors.Add("Inserire una cartella valida per il documento");

            if (_type == null)
                ValidationErrors.Add("Inserire una causalea valida per il documento");


            foreach (AttachmentForDocument item in _attachments)
            {
                if (!item.IsValid())
                    ValidationErrors.Add(GetErrorString(item.ValidationErrors));
            }


            CalculateContactListString();
            CalculateAttachmentListString();
        }

        private string GetErrorString(ArrayList arrayList)
        {
            StringBuilder r = new StringBuilder();
           // r.AppendLine("");
            foreach (string item in arrayList)
            {
                r.AppendLine(item);
            }

            return r.ToString();
        }

        public string Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }
   
        public int Year
        {
            get
            {
                return _date.Year;
            }
          
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }

        public DocumentScope Scope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }

        public string Responsable
        {
            get
            {
                return _responsable;
            }
            set
            {
                _responsable = value;
            }
        }

        public Operator Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                _operator = value;
            }
        }

        public IList Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
            }
        }

        public DocumentType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public PriorityType Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }

        public string ContactList
        {
            get
            {
                return _contactList;
            }
            set
            {
                _contactList = value;
            }
        }

        public string AttachmentList
        {
            get
            {
                return _attachmentList;
            }
            set
            {
                _attachmentList = value;
            }
        }

        public IList Attachments
        {
            get
            {
                return _attachments;
            }
            set
            {
                _attachments = value;
            }
        }

        public IDocumentBody Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
            }
        }

        public DocumentNature Nature
        {
            get
            {
                return _nature;
            }
            set
            {
                _nature = value;
            }
        }



        public enum DocumentNature
        {
            Interno,
            Esterno
        }


        public void CalculateProtocol(ILastProtocolNumberRetriever protocolRetriever)
        {
            //if (base.Key == null)
            //    _protocol = "";

//            _protocol = base.Key.LongValue().ToString() + "/" ;

            if (_type != null)
            {
                if (!string.IsNullOrEmpty(_type.ProtocolCode))
                    _protocol = _type.ProtocolCode;
            }


            _protocol = _protocol + protocolRetriever.GetLastProtocolNumber(_date.Year).ToString() + "/";

            if (_scope != null)
            {
                _protocol += _scope.ProtocolCode + "/";
                _protocol += _scope.ResponsableProtocolCode;
            }
            if (_operator != null)
                _protocol += "/" + _operator.ProtocolCode;

            
        }
    }
}
