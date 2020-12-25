using Newtonsoft.Json;

namespace SubtitleSynchronizer.Domain.Operator
{
    public class SubtitleOperator
    {
        [JsonProperty("fileContent")]
        public string FileContent { get; set; }

        [JsonProperty("offset")]
        public string Offset { get; set; }
    }
}
