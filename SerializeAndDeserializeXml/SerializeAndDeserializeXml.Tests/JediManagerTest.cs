using System.Text;
using Xunit;

namespace SerializeAndDeserializeXml.Tests
{
    public class JediManagerTest
    {
        [Fact]
        public void SerializeSimple()
        {
            var xmlExpected = new StringBuilder()
                                .AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                                .AppendLine("<jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\">")
                                .AppendLine("  <id>1</id>")
                                .AppendLine("  <name>Yoda</name>")
                                .AppendLine("  <planet xsi:nil=\"true\" />")
                                .AppendLine("  <amount />")
                                .Append("</jedi>");

            var jedi = new Jedi()
            {
                Id = 1,
                Name = "Yoda"
            };

            var sut = new JediManager();

            var result = sut.Serialize(jedi);

            Assert.NotEmpty(result);
            Assert.Equal(xmlExpected.ToString(), result);
        }


        [Fact]
        public void SerializeSimpleWithNamespaces()
        {
            var xmlExpected = new StringBuilder()
                                .AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                                .AppendLine("<sw:jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:sw=\"https://www.starwars.com\">")
                                .AppendLine("  <sw:id>1</sw:id>")
                                .AppendLine("  <sw:name>Yoda</sw:name>")
                                .AppendLine("  <sw:planet xsi:nil=\"true\" />")
                                .AppendLine("  <sw:amount />")
                                .Append("</sw:jedi>");

            var jedi = new Jedi()
            {
                Id = 1,
                Name = "Yoda"
            };

            var sut = new JediManager();

            var result = sut.SerializeWithNamespaces(jedi);

            Assert.NotEmpty(result);
            Assert.Equal(xmlExpected.ToString(), result);
        }


        [Fact]
        public void SerializeJediComplete()
        {
            var jedi = new Jedi()
            {
                Id = 1,
                Name = "Yoda",
                Planet = "Demo",
                Amount = 1.23
            };

            var sut = new JediManager();

            var result = sut.Serialize(jedi);

            Assert.NotEmpty(result);
        }


        [Fact]
        public void DeserializeSimple()
        {
            var xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\"><id>1</id><name>Yoda</name><planet xsi:nil=\"true\" /></jedi>";
            
            var sut = new JediManager();

            var result = sut.Deserialize(xmlData);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Yoda", result.Name);
            Assert.Null(result.Planet);
            Assert.Null(result.Amount);
        }

        [Fact]
        public void Deserialize_EmptyPlanetAttribute_Should_ReturnEmptyValue()
        {
            var xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\"><id>1</id><name>Yoda</name><planet /></jedi>";

            var sut = new JediManager();

            var result = sut.Deserialize(xmlData);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Yoda", result.Name);
            Assert.Equal(string.Empty, result.Planet);
            Assert.Null(result.Amount);
        }

        [Fact]
        public void Deserialize_WithoutPlanetAttribute_Should_ReturnEmptyValue()
        {
            var xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\"><id>1</id><name>Yoda</name></jedi>";

            var sut = new JediManager();

            var result = sut.Deserialize(xmlData);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Yoda", result.Name);
            Assert.Null(result.Planet);
        }


        [Fact]
        public void Deserialize_NullAmountAttribute_Should_ReturnNullValue()
        {
            var xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\"><id>1</id><name>Yoda</name><planet /><amount xsi:nil=\"true\" /></jedi>";

            var sut = new JediManager();

            var result = sut.Deserialize(xmlData);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Yoda", result.Name);
            Assert.Equal(string.Empty, result.Planet);
            Assert.Null(result.Amount);
        }

        [Fact]
        public void Deserialize_WithoutAmountAttribute_Should_ReturnEmptyValue()
        {
            var xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\"><id>1</id><name>Yoda</name></jedi>";

            var sut = new JediManager();

            var result = sut.Deserialize(xmlData);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Yoda", result.Name);
            Assert.Null(result.Planet);
        }


        [Fact]
        public void Deserialize_WithAmountElementEmpty_Should_ReturnNullValue()
        {
            var xmlData = "<?xml version=\"1.0\" encoding=\"utf-8\"?><jedi xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"https://www.starwars.com\"><id>1</id><name>Yoda</name><planet /><amount /></jedi>";

            var sut = new JediManager();

            var result = sut.Deserialize(xmlData);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Yoda", result.Name);
            Assert.Equal(string.Empty, result.Planet);
            Assert.Null(result.Amount);
        }



    }
}