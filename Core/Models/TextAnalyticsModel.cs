using System.Collections.Generic;
using Newtonsoft.Json;

namespace maximst.CognitiveDemo.Core.Models
{

    public class TextAnalyticsModel
    {
        [JsonProperty("languageDetection")]
        public LanguageDetection LanguageDetection { get; set; }

        [JsonProperty("keyPhrases")]
        public KeyPhrases KeyPhrases { get; set; }

        [JsonProperty("sentiment")]
        public Sentiment Sentiment { get; set; }
    }

    public class KeyPhrases
    {
        [JsonProperty("documents")]
        public List<KeyPhrasesDocument> Documents { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }

    public class KeyPhrasesDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("keyPhrases")]
        public List<string> KeyPhrases { get; set; }
    }

    public class LanguageDetection
    {
        [JsonProperty("documents")]
        public List<LanguageDetectionDocument> Documents { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }

    public class LanguageDetectionDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("detectedLanguages")]
        public List<DetectedLanguage> DetectedLanguages { get; set; }
    }

    public class DetectedLanguage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iso6391Name")]
        public string Iso6391Name { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public class Sentiment
    {
        [JsonProperty("documents")]
        public List<SentimentDocument> Documents { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }

    public class SentimentDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public class Document
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Documents
    {
        public Documents()
        {
            DocumentsList = new List<Document>();
        }
        [JsonProperty("documents")]
        public List<Document> DocumentsList { get; set; }
    }

}