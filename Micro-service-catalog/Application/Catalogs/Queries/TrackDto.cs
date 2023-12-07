using System;
namespace Application.Catalogs.Queries
{
	public class TrackDTO
	{
        public long IdTrack { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public string? Cover_small { get; set; }

    }
}

