using core.Providers;
using Example.Specflow.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SolidToken.SpecFlow.DependencyInjection;
using UTAF.Core.Logger;
using UTAF.Core.Reporter;
using UTAF.Ui.Driver;
using UTAF.Ui.Providers;

namespace Example.Specflow.DI
{
   
    public partial class DependencyInjector
    {
        [ScenarioDependencies]
        public static IServiceCollection GetServiceProvider()
        {
            var services = new ServiceCollection();
            services
              .AddScoped<IBalazeHomePage, BalazeHomePage>()
              .AddSingleton<ILoggerService, LoggerService>()
              .AddSingleton(CoreConfigurationProvide.ReporterConfiguration)
              .AddSingleton<IReporterFactory, ReporterFactory>()
              .AddSingleton(UIConfigurationProvider.Environment)
              .AddSingleton(UIConfigurationProvider.WebDriver)
              .AddScoped<IDriverFactory, DriverFactory>()
              .AddScoped<IDriverWait, DriverWait>();

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            });

            return services;

        }
    }
}
