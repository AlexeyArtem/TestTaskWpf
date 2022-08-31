using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    interface IRepository<T> where T : Entity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id);

        void Add(T item);
        Task AddAsync(T item);

        void Update(T item);
        Task UpdateAsync(T item);

        void Remove(int id);
        Task RemoveAsync(int id);
    }
}
