using System;
using System.Text.Json;
using System.Threading.Tasks;

//locals
using MLBNotificationService.Data;

//3rd party
using RestSharp;

namespace MLBNotificationService.Service
{
    public static class MLBService
    {
        public static async Task<GameDayData> GetGame(string date)
        {
            GameDayData result = new();

            if (date.IsEmpty())
            {
                date = DateTime.Now.ToString("yyyyMMdd");
            }

            string url = $"https://tank01-mlb-live-in-game-real-time-statistics.p.rapidapi.com/getMLBGamesForDate?gameDate={date}";

            var client = new RestClient();
            var request = new RestRequest(url);
            request.AddHeader("X-RapidAPI-Key", "ADD_YOUR_API_KEY_HERE");
            request.AddHeader("X-RapidAPI-Host", "tank01-mlb-live-in-game-real-time-statistics.p.rapidapi.com");
            var response = client.ExecuteGet(request);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            result = JsonSerializer.Deserialize<GameDayData>(response.Content!, options)!;

            if(result.StatusCode != 200)
            {
                result = new ();
                Console.WriteLine($"Error getting games: {result.StatusCode}");
            }

            await Task.CompletedTask;
            return result;

        }

        public static async Task<CurrentTeamData> GetCurrentTeamData()
        {
            CurrentTeamData result = new ();

            string url = $"https://tank01-mlb-live-in-game-real-time-statistics.p.rapidapi.com/getMLBTeams?teamStats=false&topPerformers=false";

            var client = new RestClient();
            var request = new RestRequest(url);
            request.AddHeader("X-RapidAPI-Key", "ADD_YOUR_API_KEY_HERE");
            request.AddHeader("X-RapidAPI-Host", "tank01-mlb-live-in-game-real-time-statistics.p.rapidapi.com");
            var response = client.ExecuteGet(request);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //try again
                await Task.Delay(1000);
                response = client.ExecuteGet(request);
            }

            try
            {
                result = JsonHelper.Deserialize<CurrentTeamData>(response.Content!)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting games: {ex.Message}");
            }   

            if (result.StatusCode != 200)
            {
                //could not deserialize the content
                result = new ();
                Console.WriteLine($"Error getting games: {result.StatusCode}");
            }

            await Task.CompletedTask;
            return result;

        }

        public static async Task<GeneralGameInfo> GetGeneralGameInfo(string gameId)
        {
            GeneralGameInfo result = new ();

            if (gameId.IsEmpty())
            {
                return result;
            }

            string url = $"https://tank01-mlb-live-in-game-real-time-statistics.p.rapidapi.com/getMLBGameInfo?gameID={gameId}";

            var client = new RestClient();
            var request = new RestRequest(url);
            request.AddHeader("X-RapidAPI-Key", "ADD_YOUR_API_KEY_HERE");
            request.AddHeader("X-RapidAPI-Host", "tank01-mlb-live-in-game-real-time-statistics.p.rapidapi.com");
            var response = client.ExecuteGet(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //try again
                await Task.Delay(1000);
                response = client.ExecuteGet(request);
            }

            result = JsonHelper.Deserialize<GeneralGameInfo>(response.Content!)!;

            if (result.StatusCode != 200)
            {
                //could not deserialize the content
                result = new GeneralGameInfo();
                Console.WriteLine($"Error getting games: {result.StatusCode}");
            }

            await Task.CompletedTask;
            return result;
        }
    }
}
