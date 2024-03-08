using Microsoft.Extensions.Configuration;
using UTAF.Core.Models;

namespace core.Providers
{
    public interface ICoreConfigurationProvider
    {
        LoggerConfiguration LoggerConfiguration { get; }
        ReporterConfiguration ReporterConfiguration { get; }
    }
    public class CoreConfigurationProvider:ICoreConfigurationProvider
    {
        private readonly IConfiguration _configuration;
        public CoreConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoggerConfiguration LoggerConfiguration => _configuration.GetSection("logger").Get<LoggerConfiguration>();
        public ReporterConfiguration ReporterConfiguration => _configuration.GetSection("reporter").Get<ReporterConfiguration>();
    }
}
