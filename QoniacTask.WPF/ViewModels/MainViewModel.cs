using QoniacTask.WPF.Command;
using QoniacTask.WPF.Services;
using QoniacTask.WPF.State;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QoniacTask.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IConverterService _converterService;
        public INavigator Navigator { get; set; } = new Navigator();
        public MainViewModel(IConverterService converterService)
        {
            _converterService = converterService;
            Navigator.CurrentViewModel = new ConverterViewModel(_converterService);
        }
    }
}
