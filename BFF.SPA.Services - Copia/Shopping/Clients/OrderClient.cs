using BFF.SPA.Services.Shopping.Clients.Interfaces;
using BFF.SPA.Services.Shopping.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BFF.SPA.Services.Shopping.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly HttpClient _httpClient;

        public OrderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://example.com.br/v1/orders");
        }
        public async Task<List<Order>> GetOrdersByCustomerAsync(string customerId)
        {
            var response = await _httpClient.GetAsync($"?customer={customerId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<List<Order>>(content);
                }
            }
            return default;
        }
    }
}
