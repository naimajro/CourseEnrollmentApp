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
            builder.HasKey(register =>  register.Id );
            builder.Property(participant => participant.Id ).ValueGeneratedOnAdd();
            builder.HasMany(register => register.Participants)
               .WithOne()
                 .HasForeignKey(participant => participant.RegisterId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
