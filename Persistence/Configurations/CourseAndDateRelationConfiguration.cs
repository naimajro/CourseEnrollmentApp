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
    internal sealed class CourseAndDateRelationConfiguration : IEntityTypeConfiguration<CourseAndDateRelation>
    {
            public void Configure(EntityTypeBuilder<CourseAndDateRelation> builder)
            {
                builder.ToTable(nameof(CourseAndDateRelation));
                builder.HasKey(cdr => cdr.Id);

            builder.Property(register => register.Id).ValueGeneratedOnAdd();


            builder.HasMany(c => c.Registers)
                .WithOne()
                  .HasForeignKey(register => register.CDRId)
                  .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(cc => cc.Courses)
            //    .WithMany(c => c.CourseAndDateRelations)
            //    .HasForeignKey(cc => cc.CourseId);

            //builder.HasOne(cc => cc.Dates)
            //    .WithMany(c => c.CourseAndDateRelations)
            //    .HasForeignKey(cc => cc.DateId);


        }
    }
}
