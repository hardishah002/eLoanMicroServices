namespace Customer.Application.Models
{
    public record CustomerResponse(Guid CustomerId, string FirstName, string LastName, string Email, string Phone, string Address, DateTime CreatedDate)
    {
        public string FullName => $"{FirstName} {LastName}";
    };
}
