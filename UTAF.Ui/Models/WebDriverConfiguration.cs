namespace UTAF.Ui.Models
{
    public class WebDriverConfiguration
    {
        public BrowserType BrowserName { get; set; }
        public string? ScreenshotsPath { get; set; }
        public int? DefaultTimeout { get; set; }
        public int? PollingInterval { get; set; }
        public string? BrowserLanguage { get; set; }
        public string? LocalWebDriverPath { get; set; }
        public string? OptionArgMax { get; set; }

    }
}
