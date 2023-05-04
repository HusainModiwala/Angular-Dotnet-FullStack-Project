using ReimbursementApp.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReimbursementApp.DataAccessLayer.Repository
{
    public interface IClaimRepository
    {
        Task<List<Claim>> GetAllClaims();
        Task<Claim> GetClaimById(int claimId);
        Task<int> AddClaim(Claim model);
        Task<bool> UpdateClaim(Claim model);
        Task DeleteClaim(Claim model, int id);
    }
}