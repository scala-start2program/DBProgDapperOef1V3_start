using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Gezelschapsspelen.Core.Services
{
    internal class Helper
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ScalaGezelschapsspelen; Integrated security=true;";
        }
        public static string HandleQuotes(string value)
        {
            return value.Trim().Replace("'", "''");
        }
    }
}
