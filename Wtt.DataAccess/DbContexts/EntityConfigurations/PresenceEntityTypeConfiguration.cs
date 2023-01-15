using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    internal class PresenceEntityTypeConfiguration : IEntityTypeConfiguration<Presence>
    {
        public void Configure(EntityTypeBuilder<Presence> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Description).HasMaxLength(4096);


            builder.HasOne<Employee>(e => e.Employee)
                .WithMany(e => e.Presences)
                .HasForeignKey(e => e.EmployeeId);

        }
    }
}
