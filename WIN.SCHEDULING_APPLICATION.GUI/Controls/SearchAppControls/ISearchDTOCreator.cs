using System;
using System.Collections.Generic;
using System.Text;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;

namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    public interface ISearchDTOCreator
    {
        IsearchDTO CreateDTO();
    }
}
