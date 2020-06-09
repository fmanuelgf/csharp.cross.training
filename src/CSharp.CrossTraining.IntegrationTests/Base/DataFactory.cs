namespace CSharp.CrossTraining.IntegrationTests.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Csharp.CrossTraining.Infrastructure.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public class DataFactory : IDisposable
    {
        private readonly IGenericRepository<Person> personsRespository;
        private readonly IGenericRepository<Pet> petsRespository;
        private List<Person> personsCache;

        public DataFactory(IServiceProvider serviceProvider)
        {
            var scopedServices = serviceProvider.CreateScope().ServiceProvider;
            this.personsRespository = scopedServices.GetRequiredService<IGenericRepository<Person>>();
            this.petsRespository = scopedServices.GetRequiredService<IGenericRepository<Pet>>();

            this.personsCache = new List<Person>();
        }

        public Person BuildDefaultPerson()
        {
            var person = new Person("John", 30, 70);

            this.personsCache.Add(person);
            return person;
        }

        public void Save()
        {
            this.personsCache.ForEach(person => 
            {
                this.personsRespository.AddAsync(person);
            });
        }

        public void EnsureForRemoval(Person person)
        {
            this.personsCache.Add(person);
        }

        public void Dispose()
        {
            this.personsCache.ForEach(person => 
            {
                this.personsRespository.DeleteAsync(person);
            });
        }
    }
}