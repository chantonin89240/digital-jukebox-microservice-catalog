using Application.Catalogs.Queries.SearchDeezer;
using Application.Common.Interfaces;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.Queries.GetTrackById;

public record GetTrackByIdQuery(GetTrackByIdDto trackId) : IRequest<TrackDto> { }

public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, TrackDto>
{
    private readonly IMongoDbContext _context;

    public GetTrackByIdHandler(IMongoDbContext mongoDbContext)
    {
        this._context = mongoDbContext;
    }

    public async Task<TrackDto> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
    {
        TrackDto track = await _context.Tracks.Find(track => track.IdTrack == request.trackId.IdTrack && track.IdBar == request.trackId.IdBar).Project(track => new TrackDto { IdBar = track.IdBar, IdTrack = track.IdTrack, TitleSong = track.TitleSong, Cover = track.Cover, Link = track.Link, ArtistName = track.ArtistName, AlbumName = track.AlbumName }).FirstOrDefaultAsync();

        return track;
    }
}

