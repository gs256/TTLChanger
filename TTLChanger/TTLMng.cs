//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Microsoft.Win32;

namespace TTLChanger
{
    public static class TTLMng
    {
        private static string ttlKeyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters";
        private static RegistryKey rkey = Registry.LocalMachine;
        private static RegistryKey ttlKey = rkey.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", true);

        /// <summary>
        /// Returns default ttl or zero if it's not set
        /// </summary>
        public static int GetDefaultTTL()
        {
            try
            {
                return (int)ttlKey.GetValue("DefaultTTL");
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Sets default ttl                                                                                 //FIXME
        /// </summary>
        public static bool SetDefaultTTL(int value)
        {
            try
            {
                Registry.SetValue(ttlKeyName, "DefaultTTL", value, RegistryValueKind.DWord  );
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Restores default ttl value
        /// </summary>
        public static bool RestoreSystemTTLValue()
        {
            try
            {
                ttlKey.DeleteValue("DefaultTTL");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
