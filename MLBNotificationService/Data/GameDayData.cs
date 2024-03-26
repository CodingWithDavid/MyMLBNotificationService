using System;
using System.Collections.Generic;

namespace MLBNotificationService.Data
{

    public class GameDayData
    {
        public int StatusCode { get; set; } = 0;
        public List<Game> Body { get; set; } = default!;
    }

    public class Game
    {
        public string GameID { get; set; } = default!;
        public string GameType { get; set; } = default!;
        public string Away { get; set; } = default!;
        public string GameTime { get; set; } = default!;   
        public string GameDate { get; set; } = default!;
        public string TeamIDHome { get; set; } = default!;
        public string GameTime_epoch { get; set; } = default!;
        public string TeamIDAway { get; set; } = default!;
        public ProbableStartingPitchers ProbableStartingPitchers { get; set; } = default!;
        public string Home { get; set; } = default!;
    }

    public class ProbableStartingPitchers
    {
        public string Away { get; set; } = default!;
        public string Home { get; set; } = default!;
    }

}
