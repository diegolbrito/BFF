using BFF.SPA.Services.Customers.Clients.Interfaces;
using BFF.SPA.Services.Customers.Models;
using BFF.SPA.Services.Customers.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BFF.SPA.Services.Customers.Clients
{
    public class CustomerClient : ICustomerClient
    {
        private readonly HttpClient _httpClient;
        private readonly CustomerSettings _settings;

        public CustomerClient(HttpClient httpClient, IOptions<CustomerSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseAddress);
        }
        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"customers/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Customer>(content);
                }
            }
            return default;
        }

        public Task<bool> HealthCheckAsync() => Task.FromResult(_httpClient.GetAsync("hc").Result.IsSuccessStatusCode);
    }
}
