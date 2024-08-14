using AppAcademy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAcademy.Data.Configiurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name).IsRequired(true).HasMaxLength(5);
            builder.Property(g => g.Limit).IsRequired(true).HasMaxLength(5);
            builder.HasKey(g => g.Id);
        }
    }
}
