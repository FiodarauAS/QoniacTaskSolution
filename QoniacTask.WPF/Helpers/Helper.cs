using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QoniacTask.WPF.Helpers
{
    public class Helper
    {
        public static bool IsCorrectFormat(string value)
        {
            Regex regex = new Regex("^[0-9.,]*$");

            return regex.IsMatch(value);
        }

        public static double GetDoubleValue(string value)
        {
            string svalue = value;

            if (value.Contains(","))
                svalue = value.Replace(",",".");

            return double.Parse(svalue);
        }
    }
}
