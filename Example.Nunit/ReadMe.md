Getting Started :

Dependency Injection:

Test Configuration:

Logging :
 1. To enable logging of test case at test level use inbuilt Trace supported by Nunit
   Add Trace.Listeners.Add(new ConsoleTraceListener()); in one time setop and use it in test.
https://docs.nunit.org/articles/vs-test-adapter/Trace-and-Debug.html
2. Logs are also supported at framework level . They can be called by using IloggerServices.Please refer BalzeHomePage.cs.

Reporting :
1. Change the Report name to Extent /Allure and corrsponding report will be
   generate in Report folder .