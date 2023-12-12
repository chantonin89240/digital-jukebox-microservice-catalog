using Application.Catalogs.Queries.GetTrackById;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.Commands.AddSongCatalog
{
    public record class AddSongCatalogCommand : IRequest<int>
    {
        public long IdBar { get; set; }
        public long IdTrack { get; set; }
        public string? TitleSong { get; set; }
        public string? Link { get; set; }
        public string? ArtistName { get; set; }
        public string? AlbumName { get; set; }
        public string? Cover { get; set; }
    }

    public class AddSongCatalogCommandHandler : IRequestHandler<AddSongCatalogCommand, int>
    {
        private readonly IMongoDbContext _context;
        private readonly IMediator _mediator;

        public AddSongCatalogCommandHandler(IMongoDbContext mongoDbContext, IMediator mediator) 
        {
            this._context = mongoDbContext;
            this._mediator = mediator;
        }

        public async Task<int> Handle(AddSongCatalogCommand request, CancellationToken cancellationToken)
        {
            GetTrackByIdDto trackId = new GetTrackByIdDto() { IdBar = request.IdBar , IdTrack = request.IdTrack };

            var result = await _mediator.Send(new GetTrackByIdQuery(trackId));


            if (result != null)
            {
                return 0;
            }
            else
            {
                var entity = new Track
                {
                    IdBar = request.IdBar,
                    IdTrack = request.IdTrack,
                    TitleSong = request.TitleSong,
                    Link = request.Link,
                    ArtistName = request.ArtistName,
                    AlbumName = request.AlbumName,
                    Cover = request.Cover,
                };

                await this._context.Tracks.InsertOneAsync(entity);

                return 1;
            }
        }
    }
}
