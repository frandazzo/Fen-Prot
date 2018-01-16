using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    class ProtocolRetrieverProgressive: ILastProtocolNumberRetriever
    {
        IPersistenceFacade _service;

        public ProtocolRetrieverProgressive(IPersistenceFacade service)
        {
            _service = service;
        }

        #region ILastProtocolNumberRetriever Membri di

        public int GetLastProtocolNumber(int year)
        {
            //imposto l'anno ad uno stesso valore
            int progressYear = 2011;

            int result = 0;

            //verifico la presenza del protocollo nell'anno
            object o = _service.ExecuteScalar(string.Format("Select Protocol from App_LastProtocols where Year = {0}", progressYear.ToString()));

            //se non esiste inserisco l'anno con protocollo 1 e lo restituisco
            if (o == null)
            {
                if (DataAccessServices.Instance().PersistenceFacade.DBType == DB.DBType.Access)
                    _service.ExecuteNonQuery(string.Format("Insert into App_LastProtocols ([Year], [Protocol]) values ({0}, {1})", progressYear.ToString(), "1"));
                else
                    _service.ExecuteNonQuery(string.Format("Insert into App_LastProtocols (Year, Protocol) values ({0}, {1})", progressYear.ToString(), "1"));
                return 1;
            }
            if (DataAccessServices.Instance().PersistenceFacade.DBType == DB.DBType.Access)
            {
                _service.ExecuteNonQuery("Update App_LastProtocols set Protocol = Protocol + 1");
                o = _service.ExecuteScalar(string.Format("Select Protocol from App_LastProtocols where Year = {0}", progressYear.ToString()));
            }
            else
                o = _service.ExecuteScalar(string.Format("Update App_LastProtocols set Protocol = Protocol + 1; Select Protocol from App_LastProtocols where Year = {0}", progressYear.ToString()));

            result = Convert.ToInt32(o);

            return result;
        }

        #endregion
    }
}
