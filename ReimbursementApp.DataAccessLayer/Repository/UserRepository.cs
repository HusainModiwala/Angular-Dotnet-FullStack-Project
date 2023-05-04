using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReimbursementApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementApp.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }


        public string UserId1 => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<IdentityResult> RegisterUser(User user, string password)
        {
            if(String.Compare(user.Email, "admin@gmail.com") == 0)
            {
                user.isApprover = true;
            }
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<object> LoginUser(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<System.Security.Claims.Claim>()
            {
                new System.Security.Claims.Claim(ClaimTypes.Name, email),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
