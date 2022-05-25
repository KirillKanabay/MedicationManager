using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Common.Data.Documents;
using MedicationManager.Infrastructure.Contexts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MedicationManager.Common.Data.BaseRepositories
{
    public abstract class RepositoryBase
    {
        protected abstract string CollectionName { get; }
        protected readonly IDbContext DbContext; 
        
        protected RepositoryBase(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }

    public abstract class RepositoryBase<TDocument> : RepositoryBase 
        where TDocument : DocumentBase
    {
        protected RepositoryBase(IDbContext dbContext) : base(dbContext)
        {
        }

        protected IMongoCollection<TDocument> Collection => DbContext.GetCollection<TDocument>(CollectionName);

        public virtual Task<TDocument> GetByIdAsync(string id)
        {
            var query = GetQuery();

            return query.FirstOrDefaultAsync(document => document.Id.Equals(id));
        }

        public virtual Task InsertAsync(TDocument document)
        {
            return Collection.InsertOneAsync(document);
        }

        public virtual Task InsertManyAsync(List<TDocument> documents)
        {
            return Collection.InsertManyAsync(documents);
        }

        public virtual Task<List<TDocument>> ListAllAsync()
        {
            return Collection.Find(p => true).ToListAsync();
        }

        public virtual Task<List<TDocument>> ListAsync(IMongoQueryable<TDocument> query)
        {
            return query.ToListAsync();
        }

        public virtual Task<List<TDocument>> ListAsync(FilterDefinition<TDocument> filter)
        {
            return Collection.Find(filter).ToListAsync();
        }

        public virtual async Task RemoveAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, id);
            
            await Collection.DeleteOneAsync(filter);
        }

        public virtual async Task RemoveManyAsync(FilterDefinition<TDocument> filter)
        {
            await Collection.DeleteManyAsync(filter);
        }

        protected virtual IMongoQueryable<TDocument> GetQuery()
        {
            return Collection.AsQueryable(new AggregateOptions {AllowDiskUse = true});
        }
    }
}
