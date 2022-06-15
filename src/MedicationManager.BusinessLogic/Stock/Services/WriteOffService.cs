using System.Threading.Tasks;
using AutoMapper;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Stock.Contracts;
using MedicationManager.BusinessLogic.Stock.Dtos;
using MedicationManager.Data.Stocks.Contracts;
using MedicationManager.Data.Stocks.Documents;

namespace MedicationManager.BusinessLogic.Stock.Services
{
    public class WriteOffService : BaseStockService<WriteOffDto, WriteOffDocument>, IWriteOffService
    {
        private readonly IMedicationService _medicationService;

        public WriteOffService(IMapper mapper, IMedicationService medicationService, IWriteOffRepository writeOffRepository) : base(mapper, medicationService, writeOffRepository)
        {
            _medicationService = medicationService;
        }

        public override async Task AddAsync(WriteOffDto dto)
        {
            await _medicationService.SubtractCountAsync(dto.MedicationId, dto.Count);

            dto.TotalPrice = dto.Count * dto.PricePerItem;

            await base.AddAsync(dto);
        }
    }
}