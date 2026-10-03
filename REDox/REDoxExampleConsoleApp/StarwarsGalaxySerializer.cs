using System;
using REDox.Json;
using REDoxExampleConsoleApp.Entities;

namespace REDoxExampleConsoleApp
{
    public class StarwarsGalaxySerializer
    {
        public static string Serialize(Jedi jedi)
        {
            return JsonSerializer.Serialize(jedi);
        }

        public static Jedi? Deserialize(string json)
        {
            return JsonSerializer.Deserialize<Jedi>(json);
        }
    }
}
