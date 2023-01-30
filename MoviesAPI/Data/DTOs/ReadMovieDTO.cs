namespace MoviesAPI.Data.DTOs;

public class ReadMovieDTO
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int DurationMinutes { get; set; }
    public DateTime ConsultTime { get; set; }
}
