using core.Providers;
using UTAF.Ui.Models;

namespace UTAF.Ui.Providers
{
    public class UIConfigurationProvider : CoreConfigurationProvide
    {
        private const string WebDriverConfigSectionName = "webdriver";
        private const string EnvironmentConfigSectionName = "environment";

        public static WebDriverConfiguration WebDriver =>
            Load<WebDriverConfiguration>(WebDriverConfigSectionName);

        public static EnvironmentConfiguration Environment =>
            Load<EnvironmentConfiguration>(EnvironmentConfigSectionName);

    }
}
