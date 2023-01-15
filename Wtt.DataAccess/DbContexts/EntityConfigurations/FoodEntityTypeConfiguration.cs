using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wtt.Domain.Entities;

namespace Wtt.DataAccess.DbContexts.EntityConfigurations
{

    internal class FoodEntityTypeConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasMaxLength(64);
        }
    }
}
