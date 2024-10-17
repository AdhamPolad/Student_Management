using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Statics
{
    internal static class Path
    {
        private static string excelPath = @"C:\Users\aser\Desktop\c#\homework\homewrok18 excel\Students.XLSX";
        private static string logPath = @"C:\Users\aser\Desktop\c#\homework\homewrok18 excel\ConsoleApp1\ConsoleApp1\Logs\";


        public static string GetExcelPath() { return excelPath; }


        public static string GetLogPath() { return logPath; }
    }

}

