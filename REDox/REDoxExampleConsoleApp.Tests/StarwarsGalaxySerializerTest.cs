using System.Linq;
using Xunit;
using REDoxExampleConsoleApp.Entities;

namespace REDoxExampleConsoleApp.Tests
{
    public class StarwarsGalaxySerializerTest
    {
        [Fact]
        public void SerializeAndDeserialize_Jedi_RestoresValues()
        {
            var yoda = new Jedi
            {
                Name = "Yoda",
                Age = 900,
                Species = "Unknown",
                Homeworld = "Unknown",
                Affiliation = "Jedi Order",
                Rank = "Grand Master",
                LightsaberColor = "Green",
                ForceAbilities = new[] { "Telekinesis", "Force healing", "Force lightning resistance" },
                Traits = new[] { "Wise", "Patient", "Short", "Powerful" },
                IsAlive = false
            };

            var json = StarwarsGalaxySerializer.Serialize(yoda);
            var restored = StarwarsGalaxySerializer.Deserialize(json);

            Assert.NotNull(restored);
            Assert.Equal(yoda.Name, restored!.Name);
            Assert.Equal(yoda.Age, restored.Age);
            Assert.Equal(yoda.Rank, restored.Rank);
            Assert.Equal(yoda.ForceAbilities.Length, restored.ForceAbilities.Length);
            Assert.True(restored.Traits.Contains("Wise"));
            Assert.Equal(yoda.IsAlive, restored.IsAlive);
        }
    }
}
