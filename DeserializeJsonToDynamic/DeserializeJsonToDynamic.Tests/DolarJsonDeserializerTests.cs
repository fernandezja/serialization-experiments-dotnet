using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeserializeJsonToDynamic.Tests
{
    [TestClass]
    public class DolarJsonDeserializerTests
    {
        [TestMethod]
        public void ParseDynamic_ReturnsDolarValues()
        {
            const string json = "{\"Dolares\":[{\"Valor\":\"603,31\",\"Fecha\":\"2018-04-27\"}]}";

            JObject result = DolarJsonDeserializer.ParseDynamic(json);

            Assert.AreEqual("603,31", (string)result["Dolares"][0]["Valor"]);
            Assert.AreEqual("2018-04-27", (string)result["Dolares"][0]["Fecha"]);
        }

        [TestMethod]
        public void ParseDynamic_ReturnsEmptyDolaresArray()
        {
            JObject result = DolarJsonDeserializer.ParseDynamic("{\"Dolares\":[]}");

            Assert.AreEqual(0, ((JArray)result["Dolares"]).Count);
        }

        [TestMethod]
        public void ParseDynamic_ThrowsForInvalidJson()
        {
            Assert.ThrowsException<JsonReaderException>(
                () => DolarJsonDeserializer.ParseDynamic("{"));
        }

        [TestMethod]
        public void ParseDynamic_ThrowsForNonObjectRoot()
        {
            Assert.ThrowsException<JsonReaderException>(
                () => DolarJsonDeserializer.ParseDynamic("[]"));
        }

        [TestMethod]
        public void Deserialize_ReturnsDolarValues()
        {
            const string json = "{\"Dolares\":[{\"Valor\":\"603,31\",\"Fecha\":\"2018-04-27\"}]}";

            DolarViewModel result = DolarJsonDeserializer.Deserialize(json);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Dolares.Count);
            Assert.AreEqual("603,31", result.Dolares[0].Valor);
            Assert.AreEqual("2018-04-27", result.Dolares[0].Fecha);
        }

        [TestMethod]
        public void Deserialize_PreservesOrderOfMultipleDolarValues()
        {
            const string json = "{\"Dolares\":[{\"Valor\":\"1\",\"Fecha\":\"2024-01-01\"},{\"Valor\":\"2\",\"Fecha\":\"2024-01-02\"}]}";

            DolarViewModel result = DolarJsonDeserializer.Deserialize(json);

            Assert.AreEqual(2, result.Dolares.Count);
            Assert.AreEqual("1", result.Dolares[0].Valor);
            Assert.AreEqual("2", result.Dolares[1].Valor);
        }

        [TestMethod]
        public void Deserialize_ReturnsEmptyDolaresList()
        {
            DolarViewModel result = DolarJsonDeserializer.Deserialize("{\"Dolares\":[]}");

            Assert.IsNotNull(result.Dolares);
            Assert.AreEqual(0, result.Dolares.Count);
        }

        [TestMethod]
        public void Deserialize_LeavesMissingPropertiesNull()
        {
            DolarViewModel result = DolarJsonDeserializer.Deserialize("{\"Dolares\":[{}]}");

            Assert.IsNull(result.Dolares[0].Valor);
            Assert.IsNull(result.Dolares[0].Fecha);
        }

        [TestMethod]
        public void Deserialize_LeavesDolaresNullWhenPropertyIsMissing()
        {
            DolarViewModel result = DolarJsonDeserializer.Deserialize("{}");

            Assert.IsNotNull(result);
            Assert.IsNull(result.Dolares);
        }

        [TestMethod]
        public void Deserialize_ReturnsNullForJsonNull()
        {
            Assert.IsNull(DolarJsonDeserializer.Deserialize("null"));
        }

        [TestMethod]
        public void Deserialize_ThrowsForInvalidJson()
        {
            Assert.ThrowsException<JsonSerializationException>(
                () => DolarJsonDeserializer.Deserialize("{"));
        }
    }
}
