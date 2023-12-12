using System;
using MongoDB.Driver;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Infrastructure.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }


        public IMongoCollection<Track> Tracks => _database.GetCollection<Track>("Tracks");

        public IMongoCollection<Track> Counter => _database.GetCollection<Track>("Counter");

    }

}