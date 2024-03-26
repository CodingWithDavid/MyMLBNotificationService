
namespace MLBNotificationService.Data
{
    public class CurrentTeamData
    {
        public int StatusCode { get; set; }
        public List<Team> Body { get; set; } = default!;
    }

    public class Team
    {
        public string TeamAbv { get; set; } = default!;
        public string TeamCity { get; set; } = default!;
        public string Loss { get; set; } = default!;
        public string TeamName { get; set; } = default!;
        public string MlbLogo1 { get; set; } = default!;
        public string TeamID { get; set; } = default!;
        public string Division { get; set; } = default!;
        public string ConferenceAbv { get; set; } = default!;
        public string EspnLogo1 { get; set; } = default!;
        public string Wins { get; set; } = default!;
        public string Conference { get; set; } = default!;
    }
}