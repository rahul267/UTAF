using core.Providers;
using Example.Specflow.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SolidToken.SpecFlow.DependencyInjection;
using UTAF.Api;
using UTAF.Core.Logger;
using UTAF.Core.Reporter;
using UTAF.Ui.Driver;
using UTAF.Ui.Providers;

namespace Example.Specflow.DI
{
   
    public partial class DependencyInjector
    {
       
        private const string FilePath = @"..\..\..\TestSettings.json";
        private static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        [ScenarioDependencies]
        public static IServiceCollection GetServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(SettingsPath, optional: false, reloadOnChange: true)
            .Build();

            var services = new ServiceCollection();
            services
               .AddSingleton<IConfiguration>(configuration)
               .AddScoped<IBalazeHomePage, BalazeHomePage>()
               .AddScoped<ICalculatorPageObject, CalculatorPageObject>()
               .AddSingleton<ILoggerService, LoggerService>()
               .AddSingleton<IReporterFactory, ReporterFactory>()
               .AddSingleton<IUIConfigurationProvider, UIConfigurationProvider>()
               .AddScoped<IDriverFactory, DriverFactory>()
               .AddScoped<IDriverWait, DriverWait>()
               .AddSingleton<IRestSharpClient, RestSharpClient>()
               .AddSingleton<ICoreConfigurationProvider, CoreConfigurationProvider>();

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddConsole();
            });

            return services;

        }
    }
}
