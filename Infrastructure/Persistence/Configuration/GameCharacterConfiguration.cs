using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.GameCharacter;

namespace Infrastructure.Persistence.Configuration
{
    public class GameCharacterConfiguration : IEntityTypeConfiguration<GameCharacter>
    {
        public void Configure(EntityTypeBuilder<GameCharacter> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(2048);

            builder.Property(x => x.LogoUrl)
                .HasMaxLength(2048);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasMany(x => x.Images)
                .WithOne()
                .HasForeignKey(x => x.GameCharacterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
