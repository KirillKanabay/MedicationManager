using MedicationManager.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MedicationManager.Infrastructure.Contexts
{
    public class BaseMongoDbContext : IDbContext
    {
        private readonly IMongoDatabase _database;
        public BaseMongoDbContext(IOptions<DbConfiguration> dbOptions)
        {
            var config = dbOptions.Value;

            var client = new MongoClient(config.ConnectionString);
            _database = client.GetDatabase(config.DatabaseName);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>(string collectionName)
        {
            return _database.GetCollection<TDocument>(collectionName);
        }
    }
}
