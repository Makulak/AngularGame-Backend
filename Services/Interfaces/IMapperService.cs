using CardsGame.Database.MongoDb;
using CardsGame.ViewModels;
using System.Collections.Generic;

namespace CardsGame.Services.Interfaces
{
    public interface IMapperService
    {
        RoomViewModel_Get MapToRoomViewModel(Room room);
        IEnumerable<RoomViewModel_Get> MapToRoomViewModel(IEnumerable<Room> rooms);
    }
}
