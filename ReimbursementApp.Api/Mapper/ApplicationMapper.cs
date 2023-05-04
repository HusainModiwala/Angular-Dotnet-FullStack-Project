using AutoMapper;
using ReimbursementApp.BuisnessLayer.Models;
using ReimbursementApp.BusinessLayer.Models;
using ReimbursementApp.DataAccessLayer.Entities;

namespace Buisness_Layer.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper():base("WebMappingProfile")
        {
            CreateMap<Claim, ClaimModel>().ReverseMap();
            CreateMap<ClaimModel, Claim>().ReverseMap();

            //CreateMap<User, UserModel>().ReverseMap();
            //CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
