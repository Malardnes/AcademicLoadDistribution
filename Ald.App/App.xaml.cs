using Ald.App.Data;
using Ald.App.Services;
using Ald.App.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;

namespace Ald.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Хост приложения.
        /// </summary>
        private static IHost __Host;

        /// <summary>
        /// Свойство - используемое во время процесса разработки.
        /// </summary>
        public static bool IsDesignMode { get; private set; } = true;

        /// <summary>
        /// Свойство - для доступа к хосту приложения.
        /// </summary>
        /// <remarks>
        /// Первое обращение к свойству Host, заставит этот хост создаться,
        /// все последующие обращения к свойству будут переадресованны к полю
        /// __Host - которое и было созданно при первом обращении к свойству.
        /// </remarks>
        public static IHost Host => __Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        /// <summary>
        /// Свойство - для доступа к сервисам приложения.
        /// </summary>
        /// <remarks>
        /// Если первое обращение к свойству Services вдруг случилось до создания хоста,
        /// то это всеравно приведет к созданию хоста и его конфигурации, а так же конфигурации
        /// самих сервисов (если они там конечно есть).
        /// </remarks>
        public static IServiceProvider Services => Host.Services;

        /// <summary>
        /// Главный метод для регистрации всех зависимостей в приложении.
        /// </summary>
        /// <param name="host">
        /// Хост приложения.
        /// </param>
        /// <param name="services">
        /// Список сервисов.
        /// </param>
        /// <remarks>
        /// При добавлении нового контейнера зависимостей (регистратора), необходимо вызвать его
        /// в этом методе.
        /// </remarks>
        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddServices()
            .AddViewModels()
        ;

        /// <summary>
        /// Свойство для чтения. Возвращает текущее активное окно программы или null, если нет активных окон.
        /// </summary>
        public static Window ActiveWindow =>
            Application.Current.Windows.OfType<Window>().SingleOrDefault(window => window.IsActive);

        /// <summary>
        /// Свойство для чтения. Возвращает окно программы на котором установлен фокус ввода или null,
        /// если ни на одном из окон фокус ввода установлен не был.
        /// </summary>
        public static Window FocusedWindow =>
            Application.Current.Windows.OfType<Window>().SingleOrDefault(window => window.IsFocused);

        /// <summary>
        /// Свойство для чтения. Возвращает текущее окно программы или null, если окна отсутствуют.
        /// </summary>
        public static Window CurrentWindow => ActiveWindow ?? FocusedWindow;

        /// <summary>
        /// Метод - вызываемый при старте программы.
        /// </summary>
        /// <param name="e">
        /// Событие - возникающее при старте программы.
        /// </param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }

        /// <summary>
        /// Метод - вызываемый при завершении работы программы.
        /// </summary>
        /// <param name="e">
        /// Событие - возникающее при завершении работы программы.
        /// </param>
        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
