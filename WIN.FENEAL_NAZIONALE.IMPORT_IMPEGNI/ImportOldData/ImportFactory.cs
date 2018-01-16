using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.FENEAL_NAZIONALE.IMPORT_IMPEGNI.ImportOldData
{
    class ImportFactory
    {
        public static abstractImporter GetImporter(string type, string connectioonString, string inputDb)
        {
            if (type == "Rimesse tesseramento")
                return new ImportRimesse(connectioonString, inputDb);

            return new ImportQuac(connectioonString, inputDb);
        
        }
    }
}
