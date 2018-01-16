using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS
{
    public class ProtocolRetriever : ILastProtocolNumberRetriever
    {
        IPersistenceFacade _service;

        public ProtocolRetriever(IPersistenceFacade service)
        {
            _service = service;
        }

        #region ILastProtocolNumberRetriever Membri di

        public int GetLastProtocolNumber(int year)
        {
            int result = 0;

            //verifico la presenza del protocollo nell'anno
            object o = _service.ExecuteScalar(string.Format("Select Protocol from App_LastProtocols where Year = {0}", year.ToString()));

            //se non esiste inserisco l'anno con protocollo 1 e lo restituisco
            if (o == null)
            {
                if (DataAccessServices.Instance().PersistenceFacade.DBType == DB.DBType.Access)
                    _service.ExecuteNonQuery(string.Format("Insert into App_LastProtocols ([Year], [Protocol]) values ({0}, {1})", year.ToString(), "1"));
                else
                    _service.ExecuteNonQuery(string.Format("Insert into App_LastProtocols (Year, Protocol) values ({0}, {1})", year.ToString(), "1"));
                return 1;
            }
            if (DataAccessServices.Instance().PersistenceFacade.DBType == DB.DBType.Access)
            {
                _service.ExecuteNonQuery("Update App_LastProtocols set Protocol = Protocol + 1");
                o = _service.ExecuteScalar(string.Format("Select Protocol from App_LastProtocols where Year = {0}", year.ToString()));
            }
            else
                o = _service.ExecuteScalar(string.Format("Update App_LastProtocols set Protocol = Protocol + 1; Select Protocol from App_LastProtocols where Year = {0}", year.ToString()));

            result = Convert.ToInt32(o);

            return result;
        }

        #endregion
    }
}
