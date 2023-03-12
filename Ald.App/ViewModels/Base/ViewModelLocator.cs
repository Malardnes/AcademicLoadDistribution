using Microsoft.Extensions.DependencyInjection;
using Ald.App.ViewModels.Windows;

namespace Ald.App.ViewModels.Base
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
