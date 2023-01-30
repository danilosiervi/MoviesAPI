using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "The Title field is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "The Genre field is required")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "The DurationMinutes field is required")]
    [Range(70, 600, ErrorMessage = "Duration must be between 70 and 600 minutes")]
    public int DurationMinutes { get; set; }
}
