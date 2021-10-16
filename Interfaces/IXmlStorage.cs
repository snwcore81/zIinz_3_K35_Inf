using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zIinz_3_K35_Inf.Interfaces
{
    public interface IXmlStorage
    {
        bool FromXml(Stream stream);
        MemoryStream ToXml();
    }
}
