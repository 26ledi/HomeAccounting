using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.DataAccess.Entities;

namespace HomeAccounting.Profiles
{
    public class FamilyProfile:Profile
    {
        public FamilyProfile() 
        {
            CreateMap<Family, FamilyDto>().ReverseMap();
        }
    }
}
