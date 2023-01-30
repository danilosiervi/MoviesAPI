using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[Controller]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadMovieDTO> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadMovieDTO>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
            return NotFound();

        var movieDTO = _mapper.Map<ReadMovieDTO>(movie);
        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult PostMovie([FromBody] CreateMovieDTO movieDTO)
    {
        Movie movie = _mapper.Map<Movie>(movieDTO);

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult PutMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
            return NotFound();

        _mapper.Map(movieDTO, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchMovie(int id, JsonPatchDocument<UpdateMovieDTO> patch)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
            return NotFound();

        var movieToPatch = _mapper.Map<UpdateMovieDTO>(movie);

        patch.ApplyTo(movieToPatch, ModelState);
        if (!TryValidateModel(movieToPatch))
            return ValidationProblem(ModelState);

        _mapper.Map(movieToPatch, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null)
            return NotFound();

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}
