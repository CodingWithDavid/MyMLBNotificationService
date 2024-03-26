using System;

namespace MLBNotificationService
{
    public static class TimeHelper
    {
        public static string AdjustTime(string gameTime, int timeOffSet)
        {
            string fullDate = gameTime.Replace("p", " pm");
            fullDate = fullDate.Replace("a", " am");
            DateTime dt = DateTime.Parse(fullDate).AddHours(timeOffSet);
            return dt.ToString("h:mm");
        }
    }
}
