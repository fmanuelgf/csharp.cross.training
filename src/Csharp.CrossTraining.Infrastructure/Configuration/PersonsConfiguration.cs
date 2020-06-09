namespace Csharp.CrossTraining.Infrastructure.Configuration
{
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonsConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.HasMany(x => x.Pets).WithOne().HasForeignKey(x => x.PersonId).IsRequired();
        }
    }
}