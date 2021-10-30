using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_K35_Inf.Classes.Exceptions
{
    public class NetworkDataBufferIsEmpty : Exception
    {
        public NetworkDataBufferIsEmpty(string a_sBufferName) : 
            base($"<{a_sBufferName}> - bufor danych nie istnieje!")
        {
        }
    }
}
