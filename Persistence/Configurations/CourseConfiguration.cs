using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(nameof(Course));

            builder.HasKey(course => course.Id);

            builder.Property(cdr => cdr.Id).ValueGeneratedOnAdd();
            builder.Property(course => course.Name).HasMaxLength(50);

            builder.HasMany(course => course.CourseAndDateRelations)
                .WithOne()
                  .HasForeignKey(cdr => cdr.CourseId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
