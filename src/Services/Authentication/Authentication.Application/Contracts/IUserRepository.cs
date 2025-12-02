using Authentication.Domain.Entities;

namespace Authentication.Application.Contracts
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
