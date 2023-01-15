using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    internal class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(256);

        }
    }
}
