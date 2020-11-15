using System.Threading.Tasks;
using VatanAPI.Core.Models;
using VatanAPI.Core.Services.Communication;
using VatanAPI.Domain.Services.Communication;

namespace VatanAPI.Core.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUserAsync(User user, params ERole[] userRoles);
        Task<User> FindByEmailAsync(string email);
        Task<CreateUserResponse> UpdateAsync(string email, User user);
    }
}