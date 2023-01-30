using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}
