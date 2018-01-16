using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APP.GUI.Initializzation
{
    public interface IInitialize
    {
        void Initialize();
        InitializzationType Type { get; }
    }

    public enum InitializzationType
    {
        Security,
        Persistence,
        Geo,
        Licensing,
        DocScopeInitializzation
    }
}
