using AppAcademy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAcademy.Data.Configiurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Name).IsRequired(true).HasMaxLength(30);
            builder.Property(s => s.FileName).IsRequired(true).HasMaxLength(100);
            builder.Property(s => s.Email).IsRequired(true).HasMaxLength(100);
            builder
                .HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
