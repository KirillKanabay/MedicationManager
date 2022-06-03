using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicationManager.Common.Data.BaseRepositories;
using MedicationManager.Common.Data.Immutable;
using MedicationManager.Common.Extensions;
using MedicationManager.Data.Providers.Contracts;
using MedicationManager.Data.Providers.Documents;
using MedicationManager.Data.Providers.Filters;
using MedicationManager.Infrastructure.Contexts;
using MongoDB.Driver.Linq;

namespace MedicationManager.Data.Providers.Repositories
{
    public class ProviderRepository : RepositoryBase<ProviderDocument>, IProviderRepository
    {
        protected override string CollectionName => CollectionNames.Provider;

        public ProviderRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<ProviderDocument>> GetAllProvidersAsync()
        {
            return base.ListAllAsync();
        }

        public Task<List<ProviderDocument>> GetProvidersAsync(ProviderFilter filter)
        {
            var query = GetQuery();

            if (!filter.CompanyName.IsNullOrWhitespace())
            {
                if (filter.CompanyName.Count == 1)
                {
                    var companyName = filter.CompanyName.First();
                    var regex = new Regex($"^.*{companyName}.*", RegexOptions.IgnoreCase);
                    query = query.Where(x => regex.IsMatch(x.CompanyName));
                }
                else
                {
                    query = query.Where(x => filter.CompanyName.Contains(x.CompanyName));
                }
            }

            if (filter.Id.IsPresent())
            {
                query = query.Where(x => filter.Id.Contains(x.Id));
            }

            return ListAsync(query);
        }

        public Task UpdateAsync(ProviderDocument document)
        {
            return base.UpdateOneAsync(document);
        }

        public Task AddAsync(ProviderDocument document)
        {
            return base.InsertAsync(document);
        }

        public Task DeleteAsync(string id)
        {
            return base.RemoveAsync(id);
        }
    }
}
