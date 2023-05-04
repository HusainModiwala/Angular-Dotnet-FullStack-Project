using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReimbursementApp.DataAccessLayer.Entities;
using System.Security.Claims;

namespace ReimbursementApp.DataAccessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<User> _userManager;
        public UserService(IHttpContextAccessor accessor, UserManager<User> userManager)
        {
            _accessor = accessor;
            _userManager = userManager;
        }
        public string GetUserId()
        {
            var user = (ClaimsIdentity) _accessor.HttpContext.User.Identity;
            if (user != null)
            {
                var id = user.FindFirst(ClaimTypes.NameIdentifier);
                return id.ToString();
            }
            return null;
        }

        public string IsApprover()
        {
            var user = (ClaimsIdentity)_accessor.HttpContext.User.Identity;
            if (user != null)
            {
                var isApp = user.Claims;
                return isApp.ToString();
            }
            return null;
        }

        public string GetUserEmail()
        {
            var user = _accessor.HttpContext.User;
            if (user != null)
            {
                return user.Identity.Name.ToString();
            }
            return null;
        }
        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
