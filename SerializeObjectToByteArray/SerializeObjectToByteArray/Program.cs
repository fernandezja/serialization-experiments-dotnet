using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeObjectToByteArray
{
    /// <summary>
    /// IMPORTANT:
    ///     -   BinaryFormatter serialization methods are obsolete and prohibited in ASP.NET apps
    //          https://docs.microsoft.com/es-es/dotnet/core/compatibility/core-libraries/5.0/binaryformatter-serialization-obsolete
    /// </summary>
    class Program
    {
        static void Main(string[] args)
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

        private static byte[] ObjectToByteArray(object obj)
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

        private static T ByteArrayToObject<T>(byte[] data)
        {
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
