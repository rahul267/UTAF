using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTAF.Core.Reporter
{
    public interface IReporter
    {
        void StartTest(string testName);
        void Log(string message);
        void Pass(string message);
        void Fail(string message);
        void StopTest();
    }
}
