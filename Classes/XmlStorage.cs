using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using zIinz_3_K35_Inf.Interfaces;

namespace zIinz_3_K35_Inf.Classes
{
    public static class XmlStorageTypes
    {
        private static readonly List<Type> Types = new List<Type>();

        static XmlStorageTypes()
        {
            Register<Object>();
            Register<Exception>();

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!type.IsGenericType)
                {
                    foreach (var attr in type.GetCustomAttributes())
                    {
                        if (attr.GetType() == typeof(DataContractAttribute))
                        {
                            Register(type);
                            break;
                        }
                    }
                }
            }
        }

        public static void Register(Type type)
        {
            if (!Types.Contains(type))
            {
                Console.WriteLine($"Zarejestrowano:<{type.Name}>");
                Types.Add(type);
            }
        }

        public static void Register<T>()
        {
            Register(typeof(T));
        }

        public static Type[] GetArray() => Types.ToArray();
    }

    [DataContract]
    public abstract class XmlStorage<T> : IXmlStorage where T : class
    {
        public abstract bool InitializeFromObject(T Object);

        public virtual bool FromXml(Stream stream)
        {
            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var oReader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            return InitializeFromObject((T)oSerializer.ReadObject(oReader, false));
        }

        public virtual MemoryStream ToXml()
        {
            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var oStream = new MemoryStream();

            using var oWriter = XmlDictionaryWriter.CreateTextWriter(oStream,Encoding.UTF8);

            oSerializer.WriteObject(oWriter, this);

            return oStream;
        }
    }
}
