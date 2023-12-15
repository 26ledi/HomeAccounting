using AutoMapper;
using AutoMapper.Execution;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace HomeAccounting.BusinessLogic.Services.Implementations
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public FamilyService(IFamilyRepository familyRepository, IMapper mapper, IMemberRepository memberRepository, IMemoryCache cache)
        {
            _familyRepository = familyRepository;
            _mapper = mapper;
            _memberRepository = memberRepository;
            _cache = cache;
        }
        public async Task<FamilyDto> AddAsync(FamilyDto familyDto)
        {
            var familylooked = await _familyRepository.GetFamilyByNameAsync(familyDto.FamilyName);
            if (familylooked is not null)
            {
                throw new AlreadyExistException("The family already exists");
            }
            var familyReturned = await _familyRepository.AddAsync(_mapper.Map<Family>(familyDto));

            return _mapper.Map<FamilyDto>(familyReturned);
        }

        public async Task<FamilyDto> DeleteAsync(int id)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);
            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exists ");
            }

            var familyReturned = await _familyRepository.DeleteAsync(_mapper.Map<Family>(familyLooked));

            return _mapper.Map<FamilyDto>(familyReturned);
        }

        public async Task<List<FamilyDto>> GetAllFamilyAsync()
        {
            const string cacheKey = "AllFamilies"; // Clé pour stocker en cache toutes les familles

            if (_cache.TryGetValue(cacheKey, out List<FamilyDto> cachedFamilies))
            {
                Console.WriteLine("Retrieving data from cache...");
                return cachedFamilies; // Retourner les données en cache si disponibles
            }
            else
            {
                // Si les données ne sont pas en cache, les récupérer normalement
                var family = await _familyRepository.GetAllFamilyAsync();

                if (family is null)
                {
                    throw new NotFoundException("Family does not exist");
                }

                // Mettre les données en cache pour une utilisation ultérieure
                var cacheEntryOptions = new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) };
                _cache.Set(cacheKey, _mapper.Map<List<FamilyDto>>(family), cacheEntryOptions);

                return _mapper.Map<List<FamilyDto>>(family);
            }
        }

        public async Task<FamilyDto> GetAllFamilyByIdAsync(int id)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exists ");
            }

            return _mapper.Map<FamilyDto>(familyLooked);
        }
        public async Task<FamilyDto> UpdateAsync(FamilyDto familyDto)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(familyDto.Id.Value);
            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exists ");
            }
            _mapper.Map(familyDto, familyLooked);
            await _familyRepository.UpdateAsync(familyLooked);

            return familyDto;
        }
        public async Task<double> CalculateIncomeGivingTimeAsync(int id, DateTime startTime, DateTime endTime)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exist");
            }

            double incomeTotal = 0;
            var members = await _memberRepository.GetMemberAsync();

            foreach (var Member in familyLooked.FamilyMember)
            {
                Member.Incomes = members.Where(m => m.FamilyId == id).Select(m => m.Incomes).FirstOrDefault();

                if (Member.Incomes != null)
                {
                    foreach (var income in Member.Incomes)
                    {
                        if (income.Date >= startTime && income.Date <= endTime)
                        {
                            incomeTotal += income.Amount;
                        }
                    }
                }
            }

            return incomeTotal;
        }
        public async Task<double> CalculateIncomeForMonthAsync(int id, int year, int month)
        {
            DateTime startTime = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime endTime = new DateTime(year, month, daysInMonth);
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exist");
            }
            double incomeTotal = 0;
            var members = await _memberRepository.GetMemberAsync();

            foreach (var Member in familyLooked.FamilyMember)
            {
                Member.Incomes = members.Where(m => m.FamilyId == id).Select(m => m.Incomes).FirstOrDefault();

                if (Member.Incomes != null)
                {
                    foreach (var income in Member.Incomes)
                    {
                        if (income.Date >= startTime && income.Date <= endTime)
                        {
                            incomeTotal += income.Amount;
                        }
                    }
                }
            }

            return incomeTotal;
        }
        public async Task<double> CalculateIncomeForYearAsync(int id, int year)
        {
            DateTime startTime = new DateTime(year, 1, 1);
            DateTime endTime = new DateTime(year, 12, 31);
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exist");
            }

            double incomeTotal = 0;
            var members = await _memberRepository.GetMemberAsync();

            foreach (var Member in familyLooked.FamilyMember)
            {
                Member.Incomes = members.Where(m => m.FamilyId == id).Select(m => m.Incomes).FirstOrDefault();

                if (Member.Incomes != null)
                {
                    foreach (var income in Member.Incomes)
                    {
                        if (income.Date >= startTime && income.Date <= endTime)
                        {
                            incomeTotal += income.Amount;
                        }
                    }
                }
            }

            return incomeTotal;
        }
        public async Task<double> GetHighestIncomeGivingTimeAsync(int id, DateTime startime, DateTime endtime)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("This Family doesn't exists");
            }
            double currentVal;
            double max = 0;
            var members = await _memberRepository.GetMemberAsync();

            foreach (var highestIncome in familyLooked.FamilyMember)
            {
                highestIncome.Incomes = members.Where(m => m.FamilyId == id).Select(m => m.Incomes).FirstOrDefault();
                if (highestIncome.Incomes != null)
                {
                    foreach (var maxIncome in highestIncome.Incomes)
                    {
                        if (maxIncome.Date >= startime && maxIncome.Date <= endtime)
                        {
                            currentVal = maxIncome.Amount;
                            if (currentVal > max)
                            {
                                max = currentVal;
                            }
                        }
                    }

                }
            }

            return max;
        }
        public async Task<double> GetHighestIncomeMonthAsync(int id, int year, int month)
        {
            DateTime startTime = new DateTime(year, month, 1);
            DateTime endTime = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exist");
            }
            double currentVal;
            double max = 0;
            var members = await _memberRepository.GetMemberAsync();

            foreach (var highestIncome in familyLooked.FamilyMember)
            {
                highestIncome.Incomes = members.Where(m => m.FamilyId == id).Select(m => m.Incomes).FirstOrDefault();

                if (highestIncome.Incomes != null)
                {
                    foreach (var maxIncome in highestIncome.Incomes)
                    {
                        if (maxIncome.Date >= startTime && maxIncome.Date <= endTime)
                        {
                            currentVal = maxIncome.Amount;
                            if (currentVal > max)
                            {
                                max = currentVal;
                            }
                        }
                    }

                }
            }
            return max;
        }
   
        public async Task<double> GetHighestIncomeYearAsync(int id, int year)
        {
            DateTime startTime = new DateTime(year, 1, 1);
            DateTime endTime = new DateTime(year, 12, 31);
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);

            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exist");
            }
            double max = 0;
            double currentVal;
            double sum = 0;
           
            foreach (var highestIncome in familyLooked.FamilyMember)
            {
                if (highestIncome.Incomes != null)
                {
                    foreach (var maxIncome in highestIncome.Incomes)
                    {
                        if (maxIncome.Date.Year >= startTime.Year && maxIncome.Date.Year <= endTime.Year)
                        {
                            currentVal = maxIncome.Amount;
                            if (currentVal > max)
                            {
                                max = currentVal;
                            }
                        }
                    }

                }
            }
            return max;
        }
    }
}
