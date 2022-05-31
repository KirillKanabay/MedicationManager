using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicationManager.Common.Data.BaseRepositories;
using MedicationManager.Common.Data.Immutable;
using MedicationManager.Common.Extensions;
using MedicationManager.Data.Medications.Contracts;
using MedicationManager.Data.Medications.Documents;
using MedicationManager.Data.Medications.Filters;
using MedicationManager.Infrastructure.Contexts;
using MongoDB.Driver.Linq;

namespace MedicationManager.Data.Medications.Repositories
{
    public class MedicationRepository : RepositoryBase<MedicationDocument>, IMedicationRepository
    {
        protected override string CollectionName => CollectionNames.Medication; 

        public MedicationRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<MedicationDocument>> GetAllMedicationsAsync()
        {
            return ListAllAsync();
        }

        public Task<List<MedicationDocument>> GetMedicationsAsync(MedicationFilter filter)
        {
            var query = GetQuery();

            if (!filter.Name.IsNullOrWhitespace())
            {
                if (filter.Name.Count == 1)
                {
                    var medicationName = filter.Name.First();
                    var regex = new Regex($"^.*{medicationName}.*", RegexOptions.IgnoreCase);
                    query = query.Where(x => regex.IsMatch(x.Name));
                }
                else
                {
                    query = query.Where(x => filter.Name.Contains(x.Name));
                }
            }

            if (filter.Id.IsPresent())
            {
                query = query.Where(x => filter.Id.Contains(x.Id));
            }

            return ListAsync(query);
        }

        public Task UpdateAsync(MedicationDocument document)
        {
            return base.UpdateOneAsync(document);
        }

        public Task AddAsync(MedicationDocument document)
        {
            return base.InsertAsync(document);
        }
    }
}
