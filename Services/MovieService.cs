using Microsoft.EntityFrameworkCore;
using MovieOscarsApi.Data;
using MovieOscarsApi.DTOs;
using MovieOscarsApi.Models;

namespace MovieOscarsApi.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _context;

    public MovieService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await _context.Movies
            .OrderBy(movie => movie.ReleaseYear)
            .ThenBy(movie => movie.Title)
            .ToListAsync();

        return movies.Select(MapToDto);
    }

    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        return movie is null ? null : MapToDto(movie);
    }

    public async Task<MovieDto> CreateAsync(CreateMovieDto createMovieDto)
    {
        var movie = new Movie
        {
            Title = createMovieDto.Title,
            ReleaseYear = createMovieDto.ReleaseYear,
            Director = createMovieDto.Director,
            Genre = createMovieDto.Genre,
            OscarNominations = createMovieDto.OscarNominations,
            OscarWins = createMovieDto.OscarWins,
            BestPictureWinner = createMovieDto.BestPictureWinner
        };

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return MapToDto(movie);
    }

    public async Task<bool> UpdateAsync(int id, UpdateMovieDto updateMovieDto)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie is null)
        {
            return false;
        }

        movie.Title = updateMovieDto.Title;
        movie.ReleaseYear = updateMovieDto.ReleaseYear;
        movie.Director = updateMovieDto.Director;
        movie.Genre = updateMovieDto.Genre;
        movie.OscarNominations = updateMovieDto.OscarNominations;
        movie.OscarWins = updateMovieDto.OscarWins;
        movie.BestPictureWinner = updateMovieDto.BestPictureWinner;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie is null)
        {
            return false;
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return true;
    }

    private static MovieDto MapToDto(Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            ReleaseYear = movie.ReleaseYear,
            Director = movie.Director,
            Genre = movie.Genre,
            OscarNominations = movie.OscarNominations,
            OscarWins = movie.OscarWins,
            BestPictureWinner = movie.BestPictureWinner
        };
    }
}
