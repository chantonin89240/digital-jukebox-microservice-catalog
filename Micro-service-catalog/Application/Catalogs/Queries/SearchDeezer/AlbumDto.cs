namespace Application.Catalogs.Queries.SearchDeezer;

public class AlbumDto
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public string? Cover { get; set; }
    public string? Cover_small { get; set; }
    public string? Cover_big { get; set; }
    public string? Cover_xl { get; set; }
    public string? Md5_image { get; set; }
    public string? Tracklist { get; set; }
    public string? Type { get; set; }
}