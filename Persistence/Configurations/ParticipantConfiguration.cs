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
    internal sealed class ParticipantConfiguration:IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable(nameof(Participant));
            builder.HasKey(participant => participant.Id);
            builder.Property(register => register.Id);
            builder.Property(participant => participant.Name).HasMaxLength(50);
            builder.Property(participant => participant.Email);
            builder.Property(participant => participant.Phone);

            builder.HasMany(participant => participant.Registers)
                .WithOne()
                  .HasForeignKey(register => register.ParticipantId)
                  .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
