using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardsGame.Database.Models
{
    public class WhiteCard
    {
        string Text { get; set; }

        CardSet CardSet { get; set; }
        int CardSetId { get; set; }
    }

    public class WhiteCardConfiguration : IEntityTypeConfiguration<WhiteCard>
    {
        public void Configure(EntityTypeBuilder<WhiteCard> builder)
        {
        }
    }
}
