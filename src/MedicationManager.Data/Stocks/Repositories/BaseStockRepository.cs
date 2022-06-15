using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Data.Common.BaseRepositories;
using MedicationManager.Data.Stocks.Contracts;
using MedicationManager.Data.Stocks.Documents;
using MedicationManager.Infrastructure.Contexts;

namespace MedicationManager.Data.Stocks.Repositories
{
    public abstract class BaseStockRepository<TStockDocument> : RepositoryBase<TStockDocument>, IStockRepository<TStockDocument>
        where TStockDocument : BaseStockDocument
    {
        protected BaseStockRepository(IDbContext dbContext) : base(dbContext)
        {
        }
        
        public Task<List<TStockDocument>> GetAllAsync()
        {
            return base.ListAllAsync();
        }

        public Task UpdateAsync(TStockDocument document)
        {
            return base.UpdateOneAsync(document);
        }

        public Task AddAsync(TStockDocument document)
        {
            return base.InsertAsync(document);
        }

        public Task DeleteAsync(string id)
        {
            return base.RemoveAsync(id);
        }
    }
}
