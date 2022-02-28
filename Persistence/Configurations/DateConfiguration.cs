using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal sealed class DateConfiguration : IEntityTypeConfiguration<Date>
    {
            public void Configure(EntityTypeBuilder<Date> builder)
            {
                builder.ToTable(nameof(Date));

                builder.HasKey(date => date.Id);
                builder.Property(cdr => cdr.Id).ValueGeneratedOnAdd();

                builder.Property(date => date.Id).ValueGeneratedOnAdd();

                builder.Property(date => date.CourseDate).IsRequired();
            builder.HasMany(date => date.CourseAndDateRelations)
                .WithOne()
                  .HasForeignKey(cdr => cdr.DateId)
                  .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
