using System.Collections.Generic;
using System.Threading.Tasks;
using Interview_Project.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interview_Project.Persistence.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        private readonly DbSet<TEntity> _entities;

        public Repository(TContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
                return entity;

            _entities.Remove(entity);

            return entity;
        }

        public async Task<TEntity> DeleteAsync(short id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
                return entity;

            _entities.Remove(entity);

            return entity;
        }

        public async Task<TEntity> DeleteAsync(string id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity == null)
                return entity;

            _entities.Remove(entity);

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            return entity;
        }
    }
}