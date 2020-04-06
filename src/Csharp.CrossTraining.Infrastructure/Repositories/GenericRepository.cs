// namespace Csharp.CrossTraining.Infrastructure.Repositories
// {
//     using System.Linq;
//     using Csharp.CrossTraining.Infrastructure.Entities;

//     public class GenericRepository<TEntity>
//         where TEntity : EntityBase
//     {
        
//         private readonly AppDbContext context;

//         public GenericRepository(AppDbContext context)
//         {
//             this.context = context;
//         }

//         public IQueryable<TEntity> AsQueryable()
//         {
//             return this.context.Set<TEntity>().AsQueryable();
//         }
//     }
// }