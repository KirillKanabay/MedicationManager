using MedicationManager.Data.Stocks.Documents;

namespace MedicationManager.Data.Stocks.Contracts
{
    public interface IWriteOffRepository : IStockRepository<WriteOffDocument>
    {
    }
}