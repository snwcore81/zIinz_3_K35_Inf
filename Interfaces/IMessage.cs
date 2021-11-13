using System;
using System.Collections.Generic;
using System.Text;
using zIinz_3_K35_Inf.Classes.Network;

namespace zIinz_3_K35_Inf.Interfaces
{
    public interface IMessage
    {
        IMessage ProcessRequest(StateObject Object = null);
        IMessage ProcessResponse(StateObject Object = null);

        NetworkData AsNetworkData(int a_iDataSize = NetworkService.BUFFER_SIZE);
    }
}
