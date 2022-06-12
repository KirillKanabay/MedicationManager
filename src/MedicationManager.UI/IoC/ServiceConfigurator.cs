using System;
using System.Collections.Generic;
using System.Reflection;
using MedicationManager.BusinessLogic.Medications.Contracts;
using MedicationManager.BusinessLogic.Medications.Services;
using MedicationManager.BusinessLogic.Providers.Contracts;
using MedicationManager.BusinessLogic.Providers.Services;
using MedicationManager.Data.Medications.Contracts;
using MedicationManager.Data.Medications.Repositories;
using MedicationManager.Data.Providers.Contracts;
using MedicationManager.Data.Providers.Repositories;
using MedicationManager.Infrastructure.Configurations;
using MedicationManager.Infrastructure.Contexts;
using MedicationManager.UI.Core.ViewModels;
using MedicationManager.UI.Core.ViewModels.Medications;
using MedicationManager.UI.Core.ViewModels.Providers;
using MedicationManager.UI.Core.ViewModels.Providers.Import;
using MedicationManager.UI.Core.ViewModels.Providers.Import.Creator;
using MedicationManager.UI.Views;
using MedicationManager.UI.Views.Providers;
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
            services.AddSingleton<IProviderRepository, ProviderRepository>();
        }
        
        public static void RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<StartWindowViewModel>();
            services.AddTransient<MainMenuViewModel>();

            services.AddTransient<MedicationControlViewModel>();
            services.AddTransient<MedicationSelectableItemViewModel>();
            services.AddTransient<MedicationEditorViewModel>();
            services.AddTransient<MedicationCreatorViewModel>();

            services.AddTransient<ProviderControlViewModel>();
            services.AddTransient<ProviderSelectableItemViewModel>();
            services.AddTransient<ProviderEditorViewModel>();
            services.AddTransient<ProviderCreatorViewModel>();
            services.AddTransient<ProviderInformationCreatorViewModel>();
            services.AddTransient<ProviderProductCreatorViewModel>();
            services.AddTransient<ProviderConcreteProductCreatorViewModel>();
            services.AddTransient<ProviderProductSelectableItemViewModel>();
        }

        public static void RegisterWindows(this IServiceCollection services)
        {
            services.AddTransient<StartWindow>();
        }

        public static void RegisterViews(this IServiceCollection services)
        {
            services.AddTransient<MedicationsControlView>();
            services.AddTransient<ProvidersControlView>();
        }

        public static void RegisterBllServices(this IServiceCollection services)
        {
            services.AddSingleton<IMedicationService, MedicationService>();
            services.AddSingleton<IProviderService, ProviderService>();
        }

        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper 
            (
                cfg =>
                {
                    cfg.AddMaps
                    (
                        typeof(IMedicationService).GetTypeInfo().Assembly, //Medication.BusinessLogic
                        typeof(MedicationControlViewModel).GetTypeInfo().Assembly //Medication.UI.Core
                    );

                    cfg.DisableConstructorMapping();
                });
        }
    }
}
