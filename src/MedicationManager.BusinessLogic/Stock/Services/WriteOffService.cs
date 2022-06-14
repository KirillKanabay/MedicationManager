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
        public WriteOffService(IMapper mapper, IMedicationService medicationService, IWriteOffRepository writeOffRepository) : base(mapper, medicationService, writeOffRepository)
        {
        }
    }
}