using Microsoft.Extensions.ObjectPool;
using System.Text.RegularExpressions;

namespace Qoniac.WebApi.Helpers
{
    public static class Helper
    {
        public static bool IsWithInRange(double number)
        {
            try
            {
                double minDollars = 0;
                double maxDollars = 999999999;
                double maxCents = 99;
                double cents = ParseCents(number);

                bool isWithin = ((int)number >= minDollars && (int)number <= maxDollars) && cents <= maxCents;

                return isWithin;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        private static int ParseCents(double value)
        {
            string sValue = value.ToString();

            if (sValue.Contains('.'))
            {
                string intValue = sValue.Split(".")[1];

                return int.Parse(intValue);
            }

            return 0;
        }
    }
}
