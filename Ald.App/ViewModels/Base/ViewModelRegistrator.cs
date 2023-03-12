using Ald.App.ViewModels.Controls;
using Ald.App.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Ald.App.ViewModels.Base
{
    /// <summary>
    /// Класс регистратор моделей-представлений.
    /// </summary>
    /// <remarks>
    /// Все модели-представления регистрируются, как синглтоны.
    /// При добавлении новой view-model`и необходимо добавить (зарегестировать) её
    /// в методе AddViewModels.
    /// </remarks>
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<HomePageViewModel>()
            .AddSingleton<GroupsViewModel>()
        ;
    }
}
