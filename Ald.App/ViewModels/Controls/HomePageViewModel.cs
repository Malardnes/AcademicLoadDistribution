using Ald.App.ViewModels.Base;
using Ald.App.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
