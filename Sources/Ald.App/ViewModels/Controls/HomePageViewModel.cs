using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Windows;

namespace Ald.App.ViewModels.Controls
{
    internal class HomePageViewModel : ViewModel
    {
        public MainWindowViewModel ParentViewModel { get; private set; }

        public GroupsViewModel GroupsViewModel { get; private set; }

        public HomePageViewModel() : this(null)
        {

        }

        public HomePageViewModel(MainWindowViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;

            GroupsViewModel = new GroupsViewModel(this);
        }
    }
}
