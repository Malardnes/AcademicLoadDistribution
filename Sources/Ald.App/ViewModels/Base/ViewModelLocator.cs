using Ald.App.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Ald.App.ViewModels.Base
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
