using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Data.Stocks.Documents;

namespace MedicationManager.Data.Stocks.Contracts
{
    public interface IStockRepository<TStockDocument> where TStockDocument : BaseStockDocument
    {
        Task<List<TStockDocument>> GetAllAsync();
        Task<TStockDocument> GetByIdAsync(string id, bool unSafe = false);
        Task UpdateAsync(TStockDocument document);
        Task AddAsync(TStockDocument document);
        Task DeleteAsync(string id);
    }
}