using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;


namespace UTAF.Core.Reporter
{
    public class ExtentReporter : IReporter
    {
        private const string FAILED = "Failed";
        private const string INCONCLUSIVE = "Inconclusive";
        private const string SKIPPED = "Skipped";
       
        protected static  ExtentReports extent {  get; }

        [ThreadStatic]
        protected static ExtentTest _feature;
        [ThreadStatic]
        protected static ExtentTest _scenario;


         static  ExtentReporter()
        {
            var extentSparkReporter = new ExtentSparkReporter(ReportDirectoryCreator());
            var  extentReports = new ExtentReports();
            extentReports.AttachReporter(extentSparkReporter);
            extent = extentReports;
        }

        public void StartTest(string testName)
        {
            _feature = extent.CreateTest(testName);
        }

        public void StartFeature(string testName)
        {
            _feature = extent.CreateTest(new GherkinKeyword("Feature"),testName);
            
        }

        public void StartScenario(string scenarioName)
        {
            _scenario = _feature.CreateNode(new GherkinKeyword("Scenario"), scenarioName);
        }

        public void Log(string stacktrace)
        {
        }
        public void LogNunit(string status, string? log, string stacktrace)
        {
            switch (status)
            {
                case FAILED:
                    Fail(stacktrace);
                    break;
                case INCONCLUSIVE:
                    Inconclusive(log);
                    break;
                case SKIPPED:
                    Skipped(log);
                    break;
                default:
                    Pass("This test passed"+log);
                    break;
            }
        }



        public void StopTest()
        {
            // Extent-specific implementation for finishing a test
            extent.Flush();
        }

        public void Pass(String log)
        {
            _feature.Pass(log);
        }

       public  void Fail(String log)
        {
            _feature.Fail(log);
        }

        public void Inconclusive(String log)
        {
            _feature.Warning(log);
        }

        public void Skipped(String log)
        {
            _feature.Skip(log);
        }

        public  void FailSpec(string stepType, string stepText, string errorMessage)
        {
            if (stepType == "Given")
            {
                _scenario.CreateNode<Given>(stepText).Fail(errorMessage);
            }
            else if (stepType == "When")
            {
                _scenario.CreateNode<When>(stepText).Fail(errorMessage);
            }
            else if (stepType == "Then")
            {
                _scenario.CreateNode<Then>(stepText).Fail(errorMessage);
            }
            else if (stepType == "And")
            {
                _scenario.CreateNode<And>(stepText).Fail(errorMessage);
            }
        }

        public  void PassSpec(string stepType, string stepText)
        {
            if (stepType == "Given")
                _scenario.CreateNode<Given>(stepText);
            else if (stepType == "When")
                _scenario.CreateNode<When>(stepText);
            else if (stepType == "Then")
                _scenario.CreateNode<Then>(stepText);
            else if (stepType == "And")
                _scenario.CreateNode<And>(stepText);
        }

        private static String ReportDirectoryCreator()
        {
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "MyExtentReport.html");
            if (!Directory.Exists(Path.GetDirectoryName(reportPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath));
            }
            return reportPath;
        }
        
    }
    

}
