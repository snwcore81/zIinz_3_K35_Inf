using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace zIinz_3_K35_Inf.Classes
{
    [DataContract]
    public class AutoInitXmlStorage<T> : XmlStorage<T> where T : class
    {
        public override bool InitializeFromObject(T Object)
        {
            foreach (var property in typeof(T).GetProperties())
            {
                property.SetValue(this, property.GetValue(Object));
            }

            foreach (var field in typeof(T).GetFields())
            {
                field.SetValue(this, field.GetValue(Object));
            }

            return true;
        }
    }
}
