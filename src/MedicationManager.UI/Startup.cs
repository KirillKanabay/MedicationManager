using System.IO;
using MedicationManager.UI.Core.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationManager.UI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup()
        {
            _configuration = GetConfiguration();
        }
        
        public IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.RegisterDatabase(_configuration);
            services.RegisterRepositories();

            return services;
        }

        protected IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        } 
    }
}
