using System.Collections.Generic;
using System.Threading.Tasks;
using TripPlanner.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner.API.Repository
{
    public abstract class AppRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity: class, IEntity
        where TContext: DbContext
    {
        protected readonly TContext Context;

        protected AppRepository(TContext context)
        {
            this.Context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entry = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return null;
            }

            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

    }
}