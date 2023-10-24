using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;

namespace HomeAccounting.BusinessLogic.Services.Implementations
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        public IncomeService(IIncomeRepository incomeRepository, IMapper mapper)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }
        public async Task<IncomeDto> AddAsync(IncomeDto incomeDto)
        { 
           var incomeReturned = await _incomeRepository.AddAsync(_mapper.Map<Income>(incomeDto));

           return _mapper.Map<IncomeDto>(incomeReturned);
        }
        public async Task<IncomeDto> DeleteAsync(int id)
        {
            var incomeLooked = await _incomeRepository.GetIncomeByIdAsync(id);
            if (incomeLooked is null)
            {
                throw new NotFoundException("This income does not exist");
            }
            var incomeReturned=await _incomeRepository.DeleteAsync(_mapper.Map<Income>(incomeLooked));
             
            return _mapper.Map<IncomeDto>(incomeReturned);
        }
        public async Task<List<IncomeDto>> GetIncomeAsync()
        {
            var incomes = await _incomeRepository.GetAllIncomeAsync();
            if (incomes is null)
            {
                throw new NotFoundException("There are not incomes");
            }

            return _mapper.Map<List<IncomeDto>>(incomes);
        }
        public async Task<IncomeDto> GetIncomeDtoByIdAsync(int id)
        {
            var income = await _incomeRepository.GetIncomeByIdAsync(id);
            if (income is null)
            {
                throw new NotFoundException("This income does not exists");
            }

            return _mapper.Map<IncomeDto>(income);
        }
        public async Task<IncomeDto> UpdateAsync(IncomeDto incomeDto)
        {
            var incomeLooked = await _incomeRepository.GetIncomeByIdAsync(incomeDto.Id);
            if (incomeLooked is null)
            {
                throw new NotFoundException("This income does not exists");
            }
            _mapper.Map(incomeDto, incomeLooked);
            await _incomeRepository.UpdateAsync(incomeLooked);

            return incomeDto;
        }
    }
}
