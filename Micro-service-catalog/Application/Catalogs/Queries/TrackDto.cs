using System;
namespace Application.Catalogs.Queries
{
	public class TrackDto
	{
        public long IdBar { get; set; }
        public long IdTrack { get; set; }
        public string? TitleSong { get; set; }
        public string? Link { get; set; }
        public string? ArtistName { get; set; }
        public string? AlbumName { get; set; }
        public string? Cover { get; set; }

    }
}

