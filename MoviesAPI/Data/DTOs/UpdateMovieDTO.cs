using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.DTOs;

public class UpdateMovieDTO
{
    [Required(ErrorMessage = "The Title field is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The Genre field is required")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "The DurationMinutes field is required")]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes")]
    public int DurationMinutes { get; set; }
}
