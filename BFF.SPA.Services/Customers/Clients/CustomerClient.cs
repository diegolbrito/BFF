using BFF.SPA.Services.Customers.Clients.Interfaces;
using BFF.SPA.Services.Customers.Models;
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

        public CustomerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://example.com.br/v1/customers");
        }
        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"/{id}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var content = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Customer>(content);
                }
            }
            return default;
        }
    }
}
