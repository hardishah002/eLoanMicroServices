using Document.Application.Services;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Document.Infrastructure.Services
{
    public class LoanServiceClient : ILoanServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public LoanServiceClient(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> ValidateLoanAsync(Guid loanId, CancellationToken cancellationToken)
        {
            var token = _contextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("Bearer", ""));

            var response = await _httpClient.GetAsync($"api/Loan/{loanId}/exists");

            return response.StatusCode switch
            { 
                HttpStatusCode.OK => true,
                HttpStatusCode.NotFound => false,
                HttpStatusCode.Forbidden => throw new UnauthorizedAccessException("Access to the loan is forbidden."),
                HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("Unauthorized to call loan api."),
                _ => throw new InvalidOperationException($"Loan API responded with unexpected status: {response.StatusCode}")
            };
        }
    }
}
