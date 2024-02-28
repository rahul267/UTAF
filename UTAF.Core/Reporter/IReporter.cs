using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTAF.Core.Reporter
{
    public interface IReporter
    {
        void StartFeature(string testName);
        void StartTest(string testName);
        void StartScenario(string testName);
        void Log(String message);
        void LogNunit(string status, string? log , string stackTrace);
        void StopTest();
        void Pass(String log);
        void Fail(String log);
        void Inconclusive(String log);
        void Skipped(String log);
         void PassSpec(string stepType, string stepText){ }
         void FailSpec(string stepType, string stepText, string errorMessage) { }


    }
}
