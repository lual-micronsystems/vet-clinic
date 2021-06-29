using vet_clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace vet_clinic.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();
                
            builder.Property(t => t.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Email)
                .HasMaxLength(200)
                .IsRequired();
            
            builder.Property(t => t.UserName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Password)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.UserType)
                .IsRequired();
        }
    }
}