using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.Data.Entities;

namespace HomeAccounting.Profiles;

public class MemberProfile : Profile 
{
    public MemberProfile()
    {
        CreateMap<Member, MemberDto>()
            .ReverseMap();
    }
}
