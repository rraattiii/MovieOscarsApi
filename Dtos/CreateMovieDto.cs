using System.ComponentModel.DataAnnotations;

namespace MovieOscarsApi.DTOs;

public class CreateMovieDto
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Range(1888, 2100)]
    public int ReleaseYear { get; set; }

    [Required]
    [MaxLength(100)]
    public string Director { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Range(0, 100)]
    public int OscarNominations { get; set; }

    [Range(0, 100)]
    public int OscarWins { get; set; }

    public bool BestPictureWinner { get; set; }
}
