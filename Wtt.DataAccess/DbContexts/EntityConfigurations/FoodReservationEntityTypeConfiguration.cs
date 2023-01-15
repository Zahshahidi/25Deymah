using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    internal class FoodReservationEntityTypeConfiguration : IEntityTypeConfiguration<FoodReservation>
    {
        public void Configure(EntityTypeBuilder<FoodReservation> builder)
        {

            builder.HasKey(e => e.Id);

            builder.HasOne<Employee>(e => e.Employee)
                .WithMany(e => e.FoodReservations)
                .HasForeignKey(r => r.EmployeeId);

            builder.HasOne<Food>(e => e.Food)
                .WithMany(e => e.FoodReservations)
                .HasForeignKey(r => r.FoodId);
        }
    }
}
