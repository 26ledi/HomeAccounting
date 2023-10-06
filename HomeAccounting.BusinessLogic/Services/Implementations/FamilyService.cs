using AutoMapper;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using HomeAccounting.DataAccess.Entities;
using HomeAccounting.BusinessLogic.Exceptions;
using HomeAccounting.DataAccess.Repositories.Interfaces;

namespace HomeAccounting.BusinessLogic.Services.Implementations
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyRepository _familyRepository;
        private readonly IMapper _mapper;
        public FamilyService(IFamilyRepository familyRepository, IMapper mapper)
        {
            _familyRepository = familyRepository;
            _mapper = mapper;
        }
        public async Task<FamilyDto> AddAsync(Family family)
        {
            var familylooked = await _familyRepository.GetAllFamilyAsync();
            if (familylooked is not null)
            {
                throw new  AlreadyExistException("The family already exists");
            }
            var familyReturned = await _familyRepository.AddAsync(_mapper.Map<Family>(family));

            return _mapper.Map<FamilyDto>(familyReturned);

        }

        public async Task<FamilyDto>DeleteAsync(int id)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);
            if(familyLooked is null) 
            {
                throw new NotFoundException("Family does not exists ");
            }

            var familyReturned = await _familyRepository.DeleteAsync(_mapper.Map<Family>(familyLooked));

            return _mapper.Map<FamilyDto>(familyReturned);
            
        }

        public async Task<List<FamilyDto>>GetAllFamilyAsync()
        {
            var family = await _familyRepository.GetAllFamilyAsync();
            if (family is null)
            {
                throw new NotFoundException("Family does not exists ");
            }
          
            return _mapper.Map<List<FamilyDto>>(family);

        }


        public async Task<FamilyDto>UpdateAsync(int id)
        {
            var familyLooked = await _familyRepository.GetFamilyByIdAsync(id);
            if (familyLooked is null)
            {
                throw new NotFoundException("Family does not exists ");
            }

            var familyReturned = await _familyRepository.UpdateAsync(_mapper.Map<Family>(familyLooked));

            return _mapper.Map<FamilyDto>(familyReturned);
        }
    }
}
