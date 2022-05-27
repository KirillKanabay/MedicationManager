using MedicationManager.Data.Medications.Contracts;
using MedicationManager.Data.Medications.Repositories;
using MedicationManager.Infrastructure.Configurations;
using MedicationManager.Infrastructure.Contexts;
using MedicationManager.UI.Core.ViewModels;
using MedicationManager.UI.Core.ViewModels.Medications;
using MedicationManager.UI.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationManager.UI.IoC
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
        
        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<StartWindowViewModel>();
            services.AddTransient<MainMenuViewModel>();

            services.AddTransient<MedicationPageViewModel>();
        }

        public static void RegisterWindows(this IServiceCollection services)
        {
            services.AddTransient<StartWindow>();
        }
    }
}
