using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms.MovimentoInitializzationStrategies
{
    public class InitializeQuacStrategy : IInitializzationStrategy
    {
        public void InitializeControls(MovimentoForm form, bool forCreation)
        {
            if (forCreation)
            {
                //date pichek
                form.layoutItemDatapicker.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
          
                //day picker
                form.layoutDayPicker.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //period setting
                form.layoutSuggest.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                //date pichek
                form.layoutItemDatapicker.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //day picker
                form.layoutDayPicker.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                //period setting
                form.layoutSuggest.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            //importo
            form.layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //regione
            form.layoutRegione.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //provincia
            form.layoutProvincia.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //causale
            form.layoutCausale.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //note
            form.layoutNote.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            //layout group title
            form.layoutGroup.Text = "Quac Feneal";

            //form titolo
            form.Text = "Creazione o  aggiornamento quac";
        }
    }
}
