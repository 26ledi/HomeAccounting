using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Implementations;
using HomeAccounting.DataAccess.Repositories.Interfaces;

namespace HomeAccounting.BusinessLogic.Services.Implementations
{
    public class ConsumptionService : IConsumptionService
    {
        public readonly IConsumptionRepository _consumptionRepository;
        public readonly IMemberRepository _memberRepository;
        public readonly IConsumptionTypeRepository _consumptionTypeRepository;
        public readonly IMapper _mapper;
        public ConsumptionService(IConsumptionRepository consumptionRepository,IConsumptionTypeRepository consumptionTypeRepository,IMemberRepository memberRepository, IMapper mapper)
        {
            _mapper = mapper;
            _consumptionRepository = consumptionRepository;
            _consumptionTypeRepository = consumptionTypeRepository;
            _memberRepository = memberRepository;
        }
        public async Task<ConsumptionDto> AddAsync(ConsumptionDto consumptionDto)
        {

            var consumptionReturned = await _consumptionRepository.AddAsync(_mapper.Map<Consumption>(consumptionDto));

            return _mapper.Map<ConsumptionDto>(consumptionReturned);
        }

        public async Task<ConsumptionDto> DeleteAsync(int id)
        {
            var consumptionLooked = await _consumptionRepository.GetConsumptionByIdAsync(id);

            if (consumptionLooked is null)
            {
                throw new NotFoundException("This consumption does not exists");
            }
            var consumptionReturned = await _consumptionRepository.DeleteAsync(_mapper.Map<Consumption>(consumptionLooked));

            return _mapper.Map<ConsumptionDto>(consumptionReturned);
        }

        public async Task<ConsumptionDto> UpdateAsync(ConsumptionDto consumptionDto)
        {
            var consumptionLooked = await _consumptionRepository.GetConsumptionByIdAsync(consumptionDto.Id);

            if (consumptionLooked is null)
            {
                throw new NotFoundException("This consumption does not exists");
            }

            _mapper.Map(consumptionDto, consumptionLooked);
            await _consumptionRepository.UpdateAsync(consumptionLooked);

            return consumptionDto;
        }
        public async Task<List<ConsumptionDto>> GetAsync()
        {
            var consumptions = await _consumptionRepository.GetAllConsumptionAsync();

            if (consumptions is null)
            {
                throw new NotFoundException("There is no consumption");
            }

            return _mapper.Map<List<ConsumptionDto>>(consumptions);
        }
        public async Task<ConsumptionDto> GetByIdAsync(int id)
        {
            var consumptionLooked = await _consumptionRepository.GetConsumptionByIdAsync(id);

            if (consumptionLooked is null)
            {
                throw new NotFoundException("This consumption does not exists");
            }

            return _mapper.Map<ConsumptionDto>(consumptionLooked);
        }
        public async Task<List<string>> GetMemberFrequentConsumptionByTimeAsync(DateTime startTime,DateTime endTime)
        {
            var consumptionMember = await _consumptionRepository.GetAllConsumptionAsync();

            var frequentConsumptionTypes = consumptionMember
                .Where(f => f.Date >= startTime.Date && f.Date <= endTime.Date)
                .Select(f => f.Member.Surname)
                .ToList();
               
            return frequentConsumptionTypes;
        }
        public async Task<List<string>>GetMemberFrequentConsumptionByMonthAsync(int month, int year)
        {
            DateTime startDate = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime endDate = new DateTime(year, month, daysInMonth);
            var consumptionMember = await _consumptionRepository.GetAllConsumptionAsync();

            var frequentConsumptionTypes = consumptionMember
                .Where(f => f.Date >= startDate.Date && f.Date <= endDate.Date)
                .Select(f => f.Member.Surname)
    .           ToList();

            return frequentConsumptionTypes;
        }

        public async Task<List<string>>GetMemberFrequentConsumptionByYearAsync(int year)
        {
            DateTime startTime = new DateTime(year, 1, 1);
            DateTime endTime = new DateTime(year, 12, 31);

            var consumptionMember = await _consumptionRepository.GetAllConsumptionAsync();

            var frequentConsumptionTypes = consumptionMember
                .Where(f => f.Date >= startTime.Date && f.Date <= endTime.Date)
                .Select(f => f.Member.Surname)
                .ToList();

            return frequentConsumptionTypes;

        }
        public async Task<List<string>>GetFrequentConsumptionTypeByMonthAsync(int month,int year)
        {
            DateTime startDate = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime endDate = new DateTime(year, month, daysInMonth);

            var consumptionTypes = await _consumptionRepository.GetAllConsumptionAsync();

            var frequentConsumptionTypes = consumptionTypes
                .Where(f => f.Date >= startDate.Date && f.Date <= endDate.Date)
                .GroupBy(f => f.ConsumptionType.Name)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .ToList();

            return frequentConsumptionTypes;
        }
        public async Task<List<string>> GetFrequentConsumptionTypeByTimeAsync(DateTime startTime, DateTime endTime)
        {
            var consumptionTypes = await _consumptionRepository.GetAllConsumptionAsync();

            var frequentConsumptionTypes = consumptionTypes
                .Where(f => f.Date >= startTime.Date && f.Date <= endTime.Date)
                .GroupBy(f => f.ConsumptionType.Name)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .ToList();

            return frequentConsumptionTypes;
        }
        public async Task<List<string>>GetFrequentConsumptionTypeByYearAsync(int year)
        {
            DateTime startTime = new DateTime(year, 1, 1);
            DateTime endTime = new DateTime(year, 12, 31);
            var consumptionTypes = await _consumptionRepository.GetAllConsumptionAsync();
            var frequentConsumptionTypes = consumptionTypes
                .Where(f => f.Date >= startTime.Date && f.Date <= endTime.Date)
                .GroupBy(f => f.ConsumptionType.Name)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .ToList();

            return frequentConsumptionTypes;
        }   
    }
}
