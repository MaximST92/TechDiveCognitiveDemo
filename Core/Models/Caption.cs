using Newtonsoft.Json;

namespace maximst.CognitiveDemo.Core.Models
{
    public partial class Caption
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }
}