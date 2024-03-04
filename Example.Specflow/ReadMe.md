Logging :
 1. You can use Specflow default logs 
    _specFlowOutputHelper.WriteLine("TEXT");
    https://docs.specflow.org/projects/specflow/en/latest/outputapi/outputapi.html
 2. Logs are also supported at framework level . They can be called by using IloggerServices.Please refer BalzeHomePage.cs.
Reporting :
1. Change the Report name to "Extent" in TestSetting.json  and corrsponding report will be
   generate in Report folder .
2. Allure Report : It is unstable as on March 2024

Parallel Running :
 1. This project supports paralle running of Features in paralle. It will not 
 support parallel running of scenarios in feature.
 2. As this project is Specflow+Nunit . We need to use ```[assembly: Parallelizable(ParallelScope.Fixtures)]``` refer Hooks/ParallelNunitTests