using Domain.Entities;
using MongoDB.Driver;

namespace Application.Common.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<Track> Tracks { get; }

    }
}