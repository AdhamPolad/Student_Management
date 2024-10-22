using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    internal interface ILogger
    {
        void LogError(Exception exp);
        void LogInfo(string message);
        void LogError(string message);

    }
}
