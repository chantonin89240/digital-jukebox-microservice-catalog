using Application.Catalogs.Queries.GetTrackById;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetTrackByCatalog;

public record GetTrackByCatalogQuery(GetTrackByCatalogDto barId) : IRequest<TrackCatalog> { }

public class GetTrackByCatalogHandler : IRequestHandler<GetTrackByCatalogQuery, TrackCatalog>
{
    private readonly IMongoDbContext _context;

    public GetTrackByCatalogHandler(IMongoDbContext mongoDbContext)
    {
        this._context = mongoDbContext;
    }

    public async Task<TrackCatalog> Handle(GetTrackByCatalogQuery request, CancellationToken cancellationToken)
    {

        TrackCatalog track = new TrackCatalog();
        track.listStrack = await _context.Tracks.Find(track => track.IdBar == request.barId.IdBar).Project(track => new TrackDto { IdBar = track.IdBar, IdTrack = track.IdTrack, TitleSong = track.TitleSong, Cover = track.Cover, Link = track.Link, ArtistName = track.ArtistName, AlbumName = track.AlbumName }).ToListAsync();

        return track;
    }
}
