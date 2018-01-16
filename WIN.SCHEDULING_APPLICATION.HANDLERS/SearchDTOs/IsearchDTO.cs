using System;
using System.Collections.Generic;
using System.Text;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs
{
    public interface IsearchDTO
    {
         WIN.TECHNICAL.PERSISTENCE.AbstractBoolCriteria GenerateSql();
    }
}
