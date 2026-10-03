using System;
using System.Collections.Generic;
using System.Text;

namespace REDoxExampleConsoleApp.Entities
{
    public sealed class Jedi
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Species { get; set; }
        public string? Homeworld { get; set; }
        public string? Affiliation { get; set; }
        public string? Rank { get; set; }
        public string? LightsaberColor { get; set; }
        public string[] ForceAbilities { get; set; } = Array.Empty<string>();
        public string[] Traits { get; set; } = Array.Empty<string>();
        public bool IsAlive { get; set; }
    }
}

