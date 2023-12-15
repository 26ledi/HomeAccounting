using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HomeAccounting.BusinessLogic.Services.Implementations;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public MemberService(IMemberRepository memberRepository, IMapper mapper, IMemoryCache cache)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
        _cache = cache;
    }
    public async Task<MemberDto> AddAsync(MemberDto member)
    {
        //verification
        var memberLooked = await _memberRepository.GetMemberByNameAndSurname(member.Name, member.Surname);

        if (memberLooked is not null)
        {
            throw new AlreadyExistException("This member exists already");
        }

        var memberReturned = await _memberRepository.AddAsync(_mapper.Map<Data.Entities.Member>(member));

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


        return _mapper.Map<MemberDto>(memberLooked);
    }

    public async Task<List<MemberDto>> GetMemberDtoAsync()
    {
        const string cacheKey = "AllMembers"; // Clé pour stocker en cache toutes les familles

        if (_cache.TryGetValue(cacheKey, out List<MemberDto> cachedMembers))
        {
            Console.WriteLine("Retrieving data from cache...");

            return cachedMembers; // Retourner les données en cache si disponibles
        }
        else
        {
            var members = await _memberRepository.GetMemberAsync();

            if (members is null)
            {
                throw new NotFoundException("Not Found");
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) };
            _cache.Set(cacheKey, _mapper.Map<List<MemberDto>>(members), cacheEntryOptions);


            return _mapper.Map<List<MemberDto>>(members);
        }

    }

    /// <summary>
    /// Function which calculate the sum of all the income for a given time
    /// </summary>
    /// <param name="id"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<double> CalculateIncomeGivingTimeAsync(int id, DateTime startTime, DateTime endTime)
    {
        var memberLooked = await _memberRepository.GetMemberByIdAsync(id);

        if (memberLooked is null)
        {
            throw new NotFoundException("Member does not exist");
        }

        double incomeTotal = 0;

        foreach (var incomeRecord in memberLooked.Incomes)
        {
            if (incomeRecord.Date >= startTime && incomeRecord.Date <= endTime)
            {
                incomeTotal = incomeTotal + incomeRecord.Amount;
            }
        }
        return incomeTotal;

    }
    /// <summary>
    /// Function which calculate the sum of all the income for a given month
    /// </summary>
    /// <param name="memberId"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<double> CalculateIncomeForMonthAsync(int memberId, int year, int month)
    {
        DateTime startDate = new DateTime(year, month, 1);
        var daysInMonth = DateTime.DaysInMonth(year, month);
        DateTime endDate = new DateTime(year, month, daysInMonth);
        var memberLooked = await _memberRepository.GetMemberByIdAsync(memberId);

        if (memberLooked is null)
        {
            throw new NotFoundException("Member does not exist");
        }
        double incomeTotal = 0;
        foreach (var incomeRecord in memberLooked.Incomes)
        {
            if (incomeRecord.Date >= startDate && incomeRecord.Date <= endDate)
            {
                incomeTotal = incomeTotal + incomeRecord.Amount;
            }
        }
        return incomeTotal;
    }

    /// <summary>
    /// Function which calculate the sum of all the income for a given year
    /// </summary>
    /// <param name="id"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<double> CalculateIncomeMemberForYearAsync(int id, int year)
    {
        DateTime startTime = new DateTime(year, 1, 1);
        DateTime endTime = new DateTime(year, 12, 31);
        var memberLooked = await _memberRepository.GetMemberByIdAsync(id);
        if (memberLooked is null)
        {
            throw new NotFoundException("Member does not exist");
        }

        double incomeTotal = 0;
        foreach (var incomeRecord in memberLooked.Incomes)
        {
            if (incomeRecord.Date >= startTime && incomeRecord.Date <= endTime)
            {
                incomeTotal = incomeTotal + incomeRecord.Amount;

            }

        }
        return incomeTotal;
    }
    /// <summary>
    /// Function which is getting the highest income for a given time
    /// </summary>
    /// <param name="id"></param>
    /// <param name="startime"></param>
    /// <param name="endtime"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<double> GetHighestIncomeGivingTimeAsync(int id, DateTime startime, DateTime endtime)
    {
        var memberLooked = await _memberRepository.GetMemberByIdAsync(id);
        if (memberLooked is null)
        {
            throw new NotFoundException("This Member doesn't exists");
        }
        double currentVal;
        double max = 0;
        foreach (var highestIncome in memberLooked.Incomes)
        {
            if (highestIncome.Date >= startime && highestIncome.Date <= endtime)
            {
                currentVal = highestIncome.Amount;
                if (currentVal > max)
                {
                    max = currentVal;
                }
            }
        }
        return max;
    }
    /// <summary>
    ///Function which is getting the highest income for a given month
    /// </summary>
    /// <param name="id"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>

    public async Task<double> GetHighestIncomeMonthAsync(int id, int year, int month)
    {
        DateTime startTime = new DateTime(year, month, 1);
        DateTime endTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        var memberLooked = await _memberRepository.GetMemberByIdAsync(id);
        if (memberLooked is null)
        {
            throw new NotFoundException("Member does not exist");
        }
        double max = 0;
        double currentVal;
        foreach (var incomeRecord in memberLooked.Incomes)
        {
            if (incomeRecord.Date >= startTime && incomeRecord.Date <= endTime)
            {
                currentVal = incomeRecord.Amount;
                if (currentVal > max)
                {
                    max = currentVal;
                }
            }
        }
        return max;

    }
    /// <summary>
    /// Function which is getting the highest income for a year
    /// </summary>
    /// <param name="id"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<double> GetHighestIncomeYearAsync(int id, int year)
    {
        DateTime startTime = new DateTime(year, 1, 1);
        DateTime endTime = new DateTime(year, 12, 31);
        var memberLooked = await _memberRepository.GetMemberByIdAsync(id);
        if (memberLooked is null)
        {
            throw new NotFoundException("Member does not exist");
        }
        double max = 0;
        double currentVal;
        double sum = 0;
        foreach (var incomeRecord in memberLooked.Incomes)
        {
            if (incomeRecord.Date.Year >= startTime.Year && incomeRecord.Date.Year <= endTime.Year)
            {
                sum = sum + incomeRecord.Amount;
                currentVal = sum;
                if (currentVal > max)
                {
                    max = currentVal;
                }
            }
        }
        return max;
    }
}
