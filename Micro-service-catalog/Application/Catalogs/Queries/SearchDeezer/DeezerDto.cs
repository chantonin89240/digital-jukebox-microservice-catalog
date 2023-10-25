namespace Application.Catalogs.Queries.SearchDeezer;

public class DeezerDto
{
    public long Id { get; set; }
    public bool Readable { get; set; }
    public string? Title { get; set; }
    public string? Title_short { get; set; }
    public string? Title_version { get; set; }
    public string? Link { get; set; }
    public long Duration { get; set; }
    public long Rank { get; set; }
    public bool explicit_lyrics { get; set; }
    public long Explicit_content_lyrics { get; set; }
    public long Explicit_content_cover { get; set; }
    public string? Preview { get; set; }
    public ArtistDto? Artist { get; set; }
    public AlbumDto? Album { get; set; }
    public string Type { get; set; }
}

