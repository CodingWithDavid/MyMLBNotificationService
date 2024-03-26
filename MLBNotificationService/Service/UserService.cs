using System.Collections.Generic;

//locals
using MLBNotificationService.Data;

namespace MLBNotificationService.Service
{
    public static class UserService
    {
        public static List<UserProfile> GetAllProfiles()
        {
            List<UserProfile> result = new();
            //read in file
            var inUsers = FileHelper.TextFileToList("users.dat");

            //parse the file
            result = ParseUsers(inUsers);

            return result;
        }

        private static List<UserProfile> ParseUsers(List<string> inUsers)
        {
            List<UserProfile> result = new();

            foreach (var user in inUsers)
            {
                var fields = user.Split(',');
                var profile = new UserProfile
                {
                    Id = int.Parse(fields[0]),
                    UserName = fields[1].Trim(),
                    Email = fields[2].Trim(),
                    Team = fields[4].Trim(),
                    PhoneNumber = fields[3].Trim(),
                    GameStart = bool.Parse(fields[5].Trim()),
                    GameLink = bool.Parse(fields[6].Trim()),
                    TeamRecord = bool.Parse(fields[7].Trim()),
                    TeamStats = bool.Parse(fields[8].Trim()),
                    TimeOffSet = fields[9].ToInt()
                };
                result.Add(profile);
            }
            return result;
        }
    }
}
