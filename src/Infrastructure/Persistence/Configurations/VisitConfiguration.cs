using vet_clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vet_clinic.Infrastructure.Persistence.Configurations
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            //builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.VisitType)
                .IsRequired();

            builder.Property(t => t.VisitDate)
                .IsRequired();
            
            builder.Property(t => t.Notes)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}