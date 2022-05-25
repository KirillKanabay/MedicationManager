using MedicationManager.Data.Medications.Contracts;
using MedicationManager.Data.Medications.Repositories;
using MedicationManager.Infrastructure.Configurations;
using MedicationManager.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationManager.UI.Core.IoC
{
    public static class ServiceConfigurator
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DbConfiguration>(opt =>
            {
                opt.ConnectionString = config.GetValue<string>("DatabaseConfiguration:ConnectionString");
                opt.DatabaseName = config.GetValue<string>("DatabaseConfiguration:DatabaseName");
            });

            services.AddSingleton<IDbContext, BaseMongoDbContext>();
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMedicationRepository, MedicationRepository>();
        }
    }
}
