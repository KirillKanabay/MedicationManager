using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.Data.Stocks.Contracts;
using MedicationManager.Data.Stocks.Documents;
using MedicationManager.Infrastructure.Extensions;

namespace MedicationManager.BusinessLogic.Stock.Services
{
    public class DeliveryService : BaseStockService<DeliveryDto, DeliveryDocument>, IDeliveryService
    {
        private readonly IProviderService _providerService;
        private readonly IMedicationService _medicationService;

        public DeliveryService(IMapper mapper, IMedicationService medicationService, IDeliveryRepository deliveryRepository, IProviderService providerService) : base(mapper, medicationService, deliveryRepository)
        {
            _medicationService = medicationService;
            _providerService = providerService;
        }

        public override async Task AddAsync(DeliveryDto dto)
        {
            await _medicationService.AddCountAsync(dto.MedicationId, dto.Count);

            dto.TotalPrice = dto.Count * dto.PricePerItem;

            await base.AddAsync(dto);
        }

        protected override async Task<DeliveryDto> ToDto(DeliveryDocument document)
        {
            var baseDto = await base.ToDto(document);

            if (!baseDto.ProviderId.IsNullOrWhitespace())
            {
                var provider = await _providerService.GetByIdUnsafeAsync(baseDto.ProviderId);

                baseDto.Provider = provider;
            }

            return baseDto;
        }
    }
}
