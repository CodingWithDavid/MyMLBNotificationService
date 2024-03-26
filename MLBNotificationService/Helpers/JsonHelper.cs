using System;

//3rd party
using Newtonsoft.Json;

namespace MLBNotificationService
{
    internal class JsonHelper
    {
        public static T Deserialize<T>(string input) where T : class
        {
            if (input.IsNotEmpty())
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(input)!;
                }
                catch (Exception ex)
                {
                    return (T)Activator.CreateInstance(typeof(T))!;
                }
            }
            else
            {
                return (T)Activator.CreateInstance(typeof(T))!;
            }
        }
    }
}
