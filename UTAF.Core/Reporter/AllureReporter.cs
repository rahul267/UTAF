using Allure.Net.Commons;


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



        public void Log(string message)
        {
            AllureLifecycle.Instance.AddAttachment("Log", "text/plain", message);
        }

        public void Pass(string message)
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

    }
}

