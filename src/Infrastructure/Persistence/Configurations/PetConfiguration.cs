using vet_clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vet_clinic.Infrastructure.Persistence.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            //builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.PetName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.PetType)
                .IsRequired();
        }
    }
}