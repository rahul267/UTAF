using Allure.Net.Commons;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Gherkin;


namespace UTAF.Core.Reporter
{
    [NUnit.Allure.Core.AllureNUnit]
    public class AllureReporter : IReporter
    {
        public  AllureReporter()
        {
            
        }
        public void StartTest(string testName)
        {
            AllureLifecycle.Instance.UpdateTestCase(tc => tc.name = testName);
        }

        public void StartScenario(string scenarioName)
        {
           
        }



        public void Log(string message)
        {
            AllureLifecycle.Instance.AddAttachment("Log", "text/plain", message);
        }

        public void Pass(String log)
        {
            AllureLifecycle.Instance.UpdateTestCase(tc => tc.status = Status.passed);
        }

        public void Fail(string message)
        {
            AllureLifecycle.Instance.UpdateTestCase(tc => tc.status = Status.failed);
        }

        public void StopTest()
        {
            //AllureLifecycle.Instance.StopTestCase();
        }

        void IReporter.Inconclusive(String log)
        {
            throw new NotImplementedException();
        }

        void IReporter.Skipped(String log)
        {
            throw new NotImplementedException();
        }

        void IReporter.LogNunit(string status, string? log, string stackTrace)
        {
            throw new NotImplementedException();
        }

        void IReporter.StartFeature(string testName)
        {
            throw new NotImplementedException();
        }
    }
}

