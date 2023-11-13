using Qoniac.WebApi.Helpers;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace Qoniac.WebApi.Services
{
    public class NumberConversionService : INumberConversionService
    {
        private readonly Dictionary<int, string> units = new Dictionary<int, string>()
        {
            { 0 , "zero"},
            { 1 , "one"},
            { 2 , "two"},
            { 3 , "three"},
            { 4 , "four"},
            { 5 , "five"},
            { 6 , "six"},
            { 7 , "seven"},
            { 8 , "eight"},
            { 9 , "nine"},
            { 10 , "ten"},
            { 11 , "eleven"},
            { 12 , "twelve"},
            { 13 , "thirteen"},
            { 14 , "fourteen"},
            { 15 , "fifteen"},
            { 16 , "sixteen"},
            { 17 , "seventeen"},
            { 18 , "eighteen"},
            { 19 , "nineteen"}
        };

        private readonly Dictionary<int, string> tens = new Dictionary<int, string>()
        {
            { 0 , "zero"},
            { 1 , "ten"},
            { 2 , "twenty"},
            { 3 , "thirty"},
            { 4 , "forty"},
            { 5 , "fifty"},
            { 6 , "sixty"},
            { 7 , "seventy"},
            { 8 , "eighty"},
            { 9 , "ninety"}
        };

        private readonly int tenMultiplier = 10;

        public async Task<string> GetConvertedNumber(double number)
        {
            if (!Helper.IsWithInRange(number))
            {
                return "The value is out of range.";
            }

            string result = ConvertNumberToWords(number);
            return result;
        }

        private string ConvertNumberToWords(double number)
        {
            if (number == 0 || number == 1)
            {
                return number == 0 ? units[(int)number] + " dollars" : units[(int)number] + " dollar";
            }

            StringBuilder sb = new StringBuilder();

            int millions = (int)(number / 1000000);
            int thousands = (int)((number % 1000000) / 1000);
            int hundreds = (int)(number % 1000);
            int cents = (int)((number % 1) * 100);

            bool isAndCents = false;

            if (millions > 0)
            {
                sb.Append(GetDollarsInWords(millions, "million "));
                isAndCents = true;
            }

            if (thousands > 0)
            {
                sb.Append(GetDollarsInWords(thousands, "thousand "));
                isAndCents = true;
            }

            if (hundreds > 0)
            {
                sb.Append(GetDollarsInWords(hundreds, "dollars"));
                isAndCents = true;
            }

            if (cents > 0)
            {
                if (isAndCents)
                {
                    sb.Append(" and " + GetCentsInWords(cents));
                }
                else
                {
                    sb.Append(GetCentsInWords(cents));
                }
            }

            return sb.ToString();
        }
        private string GetDollarsInWords(int number, string rang = "")
        {
            string result = string.Empty;

            int hundred = number / 100;
            int ten = (number - (hundred * 100)) / 10;
            int unit = number - hundred * 100 - ten * 10;

            if (hundred > 0)
            {
                result += units[hundred] + " hundred ";
            }

            if (ten > 0)
            {
                int tensOrig = ten * tenMultiplier + unit;
                
                if (tensOrig < 20)
                {
                    result += units[tensOrig] + " " + rang;
                    return result;
                }
                else
                {
                    if (unit > 0)
                    {
                        result += tens[ten] + "-";
                    }
                    else
                    {
                        result += tens[ten] + " ";
                    }
                }
            }

            if (unit > 0)
            {
                result += units[unit] + " ";
            }

            result += rang;

            return result;
        }
        private string GetCentsInWords(int number)
        {
            string result = string.Empty;

            if (number < 20)
            {
                if (number == 1)
                {
                    return units[number] + " cent";
                }

                return units[number] + " cents";
            }

            int ten = number / 10;
            int unit = number % 10;

            if (unit > 0)
            {
                result += tens[ten] + "-";
            }
            else
            {
                result += tens[ten];
            }

            if (unit > 0)
            {
                result += units[unit];
            }

            return result + " cents";
        }
    }
}
