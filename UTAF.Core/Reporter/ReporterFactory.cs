using core.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAF.Core.Models;

namespace UTAF.Core.Reporter
{
    public class ReporterFactory : IReporterFactory , IDisposable
    {
        private static ReporterConfiguration reporterConfiguration;
        public IReporter Reporter { get; }
        public ReporterFactory(ReporterConfiguration _reporterConfiguration)
        {
            reporterConfiguration = _reporterConfiguration;
            Reporter = CreateReporter();
        }
        public static IReporter CreateReporter()
        {
            return reporterConfiguration.ReportName switch
            {
                ReporterType.Extent => new ExtentReporter(),
                ReporterType.Allure => new AllureReporter(),
                //ReporterType.ReportPortal => new ReportPortalReporter(),
                _ => new ExtentReporter()
            };

        }
        public void Dispose()
        {
            Reporter.StopTest();
        }



    }
    public enum ReporterType
    {
        Extent,
        Allure,
        ReportPortal
    }
}
