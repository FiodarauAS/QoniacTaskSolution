using QoniacTask.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QoniacTask.WPF.State
{
    public enum ViewType
    {
        Converter
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
