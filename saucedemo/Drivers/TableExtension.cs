using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saucedemo.Drivers
{
    public class TableExtension
    {
        public static Dictionary<string,string> ToDictionary(Table table)
        {
            return table.Rows.ToDictionary(row => row[0], row => row[1]);
        }
    }
}
