using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WIN.SCHEDULING_APP.GUI
{
    public class MemoryHelper
    {
        private static bool _Toggle = true;

        internal static void ReduceMemory()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Reducing memory...");

                Process loProcess = Process.GetCurrentProcess();
                if (_Toggle)
                {
                    loProcess.MaxWorkingSet = (IntPtr)((int)loProcess.MaxWorkingSet - 1);
                    loProcess.MinWorkingSet = (IntPtr)((int)loProcess.MinWorkingSet - 1);
                }
                else
                {
                    loProcess.MaxWorkingSet = (IntPtr)((int)loProcess.MaxWorkingSet + 1);
                    loProcess.MinWorkingSet = (IntPtr)((int)loProcess.MinWorkingSet + 1);
                }
                _Toggle = !_Toggle;
            }
            catch (Exception x)
            {
                Debug.WriteLine(x);
            }
        } 
    }
}
