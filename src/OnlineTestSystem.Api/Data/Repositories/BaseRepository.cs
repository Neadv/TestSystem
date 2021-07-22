using Microsoft.EntityFrameworkCore;
using OnlineTestSystem.Api.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Data.Contracts
{
    public abstract class BaseRepository<T> : IRepository<T> where T: class
    {
        protected readonly ApplicationContext Context;
        protected readonly DbSet<T> Set;

        protected BaseRepository(ApplicationContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await Set.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Set.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Set.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await Set.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Set.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}
