using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Dtos;
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
        private readonly IMedicationService _medicationService;

        public ProviderService(IMapper mapper, IProviderRepository providerRepository, IMedicationService medicationService)
        {
            _mapper = mapper;
            _providerRepository = providerRepository;
            _medicationService = medicationService;
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

            var dtos = await ToDto(providers);

            return dtos;
        }

        public async Task<List<ProviderDto>> ListAllAsync()
        {
            var providers = await _providerRepository.GetAllProvidersAsync();

            var dtos = await ToDto(providers);

            return dtos;
        }

        public async Task<ProviderDto> GetByIdAsync(string id)
        {
            var provider = await _providerRepository.GetByIdAsync(id);

            var dto = await ToDto(provider);

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

        private async Task<List<ProviderDto>> ToDto(List<ProviderDocument> documents)
        {
            var tasks = documents.Select(ToDto);

            var result = await Task.WhenAll(tasks);

            return result.ToList();
        }

        private async Task<ProviderDto> ToDto(ProviderDocument document)
        {
            var dto = _mapper.Map<ProviderDto>(document);
            
            if (dto.Products?.Any() ?? false)
            {
                var productsId = dto.Products?.Select(x => x.MedicationId).ToList();

                var medications = await _medicationService.ListAsync(new MedicationFilterDto
                {
                    Id = productsId
                });

                foreach (var providerProductDto in dto.Products)
                {
                    providerProductDto.ProviderId = dto.Id;
                    providerProductDto.Medication = medications
                        .FirstOrDefault(x => x.Id.Equals(providerProductDto.MedicationId));
                }
            }

            dto.Products = dto.Products?.Where(x => x.Medication != null).ToList() ?? new List<ProviderProductDto>();

            return dto;
        }
    }
}
