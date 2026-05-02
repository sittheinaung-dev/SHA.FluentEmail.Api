using System.Net.Http.Json;
using FluentEmail.Core.Models;
using SHA.FluentEmail.Api;

namespace SHA.FluentEmail.MVC.Services
{
    public interface IEmailApiService
    {
        Task<SendResponse> SendEmailAsync(EmailRequestModel model);
    }

    public class EmailApiService : IEmailApiService
    {
        private readonly HttpClient _httpClient;

        public EmailApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7246/");
        }

        public async Task<SendResponse> SendEmailAsync(EmailRequestModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Email", model);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SendResponse>() ?? new SendResponse { ErrorMessages = new List<string> { "Failed to deserialize response" } };
            }

            return new SendResponse
            {
                ErrorMessages = new List<string> { $"API returned {response.StatusCode}: {await response.Content.ReadAsStringAsync()}" }
            };
        }
    }
}
