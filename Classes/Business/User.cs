using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zIinz_3_K35_Inf.Classes.Business
{
    [DataContract]
    public class User : AutoInitXmlStorage<User>
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Permission { get; set; }
        [DataMember]
        public ResponseObject Response { get; set; }

        public User()
        {
            Response = new ResponseObject();
        }

        public override string ToString()
        {
            return $"[Login={Login}|Password=???|Permission={Permission}|Response={Response}]";
        }
    }
}
