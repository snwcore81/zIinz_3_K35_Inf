using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_K35_Inf.Classes.Exceptions
{
    public class StateObjectReferenceIsNull : Exception
    {
        public StateObjectReferenceIsNull() :
            base("Referencja do obiektu ma wartość null!")
        {
        }
    }
}
