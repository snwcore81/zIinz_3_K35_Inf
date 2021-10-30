using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_K35_Inf.Classes
{
    public static class Extensions
    {
        public static string CleanType(this string a_sTypeName)
        {
            if (!string.IsNullOrEmpty(a_sTypeName) && a_sTypeName.Contains('`'))
            {
                a_sTypeName = a_sTypeName.Substring(0, a_sTypeName.IndexOf('`')) + "<T>";
            }

            return a_sTypeName;
        }

       
    }
}
