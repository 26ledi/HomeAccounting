using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;

namespace HomeAccounting.BusinessLogic.Services.Implementations
{
    public class SourceIncomeService : ISourceIncomeService
    {
        private readonly ISourceIncomeRepository _sourceIncomeRepository;
        private readonly IMapper _mapper;
        public SourceIncomeService(ISourceIncomeRepository sourceIncomeRepository, IMapper mapper)
        {
            _sourceIncomeRepository = sourceIncomeRepository;
            _mapper = mapper;
        }
        public async Task<SourceIncomeDto> AddAsync(SourceIncomeDto sourceIncomeDto)
        {
            var sourceIncomeLooked = _sourceIncomeRepository.GetSourceIncomeByIdAsync(sourceIncomeDto.Id);

            if (sourceIncomeLooked is not null)
            {
                throw new AlreadyExistException("This Income Already Exists");
            }
            var sourceIncomeReturned = await _sourceIncomeRepository.AddAsync(_mapper.Map<SourceIncome>(sourceIncomeLooked));

            return _mapper.Map<SourceIncomeDto>(sourceIncomeReturned);
        }
        public async Task<SourceIncomeDto> DeleteAsync(int id)
        {
            var sourceIncomeLooked = _sourceIncomeRepository.GetSourceIncomeByIdAsync(id);

            if (sourceIncomeLooked is null)
            {
                throw new NotFoundException("This income does not exist");
            }

            var sourceIncomeReturned = await _sourceIncomeRepository.DeleteAsync(_mapper.Map<SourceIncome>(sourceIncomeLooked));

            return _mapper.Map<SourceIncomeDto>(sourceIncomeReturned);

        }
        public async Task<List<SourceIncomeDto>> GetSourceIncomeAsync()
        {
            var sourceincomes = await _sourceIncomeRepository.GetAllSourceIncomeAsync();

            if (sourceincomes is null)
            {
                throw new NotFoundException("There are not incomes");
            }

            return _mapper.Map<List<SourceIncomeDto>>(sourceincomes);
        }
        public async Task<SourceIncomeDto> GetSourceIncomeDtoByIdAsync(int id)
        {
            var sourceincome = await _sourceIncomeRepository.GetSourceIncomeByIdAsync(id);

            if (sourceincome is null)
            {
                throw new NotFoundException("This income does not exists");
            }

            return _mapper.Map<SourceIncomeDto>(sourceincome);
        }
        public async Task<SourceIncomeDto> UpdateAsync(SourceIncomeDto sourceIncomeDto)
        {
            var sourceIncomeLooked = await _sourceIncomeRepository.GetSourceIncomeByIdAsync(sourceIncomeDto.Id);

            if (sourceIncomeLooked is null)
            {
                throw new NotFoundException("This income does not exists");
            }

            _mapper.Map(sourceIncomeDto, sourceIncomeLooked);
            await _sourceIncomeRepository.UpdateAsync(sourceIncomeLooked);

            return sourceIncomeDto;
        }
    }
}
