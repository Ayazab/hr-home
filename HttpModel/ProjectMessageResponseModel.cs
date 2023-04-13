using Newtonsoft.Json;

namespace HR_One.HttpModel
{
    public class ProjectMessageResponseModel
    {
        [JsonProperty("error")]
        public int Error { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("data")]
        public List<MessageDetails> MessageDetails { get; set; }
    }

    public class MessageDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("message_status")]
        public int MessageStatus { get; set; }
    }
}
