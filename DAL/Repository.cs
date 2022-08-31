using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class Repository<T> : IRepository<T> where T: Entity, new()
    {
        private readonly DbContext db;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            db = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> Items => dbSet;
        public bool IsAutoSaveChanges { get; set; } = true;

        public T Get(int id)
        {
            return Items.SingleOrDefault(item => item.Id == id);
        }

        public async Task<T> GetAsync(int id)
        {
            return await Items.SingleOrDefaultAsync(item => item.Id == id).ConfigureAwait(false);
        }

        public void Add(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(T));

            dbSet.Add(item);

            if (IsAutoSaveChanges)
                db.SaveChanges();
        }

        public async Task AddAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(T));

            dbSet.Add(item);

            if (IsAutoSaveChanges)
                await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Update(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            db.Entry(item).State = EntityState.Modified;

            if (IsAutoSaveChanges)
                db.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            db.Entry(item).State = EntityState.Modified;

            if (IsAutoSaveChanges)
                await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Remove(int id)
        {
            T item = Get(id);

            if(item != null)
                dbSet.Remove(item);

            if (IsAutoSaveChanges)
                db.SaveChanges();
        }

        public async Task RemoveAsync(int id)
        {
            T item = Get(id);

            if (item != null)
                dbSet.Remove(item);

            if (IsAutoSaveChanges)
                await db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
