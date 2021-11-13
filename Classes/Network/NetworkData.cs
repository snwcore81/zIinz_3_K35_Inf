using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using zIinz_3_K35_Inf.Classes.Exceptions;

namespace zIinz_3_K35_Inf.Classes.Network
{
    public class NetworkData
    {
        private byte[] m_oBuffer;

        public NetworkData(int a_iBufferSize)
        {
            m_oBuffer = new byte[a_iBufferSize];
            Clear();
        }

        public void Clear()
        {
            Array.Fill<byte>(m_oBuffer, 0);
        }

        public void Resize(int a_iBufferSize)
        {
            if (a_iBufferSize>0 && a_iBufferSize != BufferLength)
            {
                m_oBuffer = new byte[a_iBufferSize];
                Clear();
            }
        }

        public int BufferLength => m_oBuffer.Length;

        public int DataLength(bool a_bWithZero = false)
        {
            int iLength = m_oBuffer.ToList().FindIndex(x => x == 0);

            return (iLength > -1 ? iLength : m_oBuffer.Length) + (a_bWithZero ? 1 : 0);
        }
        public bool HasAnyData => DataLength() > 0;

        public byte[] Buffer
        {
            get => m_oBuffer;
            set
            {
                using var log = Log.DET(this, "=>Buffer");

                Clear();

                if (value == null)
                    throw new NetworkDataBufferIsEmpty("Bufor wejściowy");

                if (value.Length > BufferLength)
                    throw new NetworkDataBufferToLarge("Bufor wejściowy", value.Length, BufferLength);

                Array.Copy(value, m_oBuffer, value.Length);
            }
        }

        public byte[] BufferWithData => Buffer.Take(DataLength()).ToArray();

        public override string ToString()
        {
            string sResult = "Buffer=";

            foreach (var oByte in m_oBuffer)
            {
                sResult += $"[{oByte}] ";
            }

            return sResult;
        }
    }
}
