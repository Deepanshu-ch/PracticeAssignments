using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAssignments
{
    static class Extension
    {
        public static string Truncate(this string longString)
        {
            string shortString = longString[..20];
            return $"{shortString}...";
        }
    }
}
