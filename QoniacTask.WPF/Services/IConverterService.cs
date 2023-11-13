using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoniacTask.WPF.Services
{
    public interface IConverterService
    {
        Task<string> GetConvertedValue(string value);
    }
}
