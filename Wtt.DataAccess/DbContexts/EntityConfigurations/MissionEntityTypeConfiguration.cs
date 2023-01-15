using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    internal class MissionEntityTypeConfiguration : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).HasMaxLength(1024);
            builder.Property(e => e.Place).HasMaxLength(512);
            builder.Property(e => e.Description).HasMaxLength(2048);


            builder.HasOne<Employee>(e => e.Employee)
                .WithMany(e => e.Missions)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasOne<Project>(e => e.Project)
                .WithMany(e => e.Missions)
                .HasForeignKey(e => e.ProjectId);



            /*            builder.HasKey(t => t.Id); 
                        builder.HasOne<Employee>(r => r.Employee)
                            .HasOne<Food>(r => r.Food)
                            .WithMany(e => e.FoodReservation)
                            .WithMany(f => f.FoodReservation)
                            .HasForeignKey(t => t.EmployeeId);*/
        }
    }
}
