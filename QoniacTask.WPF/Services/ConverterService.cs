using QoniacTask.WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace QoniacTask.WPF.Services
{
    public class ConverterService : IConverterService
    {
        public async Task<string> GetConvertedValue(string parameter)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    if (!Helper.IsCorrectFormat(parameter))
                    {
                        return "Wrong input format.";
                    }

                    double value = Helper.GetDoubleValue(parameter);

                    var stringContent = JsonSerializer.Serialize(value);
                    var content = new StringContent(stringContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://localhost:7094/NumberToWordsConverter/ConvertToWords", content);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Conversion error.");
                    }

                    string data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }
    }
}
