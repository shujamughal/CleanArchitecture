using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerServices(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            var client = _httpClientFactory.CreateClient("MyAPI");
            var response = await client.GetAsync("Customer");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomerViewModel>>(content);
                return customers;
            }
            return new List<CustomerViewModel>();
        }

        public Task<CustomerDetailsViewModel> GetCustomerDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
