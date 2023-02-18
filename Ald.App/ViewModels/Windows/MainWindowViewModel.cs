using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ald.App.ViewModels.Windows
{
    internal class MainWindowViewModel : ViewModel
    {
        public HomePageViewModel HomePageViewModel { get; private set; }

        public MainWindowViewModel()
        {
            HomePageViewModel = new HomePageViewModel(this);
        }
    }
}
