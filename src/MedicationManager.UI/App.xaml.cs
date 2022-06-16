using System;
using System.Windows;
using MedicationManager.UI.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationManager.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var startup = new Startup();
            var services = startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var window = scope.ServiceProvider.GetService<StartWindow>();

                if (window is null)
                {
                    throw new Exception("Start window not found. Check window registration in Startup.cs");
                }

                window.Show();
            }

            base.OnStartup(e);
        }
    }
}
