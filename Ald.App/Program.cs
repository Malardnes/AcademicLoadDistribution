using Microsoft.Extensions.Hosting;
using System;

namespace Ald.App
{
    /// <summary>
    /// Класс с точкой входа в приложение.
    /// </summary>
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices)
        ;
    }
}
