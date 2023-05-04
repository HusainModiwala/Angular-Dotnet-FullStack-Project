using AutoMapper;
using Microsoft.AspNetCore.Http;
using ReimbursementApp.BuisnessLayer.Models;
using ReimbursementApp.DataAccessLayer.Entities;
using ReimbursementApp.DataAccessLayer.Repository;
using ReimbursementApp.DataAccessLayer.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReimbursementApp.BuisnessLayer.BusinessLogicLayer
{
    public class ClaimBLL
    {
        private readonly IClaimRepository _claimRepo;
        private IMapper _mapper;
        private readonly IUserService _service;

        public ClaimBLL(IClaimRepository claimRepo, IMapper mapper, IUserService service)
        {
            _claimRepo = claimRepo;
            _mapper = mapper;
            _service = service;
        }

        public Task<int> AddClaim(ClaimModel model)
        {
            var userEmail = _service.GetUserEmail();
            var claim = _mapper.Map<DataAccessLayer.Entities.Claim>(model);
            claim.Email = userEmail;
            if(claim.ReceiptUrl != null)
            {
                claim.ReceiptAttached = true;
            }
            return _claimRepo.AddClaim(claim);
        }

        public async Task DeleteClaim(int id)
        {
            DataAccessLayer.Entities.Claim claim = new DataAccessLayer.Entities.Claim() { Id = id };
            await _claimRepo.DeleteClaim(claim, id);
            return;
        }

        public async Task<List<ClaimModel>> GetAllClaims()
        {
            var claims = await _claimRepo.GetAllClaims();
            if (claims == null) { return null; }
            return _mapper.Map<List<ClaimModel>>(claims);
        }

        public async Task<ClaimModel> GetClaimById(int claimId)
        {
            var claim = await _claimRepo.GetClaimById(claimId);
            if (claim == null) { return null; }
            var res = _mapper.Map<ClaimModel>(claim);
            return res;
        }

        public async Task<string> UpdateClaim(ClaimModel model, int id)
        {
            var claim = new DataAccessLayer.Entities.Claim()
            {
                Id = id,
                Date = model.Date,
                ReimbursementType = model.ReimbursementType,
                RequestedValue = model.RequestedValue,
                ApprovedValue = model.ApprovedValue,
                ApprovedBy = model.ApprovedBy,
                InternalNotes = model.InternalNotes,
                Currency = model.Currency,
                RequestPhase = model.RequestPhase,
                ReceiptUrl = model.ReceiptUrl,
                Email = model.Email,
                UserId=model.UserId
            };
            if (model.ReceiptUrl != null)
            {
                claim.ReceiptAttached = true;
            }
            bool flag = await _claimRepo.UpdateClaim(claim);
            if (flag == false) { return "Item Not Found"; }
            return "Updated Successfully";
        }
    }
}
