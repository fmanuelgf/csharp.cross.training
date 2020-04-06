namespace Csharp.CrossTraining.Infrastructure.Configuration
{
    using Csharp.CrossTraining.Infrastructure.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PetsConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Specie).IsRequired();
            builder.Property(x => x.PersonId).IsRequired();
        }
    }
}