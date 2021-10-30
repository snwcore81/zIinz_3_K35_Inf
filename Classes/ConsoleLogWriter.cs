using System;
using System.Collections.Generic;
using System.Text;
using zIinz_3_K35_Inf.Interfaces;

namespace zIinz_3_K35_Inf.Classes
{
    public class ConsoleLogWriter : ILogWriter
    {
        public void Write(string a_sText)
        {
            if (!string.IsNullOrEmpty(a_sText))
            {
                Console.WriteLine(a_sText);
            }
        }
    }
}
