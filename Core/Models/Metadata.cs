using Newtonsoft.Json;

namespace maximst.CognitiveDemo.Core.Models
{
    public partial class Metadata
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
    }
}