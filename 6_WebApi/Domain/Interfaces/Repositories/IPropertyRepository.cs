﻿using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IPropertyRepository
    {
        void Create( Property? property );

        IEnumerable<Property> GetAll();

        Property? GetById( Guid id );

        void UpdateParams( Guid id, Property property );

        void Delete( Guid id );
    }
}
