using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;

namespace HomeAccounting.Profiles
{
    public class ConsumptionProfile:Profile
    {
        public ConsumptionProfile() 
        {
            CreateMap<Consumption, ConsumptionDto>().ReverseMap();
        }
    }
}
