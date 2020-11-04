using BFF.APP.Services.Shopping.Clients.Interfaces;
using BFF.APP.Services.Shopping.Models;
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

        public OrderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://example.com.br/v1/");
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
