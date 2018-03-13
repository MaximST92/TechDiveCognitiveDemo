using System.Collections.Generic;

namespace CognitiveDemo.Core.Model
{
    public class Hair
    {
        public double bald { get; set; }
        public bool invisible { get; set; }
        public List<HairColor> hairColor { get; set; }
    }
}