using MedicationManager.Data.Common.Immutable;
using MedicationManager.Data.Stocks.Contracts;
using MedicationManager.Data.Stocks.Documents;
using MedicationManager.Infrastructure.Contexts;

namespace MedicationManager.Data.Stocks.Repositories
{
    public class DeliveryRepository : BaseStockRepository<DeliveryDocument>, IDeliveryRepository
    {
        protected override string CollectionName => CollectionNames.Delivery;

        public DeliveryRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
