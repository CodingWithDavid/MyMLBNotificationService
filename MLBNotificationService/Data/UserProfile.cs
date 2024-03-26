
namespace MLBNotificationService.Data
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool GameStart { get; set; }
        public bool GameLink { get; set; }
        public bool TeamRecord { get; set; }
        public bool TeamStats { get; set; }
        public int TimeOffSet { get; set; }
    }
}
