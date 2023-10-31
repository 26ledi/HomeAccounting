using HomeAccounting.BusinessLogic.Dtos;

namespace HomeAccounting.BusinessLogic.Services.Interfaces
{
    public interface IConsumptionTypeService
    {
        Task<List<ConsumptionTypeDto>> GetAsync();
        Task<ConsumptionTypeDto> GetByIdAsync(int id);
        Task<ConsumptionTypeDto> AddAsync(ConsumptionTypeDto consumptionTypeDto);
        Task<ConsumptionTypeDto> UpdateAsync(ConsumptionTypeDto consumptionTypeDto);
        Task<ConsumptionTypeDto> DeleteAsync(int id);
    }
}
