using MongoDB.Driver;

namespace MedicationManager.Infrastructure.Contexts
{
    public interface IDbContext
    {
        IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName);
    }
}
