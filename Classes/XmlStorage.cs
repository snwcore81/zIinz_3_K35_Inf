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
                using var log = Log.DEV("XmlStorageTypes", "Register");

                log.PR_DEV($"Zarejestrowano typ:<{type.Name}>");
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
            using var log = Log.DET(this, "FromXml");

            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var oReader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            var bResult = InitializeFromObject((T)oSerializer.ReadObject(oReader, false));

            log.PR_DET($"Result={bResult}");

            return bResult;
        }

        public virtual MemoryStream ToXml()
        {
            using var log = Log.DET(this, "ToXml");

            DataContractSerializer oSerializer = new DataContractSerializer(typeof(T), XmlStorageTypes.GetArray());

            using var oStream = new MemoryStream();

            using var oWriter = XmlDictionaryWriter.CreateTextWriter(oStream,Encoding.UTF8);

            oSerializer.WriteObject(oWriter, this);

            return oStream;
        }
    }
}
