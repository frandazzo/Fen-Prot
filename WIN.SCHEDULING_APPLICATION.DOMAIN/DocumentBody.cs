using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public class DocumentBody : IDocumentBody
    {
        private byte[] _documentBody = null;

        #region IDocumentBody Membri di

        public byte[] Document
        {
            get
            {
                return _documentBody;
            }
            set
            {
                _documentBody = value;
            }
        }

        #endregion
    }
}
