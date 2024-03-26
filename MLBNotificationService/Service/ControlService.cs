using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

//locals
using MLBNotificationService.Data;


namespace MLBNotificationService.Service
{
    public class ControlService : IControlService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ControlService> _log;

        private SMTP2GoAPIService _emailService = new();
        

        public ControlService(ILogger<ControlService> log, IConfiguration config)
        {
            _config = config;
            _log = log;
        }

        public async Task Run()
        {
            _log.LogInformation("Service Starting...");

            //Get the users
            var profiles = UserService.GetAllProfiles();

            if (profiles.Count() == 0)
            {
                _log.LogInformation("No Users Found");
                return;
            }

            //Get the Current Team Data
            CurrentTeamData teamData = await MLBService.GetCurrentTeamData();
            if (teamData.StatusCode != 200)
            {
                _log.LogInformation("No Team Data Found");
                return;
            }

            DailyGameService dailyService = new(_log, _config);
            var result = await dailyService.ProcessTodaysGames(profiles, teamData);

            _log.LogInformation("Service Completed");
        }
    }
}
