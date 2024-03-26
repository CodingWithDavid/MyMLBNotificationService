using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//locals
using MLBNotificationService.Data;

namespace MLBNotificationService.Service
{
    public class DailyGameService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ControlService> _log;

        public DailyGameService(ILogger<ControlService> log, IConfiguration config)
        {
            _config = config;
            _log = log;
        }

        public async Task<bool> ProcessTodaysGames(List<UserProfile> profiles, CurrentTeamData teamData)
        {
            bool result = false;
            //for each user process the team
            foreach (var user in profiles)
            {
                //get the team data
                var team = teamData.Body.Where(x => x.TeamAbv == user.Team).FirstOrDefault();

                if (team == null)
                {
                    _log.LogInformation($"No Team Data Found for {user.Team}");
                    continue;
                }

                //get todays games
                try
                {
                    GameDayData gdData = await MLBService.GetGame(DateTime.Now.ToShortDateString());
                    if (gdData.StatusCode == 200)
                    {
                        var game = gdData.Body.Where(x => x.Home == user.Team || x.Away == user.Team).FirstOrDefault();
                        if (game != null)
                        {
                            //build model for message
                            MessageModel messageModel = new(game, team, user.Team, teamData);

                            //send Text
                            if (user.Email.IsNotEmpty())
                            {
                                //build the template
                                string template = TemplateService.BuildEmailTemplate(messageModel, user);
                                if (template.IsNotEmpty())
                                {
                                    //Send the Message
                                    result = EmailSender.SendEmailNotification(user, messageModel, template);
                                }
                            }

                            //Send Email
                            if (user.PhoneNumber.IsNotEmpty())
                            {
                                //build the template
                                string template = TemplateService.BuildTextTemplate(messageModel, user);
                                if (template.IsNotEmpty())
                                {
                                    //Send the Message
                                    result = EmailSender.SendTextNotification(user, messageModel, template);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _log.LogError($"Error getting games: {ex.Message}");
                }
            }
            return result;
        }
    }
}
