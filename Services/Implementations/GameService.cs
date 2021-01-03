using MongoDB.Driver;
using CardsGame.Database.MongoDb;
using CardsGame.Database.MongoDb.Settings;
using CardsGame.Services.Interfaces;

namespace CardsGame.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly IMongoCollection<Game> _games;

        public GameService(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            _games = database.GetCollection<Game>(mongoDbSettings.GamesCollectionName);
        }
    }
}
