using Microsoft.AspNetCore.Mvc;
using MovieOscarsApi.DTOs;
using MovieOscarsApi.Services;

namespace MovieOscarsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
    {
        var movies = await _movieService.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDto>> GetMovie(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);
        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto createMovieDto)
    {
        var createdMovie = await _movieService.CreateAsync(createMovieDto);
        return CreatedAtAction(nameof(GetMovie), new { id = createdMovie.Id }, createdMovie);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateMovieDto)
    {
        var updated = await _movieService.UpdateAsync(id, updateMovieDto);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var deleted = await _movieService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
