using Newtonsoft.Json;

namespace maximst.CognitiveDemo.Core.Models
{
    public partial class Description
    {
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("captions")]
        public Caption[] Captions { get; set; }
    }
}