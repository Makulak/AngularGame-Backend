using Microsoft.EntityFrameworkCore;
using PotatoServer.Database;

namespace CardsGame.Database
{
    public class CardsGameDatabaseContext : CoreDatabaseContext
    {
        public CardsGameDatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
