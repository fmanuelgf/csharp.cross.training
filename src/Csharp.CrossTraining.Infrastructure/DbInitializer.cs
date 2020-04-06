namespace Csharp.CrossTraining.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Microsoft.EntityFrameworkCore;

    public static class DbInitializer
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var rnd = new Random(DateTime.Now.Millisecond);

            for (var i = 1; i <= 1000; i++)
            {
                var person = new Person(
                    $"John {i}",
                    rnd.Next(20, 90),
                    rnd.Next(65, 105));

                modelBuilder.Entity<Person>().HasData(person);
                modelBuilder.Entity<Pet>().HasData(CreatePets(person));
            }
        }

        private static IEnumerable<Pet> CreatePets(Person person)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var totalPets = (int)rnd.Next(3);

            for (var i = 0; i < totalPets; i++)
            {
                var specieName = rnd.Next(10) % 2 == 0 
                    ? "Dog" 
                    : "Cat";

                var pet = new Pet(
                    $"My {specieName.ToLowerInvariant()} {i + 1}",
                    specieName);

                pet.PersonId = person.Id;
                yield return pet;
            }
        }
    }
}