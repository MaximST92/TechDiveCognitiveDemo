using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace maximst.CognitiveDemo.Core.Models
{
    public partial class VisionModel
    {
        [JsonProperty("description")]
        public Description Description { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}
