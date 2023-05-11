using Ald.Dal.Context;
using Ald.Dal.Entities.Base;
using Ald.Ifs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ald.Dal
{
    internal class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly CollegeContext _context;
        private readonly DbSet<T> _set;

        public Repository(CollegeContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public virtual IQueryable<T> Items => _set;

        public bool AutoSaveChanges { get; set; } = true;

        public T Get(int id)
        {
            return Items.SingleOrDefault(item => item.Id == id);
        }

        public async Task<T> GetAsync(int id, CancellationToken cancel = default)
        {
            return await Items
                .SingleOrDefaultAsync(item => item.Id == id, cancel)
                .ConfigureAwait(false);
        }

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _context.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
            return item;
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _context.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _context.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public void Remove(int id)
        {
            _context.Remove(new T { Id = id });

            if (AutoSaveChanges)
                _context.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken cancel = default)
        {
            _context.Remove(new T { Id = id });

            if (AutoSaveChanges)
                await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
