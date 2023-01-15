using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description).HasMaxLength(2048);

            builder.HasOne<Employee>(t=>t.Employee)
                .WithMany(e=>e.Tasks)
                .HasForeignKey(t=> t.EmployeeId);
        }
    }

}
