namespace Csharp.CrossTraining.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetQueryable() => this.context.Set<TEntity>().AsQueryable();

        public async Task<int> AddAsync(TEntity entity)
        {
            await this.context.Set<TEntity>().AddAsync(entity);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> AddAsync(IEnumerable<TEntity> entities)
        {
            await this.context.Set<TEntity>().AddRangeAsync(entities);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Update(entity);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
            return await this.context.SaveChangesAsync();
        }
    }
}