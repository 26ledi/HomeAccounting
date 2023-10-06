using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;

namespace HomeAccounting.BusinessLogic.Services.Implementations;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public MemberService(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }
    public async Task<MemberDto> AddAsync(MemberDto member)
    {
        //verification
        var memberLooked = await _memberRepository.GetMemberByNameAndSurname(member.Name, member.Surname);

        if (memberLooked is not null)
        {
            throw new AlreadyExistException("This member exists already");
        }

        var memberReturned = await _memberRepository.AddAsync(_mapper.Map<Member>(member));

        return _mapper.Map<MemberDto>(memberReturned);
    }

    public async Task<MemberDto> DeleteAsync(MemberDto member)
    {
        var memberLooked = await _memberRepository.GetMemberByIdAsync(member.Id.Value);

        if (memberLooked is null)
        {
            throw new NotFoundException("This Member doesn't exist");
        }

        await _memberRepository.DeleteAsync(memberLooked);

        return _mapper.Map<MemberDto>(memberLooked);
    }

    public async Task<MemberDto> UpdateAsync(MemberDto member)
    {
        var memberLooked = await _memberRepository.GetMemberByIdAsync(member.Id.Value);

        if (memberLooked is null)
        {
            throw new NotFoundException("This Member doesn't exist");
        }

        _mapper.Map(member, memberLooked);
         await _memberRepository.UpdateAsync(memberLooked);

        return member;
    }
    public async Task<MemberDto> GetMemberByIdAsync(int id)
    {
        var memberLooked = await _memberRepository.GetMemberByIdAsync(id);

        if (memberLooked is null)
        {
            throw new NotFoundException("This Member doesn't exist");
        }
        var memberReturned=await _memberRepository.UpdateAsync(_mapper.Map<Member>(memberLooked));

        return _mapper.Map<MemberDto>(memberReturned);
    }

    public async Task<List<MemberDto>> GetMemberDtoAsync()
    {
        var members = await _memberRepository.GetMemberAsync();

        if (members is null)
        {
            throw new NotFoundException("Not Found");
        }

        return _mapper.Map<List<MemberDto>>(members);
    }

    //Sum for a given time
    private double CalculateIncomeMemberForGivenTimeAsync(Member member, DateTime startime, DateTime endtime)
    {
        double income = 0;
        foreach (var incomeRecord in member.Incomes)
        {

            if (incomeRecord.Date >= startime && incomeRecord.Date <= endtime)
            {
                income = income + incomeRecord.Amount;
            }
        }

        return income;
    }
    //Sum for a month
    public async Task<double> CalculateIncomeMemberForGivenMonthAsync(int memberId, int year, int month)
    {
        DateTime startTime = new DateTime(year, month, 1);
        DateTime endTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        var member = await _memberRepository.GetMemberByIdAsync(memberId);   
        
        if(member is null)
        {
            throw new NotFoundException("Member does not exist");
        }

        return  CalculateIncomeMemberForGivenTimeAsync(member, startTime, endTime);
    }

    //Sum for a year
    public async Task<double> CalculateIncomeMemberForGivenYearAsync(int id, int year)
    {
        DateTime startTime = new DateTime(year, 1, 1);
        DateTime endTime = new DateTime(year, 12, 31);
        var member = await _memberRepository.GetMemberByIdAsync(id);
        if (member is null)
        {
            throw new NotFoundException("Member does not exist");
        }

        return  CalculateIncomeMemberForGivenTimeAsync(member, startTime, endTime);
    }
    //Max for a given time 
    private double GetHighestIncomeGivingTimeAsync(Member member, DateTime startime, DateTime endtime)
    {
        var incomesInPeriod = member.Incomes
        .Where(income => income.Date >= startime && income.Date <= endtime)
        .Select(income => income.Amount);
        var highestIncome = incomesInPeriod.Max();

        return highestIncome;
    }

    public async Task<double> GetHighestIncomeMonthAsync(int id, int year, int month)
    {
        DateTime startTime = new DateTime(year, month, 1);
        DateTime endTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        var member = await _memberRepository.GetMemberByIdAsync(id);
        if (member is null)
        {
            throw new NotFoundException("Member does not exist");
        }

        return  GetHighestIncomeGivingTimeAsync(member, startTime, endTime);
    }

    public async Task<double> GetHighestIncomeYearAsync(int id, int year)
    {
        DateTime startTime = new DateTime(year, 1, 1);
        DateTime endTime = new DateTime(year, 12, 31);
        var member = await _memberRepository.GetMemberByIdAsync(id);
        if (member is null)
        {
            throw new NotFoundException("Member does not exist");
        }

        return GetHighestIncomeGivingTimeAsync(member, startTime, endTime);
    }

   

}
