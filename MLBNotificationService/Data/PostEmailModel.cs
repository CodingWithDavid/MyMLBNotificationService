
using System.Text.Json.Serialization;

namespace MLBNotificationService.Data
{
    public class PostEmailModel
    {
        [JsonPropertyName("api_key")]
        public string API_Key { get; set; } = "ADD_YOUR_API_KEY_HERE";

        [JsonPropertyName("to")]
        public List<string> To { get; set; } = new();

        [JsonPropertyName("sender")]
        public string? Sender { get; set; }

        [JsonPropertyName("subject")]
        public string? Subject { get; set; }

        [JsonPropertyName("text_body")]
        public string? Text_Body { get; set; }

        [JsonPropertyName("html_body")]
        public string? HTML_Body { get; set; }
    }
}
