using Microsoft.AspNetCore.Identity;
using ReimbursementApp.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace ReimbursementApp.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUser(User user, string password);
        Task<object> LoginUser(string email, string password);
        Task LogoutUser();
    }
}
