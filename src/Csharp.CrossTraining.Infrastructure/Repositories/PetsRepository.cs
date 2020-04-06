namespace Csharp.CrossTraining.Infrastructure.Repositories
{
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public class PetsRepository : IPetsRepository
    {
        private readonly AppDbContext context;

        public PetsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Pet> GetQueryable()
        {
            return this.context.Pets.AsQueryable();
        }
    }
}