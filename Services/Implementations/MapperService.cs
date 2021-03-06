﻿using CardsGame.ViewModels;
using System.Collections.Generic;
using System.Linq;
using CardsGame.Services.Interfaces;
using CardsGame.Database.MongoDb;

namespace CardsGame.Services.Implementations
{
    public class MapperService : IMapperService
    {
        public RoomViewModel_Get MapToRoomViewModel(Room room)
        {
            if (room == null)
                return null;

            return new RoomViewModel_Get
            {
                Id = room.Id,
                Name = room.Name,
                Status = room.Status,
                HasPassword = room.HasPassword,
                PlayersCount = room.PlayersCount,
                MaxPlayersCount = room.MaxPlayersCount
            };
        }

        public IEnumerable<RoomViewModel_Get> MapToRoomViewModel(IEnumerable<Room> rooms)
        {
            if (rooms == null)
                return null;

            return rooms.Select(room => MapToRoomViewModel(room));
        }
    }
}
