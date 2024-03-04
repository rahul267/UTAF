using TechTalk.SpecFlow;
using UTAF.Core.Reporter;
using UTAF.Ui.Driver;

namespace Example.Specflow.Hooks
{
    [Binding]
    public class ExtentHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public static IReporter _reporter;
        private IDriverFactory _driver;


        public ExtentHooks(FeatureContext featureContext,ScenarioContext scenarioContext,IDriverFactory driver)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _driver = driver;  
        }

        [BeforeTestRun]
        public static void InitializeReport(IReporterFactory reporter)
        {
            _reporter = reporter.Reporter;
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
           
            _reporter.StartFeature(featureContext.FeatureInfo.Title);

        }
       
        [BeforeScenario]
        public void InitializeScenario()
        {
            _reporter.StartScenario(_scenarioContext.ScenarioInfo.Title);
            
        }

        [AfterFeature]
        public static void CloseFaeture()
        {
            _reporter.StopTest();
        }

        [AfterScenario]
        public static void CloseScenario()
        {
            _reporter.StopTest();
        }

        [AfterStep]
        public  void InsertReportingSteps()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
                
            var stepText = _scenarioContext.StepContext.StepInfo.Text;
            
            if (_scenarioContext.TestError == null)
            {
                _reporter.PassSpec(stepType, stepText);
            }
            else if (_scenarioContext.TestError != null)
            {
                var errorMessage = _scenarioContext.TestError.Message;
                var imgPath = _driver.TakeScreenshotAsPath("img.png");
                _reporter.FailSpec(stepType, stepText, errorMessage,imgPath);
            }
        }

        

        [AfterTestRun]
        public  static void TearDownReport()
        {
            _reporter.StopTest();
        }

       
    }
}
