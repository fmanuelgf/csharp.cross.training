namespace Csharp.CrossTraining.Infrastructure.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetQueryable();

        Task<int> AddAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> DeleteAsync(TEntity entity);
    }
}