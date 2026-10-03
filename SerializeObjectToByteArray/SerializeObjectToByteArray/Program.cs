using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeObjectToByteArray
{
    /// <summary>
    /// IMPORTANT:
    ///     -   BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps
    ///          https://docs.microsoft.com/es-es/dotnet/core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete
    ///
    /// PROOF OF CONCEPT ONLY — NOT RECOMMENDED FOR PRODUCTION!!!
    /// The setting only enables BinaryFormatter on runtimes that still support it.
    /// This project targets .NET 10, where BinaryFormatter throws
    /// PlatformNotSupportedException. It is obsolete and vulnerable; never deserialize
    /// untrusted data.
    ///
    /// Anyone who copies or enables this setting in another application does so at
    /// their own risk and is solely responsible for assessing its security impact.
    ///
    /// Remove this setting and migrate to a supported serialization format before
    /// using this code in production.
    /// </summary>
    class Program
    {
        internal static void Main(string[] args)
        {
            var hashTable = new Hashtable();
            hashTable.Add(1, new Jedi { Id = 11, Name= "Yoda" });
            hashTable.Add(2, new Jedi { Id = 22, Name= "Luke Skywalker" });
            hashTable.Add(3, new Jedi { Id = 33, Name= "Obi-Wan Kenobi" });
            hashTable.Add(4, new Jedi { Id = 44, Name = "Qui-Gon Jinn" });

            var dataSerialize = ObjectToByteArray(hashTable);
            string dataSerializeText = System.Text.Encoding.UTF8.GetString(dataSerialize);

            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Data Serialize Byte Array: ");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(dataSerializeText);

            Console.WriteLine();
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("Data Deserialize to Object: ");
            Console.WriteLine(new string('-', 70));
            var hashTableUnserialize = ByteArrayToObject<Hashtable>(dataSerialize);
            foreach (var key in hashTableUnserialize.Keys)
            {
                var jedi = (Jedi)hashTableUnserialize[key];
                Console.WriteLine("Jedi {0} > {1}", jedi.Id, jedi.Name);
            }

            Console.ReadKey();
        }

        internal static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        internal static T ByteArrayToObject<T>(byte[] data)
        {
            ArgumentNullException.ThrowIfNull(data);

            using (MemoryStream ms = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                ms.Write(data, 0, data.Length);
                ms.Seek(0, SeekOrigin.Begin);
                T obj = (T)binaryFormatter.Deserialize(ms);
                return obj;
            }
        }
    }
}
