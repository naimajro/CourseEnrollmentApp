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
    internal sealed class CompanyConfiguration:IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable(nameof(Company));
            builder.HasKey(company => company.Id);
            builder.Property(participant => participant.Id).ValueGeneratedOnAdd();
            builder.Property(company => company.Name).HasMaxLength(50);
            builder.Property(company => company.Email);
            builder.Property(company => company.Phone);
            builder.HasMany(company => company.Participants)
                .WithOne()
                .HasForeignKey(participant => participant.CompId)
                .OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
