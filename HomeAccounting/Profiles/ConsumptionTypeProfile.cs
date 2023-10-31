using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;

namespace HomeAccounting.Profiles
{
    public class ConsumptionTypeProfile:Profile
    {
        public ConsumptionTypeProfile() 
        {
            CreateMap<ConsumptionTypeDto,ConsumptionType>().ReverseMap();
        }
    }
}
