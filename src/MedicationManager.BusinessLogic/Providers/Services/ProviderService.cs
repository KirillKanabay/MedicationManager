using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Dtos;
using MedicationManager.Data.Providers.Contracts;
using MedicationManager.Data.Providers.Documents;
using MedicationManager.Data.Providers.Filters;

namespace MedicationManager.BusinessLogic.Providers.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IMapper _mapper;
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IMapper mapper, IProviderRepository providerRepository)
        {
            _mapper = mapper;
            _providerRepository = providerRepository;
        }

        public async Task<List<ProviderDto>> ListAsync(ProviderFilterDto filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var documentFilter = new ProviderFilter
            {
                CompanyName = new List<string> { filter.CompanyName }
            };

            var providers = await _providerRepository.GetProvidersAsync(documentFilter);

            var dtos = _mapper.Map<List<ProviderDto>>(providers);

            return dtos;
        }

        public async Task<List<ProviderDto>> ListAllAsync()
        {
            var providers = await _providerRepository.GetAllProvidersAsync();

            var dtos = _mapper.Map<List<ProviderDto>>(providers);

            return dtos;
        }

        public async Task<ProviderDto> GetByIdAsync(string id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);

            var dto = _mapper.Map<ProviderDto>(provider);

            return dto;
        }

        public async Task UpdateAsync(ProviderDto dto)
        {
            var provider = _mapper.Map<ProviderDocument>(dto);

            await _providerRepository.UpdateAsync(provider);
        }

        public async Task AddAsync(ProviderDto dto)
        {
            var provider = _mapper.Map<ProviderDocument>(dto);

            await _providerRepository.AddAsync(provider);
        }

        public async Task DeleteAsync(string id)
        {
            await _providerRepository.DeleteAsync(id);
        }
    }
}
