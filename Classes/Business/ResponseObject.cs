using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zIinz_3_K35_Inf.Classes.Business
{
    [DataContract]
    public class ResponseObject : AutoInitXmlStorage<ResponseObject>
    {
        [DataMember]
        public string ResponseString { get; set; }
        [DataMember]
        public int ResponseCode { get; set; }

        public ResponseObject()
        {
            ResponseString = "Brak odpowiedzi";
            ResponseCode = -1;
        }

        public override string ToString()
        {
            return $"[ResponseString={ResponseString}|ResponseCode={ResponseCode}]";
        }
    }
}
