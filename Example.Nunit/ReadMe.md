Getting Started :

Dependency Injection:

Test Configuration:

Logging :
 1. To enable logging of test case at test level use inbuilt Trace supported by Nunit
   Add Trace.Listeners.Add(new ConsoleTraceListener()); in one time setop and use it in test. [Nunit Log](https://docs.nunit.org/articles/vs-test-adapter/Trace-and-Debug.html)
2. Logs are also supported at framework level . They can be called by using IloggerServices.Please refer BalzeHomePage.cs.

Reporting :
1. Change the Report name to "Extent"  and corrsponding report will be
   generate in Report folder .
2. Allure Report will be generated if [AllureNUnit] is added on test class or base test.
    1.  Requires installation of Allure commandline [Allure Report Installation](https://allurereport.org/docs/gettingstarted-installation/ )
    2.  `allure serve` will open the report , depends on how it was installed.
    3. For example if it is installed by NPM . Use ` npx allure-commandline serve`