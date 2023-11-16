using Newtonsoft.Json.Linq;
using UTAF.Core.Models;

namespace core.Providers
{
    public class CoreConfigurationProvide
    {
        private const string FilePath = @"..\..\..\TestSettings.json";
        private static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);
        private const string LoggerConfigSectionName = "logger";
        private const string ReporterConfigSectionName = "reporter";


        public static LoggerConfiguration LoggerConfiguration => Load<LoggerConfiguration>(LoggerConfigSectionName);
        public static ReporterConfiguration ReporterConfiguration => Load<ReporterConfiguration>(ReporterConfigSectionName);

        protected static T Load<T>(string sectionName) =>
            JObject.Parse(File.ReadAllText(SettingsPath)).SelectToken(sectionName).ToObject<T>();
    }
}
