using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_K35_Inf.Classes.Exceptions
{
    public class MessageFactoryTypeNotFound : Exception
    {
        public MessageFactoryTypeNotFound(string a_sTypeName) :
            base($"Nie odnaleziono w fabryce typu <{a_sTypeName}>!")
        {
        }
    }
}
