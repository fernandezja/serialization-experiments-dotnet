using REDox.Json;
using REDoxExampleConsoleApp;
using REDoxExampleConsoleApp.Entities;

#if !UNIT_TESTS
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

// Serialize and deserialize the Jedi
var json = StarwarsGalaxySerializer.Serialize(yoda);
var restored = StarwarsGalaxySerializer.Deserialize(json);

Console.WriteLine("Serialized Yoda:");
Console.WriteLine(json);
Console.WriteLine();
Console.WriteLine($"Restored Jedi: {restored?.Name}, age {restored?.Age}, rank {restored?.Rank}");
Console.WriteLine();

// Parse the JSON into REDox's editable token DOM and change it in place
using var doc = JsonDocument.Parse(json);

var root = doc.RootElement.AsObject();
root["Age"] = 901;                       
root["Rank"] = "Legendary Grand Master";   
root.Add("SpeciesNote", "A mysterious long-lived species");
root.Remove("IsAlive");                  

var traits = root["Traits"].AsArray();
traits.Add("Calm under pressure");         
traits.Insert(0, "Ancient"); 
traits.RemoveAt(3);

var editedJson = doc.RootElement.ToJsonString();

Console.WriteLine("Edited Yoda document:");
Console.WriteLine(editedJson);
#endif
