using FluentValidation;

namespace Application.Catalogs.Commands.AddSongCatalog
{
    public class AddSongCatalogCommandValidator : AbstractValidator<AddSongCatalogCommand>
    {
        public AddSongCatalogCommandValidator() 
        {
            RuleFor(b => b.IdBar).NotEmpty();
            RuleFor(b => b.IdTrack).NotEmpty();
            RuleFor(b => b.ArtistName).NotEmpty();
            RuleFor(b => b.AlbumName).NotEmpty();
            RuleFor(b => b.Cover).NotEmpty();
            RuleFor(b => b.Link).NotEmpty();
        }
    }
}
