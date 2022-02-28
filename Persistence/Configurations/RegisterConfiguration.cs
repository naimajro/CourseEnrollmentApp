using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal sealed class RegisterConfiguration : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.ToTable(nameof(Register));
            builder.HasKey(r =>  r.Id );
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            //builder.HasOne(rr => rr.CourseAndDateRelation)
            //    .WithMany(r => r.Registers)
            //    .HasForeignKey(rr => rr.CDRId);

            //builder.HasOne(rr => rr.Participants)
            //    .WithMany(r => r.Registers)
            //    .HasForeignKey(rr => rr.ParticipantId);
        }
    }
}
