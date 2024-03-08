using core.Providers;
using Microsoft.Extensions.Configuration;
using UTAF.Ui.Models;

namespace UTAF.Ui.Providers
{
    public interface IUIConfigurationProvider : ICoreConfigurationProvider
    {
        WebDriverConfiguration WebDriver { get; }
        EnvironmentConfiguration Environment { get; }
        GridConfiguration GridConfiguration { get; }
    }
    public class UIConfigurationProvider : CoreConfigurationProvider, IUIConfigurationProvider
    {
            private readonly IConfiguration _configuration;

            public UIConfigurationProvider(IConfiguration configuration) : base(configuration)
            {
                _configuration = configuration;
            }

            public WebDriverConfiguration WebDriver => _configuration.GetSection("webdriver").Get<WebDriverConfiguration>();

            public EnvironmentConfiguration Environment => _configuration.GetSection("environment").Get<EnvironmentConfiguration>();

            public GridConfiguration GridConfiguration => _configuration.GetSection("grid").Get<GridConfiguration>();
        }


    }
