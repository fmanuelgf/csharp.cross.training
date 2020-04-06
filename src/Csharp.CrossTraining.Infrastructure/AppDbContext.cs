namespace Csharp.CrossTraining.Infrastructure
{
    using Csharp.CrossTraining.Infrastructure.Configuration;
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonsConfiguration());
            modelBuilder.ApplyConfiguration(new PetsConfiguration());
            
            modelBuilder.SeedData();
        }
    }
}