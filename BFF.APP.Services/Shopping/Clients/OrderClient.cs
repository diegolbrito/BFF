using BFF.APP.Services.Shopping.Clients.Interfaces;
using BFF.APP.Services.Shopping.Models;
using BFF.APP.Services.Shopping.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BFF.APP.Services.Shopping.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly HttpClient _httpClient;
        private readonly OrderSettings _settings;

        public OrderClient(HttpClient httpClient, IOptions<OrderSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _httpClient.BaseAddress = new Uri(_settings.BaseAddress);
        }
        public async Task<List<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            var response = await _httpClient.GetAsync($"orders?customer={customerId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<List<Order>>(content);
                }
            }
            return default;
        }
        public Task<bool> HealthCheckAsync() => Task.FromResult(_httpClient.GetAsync("hc").Result.IsSuccessStatusCode);
    }
}
