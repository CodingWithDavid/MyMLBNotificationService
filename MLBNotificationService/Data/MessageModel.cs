namespace MLBNotificationService.Data
{
    public class MessageModel
    {
        public string GameId { get; set; } = "";
        public bool PlayingAtHome { get; set; }
        public string HomeTeam { get; set; } = "";
        public string AwayTeam { get; set; } = "";
        public string GameTime { get; set; } = "";
        public string Record { get; set; }   = "";
        public string TeamName { get; set; } = "";
        public string OpponentTeamName { get; set; }
        public string OpponentTeamLogo { get; set; }
        public string HomeTeamLogo { get; set; }

        public MessageModel(Game gameInfo, Team teamInfo, string userTeam, CurrentTeamData currentTeamData)
        {
            if(userTeam == gameInfo.Home)
            {
                HomeTeam = teamInfo.TeamName;
                AwayTeam = currentTeamData.Body.Where(x => x.TeamAbv == gameInfo.Away).FirstOrDefault()?.TeamName ?? "";
                OpponentTeamName = AwayTeam;
                PlayingAtHome = true;
                HomeTeamLogo = teamInfo.MlbLogo1;
                OpponentTeamLogo = currentTeamData.Body.Where(x => x.TeamAbv == gameInfo.Away).FirstOrDefault()?.MlbLogo1 ?? "";
            }
            else
            {
                AwayTeam = teamInfo.TeamName;
                HomeTeam = currentTeamData.Body.Where(x => x.TeamAbv == gameInfo.Home).FirstOrDefault()?.TeamName ?? "";
                OpponentTeamName = HomeTeam;
                OpponentTeamLogo = teamInfo.MlbLogo1;
                HomeTeamLogo = currentTeamData.Body.Where(x => x.TeamAbv == gameInfo.Home).FirstOrDefault()?.MlbLogo1 ?? "";
            }

            GameTime = gameInfo.GameTime;
            TeamName = teamInfo.TeamName;
            Record = $"{teamInfo.Wins}-{teamInfo.Loss}";
            GameId = gameInfo.GameID;
        }
    }
}
