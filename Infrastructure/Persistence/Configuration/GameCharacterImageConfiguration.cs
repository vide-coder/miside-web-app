using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.GameCharacter;

namespace Infrastructure.Persistence.Configuration
{
    public class GameCharacterImageConfiguration : IEntityTypeConfiguration<GameCharacterImage>
    {
        public void Configure(EntityTypeBuilder<GameCharacterImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(2048)
                .IsRequired();
        }
    }
}
