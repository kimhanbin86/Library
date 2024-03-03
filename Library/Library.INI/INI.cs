using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.INI
{
    public static class INI
    {
        public static string GetString(string section, string key, string file, int capacity = 512)
        {
            StringBuilder sb = new StringBuilder(capacity);
            DLL.GetPrivateProfileString(section, key, string.Empty, sb, (uint)sb.Capacity, file);
            return sb.ToString();
        }

        public static bool WriteString(string section, string key, string value, string file)
        {
            return DLL.WritePrivateProfileString(section, key, value, file);
        }
    }
}
