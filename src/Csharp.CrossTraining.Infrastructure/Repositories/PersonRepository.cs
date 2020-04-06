namespace Csharp.CrossTraining.Infrastructure.Repositories
{
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext context;

        public PersonRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Person> GetQueryable()
        {
            return this.context.Persons.AsQueryable();
        }
    }
}