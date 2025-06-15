﻿using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IRoomTypeRepository
    {
        void Create( RoomType? roomType );

        IEnumerable<RoomType> GetAllRoomTypePropertyById( Guid id );

        RoomType? GetById( Guid id );

        void Update( Guid id, RoomType? roomType );

        void Delete( Guid roomTypeId );
    }
}
