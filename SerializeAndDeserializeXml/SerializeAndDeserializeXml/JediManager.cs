using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializeAndDeserializeXml
{
    public class JediManager
    {
        private XmlSerializer _serializer;

        public JediManager()
        {
            _serializer = new XmlSerializer(typeof(Jedi));
        }

        public string Serialize(Jedi jedi) {

            using (var ms = new MemoryStream()) {
                _serializer.Serialize(ms, jedi);
                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);   
                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }

        public string SerializeWithNamespaces(Jedi jedi)
        {
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("sw", "https://www.starwars.com");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
          

            using (var ms = new MemoryStream())
            {
                _serializer.Serialize(stream: ms,
                                      o: jedi, 
                                      namespaces: namespaces);

                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);
                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }


        public Jedi Deserialize(string xmlData)
        {
            using (TextReader reader = new StringReader(xmlData))
            {
                var jedi = (Jedi)_serializer.Deserialize(reader);
                return jedi;
            }
        }


    }
}
