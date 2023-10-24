using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;

namespace HomeAccounting.Profiles
{
    public class SourceIncomeProfile:Profile
    {
        public SourceIncomeProfile() 
        {
            CreateMap<SourceIncome, SourceIncomeDto>().ReverseMap();
        }
    }
}
