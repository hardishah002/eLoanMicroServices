using Loan.Application.Interfaces;

namespace Loan.API.Services
{
    public class CustomerServiceClient : ICustomerServiceCLient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public CustomerServiceClient(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> ValidateCustomerAsync(Guid customerId)
        {
            var token = _contextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("Bearer", ""));

            var result = await _httpClient.GetAsync($"/api/customers/{customerId}");
            return result.IsSuccessStatusCode;
        }
    }
}
