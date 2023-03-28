using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ald.Ifs
{
    /// <summary>
    /// Интерфейс репозитория.
    /// </summary>
    /// <remarks>
    /// Предоставляет возможность расширять приложение, легко вносить изменения
    /// в предметную область, работать с базой данных посредством модельных
    /// сущностей, строить запросы к базе данных любого уровня сложности.
    /// </remarks>
    /// <typeparam name="T">
    /// Некоторая сущность, которая должна быть не статическим классом
    /// (можно создать экземпляр через new()), и у которой обязательно
    /// должен быть идентификатор.
    /// </typeparam>
    public interface IRepository<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// Свойство для обращения к некоторой сущности в базе данных.
        /// </summary>
        /// <remarks>
        /// Данное свойство можно переопределить в классе-наследнике.
        /// Все методы будут автоматически настроены на работу с этим свойством.
        /// </remarks>
        IQueryable<T> Items { get; }

        /// <summary>
        /// Свойство отвечающее за то, выполнять ли автоматическое
        /// сохранение данных в базу данных.
        /// </summary>
        /// <remarks>
        /// В целях оптимизации для отправки большого объема данных,
        /// данному свойству стоит присвоить значение false. В таком случае
        /// все данные будут отправлены в БД пакетно, иначе каждая запись будет
        /// отправляться в БД по отдельности, что может нагрузить систему.
        /// </remarks>
        bool AutoSaveChanges { get; set; }

        /// <summary>
        /// Получить сущность по её идентификатору.
        /// </summary>
        /// <param name="id">
        /// Идентификатор сущности.
        /// </param>
        /// <returns>
        /// Сущность или пустая ссылка.
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Получить сущность по её идентификатору.
        /// </summary>
        /// <param name="id">
        /// Идентификатор сущности.
        /// </param>
        /// <param name="cancel">
        /// Возможность отмены операции.
        /// </param>
        /// <returns>
        /// Сущность или пустая ссылка.
        /// </returns>
        Task<T> GetAsync(int id, CancellationToken cancel = default);

        /// <summary>
        /// Добавить сущность в базу данных.
        /// </summary>
        /// <param name="item">
        /// Сущность - которую необходимо добавить.
        /// </param>
        /// <returns>
        /// Добавленая сущность.
        /// </returns>
        T Add(T item);

        /// <summary>
        /// Добавить сущность в базу данных.
        /// </summary>
        /// <param name="item">
        /// Сущность - которую необходимо добавить.
        /// </param>
        /// <param name="cancel">
        /// Возможность отмены операции.
        /// </param>
        /// <returns>
        /// Добавленая сущность.
        /// </returns>
        Task<T> AddAsync(T item, CancellationToken cancel = default);

        /// <summary>
        /// Отредактировать сущность.
        /// </summary>
        /// <param name="item">
        /// Отредактированная сущность.
        /// </param>
        void Update(T item);

        /// <summary>
        /// Отредактировать сущность.
        /// </summary>
        /// <param name="item">
        /// Отредактированная сущность.
        /// </param>
        /// <param name="cancel">
        /// Возможность отмены операции.
        /// </param>
        Task UpdateAsync(T item, CancellationToken cancel = default);

        /// <summary>
        /// Удалить сущность по её идентификатору.
        /// </summary>
        /// <param name="id">
        /// Идентификатор сущности.
        /// </param>
        void Remove(int id);

        /// <summary>
        /// Удалить сущность по её идентификатору.
        /// </summary>
        /// <param name="id">
        /// Идентификатор сущности.
        /// </param>
        /// <param name="cancel">
        /// Возможность отмены операции.
        /// </param>
        Task RemoveAsync(int id, CancellationToken cancel = default);
    }
}
