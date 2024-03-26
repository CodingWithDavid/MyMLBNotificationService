using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MLBNotificationService.Service
{
    public class SMTP2GoAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "https://api.smtp2go.com/v3/email/";

        public SMTP2GoAPIService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> PostMessageAsync(object message)
        {
            var json = JsonSerializer.Serialize(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{_apiBaseUrl}send", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> PostMessagenc(object message)
        {
            var json = JsonSerializer.Serialize(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{_apiBaseUrl}send", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
