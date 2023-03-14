using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ald.Dal.Context;
using Microsoft.EntityFrameworkCore;

namespace Ald.App.Data
{
    /// <summary>
    /// Класс регистратор базы данных.
    /// </summary>
    internal static class DatabaseRegistrator
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<CollegeContext>(options =>
            {
                // Провайдер базы данных, значение берется из файла 'appsettings.json'.
                var type = configuration["Type"];

                switch (type)
                {
                    case null:
                        throw new InvalidOperationException($"Не определен тип провайдера базы данных.");
                    case "MSSQL":
                        options.UseSqlServer(configuration.GetConnectionString(type));
                        break;
                    default:
                        throw new InvalidOperationException($"Тип подключения {type} не поддерживается.");
                }
            })
        ;
    }
}
