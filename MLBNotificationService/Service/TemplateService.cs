using MLBNotificationService.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MLBNotificationService.Service
{
    internal static class TemplateService
    {
        public static string BuildEmailTemplate(MessageModel game, UserProfile user)
        {
            string location = game.PlayingAtHome ? "VS the" : "at the";

            //get the general game info
            GeneralGameInfo generalInfo = MLBService.GetGeneralGameInfo(game.GameId).Result;
            string result = $"Hello {user.UserName},\n " +
            $"The {game.TeamName} have a game today at {TimeHelper.AdjustTime(game.GameTime, user.TimeOffSet)} {location} {game.OpponentTeamName}\n" +
            $"Team Record:  {game.Record}\n";

            if (generalInfo.StatusCode == 200)
            {
                //read in the email template
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)! + "\\templates\\EmailTemplate1.html";
                result = File.ReadAllText(path);

                //tokeize the template
                result = result.Replace("%%AWAYImage%%", game.OpponentTeamLogo);
                result = result.Replace("%%HOMEImage%%", game.HomeTeamLogo);
                result = result.Replace("%%AWAYName%%", game.AwayTeam);
                result = result.Replace("%%HOMEName%%", game.HomeTeam);
                result = result.Replace("%%STARTTIME%%", TimeHelper.AdjustTime(game.GameTime, user.TimeOffSet));
                result = result.Replace("%%MLBLINK%%\"", generalInfo.Body.MlbLink);
                result = result.Replace("%%ESPNLINK%%\"", generalInfo.Body.EspnLink);
            }
            return result;
        }

        public static string BuildTextTemplate(MessageModel game, UserProfile user)
        {
            string location = game.PlayingAtHome ? "VS the" : "at the";

            string result = $"Hello {user.UserName},\n " +
            $"The {game.TeamName} have a game today at {TimeHelper.AdjustTime(game.GameTime, user.TimeOffSet)} {location} {game.OpponentTeamName}\n" +
            $"Team Record:  {game.Record}\n";

            return result;
        }
    }
}
