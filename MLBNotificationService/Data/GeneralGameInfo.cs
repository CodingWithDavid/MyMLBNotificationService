

using System.Text.Json.Serialization;

namespace MLBNotificationService.Data
{
    public class GeneralGameInfo
    {
        public int StatusCode { get; set; }

        [JsonPropertyName("body")]
        public body Body { get; set; } = new body();

        public class body
        {
            public string EspnID { get; set; } = string.Empty;
            public string MlbLink { get; set; } = string.Empty;
            public string GameStatus { get; set; } = string.Empty;
            public long LastUpdated { get; set; } = 0;
            public string Season { get; set; } = string.Empty;
            public string GameDate { get; set; } = string.Empty;
            public string TeamIDHome { get; set; } = string.Empty;
            public string GameTime { get; set; } = string.Empty;
            public string TeamIDAway { get; set; } = string.Empty;
            public string Away { get; set; } = string.Empty;
            public string MlbID { get; set; } = string.Empty;
            public string GameID { get; set; } = string.Empty;
            public string EspnLink { get; set; } = string.Empty;
            public string Home { get; set; } = string.Empty;
        }
    }
}
