using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.Data.Entities;
using HomeAccounting.DataAccess.Repositories.Interfaces;

namespace HomeAccounting.BusinessLogic.Services.Implementations
{
    public class ConsumptionTypeService : IConsumptionTypeService
    {
        private readonly IConsumptionTypeRepository _consumptionTypeRepository;
        private readonly IMapper _mapper;
        public ConsumptionTypeService(IConsumptionTypeRepository consumptionTypeRepository, IMapper mapper)
        {
            _consumptionTypeRepository = consumptionTypeRepository;
            _mapper = mapper;
        }
        public async Task<ConsumptionTypeDto> AddAsync(ConsumptionTypeDto consumptionTypeDto)
        {
            var consumptionTypeLooked = await _consumptionTypeRepository.GetConsumptionTypeByIdAsync(consumptionTypeDto.Id);

            if (consumptionTypeLooked is not null)
            {
                throw new AlreadyExistException("This ConsumptionType Already Exist");
            }

            var consumptionTypeReturned = await _consumptionTypeRepository.AddAsync(_mapper.Map<ConsumptionType>(consumptionTypeLooked));

            return _mapper.Map<ConsumptionTypeDto>(consumptionTypeReturned);
        }

        public async Task<ConsumptionTypeDto> DeleteAsync(int id)
        {
            var consumptionTypeLooked = await _consumptionTypeRepository.GetConsumptionTypeByIdAsync(id);

            if (consumptionTypeLooked is null)
            {
                throw new NotFoundException("This ConsumptionType does not exist");
            }

            var consumptionReturned = await _consumptionTypeRepository.DeleteAsync(_mapper.Map<ConsumptionType>(consumptionTypeLooked));

            return _mapper.Map<ConsumptionTypeDto>(consumptionReturned);
        }

        public async Task<List<ConsumptionTypeDto>> GetAsync()
        {
            var consumptionTypes = await _consumptionTypeRepository.GetAllConsumptionTypesAsync();

            if (consumptionTypes is null)
            {
                throw new NotFoundException("There is no consumptionTypes");
            }

            return _mapper.Map<List<ConsumptionTypeDto>>(consumptionTypes);
        }

        public async Task<ConsumptionTypeDto> GetByIdAsync(int id)
        {
            var consumptionTypeLooked = await _consumptionTypeRepository.GetConsumptionTypeByIdAsync(id);

            if (consumptionTypeLooked is null)
            {
                throw new NotFoundException("This consumption type does not exists");
            }

            return _mapper.Map<ConsumptionTypeDto>(consumptionTypeLooked);
        }

        public async Task<ConsumptionTypeDto> UpdateAsync(ConsumptionTypeDto consumptionTypeDto)
        {
            var consumptionTypeLooked = await _consumptionTypeRepository.GetConsumptionTypeByIdAsync(consumptionTypeDto.Id);

            if (consumptionTypeLooked is null)
            {
                throw new NotFoundException("This consumption type does not exists");
            }

            _mapper.Map(consumptionTypeDto, consumptionTypeLooked);
            await _consumptionTypeRepository.UpdateAsync(consumptionTypeLooked);

            return consumptionTypeDto;
        }
    }
}
