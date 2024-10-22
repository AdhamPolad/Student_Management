using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementWithSql.Confics
{
    internal static class DbConfics
    {
        public static string ConnectionStr { get; } = "Server=localhost; Database=StudentDB; Integrated Security = true; Encrypt = false";
    }
}
