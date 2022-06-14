using MedicationManager.Data.Common.Immutable;
using MedicationManager.Data.Stocks.Contracts;
using MedicationManager.Data.Stocks.Documents;
using MedicationManager.Infrastructure.Contexts;

namespace MedicationManager.Data.Stocks.Repositories
{
    public class WriteOffRepository : BaseStockRepository<WriteOffDocument>, IWriteOffRepository
    { 
        protected override string CollectionName => CollectionNames.WriteOff;
        
        public WriteOffRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
