using MovieOscarsApi.DTOs;

namespace MovieOscarsApi.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetAllAsync();
    Task<MovieDto?> GetByIdAsync(int id);
    Task<MovieDto> CreateAsync(CreateMovieDto createMovieDto);
    Task<bool> UpdateAsync(int id, UpdateMovieDto updateMovieDto);
    Task<bool> DeleteAsync(int id);
}
