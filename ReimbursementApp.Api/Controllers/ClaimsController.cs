using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementApp.BuisnessLayer.BusinessLogicLayer;
using ReimbursementApp.BuisnessLayer.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReimbursementApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimBLL _claimBLL;
        private readonly IHttpContextAccessor _accessor;
        public ClaimsController(ClaimBLL claimBLL, IHttpContextAccessor accessor)
        {
            _claimBLL = claimBLL;
            _accessor = accessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClaims()
        {
            var claims = await _claimBLL.GetAllClaims();
            if (claims == null)
            {
                return NotFound();
            }
            return Ok(claims);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaimById([FromRoute] int id)
        {
            var claim = await _claimBLL.GetClaimById(id);
            if (claim == null)
            {
                return NotFound();
            }
            return Ok(claim);
        }

        [HttpPost]
        public async Task<IActionResult> AddClaim([FromBody] ClaimModel model)
        {
            var id = await _claimBLL.AddClaim(model);
            return CreatedAtAction(nameof(GetClaimById), new { id = id, controller = "Claims" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClaim([FromBody] ClaimModel model, [FromRoute] int id)
        {
            var status = await _claimBLL.UpdateClaim(model, id);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaim([FromRoute] int id)
        {
            await _claimBLL.DeleteClaim(id);
            return Ok();
        }
    }
}
