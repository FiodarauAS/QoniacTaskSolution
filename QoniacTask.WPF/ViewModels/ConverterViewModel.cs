using QoniacTask.WPF.Command;
using QoniacTask.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QoniacTask.WPF.ViewModels
{
    public class ConverterViewModel : ViewModelBase
    {
        private string? _valueToConvert;
        public string? ValueToConvert
        {
            get => _valueToConvert;
            set
            {
                SetProperty(ref _valueToConvert, value);
            }
        }

        private string _convertedValue;
        public string ConvertedValue
        {
            get => _convertedValue;
            set
            {
                SetProperty(ref _convertedValue, value);
            }
        }

        public ICommand ConvertCommand { get; set; }

        private readonly IConverterService _converterService;

        public ConverterViewModel(IConverterService converterService)
        {
            ConvertCommand = new RelayCommand(Convert);
            _converterService = converterService;
        }

        private async void Convert(object parameter)
        {
            ConvertedValue = await _converterService.GetConvertedValue((string)parameter);
        }
    }
}
