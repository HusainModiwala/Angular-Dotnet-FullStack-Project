using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReimbursementApp.BuisnessLayer.Models;
using ReimbursementApp.BusinessLayer.Models;
using ReimbursementApp.DataAccessLayer.Data;
using ReimbursementApp.DataAccessLayer.Entities;
using ReimbursementApp.DataAccessLayer.Repository;
using ReimbursementApp.DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementApp.BusinessLayer.BusinessLogicLayer
{
    public class UserBLL
    {
        private readonly IUserRepository _userRepository;

        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _service;
        private readonly ReimbursementPortalDBContext _context;
        private readonly IHttpContextAccessor _http;

        public UserBLL(IHttpContextAccessor http, IUserRepository userRepository, IClaimRepository claimRepository, IMapper mapper, IUserService service, ReimbursementPortalDBContext context)
        {
            _userRepository = userRepository;
            _claimRepository = claimRepository;
            _mapper = mapper;
            _service = service;
            _context = context;
            _http = http;
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new User()
            {
                FullName = userModel.FullName,
                Email = userModel.Email,
                UserName = userModel.Email,
                PAN = userModel.PAN,
                Bank = userModel.Bank,
                BankAccNo = userModel.BankAccNo
            };
            return await _userRepository.RegisterUser(user, userModel.Password);
        }

        public async Task<object> LoginUser(LoginModel loginModel)
        {
            return await _userRepository.LoginUser(loginModel.Email, loginModel.Password);
        }

        public async Task<List<ClaimModel>> GetUserClaims(string email)
        {
            var claims = await _claimRepository.GetAllClaims();
            var users = await _context.Users.ToListAsync();
            foreach(var user in users)
            {
                if(user.Email == email && user.isApprover != null && user.isApprover == true)
                {
                    return _mapper.Map<List<ClaimModel>>(claims);
                }
            }
    
            var userClaims = claims.Where(x => x.Email == email).ToList();
            return _mapper.Map<List<ClaimModel>>(userClaims);
        }

        public async Task LogoutUser()
        {
            await _userRepository.LogoutUser();
            return;
        }

        public async Task<bool> IsApprover(string email)
        {
            var users = await _context.Users.ToListAsync();
            var user = users.Where(x => x.Email == email).FirstOrDefault();
            return user.isApprover!=null?(bool)user.isApprover:false;
        }
        
    }
}
