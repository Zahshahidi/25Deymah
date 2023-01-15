using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    internal class EmployeeProjectEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {

            builder.HasKey(e => e.Id);

            builder.HasOne<Employee>(e => e.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasOne<Project>(e => e.Project)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(e => e.ProjectId);
        }
    }
}
