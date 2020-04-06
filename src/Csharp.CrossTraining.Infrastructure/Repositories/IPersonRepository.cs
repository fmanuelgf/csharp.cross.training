namespace Csharp.CrossTraining.Infrastructure.Repositories
{
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;

    public interface IPersonRepository
    {
        IQueryable<Person> GetQueryable();
    }
}