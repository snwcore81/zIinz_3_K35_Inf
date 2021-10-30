using System;
using System.Collections.Generic;
using System.Text;

namespace zIinz_3_K35_Inf.Classes.Exceptions
{
    public class NetworkDataBufferToLarge : Exception
    {
        public int Length;
        public int MaxLength;

        public NetworkDataBufferToLarge(string a_sBufferName, int a_iLength, int a_iMaxLength) :
            base($"Zbyt duża ilość danych w buforze <{a_sBufferName}>! Rozmiar: {a_iLength} bajt/-ów. Maksymalny: {a_iMaxLength} bajt/-ów")
        {
            Length = a_iLength;
            MaxLength = a_iMaxLength;
        }
    }
}
