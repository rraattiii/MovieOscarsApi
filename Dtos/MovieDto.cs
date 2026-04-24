namespace MovieOscarsApi.DTOs;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public string Director { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public int OscarNominations { get; set; }
    public int OscarWins { get; set; }
    public bool BestPictureWinner { get; set; }
}
