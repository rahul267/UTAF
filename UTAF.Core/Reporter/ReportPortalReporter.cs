


namespace UTAF.Core.Reporter
{
    public  class ReportPortalReporter: IReporter
    {
        

        public ReportPortalReporter()
        {
        }

        

        public void StartTest(string testName)
        {
            // ReportPortal-specific implementation for starting a test
            //testReporter.StartTest(testName);
        }

        public void Log(string message)
        {
            // ReportPortal-specific implementation for logging
            //testReporter.Log(message);
        }

        public void Pass(string message)
        {
            // ReportPortal-specific implementation for passing a test
           // testReporter.Pass(message);
        }

        public void Fail(string message)
        {
            // ReportPortal-specific implementation for failing a test
            //testReporter.Fail(message);
        }

        public void StopTest()
        {
            // ReportPortal-specific implementation for finishing a test
           // testReporter.FinishTest();
        }

    }
}
