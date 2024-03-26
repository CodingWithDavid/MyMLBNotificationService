using System.Threading.Tasks;

//locals
using MLBNotificationService.Data;

namespace MLBNotificationService.Service
{
    internal static class EmailSender
    {
        public static bool SendEmailNotification(UserProfile user, MessageModel game, string message)
        {
            bool result = false;
            PostEmailModel postEmail = new()
            {
                API_Key = "ADD_YOUR_API_KEY_HERE",
                To = [user.Email],
                Sender = "ADD_YOUR_EMAIL_HERE",
                Subject = $"{game.TeamName} Game Today",
            };

            if (message.Contains("!DOCTYPE html"))
            {
                postEmail.HTML_Body = message;
            }
            else
            {
                postEmail.Text_Body = message;
            }

            //send message
            SMTP2GoAPIService _emailService = new();
            result = _emailService.PostMessageAsync(postEmail).Result;
            if (!result)
            {
                Task.Delay(5000);
                //wait then retry
                result = _emailService.PostMessageAsync(postEmail).Result;
            }
           return result;
        }

        public static bool SendTextNotification(UserProfile user, MessageModel game, string message)
        {
            bool result = false;
            PostEmailModel postEmail = new()
            {
                API_Key = "ADD_YOUR_API_KEY_HERE",
                To = [user.PhoneNumber],
                Sender = "ADD_YOUR_EMAIL_HERE",
                Subject = $"{game.TeamName} Game Today",
                Text_Body = message
            };

            //send message
            SMTP2GoAPIService _emailService = new();
            result = _emailService.PostMessageAsync(postEmail).Result;
            if (!result)
            {
                Task.Delay(5000);
                //wait then retry
                result = _emailService.PostMessageAsync(postEmail).Result;
            }
            return result;
        }
    }
}
