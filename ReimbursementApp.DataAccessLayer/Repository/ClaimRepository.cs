using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReimbursementApp.DataAccessLayer.Data;
using ReimbursementApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReimbursementApp.DataAccessLayer.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly ReimbursementPortalDBContext _context;
        private readonly IHttpContextAccessor _accessor;

        public ClaimRepository(ReimbursementPortalDBContext context, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _context = context;
        }

        public async Task<int> AddClaim(Entities.Claim model)
        {
            var userEmail = model.Email;
            var user = _context.Users.Where(x=>x.Email.Equals(userEmail)).FirstOrDefault();
            model.UserId = user.Id;
            _context.Claims.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task DeleteClaim(Entities.Claim model, int id)
        {
            _context.Claims.Remove(model);
            
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entities.Claim>> GetAllClaims()
        {
            var claims = await _context.Claims.ToListAsync();
            return claims;
        
        }

        public async Task<Entities.Claim> GetClaimById(int claimId)
        {
            var claim = await _context.Claims.Where(x => x.Id == claimId).FirstOrDefaultAsync();
            return claim;
        }

        public async Task<bool> UpdateClaim(Entities.Claim model)
        {
            _context.Claims.Update(model);
            var flag = await _context.SaveChangesAsync();
            return flag > 0;
        }
    }
}
