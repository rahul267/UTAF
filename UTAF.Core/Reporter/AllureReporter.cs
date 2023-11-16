using Allure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTAF.Core.Reporter
{
    public class AllureReporter : IReporter
    {
        public  AllureReporter()
        {
         
        }
        public void StartTest(string testName)
        {
            // Allure-specific implementation for starting a test
            //AllureLifecycle.Instance.WrapInStep(() => { /* Start test logic */ }, testName);
        }

        public void Log(string message)
        {
            // Allure-specific implementation for logging
           // AllureLifecycle.Instance.WrapInStep(() => { /* Log logic */ }, "Logging Step");
        }

        public void Pass(string message)
        {
            // Allure-specific implementation for passing a test
           // AllureLifecycle.Instance.CurrentTestCase.MarkAsPassed();
        }

        public void Fail(string message)
        {
            // Allure-specific implementation for failing a test
            //AllureLifecycle.Instance.CurrentTestCase.MarkAsFailed();
        }

        public void StopTest()
        {
            // Allure-specific implementation for finishing a test
            //AllureLifecycle.Instance.WrapInStep(() => { /* Stop test logic */ }, "Finishing Test");
        }

    }
}
