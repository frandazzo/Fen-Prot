using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.MovimentoInitializzationStrategies
{
    public interface IInitializzationStrategy
    {
        void InitializeControls(MovimentoForm form, bool forCreation);
    }
}
