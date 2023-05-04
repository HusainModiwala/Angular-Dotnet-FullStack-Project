using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.BusinessLayer.BusinessLogicLayer;
using ReimbursementApp.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReimbursementApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBLL _userBLL;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(UserBLL userBLL, IHttpContextAccessor httpContextAccessor)
        {
            _userBLL = userBLL;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserModel userModel)
        {
            var result = await _userBLL.RegisterUser(userModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            await _userBLL.LogoutUser();
            return Ok();
        }

        [HttpPost]
        public async Task<object> LoginUser([FromBody] LoginModel loginModel)
        {
            var result = await _userBLL.LoginUser(loginModel);
            if (result == null)
            {
                return new ResponseModel(ResponseCode.Error, "", null);
            }
            var flag = await IsApprover(loginModel.Email.ToString());
            var obj = new { token = result, isapp = flag };
            return new ResponseModel(ResponseCode.Ok, "", obj);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserClaims()
         {
            var userEmail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var result = await _userBLL.GetUserClaims(userEmail);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<bool> IsApprover(string email)
        {
            return await _userBLL.IsApprover(email);
        }
    }
}
