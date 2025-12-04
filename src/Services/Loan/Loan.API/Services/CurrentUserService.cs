using Loan.Application.Service;

namespace Loan.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid GetCustomerId()
        {
            var customerIdClaim = _contextAccessor.HttpContext?.User.FindFirst("CustomerId")?.Value;

            if (string.IsNullOrEmpty(customerIdClaim)) throw new UnauthorizedAccessException("CustomerId claim is missing.");
        
            return Guid.Parse(customerIdClaim);
        }
    }
}
