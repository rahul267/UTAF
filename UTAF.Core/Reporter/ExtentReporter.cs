using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace UTAF.Core.Reporter
{
    internal class ExtentReporter : IReporter
    {
        private readonly ExtentReports extent;

       
        public ExtentReporter()
        {
            var extentSparkReporter = new ExtentSparkReporter("Spark.html");
            var extentReports = new ExtentReports();
            extentReports.AttachReporter(extentSparkReporter);

            extent= extentReports;
        }

        public void StartTest(string testName)
        {
            // Extent-specific implementation for starting a test
            extent.CreateTest(testName);
        }

        public void Log(string message)
        {
            // Extent-specific implementation for logging
           // extent.AddTestRunnerOutput(message);
        }

        public void Pass(string message)
        {
            // Extent-specific implementation for passing a test
            extent.Flush();
        }

        public void Fail(string message)
        {
            // Extent-specific implementation for failing a test
            extent.Flush();
        }

        public void StopTest()
        {
            // Extent-specific implementation for finishing a test
            extent.Flush();
        }

    }
}
