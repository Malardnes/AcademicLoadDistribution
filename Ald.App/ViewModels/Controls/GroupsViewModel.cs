using Ald.App.ViewModels.Base;

namespace Ald.App.ViewModels.Controls
{
    internal class GroupsViewModel : ViewModel
    {
        public HomePageViewModel ParentViewModel { get; private set; }

        public GroupsViewModel() : this(null)
        {

        }

        public GroupsViewModel(HomePageViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }
    }
}
