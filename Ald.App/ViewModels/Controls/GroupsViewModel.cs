using Ald.App.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
