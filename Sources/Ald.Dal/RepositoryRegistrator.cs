using Ald.Dal.Entities;
using Ald.Ifs;
using Microsoft.Extensions.DependencyInjection;

namespace Ald.Dal
{
    /// <summary>
    /// Класс регистратор репозиториев.
    /// </summary>
    /// <remarks>
    /// Основное приложение ничего не знает о реализации репозитория для какой-либо сущности,
    /// оно знает лишь об интерфейсе репозитория. Если необходимо изменить логику выгрузки
    /// данных из базы данных, то необходимо создать реализацию репозитория для конкретной
    /// сущности, переопределить свойство Items, а затем добавить реализацию этого репозитория
    /// в метод AddRepositories(...).
    /// </remarks>
    /// <example>
    /// Добавление стандартной реализации репозитория:
    /// .AddTransient<IRepository<Сущность>, Repository<Сущность>>()
    /// 
    /// Добавление своей реализации репозитория:
    /// .AddTransient<IRepository<Сущность>, СущностьRepository>()
    /// </example>
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Group>, Repository<Group>>()
            .AddTransient<IRepository<Department>, Repository<Department>>()
            .AddTransient<IRepository<Specialization>, Repository<Specialization>>()
            .AddTransient<IRepository<CycleType>, Repository<CycleType>>()
            .AddTransient<IRepository<Cycle>, Repository<Cycle>>()
            .AddTransient<IRepository<Discipline>, Repository<Discipline>>()
            .AddTransient<IRepository<AttestationType>, Repository<AttestationType>>()
            .AddTransient<IRepository<EducationType>, Repository<EducationType>>()
            .AddTransient<IRepository<EducationPlan>, Repository<EducationPlan>>()
            .AddTransient<IRepository<Teacher>, Repository<Teacher>>()
            .AddTransient<IRepository<TeachingLoad>, Repository<TeachingLoad>>()
        ;
    }
}
