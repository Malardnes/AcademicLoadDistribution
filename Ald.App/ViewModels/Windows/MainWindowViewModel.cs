using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Controls;

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
