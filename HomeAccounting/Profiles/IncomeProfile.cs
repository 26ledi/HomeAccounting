using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;

namespace HomeAccounting.Profiles
{
    public class IncomeProfile:Profile
    {
        public IncomeProfile() 
        {
            CreateMap<Income, IncomeDto>().ReverseMap();
        }
    }
}
