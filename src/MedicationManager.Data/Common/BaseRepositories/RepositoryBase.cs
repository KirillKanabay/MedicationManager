﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MedicationManager.Data.Common.Documents;
using MedicationManager.Infrastructure.Contexts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MedicationManager.Data.Common.BaseRepositories
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

        public virtual Task<TDocument> GetByIdAsync(string id, bool unSafe = false)
        {
            var query = GetQuery(unSafe);

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
            return GetQuery().ToListAsync();
        }

        public virtual Task<List<TDocument>> ListAsync(IMongoQueryable<TDocument> query)
        {
            return query.ToListAsync();
        }

        public virtual Task<List<TDocument>> ListAsync(FilterDefinition<TDocument> filter)
        {
            return Collection.Find(filter).ToListAsync();
        }

        public virtual Task UpdateOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(x => x.Id, document.Id);

            return Collection.ReplaceOneAsync(filter, document);
        }

        public virtual async Task RemoveAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(document => document.Id, id);
            
            await Collection.UpdateOneAsync(filter, Builders<TDocument>.Update.Set(x => x.IsDeleted, true));
        }

        public virtual async Task RemoveManyAsync(FilterDefinition<TDocument> filter)
        {
            await Collection.DeleteManyAsync(filter);
        }

        protected virtual IMongoQueryable<TDocument> GetQuery(bool includeDeletedDocuments = false)
        {
            var query = Collection.AsQueryable(new AggregateOptions {AllowDiskUse = true});

            if (!includeDeletedDocuments)
            {
                query = query.Where(x => !x.IsDeleted);
            }

            return query;
        }
    }
}
