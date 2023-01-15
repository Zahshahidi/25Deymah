using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    public class VacationEntityTypeConfiguration : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {

            builder.HasKey(e => e.Id);

            builder.HasOne<Employee>(e => e.Employee)
                .WithMany(e => e.Vacations)
                .HasForeignKey(e => e.EmployeeId);


        }
    }
}
